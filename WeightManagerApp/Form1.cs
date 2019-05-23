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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CollectData();

            OutputToText.Enabled = true;
            button1.Click -= Button1_Click;
        }

        /// <summary>
        /// Excelからデータを抽出
        /// </summary>
        public void CollectData()
        {
            try
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

                        OutputWeightText(isCount, WeightDataTextBox, d, i);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Excelファイルが存在しません。");
            }
        }

        /// <summary>
        /// Excelから抽出した体重データを書き込む
        /// </summary>
        /// <param name="isTrue">体重一覧の最後列を探すための変数</param>
        /// <param name="textBox">体重推移を書き込むテキストボックス</param>
        /// <param name="xLColumn">Excelファイル</param>
        /// <param name="i">ダイエット経過日数</param>
        public void OutputWeightText(bool isTrue, TextBox textBox, IXLColumn xLColumn, int i)
        {
            while (!isTrue)
            {
                textBox.Text += OutputAllWeightText(i, xLColumn);
                i++;

                if(xLColumn.Cell(i+2).GetValue<string>() == "")
                {
                    isTrue = true;

                    CurrentWeightTextBox.Text = OutputNowWeightText(i, xLColumn);
                    LostWeightTextBox.Text = OutputLostWeightText(xLColumn, CurrentWeightTextBox.Text) + "kg";
                }
            }
        }

        public string OutputAllWeightText(int i, IXLColumn xLColumn)
        {
            return i + "日目:" + xLColumn.Cell(i + 2).GetValue<string>() + "kg\r\n";
        }

        public string OutputNowWeightText(int i, IXLColumn xLColumn)
        {
            var NowWeight = xLColumn.Cell(i + 1).GetValue<string>();
            return NowWeight + "kg";
        }

        public string OutputLostWeightText(IXLColumn xLColumn, string str)
        {
            return (xLColumn.Cell(3).GetValue<double>()
                       - double.Parse(YourWeight(str))).ToString();
        }
   
        /// <summary>
        /// 身長を入力したときの動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NextPageButton.Enabled = true;

                var IdealWeight = Calc_IdealWeight(double.Parse(HeightTextBox.Text));               
                var ByIdealWeight = Calc_ByIdealWeight(double.Parse(YourWeight(CurrentWeightTextBox.Text)), IdealWeight);

                IdealWeightlabel.Text = OutputIdealWeightLabel(IdealWeight);
                ByIdealWeightlabel.Text = OutputByIdealWeightLabel(ByIdealWeight);
            }
            catch(FormatException)
            {
                MessageBox.Show("数値のみ入力してください");
                HeightTextBox.SelectAll();
            }
        }

        public string OutputIdealWeightLabel(double IdealWeight)
        {
            return "あなたの理想体重は" + IdealWeight.ToString("F2") + "kgです。";
        }

        public string OutputByIdealWeightLabel(double ByIdealWeight)
        {
            return "あと" + ByIdealWeight.ToString("F2") + "kgです。";
        }

        public double Calc_IdealWeight(double Height)
        {
            return (Height / 100) * (Height / 100) * 22;
        }

        public double Calc_ByIdealWeight(double NowWeight, double IdealWeight)
        {
            return NowWeight - IdealWeight;
        }


        private void TextBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NextPageButton.Enabled = false;
            OutputToText.Enabled = false;
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();


            form2.BMILabel.Text = "BMI:" + YourBMI(YourHeight(HeightTextBox.Text),
                this.YourWeight(CurrentWeightTextBox.Text)).ToString("F2");

            form2.LooksLikeWho();
        }

        public string YourHeight(string strHeight)
        {
            return strHeight;
        }

        public string YourWeight(string strWeight)
        {
            return Regex.Replace(strWeight, @"[kg]", "");
        }

        public double YourBMI(string strHeight, string strWeight)
        {
            var BMI = double.Parse(strWeight) / ((double.Parse(strHeight) / 100) * ((double.Parse(strHeight) / 100)));
            return BMI;
        }

        //「結果をテキストに入力」をクリック後、テキストに一部の数値を出力する。
        private void OutputToText_Click(object sender, EventArgs e)
        {
            PutToTextFile();
        }

        public void PutToTextFile()
        {
            var filePath = @"C:\Users\syu1d\Desktop\OutToTextFile.txt";
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("直近10日間の体重推移");

                var RestoreTenWeight = new List<string>();
                var lines = this.WeightDataTextBox.Lines.Select(s => s).Count();
                var numberLines = this.WeightDataTextBox.Lines.Skip(lines - 11).ToArray();
                int a = 0;

                for (int i = lines - 10; i < lines; i++)
                {
                    writer.WriteLine(numberLines[a++]);
                }

                writer.WriteLine("");
                writer.WriteLine("現在の体重");
                writer.WriteLine(CurrentWeightTextBox.Text);
                writer.WriteLine("");
                writer.WriteLine("ダイエットで落とした総体重");
                writer.WriteLine(LostWeightTextBox.Text);
                writer.WriteLine("");
                writer.WriteLine("理想の体重まで" + ByIdealWeightlabel.Text);
            }
        }
    }
}
