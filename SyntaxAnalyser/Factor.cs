using System.Collections.Generic;

namespace SyntaxAnalyser
{
    class Factor : Binary<Primary, List<Primary>>
    {

        public Factor(Primary left, List<Primary> right) : base(left, right) { }

        new public int GetValue()
        {
            if (left != null && right != null)
            {
                int val = left.GetValue();
                foreach (Primary p in right)
                {
                    val *= p.GetValue();
                }
                return val;
            }
            else
            {
                return left.GetValue();
            }
        }

    }
}
