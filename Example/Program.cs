using System;
using System.IO;
using Antlr4.Runtime;
using CqrsDsl;
using CqrsDsl.Generated;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = File.ReadAllText("Example.cqrsx");
            AntlrInputStream inputStream = new AntlrInputStream(file);
            CqrsLexer lexer = new CqrsLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
            CqrsParser parser = new CqrsParser(commonTokenStream);
            
            var vistor = new DebugVisitor();
            var dictionary = parser.dictionary();
            vistor.VisitDictionary(dictionary);
            Console.ReadKey();
        }
    }
}
