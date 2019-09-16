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

            // Fill in 'tokens'

        }

        string GetNextToken()
        {
            // Compile the token

            iterator++;
            return "";
        }

    }
}
