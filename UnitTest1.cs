using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerwithCore;

namespace MoodAnalyzerMsTestwithCore
{
    [TestClass]
    public class UnitTest1
    {
        //summary
        [TestMethod]
        public void GivenSadMoodshouldReturnSAD()
        {
            //Arrange
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            //Act
            string mood = moodAnalyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);
        }

        //summary
        //Tc 1.2 & 2.1 Give ? I am in HappyMood? and null message Should Return HAPPY
        [TestMethod]
        //[DataRow (I am in Happy Mood)]
        [DataRow(null)]
        public void GivenHappyMoodShouldReturnHAPPY()
        {

            //arrange

            string expected = "HAPPY";
            string message = "I am In Happy Mood";
            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            //Act
            string mood = moodAnalyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);

        }
        //summary
        //Tc 3.2 Given Empty Mood should throw MoodAnalysisException Including Empty Mood
        [TestMethod]
        public void Given_Empty_Mood_should_throw_MoodAnalysisException_Including_Empty_Mood()
        {
            try
            {
                string message = "";
                MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);
                string mood = moodAnalyse.AnalyseMood();

            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("Mood should not be Empty", e.Message);
            }
        }

        //summary
        //Tc 3.1 Given Null Mood should throw MoodAnalysisException
        public void Given_NULL_MOOd_should_throw_MoodAnalysisException()
        {
            try
            {
                string message = null;
                MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("Mood should not be Null", e.Message);
            }
        }
        //summary
        //TC 4.1 Given the MoodAnalyze Class name should Return MoodAnalayzer object
        [TestMethod]
        public void TestMethod6()
        {
            string message = null;
            object expected = new MoodAnalyzer(message);
            object obj = MoodAnalyzerReflactor.CreatMoodAnalyser("MoodAnalyzerwithCore.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }



        //summary
        //TC 4.2
        [TestMethod]
        public void TestMethod7()
        {
            string msg = "Class not found";
            try
            {
                object obj = MoodAnalyzerReflactor.CreatMoodAnalyser("MSTestMoodAnalyserDay20.MoodAnalyserFake", "MoodAnalyserFake");
            }
            catch (MoodAnalyzerCustomException custom)
            {
                Assert.AreEqual(msg, custom.Message);
            }


        }
        //summary
        //TC 4.3 Given Improper Constructor should Throw MoodAnalyzerCustomException
        [TestMethod]
        public void TestMethod8()
        {
            string msg = "Constructor is not found";
            try
            {
                object obj = MoodAnalyzerReflactor.CreatMoodAnalyser("MSTestMoodAnalyserDay20.MoodAnalyser", "MoodAnalyserFake");
            }
            catch (MoodAnalyzerCustomException custom)
            {
                Assert.AreEqual(msg, custom.Message);
            }
        }
        //summary
        //TC 5.1 Given Clas name should Return MoodAnalyze Obeject
        [TestMethod]
        public void TestMethod9()
        {
            object expected = new MoodAnalyzer("HAPPY");
            object obj = MoodAnalyzerReflactor.CreateMoodAnalyseUsingParameterizedConstructor("MSTestMoodAnalyserDay20.MoodAnalyser", "MoodAnalyser", "HAPPY");
            expected.Equals(obj);

        }
        //summary
        //TC 5.2
        [TestMethod]
        public void TestMethod10()
        {
            string msg = "Class not found";
            try
            {
                object obj = MoodAnalyzerReflactor.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerwithCore.MoodAnalyzerFake", "MoodAnalyzerFake", "HAPPY");
            }
            catch (MoodAnalyzerCustomException custom)
            {
                Assert.AreEqual(msg, custom.Message);
            }
        }
        //summary
        //TC 5.3
        [TestMethod]
        public void TestMethod11()
        {
            string msg = "Constructor is not found";
            try
            {
                object obj = MoodAnalyzerReflactor.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerwithCore.MoodAnalyser", "MoodAnalyzerFake", "HAPPY");
            }
            catch (MoodAnalyzerCustomException custom)
            {
                Assert.AreEqual(msg, custom.Message);
            }
        }
        //summary
        //TC 6.1 Given Happy should retrun Happy
        [TestMethod]
        public void TestMethod12()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyzerReflactor.InvokeAnalyseMethod("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }
        //summary
        //TC 6.2
        [TestMethod]
        public void TestMethod13()
        {
            string expected = "No such method exists";
            try
            {
                string mood = MoodAnalyzerReflactor.InvokeAnalyseMethod("Happy", "AnalyseMoodFake");
            }
            catch (MoodAnalyzerCustomException custom)
            {
                Assert.AreEqual(expected, custom.Message);
            }
        }
        //summary
        //TC 7.1 Given Happy should Return Happy
        [TestMethod]
        public void TestMethod14()
        {
            string result = MoodAnalyzerReflactor.setField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }

    }
}