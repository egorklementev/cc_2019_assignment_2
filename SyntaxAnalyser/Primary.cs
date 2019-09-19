namespace SyntaxAnalyser
{
    class Primary : Expression
    {
        readonly int internal_value;

        public Primary(int internal_value)
        {
            this.internal_value = internal_value;
        }

        new public int GetValue()
        {
            return internal_value;
        }
    }
}
