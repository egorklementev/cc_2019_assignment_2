using System;
using System.Collections.Generic;
using System.Text;

namespace SyntaxAnalyser
{
    class Integer : Primary
    {

        int value;

        public Integer(int value)
        {
            this.value = value;
        }

        public int GetValue()
        {
            return value;
        }

    }
}
