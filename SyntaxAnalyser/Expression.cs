using System;
using System.Collections.Generic;
using System.Text;

namespace SyntaxAnalyser
{
    class Expression
    {
        Relation root;

        public Expression()
        {
            root = new Relation(null, null);
        }

        /// <summary>
        /// Calculates the result of the expression
        /// </summary>
        /// <returns>Result of the expression</returns>
        public Integer Calculate()
        {
            return null;
        }

    }
}
