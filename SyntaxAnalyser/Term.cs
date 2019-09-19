using System.Collections.Generic;

namespace SyntaxAnalyser
{
    class Term : Binary<Factor, List<Factor>>
    {
        List<string> sign_tokens;

        public Term(Factor left, List<Factor> right, List<string> sign_tokens) : base(left, right)
        {
            this.sign_tokens = sign_tokens;
        }

        new public int GetValue()
        {
            int val = left.GetValue();
            if (right != null)
            {
                int iter = 0;
                foreach (Factor f in right)
                {
                    switch (sign_tokens[iter])
                    {
                        case "+":
                            val += f.GetValue();
                            break;
                        case "-":
                            val -= f.GetValue();
                            break;
                    }
                    iter++;
                }
            }            
            return val;
        }

    }
}
