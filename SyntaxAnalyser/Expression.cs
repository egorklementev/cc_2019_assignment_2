using System;
using System.Collections.Generic;
using System.Text;

namespace SyntaxAnalyser
{
    class Expression : IValuable
    {
        int iterator = 0;
        List<string> tokens = null;
        Relation root;

        public Expression() { }

        public void SetTokens(List<string> tokens)
        {
            this.tokens = new List<string>();
            this.tokens.AddRange(tokens);
        }           

        public void BuildExpression()
        {
            root = GetRelation();
        }

        Relation GetRelation()
        {
            Term left = GetTerm();

            string next_token = GetNextToken();
            if (next_token != null)
            {
                Term right = GetTerm();

                switch (next_token)
                {
                    case ">":
                        return new Relation(left, right, 1);
                    case "<":
                        return new Relation(left, right, 2);
                    case "=":
                        return new Relation(left, right, 3);
                }
            }

            return new Relation(left, null, 0);
        }

        Term GetTerm()
        {
            Factor left = GetFactor();

            while (true)
            {
                string next_token = GetNextToken();

                if (next_token == null)
                {
                    break;
                }

                Factor right = GetFactor();

                if (next_token == "+")
                {
                    return new Term(left, right, 1);
                }
                else if (next_token == "-")
                {
                    return new Term(left, right, 2);
                }
                else
                {
                    iterator--;
                    break;
                }
            }

            return new Term(left, null, 0);
        }

        Factor GetFactor()
        {
            Primary left = GetPrimary();

            while (true)
            {
                string next_token = GetNextToken();

                if (next_token == null)
                {
                    break;
                }

                Primary right = GetPrimary();

                if (next_token == "*")
                {
                    return new Factor(left, right);
                }
                else
                {
                    iterator--;
                    break;
                }
            }

            return new Factor(left, null);
        }

        Primary GetPrimary()
        {
            string token = GetNextToken();

            if (token == null)
            {
                return null;
            }

            if (!int.TryParse(token, out int res))
            {
                if (token == "(")
                {
                    int par_num = 1;
                    int old_indx = iterator - 1;
                    List<string> new_tokens = new List<string>();                    

                    while (par_num != 0)
                    {
                        string next_token = GetNextToken();
                        if (next_token == null)
                        {
                            Console.Error.WriteLine("Error arised when parsing parentheses! Check the parentheses for correctness.");
                            return null;
                        }
                        if (next_token == "(")
                        {
                            par_num++;
                        }
                        else if (next_token == ")")
                        {
                            par_num--;
                        }
                        new_tokens.Add(next_token);
                    }
                    new_tokens.RemoveAt(new_tokens.Count - 1);

                    Expression exp = new Expression();
                    exp.SetTokens(new_tokens);
                    exp.BuildExpression();

                    List<string> new_lst = new List<string>();
                    for (int i = 0; i < old_indx; i++)
                    {
                        new_lst.Add(tokens[i]);
                    }
                    new_lst.Add(exp.GetValue().ToString());
                    for (int i = iterator; i < tokens.Count; i++)
                    {
                        new_lst.Add(tokens[i]);
                    }

                    tokens = new_lst;

                    iterator = old_indx;

                    return new Parenthesized(exp);
                }
                else
                {
                    Console.Error.WriteLine("Error arised when parsing primary! Token is \"" + token + "\"");
                    return null;
                }
            }
            else
            {
                return new Integer(res);
            }
        }

        string GetNextToken()
        {
            if (iterator >= tokens.Count)
            {
                return null;
            }
            else
            {
                return tokens[iterator++];
            }
        }

        public int GetValue()
        {
            return root.GetValue();
        }
    }
}
