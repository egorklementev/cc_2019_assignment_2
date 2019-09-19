namespace SyntaxAnalyser
{
    class Parenthesized : Primary
    {

        public Parenthesized(Expression expression) : base(expression.GetValue()) { }

    }
}
