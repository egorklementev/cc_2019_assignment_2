using System;
using System.Collections.Generic;
using System.Text;

namespace SyntaxAnalyser
{
    class Binary<T> : Expression
    {

        protected T left;
        protected T right;

        public Binary(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

    }
}
