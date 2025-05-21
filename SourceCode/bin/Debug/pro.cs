﻿
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF        =  0, // (EOF)
        SYMBOL_ERROR      =  1, // (Error)
        SYMBOL_WHITESPACE =  2, // Whitespace
        SYMBOL_MINUS      =  3, // '-'
        SYMBOL_EXCLAMEQ   =  4, // '!='
        SYMBOL_PERCENT    =  5, // '%'
        SYMBOL_LPAREN     =  6, // '('
        SYMBOL_RPAREN     =  7, // ')'
        SYMBOL_TIMES      =  8, // '*'
        SYMBOL_TIMESTIMES =  9, // '**'
        SYMBOL_DOTDOT     = 10, // '..'
        SYMBOL_DIV        = 11, // '/'
        SYMBOL_PLUS       = 12, // '+'
        SYMBOL_PLUSEQ     = 13, // '+='
        SYMBOL_LT         = 14, // '<'
        SYMBOL_EQ         = 15, // '='
        SYMBOL_MINUSEQ    = 16, // '-='
        SYMBOL_EQEQ       = 17, // '=='
        SYMBOL_GT         = 18, // '>'
        SYMBOL_1          = 19, // '1'
        SYMBOL_BEGIN      = 20, // begin
        SYMBOL_DIGIT      = 21, // Digit
        SYMBOL_DOUBLE     = 22, // double
        SYMBOL_ELSE       = 23, // else
        SYMBOL_END        = 24, // end
        SYMBOL_FLOAT      = 25, // float
        SYMBOL_FOR        = 26, // for
        SYMBOL_ID         = 27, // Id
        SYMBOL_IF         = 28, // if
        SYMBOL_IN         = 29, // in
        SYMBOL_INT        = 30, // int
        SYMBOL_NEWLINE    = 31, // NEWLINE
        SYMBOL_STRING     = 32, // string
        SYMBOL_ASSIGN     = 33, // <assign>
        SYMBOL_CONCEPT    = 34, // <concept>
        SYMBOL_COND       = 35, // <cond>
        SYMBOL_DATA       = 36, // <data>
        SYMBOL_DIGIT2     = 37, // <digit>
        SYMBOL_EXP        = 38, // <exp>
        SYMBOL_EXPR       = 39, // <expr>
        SYMBOL_FACTOR     = 40, // <factor>
        SYMBOL_FOR_STMT   = 41, // <for_stmt>
        SYMBOL_ID2        = 42, // <id>
        SYMBOL_IF_STMT    = 43, // <if_stmt>
        SYMBOL_OP         = 44, // <op>
        SYMBOL_PROGRAM    = 45, // <program>
        SYMBOL_RANGE      = 46, // <range>
        SYMBOL_STEP       = 47, // <step>
        SYMBOL_STMT_LIST  = 48, // <stmt_list>
        SYMBOL_TERM       = 49  // <term>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_BEGIN_END                        =  0, // <program> ::= begin <stmt_list> end
        RULE_STMT_LIST                                =  1, // <stmt_list> ::= <concept>
        RULE_STMT_LIST2                               =  2, // <stmt_list> ::= <concept> <stmt_list>
        RULE_CONCEPT                                  =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                                 =  4, // <concept> ::= <if_stmt>
        RULE_CONCEPT3                                 =  5, // <concept> ::= <for_stmt>
        RULE_ASSIGN_EQ_NEWLINE                        =  6, // <assign> ::= <id> '=' <expr> NEWLINE
        RULE_ID_ID                                    =  7, // <id> ::= Id
        RULE_EXPR_PLUS                                =  8, // <expr> ::= <term> '+' <expr>
        RULE_EXPR_MINUS                               =  9, // <expr> ::= <term> '-' <expr>
        RULE_EXPR                                     = 10, // <expr> ::= <term>
        RULE_TERM_TIMES                               = 11, // <term> ::= <factor> '*' <term>
        RULE_TERM_DIV                                 = 12, // <term> ::= <factor> '/' <term>
        RULE_TERM_PERCENT                             = 13, // <term> ::= <factor> '%' <term>
        RULE_TERM                                     = 14, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                        = 15, // <factor> ::= <exp> '**' <factor>
        RULE_FACTOR                                   = 16, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                        = 17, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                      = 18, // <exp> ::= <id>
        RULE_EXP2                                     = 19, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                              = 20, // <digit> ::= Digit
        RULE_IF_STMT_IF_NEWLINE_END                   = 21, // <if_stmt> ::= if <cond> NEWLINE <stmt_list> end
        RULE_IF_STMT_IF_NEWLINE_ELSE_NEWLINE_END      = 22, // <if_stmt> ::= if <cond> NEWLINE <stmt_list> else NEWLINE <stmt_list> end
        RULE_COND                                     = 23, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                    = 24, // <op> ::= '<'
        RULE_OP_GT                                    = 25, // <op> ::= '>'
        RULE_OP_EQEQ                                  = 26, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                              = 27, // <op> ::= '!='
        RULE_FOR_STMT_FOR_IN_NEWLINE_END              = 28, // <for_stmt> ::= for <id> in <range> NEWLINE <stmt_list> end
        RULE_RANGE_LPAREN_RPAREN_DOTDOT_LPAREN_RPAREN = 29, // <range> ::= '(' <expr> ')' '..' '(' <expr> ')'
        RULE_STEP_PLUSEQ_1                            = 30, // <step> ::= <id> '+=' '1'
        RULE_STEP_MINUSEQ_1                           = 31, // <step> ::= <id> '-=' '1'
        RULE_STEP                                     = 32, // <step> ::= <assign>
        RULE_DATA_INT                                 = 33, // <data> ::= int
        RULE_DATA_FLOAT                               = 34, // <data> ::= float
        RULE_DATA_DOUBLE                              = 35, // <data> ::= double
        RULE_DATA_STRING                              = 36  // <data> ::= string
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOTDOT :
                //'..'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSEQ :
                //'+='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSEQ :
                //'-='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_1 :
                //'1'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BEGIN :
                //begin
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEWLINE :
                //NEWLINE
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA :
                //<data>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<for_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANGE :
                //<range>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_BEGIN_END :
                //<program> ::= begin <stmt_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <concept> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <for_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ_NEWLINE :
                //<assign> ::= <id> '=' <expr> NEWLINE
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <term> '+' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <term> '-' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <factor> '*' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <factor> '/' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <factor> '%' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <exp> '**' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_NEWLINE_END :
                //<if_stmt> ::= if <cond> NEWLINE <stmt_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_NEWLINE_ELSE_NEWLINE_END :
                //<if_stmt> ::= if <cond> NEWLINE <stmt_list> else NEWLINE <stmt_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_IN_NEWLINE_END :
                //<for_stmt> ::= for <id> in <range> NEWLINE <stmt_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RANGE_LPAREN_RPAREN_DOTDOT_LPAREN_RPAREN :
                //<range> ::= '(' <expr> ')' '..' '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSEQ_1 :
                //<step> ::= <id> '+=' '1'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSEQ_1 :
                //<step> ::= <id> '-=' '1'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_INT :
                //<data> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_FLOAT :
                //<data> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_DOUBLE :
                //<data> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_STRING :
                //<data> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
