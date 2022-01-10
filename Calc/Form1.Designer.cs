namespace Calc
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_plus = new System.Windows.Forms.Button();
            this.btn_minus = new System.Windows.Forms.Button();
            this.btn_Negative = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_Coma = new System.Windows.Forms.Button();
            this.btn_1 = new System.Windows.Forms.Button();
            this.btn_Zero = new System.Windows.Forms.Button();
            this.btn_2 = new System.Windows.Forms.Button();
            this.btn_7 = new System.Windows.Forms.Button();
            this.btn_3 = new System.Windows.Forms.Button();
            this.btn_8 = new System.Windows.Forms.Button();
            this.btn_6 = new System.Windows.Forms.Button();
            this.btn_4 = new System.Windows.Forms.Button();
            this.btn_9 = new System.Windows.Forms.Button();
            this.btn_5 = new System.Windows.Forms.Button();
            this.btn_divide = new System.Windows.Forms.Button();
            this.btn_multiply = new System.Windows.Forms.Button();
            this.btn_bspace = new System.Windows.Forms.Button();
            this.btn_Result = new System.Windows.Forms.Button();
            this.btn_SQR = new System.Windows.Forms.Button();
            this.btn_SQRT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(353, 454);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 138);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Result, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.btn_plus, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn_minus, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_Negative, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btn_Coma, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btn_1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn_Zero, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btn_2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn_7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn_8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_divide, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_multiply, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_bspace, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_SQR, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_SQRT, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_clear, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(353, 312);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btn_plus
            // 
            this.btn_plus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_plus.Location = new System.Drawing.Point(267, 211);
            this.btn_plus.Name = "btn_plus";
            this.btn_plus.Size = new System.Drawing.Size(83, 46);
            this.btn_plus.TabIndex = 20;
            this.btn_plus.Text = "+";
            this.btn_plus.UseVisualStyleBackColor = true;
            this.btn_plus.Click += new System.EventHandler(this.btn_plus_Click);
            // 
            // btn_minus
            // 
            this.btn_minus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_minus.Location = new System.Drawing.Point(267, 159);
            this.btn_minus.Name = "btn_minus";
            this.btn_minus.Size = new System.Drawing.Size(83, 46);
            this.btn_minus.TabIndex = 19;
            this.btn_minus.Text = "-";
            this.btn_minus.UseVisualStyleBackColor = true;
            this.btn_minus.Click += new System.EventHandler(this.btn_minus_Click);
            // 
            // btn_Negative
            // 
            this.btn_Negative.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Negative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Negative.Location = new System.Drawing.Point(91, 263);
            this.btn_Negative.Name = "btn_Negative";
            this.btn_Negative.Size = new System.Drawing.Size(82, 46);
            this.btn_Negative.TabIndex = 16;
            this.btn_Negative.Text = "±";
            this.btn_Negative.UseVisualStyleBackColor = true;
            this.btn_Negative.Click += new System.EventHandler(this.btn_Negative_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_clear.Location = new System.Drawing.Point(179, 3);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(82, 46);
            this.btn_clear.TabIndex = 12;
            this.btn_clear.Text = "C";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_Coma
            // 
            this.btn_Coma.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Coma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Coma.Location = new System.Drawing.Point(179, 263);
            this.btn_Coma.Name = "btn_Coma";
            this.btn_Coma.Size = new System.Drawing.Size(82, 46);
            this.btn_Coma.TabIndex = 1;
            this.btn_Coma.Text = ",";
            this.btn_Coma.UseVisualStyleBackColor = true;
            this.btn_Coma.Click += new System.EventHandler(this.btn_Coma_Click);
            // 
            // btn_1
            // 
            this.btn_1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_1.Location = new System.Drawing.Point(3, 211);
            this.btn_1.Name = "btn_1";
            this.btn_1.Size = new System.Drawing.Size(82, 46);
            this.btn_1.TabIndex = 3;
            this.btn_1.Text = "1";
            this.btn_1.UseVisualStyleBackColor = true;
            this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
            // 
            // btn_Zero
            // 
            this.btn_Zero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Zero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Zero.Location = new System.Drawing.Point(3, 263);
            this.btn_Zero.Name = "btn_Zero";
            this.btn_Zero.Size = new System.Drawing.Size(82, 46);
            this.btn_Zero.TabIndex = 0;
            this.btn_Zero.Text = "0";
            this.btn_Zero.UseVisualStyleBackColor = true;
            this.btn_Zero.Click += new System.EventHandler(this.btn_Zero_Click);
            // 
            // btn_2
            // 
            this.btn_2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_2.Location = new System.Drawing.Point(91, 211);
            this.btn_2.Name = "btn_2";
            this.btn_2.Size = new System.Drawing.Size(82, 46);
            this.btn_2.TabIndex = 4;
            this.btn_2.Text = "2";
            this.btn_2.UseVisualStyleBackColor = true;
            this.btn_2.Click += new System.EventHandler(this.btn_2_Click);
            // 
            // btn_7
            // 
            this.btn_7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_7.Location = new System.Drawing.Point(3, 107);
            this.btn_7.Name = "btn_7";
            this.btn_7.Size = new System.Drawing.Size(82, 46);
            this.btn_7.TabIndex = 9;
            this.btn_7.Text = "7";
            this.btn_7.UseVisualStyleBackColor = true;
            this.btn_7.Click += new System.EventHandler(this.btn_7_Click);
            // 
            // btn_3
            // 
            this.btn_3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_3.Location = new System.Drawing.Point(179, 211);
            this.btn_3.Name = "btn_3";
            this.btn_3.Size = new System.Drawing.Size(82, 46);
            this.btn_3.TabIndex = 5;
            this.btn_3.Text = "3";
            this.btn_3.UseVisualStyleBackColor = true;
            this.btn_3.Click += new System.EventHandler(this.btn_3_Click);
            // 
            // btn_8
            // 
            this.btn_8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_8.Location = new System.Drawing.Point(91, 107);
            this.btn_8.Name = "btn_8";
            this.btn_8.Size = new System.Drawing.Size(82, 46);
            this.btn_8.TabIndex = 10;
            this.btn_8.Text = "8";
            this.btn_8.UseVisualStyleBackColor = true;
            this.btn_8.Click += new System.EventHandler(this.btn_8_Click);
            // 
            // btn_6
            // 
            this.btn_6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_6.Location = new System.Drawing.Point(179, 159);
            this.btn_6.Name = "btn_6";
            this.btn_6.Size = new System.Drawing.Size(82, 46);
            this.btn_6.TabIndex = 8;
            this.btn_6.Text = "6";
            this.btn_6.UseVisualStyleBackColor = true;
            this.btn_6.Click += new System.EventHandler(this.btn_6_Click);
            // 
            // btn_4
            // 
            this.btn_4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_4.Location = new System.Drawing.Point(3, 159);
            this.btn_4.Name = "btn_4";
            this.btn_4.Size = new System.Drawing.Size(82, 46);
            this.btn_4.TabIndex = 6;
            this.btn_4.Text = "4";
            this.btn_4.UseVisualStyleBackColor = true;
            this.btn_4.Click += new System.EventHandler(this.btn_4_Click);
            // 
            // btn_9
            // 
            this.btn_9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_9.Location = new System.Drawing.Point(179, 107);
            this.btn_9.Name = "btn_9";
            this.btn_9.Size = new System.Drawing.Size(82, 46);
            this.btn_9.TabIndex = 11;
            this.btn_9.Text = "9";
            this.btn_9.UseVisualStyleBackColor = true;
            this.btn_9.Click += new System.EventHandler(this.btn_9_Click);
            // 
            // btn_5
            // 
            this.btn_5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_5.Location = new System.Drawing.Point(91, 159);
            this.btn_5.Name = "btn_5";
            this.btn_5.Size = new System.Drawing.Size(82, 46);
            this.btn_5.TabIndex = 7;
            this.btn_5.Text = "5";
            this.btn_5.UseVisualStyleBackColor = true;
            this.btn_5.Click += new System.EventHandler(this.btn_5_Click);
            // 
            // btn_divide
            // 
            this.btn_divide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_divide.Location = new System.Drawing.Point(267, 55);
            this.btn_divide.Name = "btn_divide";
            this.btn_divide.Size = new System.Drawing.Size(83, 46);
            this.btn_divide.TabIndex = 18;
            this.btn_divide.Text = "÷";
            this.btn_divide.UseVisualStyleBackColor = true;
            this.btn_divide.Click += new System.EventHandler(this.btn_divide_Click);
            // 
            // btn_multiply
            // 
            this.btn_multiply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_multiply.Location = new System.Drawing.Point(267, 107);
            this.btn_multiply.Name = "btn_multiply";
            this.btn_multiply.Size = new System.Drawing.Size(83, 46);
            this.btn_multiply.TabIndex = 19;
            this.btn_multiply.Text = "×";
            this.btn_multiply.UseVisualStyleBackColor = true;
            this.btn_multiply.Click += new System.EventHandler(this.btn_multiply_Click);
            // 
            // btn_bspace
            // 
            this.btn_bspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_bspace.Location = new System.Drawing.Point(267, 3);
            this.btn_bspace.Name = "btn_bspace";
            this.btn_bspace.Size = new System.Drawing.Size(83, 46);
            this.btn_bspace.TabIndex = 17;
            this.btn_bspace.Text = "←";
            this.btn_bspace.UseVisualStyleBackColor = true;
            this.btn_bspace.Click += new System.EventHandler(this.btn_bspace_Click);
            // 
            // btn_Result
            // 
            this.btn_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Result.Location = new System.Drawing.Point(267, 263);
            this.btn_Result.Name = "btn_Result";
            this.btn_Result.Size = new System.Drawing.Size(83, 46);
            this.btn_Result.TabIndex = 21;
            this.btn_Result.Text = "=";
            this.btn_Result.UseVisualStyleBackColor = true;
            this.btn_Result.Click += new System.EventHandler(this.btn_Result_Click);
            // 
            // btn_SQR
            // 
            this.btn_SQR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SQR.Location = new System.Drawing.Point(91, 55);
            this.btn_SQR.Name = "btn_SQR";
            this.btn_SQR.Size = new System.Drawing.Size(82, 46);
            this.btn_SQR.TabIndex = 22;
            this.btn_SQR.Text = "x^2";
            this.btn_SQR.UseVisualStyleBackColor = true;
            // 
            // btn_SQRT
            // 
            this.btn_SQRT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SQRT.Location = new System.Drawing.Point(179, 55);
            this.btn_SQRT.Name = "btn_SQRT";
            this.btn_SQRT.Size = new System.Drawing.Size(82, 46);
            this.btn_SQRT.TabIndex = 23;
            this.btn_SQRT.Text = "√";
            this.btn_SQRT.UseVisualStyleBackColor = true;
            this.btn_SQRT.Click += new System.EventHandler(this.btn_SQRT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 454);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(230, 390);
            this.Name = "Form1";
            this.Text = "Калькулятор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_plus;
        private System.Windows.Forms.Button btn_minus;
        private System.Windows.Forms.Button btn_Negative;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_Coma;
        private System.Windows.Forms.Button btn_1;
        private System.Windows.Forms.Button btn_Zero;
        private System.Windows.Forms.Button btn_2;
        private System.Windows.Forms.Button btn_7;
        private System.Windows.Forms.Button btn_3;
        private System.Windows.Forms.Button btn_8;
        private System.Windows.Forms.Button btn_6;
        private System.Windows.Forms.Button btn_4;
        private System.Windows.Forms.Button btn_9;
        private System.Windows.Forms.Button btn_5;
        private System.Windows.Forms.Button btn_divide;
        private System.Windows.Forms.Button btn_multiply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_bspace;
        private System.Windows.Forms.Button btn_Result;
        private System.Windows.Forms.Button btn_SQR;
        private System.Windows.Forms.Button btn_SQRT;
    }
}

