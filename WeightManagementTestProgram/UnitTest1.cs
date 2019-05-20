using ClosedXML.Excel;
using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeightManagerApp;


namespace WeightManagementTestProgram
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckHeightMethod1()
        {
            var form1 = new Form1();
            string Height = form1.YourHeight("178");

            Assert.AreEqual("178", Height);
        }

        [TestMethod]
        public void CheckHeightMethod2()
        {
            var form1 = new Form1();
            string Height = form1.YourHeight("178cm");

            Assert.AreEqual("178cm", Height);
        }

        [TestMethod]
        public void CheckWeightMethod1()
        {
            var form1 = new Form1();
            string Weight = form1.YourWeight("65kg");

            Assert.AreEqual("65", Weight);
        }

        [TestMethod]
        public void CheckWeightMethod2()
        {
            var form1 = new Form1();
            string Weight = form1.YourWeight("65.5kg");

            Assert.AreEqual("65.5", Weight);  
        }

        [TestMethod]
        public void CheckBmiMethod1()
        {
            var form1 = new Form1();
            double BMI = form1.YourBMI("178", "70");

            Assert.AreEqual(22.09, BMI, 0.01);
        }

        [TestMethod]
        public void CheckIdealWeightMethod1()
        {
            var form1 = new Form1();
            double IdealWeight = form1.Calc_IdealWeight(178);

            Assert.AreEqual(69.70, IdealWeight, 0.01);
        }

        [TestMethod]
        public void CheckByIdealWeightMethod1()
        {
            var form1 = new Form1();
            double ByIdealWeight = form1.Calc_ByIdealWeight(79.55, 64.177653);

            Assert.AreEqual(15.37, ByIdealWeight, 0.01);
        }

        [TestMethod]
        public void OutputByIdealWeightLabelCheckMethod1()
        {
            var form1 = new Form1();
            string WeightLabel = form1.OutputIdealWeightLabel(70.0);

            Assert.AreEqual("あなたの理想体重は" + 70.0.ToString("F2") + "kgです。", WeightLabel);
        }

        [TestMethod]
        public void OutputLostWeightTextCheckMethod1()
        {
            var form1 = new Form1();
            using (var ExcelData = new ClosedXML.Excel.XLWorkbook
               (@"C:\Users\syu1d\source\repos\WeightManagerApp\WeightManagementTestProgram\bin\Debug\Test.xlsx"))
            {
                var worksheet = ExcelData.Worksheets.Where(i => i.Name == "Sheet1").FirstOrDefault();
                var ColumnOfWeight = worksheet.Columns("B");

                foreach (var xLColumn in ColumnOfWeight)
                {                 
                    Assert.AreEqual("4", form1.OutputLostWeightText(xLColumn,"1"));
                }
            }
        }

        [TestMethod]
        public void OutputNowWeightTextCheckMethod1()
        {
            var form1 = new Form1();
            using (var ExcelData = new ClosedXML.Excel.XLWorkbook
               (@"C:\Users\syu1d\source\repos\WeightManagerApp\WeightManagementTestProgram\bin\Debug\Test.xlsx"))
            {
                var worksheet = ExcelData.Worksheets.Where(i => i.Name == "Sheet1").FirstOrDefault();
                var ColumnOfWeight = worksheet.Columns("B");

                foreach (var xLColumn in ColumnOfWeight)
                {
                    Assert.AreEqual("3kg", form1.OutputNowWeightText(3, xLColumn));
                }
            }
        }
        [TestMethod]
        public void OutputAllWeightTextCheckMethod1()
        {
            var form1 = new Form1();
            using (var ExcelData = new ClosedXML.Excel.XLWorkbook
               (@"C:\Users\syu1d\source\repos\WeightManagerApp\WeightManagementTestProgram\bin\Debug\Test.xlsx"))
            {
                var worksheet = ExcelData.Worksheets.Where(i => i.Name == "Sheet1").FirstOrDefault();
                var ColumnOfWeight = worksheet.Columns("B");

                foreach (var xLColumn in ColumnOfWeight)
                {
                    Assert.AreEqual("1日目:5kg\r\n", form1.OutputAllWeightText(1, xLColumn));
                }
            }
        }

        [TestMethod]
        public void Calc_HowLostWeightCheckMethod1()
        {
            var form2 = new Form2();
            using (var ExcelData = new ClosedXML.Excel.XLWorkbook
               (@"C:\Users\syu1d\source\repos\WeightManagerApp\WeightManagementTestProgram\bin\Debug\Test.xlsx"))
            {
                var worksheet = ExcelData.Worksheets.Where(i => i.Name == "Sheet1").FirstOrDefault();
                var ColumnOfWeight = worksheet.Columns("B");

                foreach (var xLColumn in ColumnOfWeight)
                {
                    Assert.AreEqual(2, form2.Calc_HowLostWeight(xLColumn, 3));
                }
            }
        }

        [TestMethod]
        public void OutputLostWeightPaceCheckMethod1()
        {
            var form2 = new Form2();
            var LostWeightPace = form2.OutputLostWeightPace(10.5);

            Assert.AreEqual("あなたは1日に約10.50kg痩せています。", LostWeightPace);
        }

        [TestMethod]
        public void OutputLostWeightPaceCheckMethod2()
        {
            var form2 = new Form2();
            var LostWeightPace = form2.OutputLostWeightPace(8);

            Assert.AreEqual("あなたは1日に約8.00kg痩せています。", LostWeightPace);
        }

        [TestMethod]
        public void OutputLostWeightPaceCheckMethod3()
        {
            var form2 = new Form2();
            var LostWeightPace = form2.OutputLostWeightPace(11.2345);

            Assert.AreEqual("あなたは1日に約11.23kg痩せています。", LostWeightPace);
        }
    }
}
