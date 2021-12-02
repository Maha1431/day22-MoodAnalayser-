using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerwithCore
{
    public class MoodAnalyzerCustomException : Exception
    {

        //summary
        //Enum for exception Type
        public enum ExceptionType
        {
            NULL_MESSAGE, EMPTY_MESSAGE,
            NO_SUCH_FIELD, NO_SUCH_METHOD,
            NO_SUCH_CLASS, OBJECT_CREATION_ISSUE

        }
        //creating 'type' variable of type ExceptiontType
        private readonly ExceptionType type;


        public MoodAnalyzerCustomException(ExceptionType Type, string message) : base(message)
        {
            this.type = Type;
        }
    }
}
