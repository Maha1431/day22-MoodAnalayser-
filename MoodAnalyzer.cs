using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerwithCore
{
    public class MoodAnalyzer
    {

        public  string message;

        public MoodAnalyzer()
        {
        }

        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        /*public string AnalyseMood()
        {
            try
            {
                if (this.message.Contains("SAD"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch
            {
                return "Happy";

            }*/

        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be Empty");
                }
                if (this.message.Contains("SAD"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be Null");

            }

        }
    }


}
    

