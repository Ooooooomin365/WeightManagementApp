namespace WeightManagerApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.WeightDataTextBox = new System.Windows.Forms.TextBox();
            this.OutputToText = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CurrentWeightTextBox = new System.Windows.Forms.TextBox();
            this.LostWeightTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.IdealWeightlabel = new System.Windows.Forms.Label();
            this.ByIdealWeightlabel = new System.Windows.Forms.Label();
            this.NextPageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "ダイエット経過";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // WeightDataTextBox
            // 
            this.WeightDataTextBox.Location = new System.Drawing.Point(23, 37);
            this.WeightDataTextBox.Multiline = true;
            this.WeightDataTextBox.Name = "WeightDataTextBox";
            this.WeightDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.WeightDataTextBox.Size = new System.Drawing.Size(142, 203);
            this.WeightDataTextBox.TabIndex = 1;
            // 
            // OutputToText
            // 
            this.OutputToText.Location = new System.Drawing.Point(152, 303);
            this.OutputToText.Name = "OutputToText";
            this.OutputToText.Size = new System.Drawing.Size(118, 23);
            this.OutputToText.TabIndex = 2;
            this.OutputToText.Text = "結果をテキストに出力";
            this.OutputToText.UseVisualStyleBackColor = true;
            this.OutputToText.Click += new System.EventHandler(this.OutputToText_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(200, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "現在の体重";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(200, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "落とした体重";
            // 
            // CurrentWeightTextBox
            // 
            this.CurrentWeightTextBox.Location = new System.Drawing.Point(297, 37);
            this.CurrentWeightTextBox.Name = "CurrentWeightTextBox";
            this.CurrentWeightTextBox.Size = new System.Drawing.Size(100, 19);
            this.CurrentWeightTextBox.TabIndex = 5;
            this.CurrentWeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LostWeightTextBox
            // 
            this.LostWeightTextBox.Location = new System.Drawing.Point(297, 78);
            this.LostWeightTextBox.Name = "LostWeightTextBox";
            this.LostWeightTextBox.Size = new System.Drawing.Size(100, 19);
            this.LostWeightTextBox.TabIndex = 6;
            this.LostWeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(54, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "体重推移";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(222, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "理想の体重はいくつ？（BMI22）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(222, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "身長（cm）";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(276, 160);
            this.HeightTextBox.Multiline = true;
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(100, 18);
            this.HeightTextBox.TabIndex = 10;
            this.HeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.HeightTextBox.Click += new System.EventHandler(this.TextBox4_Click);
            this.HeightTextBox.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
            // 
            // IdealWeightlabel
            // 
            this.IdealWeightlabel.AutoSize = true;
            this.IdealWeightlabel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IdealWeightlabel.Location = new System.Drawing.Point(222, 196);
            this.IdealWeightlabel.Name = "IdealWeightlabel";
            this.IdealWeightlabel.Size = new System.Drawing.Size(152, 12);
            this.IdealWeightlabel.TabIndex = 11;
            this.IdealWeightlabel.Text = "あなたの理想体重は??kgです。";
            // 
            // ByIdealWeightlabel
            // 
            this.ByIdealWeightlabel.AutoSize = true;
            this.ByIdealWeightlabel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ByIdealWeightlabel.Location = new System.Drawing.Point(256, 218);
            this.ByIdealWeightlabel.Name = "ByIdealWeightlabel";
            this.ByIdealWeightlabel.Size = new System.Drawing.Size(73, 12);
            this.ByIdealWeightlabel.TabIndex = 12;
            this.ByIdealWeightlabel.Text = "あと??kgです。";
            // 
            // NextPageButton
            // 
            this.NextPageButton.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NextPageButton.Location = new System.Drawing.Point(360, 282);
            this.NextPageButton.Name = "NextPageButton";
            this.NextPageButton.Size = new System.Drawing.Size(51, 44);
            this.NextPageButton.TabIndex = 13;
            this.NextPageButton.Text = "➡";
            this.NextPageButton.UseVisualStyleBackColor = true;
            this.NextPageButton.Click += new System.EventHandler(this.NextPageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 338);
            this.Controls.Add(this.NextPageButton);
            this.Controls.Add(this.ByIdealWeightlabel);
            this.Controls.Add(this.IdealWeightlabel);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LostWeightTextBox);
            this.Controls.Add(this.CurrentWeightTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputToText);
            this.Controls.Add(this.WeightDataTextBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button OutputToText;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LostWeightTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label IdealWeightlabel;
        private System.Windows.Forms.Label ByIdealWeightlabel;
        public System.Windows.Forms.TextBox CurrentWeightTextBox;
        public System.Windows.Forms.TextBox HeightTextBox;
        public System.Windows.Forms.Button NextPageButton;
        public System.Windows.Forms.TextBox WeightDataTextBox;
    }
}

