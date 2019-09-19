namespace SyntaxAnalyser
{
    class Binary<L, R> : Expression
    {

        protected L left;
        protected R right;

        public Binary(L left, R right)
        {
            this.left = left;
            this.right = right;
        }

    }
}
