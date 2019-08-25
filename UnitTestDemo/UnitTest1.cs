using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Xml.Linq;
using System.Data;
using System.Web.Script;
using System.Web.Script.Serialization;
using Moq;
using System.Linq;
using TestingDemo;


namespace UnitTestDemo
{
    [TestFixture]

    public class UnitTest1

    {

        [Test, TestCaseSource("AddTestCases")]
        public void Check_Add(AddTestData testData)
        {
            //Arrange
            Demonstration obj = new Demonstration();

            //Act
            var result = obj.Add(testData.X, testData.Y);

            //Assert
            NUnit.Framework.Assert.AreEqual(testData.ExpectedResult, result, "testing of ADD function has failed for these parameters");
        }

        /// <summary>
        /// test data for "Check_Add" function
        /// </summary>
        /// <returns></returns>
        private static List<AddTestData> AddTestCases()
        {
            ///various test scenarios
            List<AddTestData> lstAddDatas = new List<AddTestData>();
            //input parameters all +ve
            lstAddDatas.Add(GetSingleAddData(1, 2, 3));
            //input parameters one +ve one -ve
            lstAddDatas.Add(GetSingleAddData(-1, 2, 1));
            //input parameters all -ve
            lstAddDatas.Add(GetSingleAddData(-1, -2, -3));
            return lstAddDatas;
        }

        /// <summary>
        /// Single test case for "Check_Add" and "check_multiply" function
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static AddTestData GetSingleAddData(int x, int y, int result)
        {
            AddTestData singleData = new AddTestData();
            singleData.X = x;
            singleData.Y = y;
            singleData.ExpectedResult = result;
            return singleData;
        }

        [Test, TestCaseSource("MultiplyTestCases")]
        public void Check_Multiply(AddTestData testData)
        {
            //Arrange
            PrivateObject obj = new PrivateObject(new Demonstration());

            //Act
            var result = obj.Invoke("Multiply", testData.X, testData.Y);

            //Assert
            NUnit.Framework.Assert.AreEqual(testData.ExpectedResult, result, "testing of multiply function has failed for these parameters");
        }

        /// <summary>
        /// test data for "Check_Multiply" function
        /// </summary>
        /// <returns></returns>
        private static List<AddTestData> MultiplyTestCases()
        {
            ///various test scenarios
            List<AddTestData> lstAddDatas = new List<AddTestData>();
            //input parameters all +ve
            lstAddDatas.Add(GetSingleAddData(1, 2, 2));
            //input parameters one +ve one -ve
            lstAddDatas.Add(GetSingleAddData(-1, 2, -2));
            //input parameters all -ve
            lstAddDatas.Add(GetSingleAddData(-1, -2, 2));
            // one input zero
            lstAddDatas.Add(GetSingleAddData(0, 5, 0));
            return lstAddDatas;
        }

        [Test, TestCaseSource("IsEvenTestCases")]
        public void Check_IsEven(KeyValuePair<int, bool> testData)
        {
            //Arrange     

            //Act 
            var result = Demonstration.IsEven(testData.Key);

            //Assert
            NUnit.Framework.Assert.AreEqual(testData.Value, result, "testing of IsEven function has failed for the parameter");
        }

        /// <summary>
        /// test data for "Check_IsEven" function
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int, bool> IsEvenTestCases()
        {
            ///various test scenarios
            ///key contains the test input parameter
            // value contains the expected result
            Dictionary<int, bool> dcIsEvenCases = new Dictionary<int, bool>();

            // -ve no scenarios
            dcIsEvenCases.Add(-1, false);//odd
            dcIsEvenCases.Add(-2, true);//even
            dcIsEvenCases.Add(-3, false);//odd
            dcIsEvenCases.Add(0, true);//even

            // +ve no scenarios
            dcIsEvenCases.Add(1, false);//odd
            dcIsEvenCases.Add(2, true);//even
            dcIsEvenCases.Add(3, false);//odd

            return dcIsEvenCases;
        }

        [Test, TestCaseSource("CalPercentageTestCases")]
        public void check_CalculatePercentage(CalculatePercentageData calPercentageData)
        {
            //Arrange
            PrivateType privateType = new PrivateType(typeof(Demonstration));

            //Act
            var result = (decimal)privateType.InvokeStatic("CalculatePercentage",
                calPercentageData.X, calPercentageData.Y);

            //Assert
            NUnit.Framework.Assert.AreEqual(calPercentageData.ExpectedResult, result, "testing of CalculatePercentage function has failed for this parameter");
        }

        /// <summary>
        /// test data for "Check_Add" function
        /// </summary>
        /// <returns></returns>
        private static List<CalculatePercentageData> CalPercentageTestCases()
        {
            ///various test scenarios
            List<CalculatePercentageData> lstCalPercentageDatas = new List<CalculatePercentageData>();
            //scenario: x < y
            lstCalPercentageDatas.Add(GetSingleCalPercentageData(2, 10, 20));
            //scenario : x = 0
            lstCalPercentageDatas.Add(GetSingleCalPercentageData(0, 10, 0));
            //scenario:  x > y
            lstCalPercentageDatas.Add(GetSingleCalPercentageData(8, 2, 400));
            return lstCalPercentageDatas;
        }

        /// <summary>
        /// Single test case for "Check_Add" and "check_multiply" function
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static CalculatePercentageData GetSingleCalPercentageData(int x, int y, int result)
        {
            CalculatePercentageData singleData = new CalculatePercentageData();
            singleData.X = x;
            singleData.Y = y;
            singleData.ExpectedResult = result;
            return singleData;
        }

        [Test ,TestCaseSource("SetWholeNoCases")]
        public void Check_SetWholeNo(SetWholeNoData testData)
        {
            //Arrange
            PrivateObject obj = new PrivateObject(new Demonstration());            

            //Act and Assert            
            NUnit.Framework.Assert.DoesNotThrow(() => obj.Invoke("SetWholeNo", testData.lstNos));
            ///fetching the value of class level private variable
            var result = (List<int>)obj.GetField("lstwholeNo");
            foreach (int actualNo in result)
            {
                NUnit.Framework.Assert.Contains(actualNo, testData.lstExpectedWholeNos, "testing of SetWholeNo function has failed");
            }            
        }

        /// <summary>
        /// test data for "Check_SetWholeNo" function
        /// </summary>
        /// <returns></returns>
        private static List<SetWholeNoData> SetWholeNoCases()
        {
            ///various test scenarios
            List<SetWholeNoData> lstCases = new List<SetWholeNoData>();
            SetWholeNoData normalCase = new SetWholeNoData();
            normalCase.lstNos = new List<int> { -2, -1, 0, 1, 2, 3 };
            normalCase.lstExpectedWholeNos = new List<int> { 0, 1, 2, 3 };
            lstCases.Add(normalCase);
            return lstCases;
        }
    }

    #region associated class,struct 

    public struct AddTestData
    {
        public int X;
        public int Y;
        public int ExpectedResult;
    }

    public struct CalculatePercentageData
    {
        public int X;
        public int Y;
        public decimal ExpectedResult;
    }

    public struct SetWholeNoData
    {
        public List<int> lstNos;
        public List<int> lstExpectedWholeNos;
    }
    #endregion
}
