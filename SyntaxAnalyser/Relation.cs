using System;
using System.Collections.Generic;
using System.Text;

namespace SyntaxAnalyser
{
    class Relation : Binary<Term>
    {
        public Relation(Term left, Term right = null)
        {
            this.left = left;
            this.right = right;
        }

    }
}
