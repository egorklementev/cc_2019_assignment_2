using System.Collections.Generic;
using System.Text;

namespace SyntaxAnalyser
{
    class Parser
    {   
        public static List<string> Parse(string input)
        {
            List<string> tokens = new List<string>();

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

            return tokens;
        }
    }
}
