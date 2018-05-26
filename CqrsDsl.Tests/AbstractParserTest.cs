using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;
using CqrsDsl.Generated;

namespace CqrsDsl.Tests
{
    public abstract class AbstractParserTest
    {
        protected ITokenStream GetTokenStream(string input)
        {
            var inputStream = new AntlrInputStream(input);
            var lexer = new CqrsLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            return tokenStream;
        }
    }
}
