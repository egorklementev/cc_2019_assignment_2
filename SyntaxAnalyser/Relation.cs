namespace SyntaxAnalyser
{
    class Relation : Binary<Term, Term>
    {
        readonly int type;

        public Relation(Term left, Term right, int type) : base(left, right)
        {
            this.type = type;
        }

        new public int GetValue()
        {
            if (left != null && right != null)
            {
                switch (type)
                {
                    case 1:
                        return left.GetValue() > right.GetValue() ? 1 : 0;
                    case 2:
                        return left.GetValue() < right.GetValue() ? 1 : 0;
                    case 3:
                        return left.GetValue() == right.GetValue() ? 1 : 0;
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
