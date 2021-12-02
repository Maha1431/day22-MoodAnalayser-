using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzerwithCore
{
     public class MoodAnalyzerReflactor
    {
        // UC 4 
        public static object CreatMoodAnalyser(string classname, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(classname, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalysetype = executing.GetType(classname);
                    return Activator.CreateInstance(moodAnalysetype);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
            }
        }

        //UC 5

        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyzer);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                }
            }
            else
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }

        //UC 6

        public static string InvokeAnalyseMethod(string msg, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerWithCore.MoodAnalyzer");
                object moodAnalyserObject = CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerwithCore.MoodAnalyzer",
                    "MoodAnalyser", msg);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyserObject, null);
                return mood.ToString();

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "No such method exists");
            }
        }


        //UC 7

        public static string setField(string message, string fieldName)
        {
            try
            {
                MoodAnalyzer mood = new MoodAnalyzer();
                Type type = typeof(MoodAnalyzer);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_FIELD, "Message should not be null");
                }
                field.SetValue(mood, message);
                return mood.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_FIELD, "field is not found");
            }
        }
    }
}
    
    
    

