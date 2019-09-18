using System;
using System.Collections.Generic;
using System.Text;

namespace SyntaxAnalyser
{
    class Parenthesized : Primary
    {

        public Parenthesized(Expression expression) : base(expression.GetValue()) { }

    }
}
