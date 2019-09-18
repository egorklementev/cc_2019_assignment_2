using System;
using System.Collections.Generic;
using System.Text;

namespace SyntaxAnalyser
{
    class Term : Binary<Factor>
    {
        readonly int type;
        
        public Term(Factor left, Factor right, int type) : base(left, right)
        {
            this.type = type;
        }

        new public int GetValue()
        {
            if (left != null && right != null)
            {
                switch(type)
                {
                    case 1:
                        return left.GetValue() + right.GetValue();
                    case 2:
                        return left.GetValue() - right.GetValue();
                }
                return left.GetValue();
            }
            else
            {
                return left.GetValue();
            }
        }

    }
}
