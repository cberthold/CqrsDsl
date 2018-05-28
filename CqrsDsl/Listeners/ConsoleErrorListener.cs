using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;

namespace CqrsDsl.Listeners
{
    public class ConsoleErrorListener<Symbol> : IAntlrErrorListener<Symbol>
    {
        public void SyntaxError(IRecognizer recognizer, Symbol offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            string formattedError = $"Error at line: {line}:{charPositionInLine} - {offendingSymbol} - {msg}";
            Console.Error.WriteLine(formattedError);
        }
    }
}
