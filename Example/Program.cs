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
            var file = File.ReadAllText("Example.cqrsx");
            var inputStream = new AntlrInputStream(file);
            var lexer = new CqrsLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            
            var parser = new CqrsParser(commonTokenStream);
            var errorListener = new ConsoleErrorListener<IToken>();
            parser.AddErrorListener(errorListener);
            var vistor = new DebugVisitor();
            var dictionary = parser.dictionary();
            vistor.VisitDictionary(dictionary);
            Console.ReadKey();
        }
    }
}
