using System;
using System.Collections.Generic;
using System.Text;

namespace SyntaxAnalyser
{
    class Factor : Binary<Primary>
    {

        public Factor(Primary left, Primary right) : base(left, right) { }

        new public int GetValue()
        {
            if (left != null && right != null)
            {
                return left.GetValue() * right.GetValue();
            }
            else
            {
                return left.GetValue();
            }
        }

    }
}
