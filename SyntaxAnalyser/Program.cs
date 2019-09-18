using System;
using System.IO;

namespace SyntaxAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = "";
                
            // File reading
            try
            {   
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    inputLine = sr.ReadToEnd();                    
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            Expression ex = new Expression();
            ex.SetTokens(Parser.Parse(inputLine));
            ex.BuildExpression();

            Console.WriteLine(ex.GetValue());

        }
    }
}
