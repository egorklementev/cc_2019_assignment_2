using System;
using System.Collections.Generic;
using System.Text;

namespace SyntaxAnalyser
{
    class Parser
    {
        int iterator = 0;
        List<string> tokens;

        public Parser(string input)
        {
            tokens = new List<string>();

            int i = 0;
            while (i < input.Length)
            {
                switch (input[i])
                {
                    case '>':
                    case '<':
                    case '=':
                        if (i + 1 < input.Length && input[i + 1] == '=')
                        {
                            tokens.Add(input[i] + "=");
                            i++;
                        }
                        else
                        {
                            tokens.Add(input[i].ToString());
                        }
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case ')':
                    case '(':
                        tokens.Add(input[i].ToString());
                        break;
                    case ' ':
                    case '\r':
                    case '\n':
                        break;
                    default:
                        StringBuilder integer = new StringBuilder();
                        while (i < input.Length && input[i] >= '0' && input[i] <= '9')
                        {
                            integer.Append(input[i++]);
                        }
                        tokens.Add(integer.ToString());
                        i--;
                        break;
                }
                i++;
            }

        }      

        public Expression GetExpression()
        {
            return null;
        }

        Relation GetRelation()
        {
            return null;
        }

        Term GetTerm()
        {
            return null;
        }

        Factor GetFactor()
        {
            return null;
        }

        Primary GetPrimary()
        {
            return null;
        }

        Integer GetInteger()
        {
            return new Integer(int.Parse(GetNextToken()));
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
    }
}
