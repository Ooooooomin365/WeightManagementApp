using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WeightManagerApp
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void DataForGraph()
        {
            using (var ExcelData = new ClosedXML.Excel.XLWorkbook
                (@"C:\Users\syu1d\source\repos\WeightManagerApp\WeightManagerApp\bin\Debug\WeightManagement.xlsx"))
            {
                var worksheet = ExcelData.Worksheets.Where(i => i.Name == "Sheet1").FirstOrDefault();
                var ColumnOfWeight = worksheet.Columns("B");

                foreach (var d in ColumnOfWeight)
                {
                    bool isCount = false;
                    int i = 1;
                    
                    Make_Graph(isCount, i, d, chart1);
                }
            }
        }

       public void Make_Graph(bool isCount, int i, IXLColumn xLColumn, Chart chart)
        {
            while (!isCount)
            {
                DataPoint dataPoint = new DataPoint();
                dataPoint.SetValueXY(i, xLColumn.Cell(i + 2).GetValue<double>());

                string legend = "体重";
                chart.Series[legend].Points.Add(dataPoint);

                i++;

                if (xLColumn.Cell(i + 2).GetValue<string>() == "")
                    isCount = true;
            }
        }

        private void LostWeightPace()
        {
            using (var ExcelData = new ClosedXML.Excel.XLWorkbook
                (@"C:\Users\syu1d\source\repos\WeightManagerApp\WeightManagerApp\bin\Debug\WeightManagement.xlsx"))
            {

                var worksheet = ExcelData.Worksheets.Where(i => i.Name == "Sheet1").FirstOrDefault();
                var ColumnOfWeight = worksheet.Columns("B");

                foreach (var d in ColumnOfWeight)
                {
                    bool isCount = false;
                    int i = 1;
           
                    Calc_LostWeightPace(isCount, i, LostPaceLabel, d);
                }
            }
        }

        public void Calc_LostWeightPace(bool isCount, int i, Label label, IXLColumn xLColumn)
        {
            while (!isCount)
            {
                if (xLColumn.Cell(i + 2).GetValue<string>() == "")
                {
                    isCount = true;
                    var HowLost_Weight = Calc_HowLostWeight(xLColumn, i);
                    var LostPace_Weight = HowLost_Weight / (i - 1);
                    label.Text = OutputLostWeightPace(LostPace_Weight);
                }
                else
                    i++;
            }
        }

        public double Calc_HowLostWeight(IXLColumn xLColumn, int i)
        {
            return xLColumn.Cell(3).GetValue<double>() - xLColumn.Cell(i + 1).GetValue<double>();
        }

        public string OutputLostWeightPace(double LostPace)
        {
            return "あなたは1日に約" + LostPace.ToString("F2") + "kg痩せています。";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataForGraph();
            
            LostWeightPace();
        }

        public void LooksLikeWho()
        {
            var ArtistDict = new Dictionary<double, string>()
            {
                {14.7, "桐谷美玲" },
                {15.6, "本田翼" },
                {17, "新垣結衣" },
                {17.4,"菅田将暉" },
                {19.1, "アンガールズ田中" },
                {20.5,"妻夫木聡" },
                {24.5,"香取慎吾" },
                {26.6,"つるべさん" },
                {30.5, "カンニング竹山" },
                {33.2,"長州小力" },
                {38.2,"石塚英彦" },
                {44.2,"マツコ・デラックス" },
            };

            var ArtistKeyList = new List<double>
            {
                14.7, 15.6, 17, 17.4, 19.1, 20.5, 24.5, 26.6, 30.5, 33.2, 38.2, 44.2
            };

            var yourBMI = double.Parse(Regex.Replace(BMILabel.Text, @"[BMI:]", ""));

            var min = ArtistKeyList.Min(d => Math.Abs(d - yourBMI));
            var nearKey = ArtistKeyList.First(d => Math.Abs(d - yourBMI) == min);
            var ArtistValue = ArtistDict[nearKey];

            ArtistNameText.Text = ArtistValue;
        }
    }
}
