namespace MatrixInverse
{
    partial class MatrixInverse
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatrixInverse));
            this.MatrixDimension = new System.Windows.Forms.NumericUpDown();
            this.MatrixDimensionLable = new System.Windows.Forms.Label();
            this.MatrixPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ValuesLable = new System.Windows.Forms.Label();
            this.BorderingButton = new System.Windows.Forms.RadioButton();
            this.JordanGaussButton = new System.Windows.Forms.RadioButton();
            this.CalculationButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.MethodLabel = new System.Windows.Forms.Label();
            this.YourMatrixLabel = new System.Windows.Forms.Label();
            this.TextLable = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SaveToFileButton = new System.Windows.Forms.Button();
            this.RandomMatrixButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixDimension)).BeginInit();
            this.SuspendLayout();
            // 
            // MatrixDimension
            // 
            resources.ApplyResources(this.MatrixDimension, "MatrixDimension");
            this.MatrixDimension.Name = "MatrixDimension";
            this.MatrixDimension.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MatrixDimension.ValueChanged += new System.EventHandler(this.MatrixDimension_ValueChanged);
            // 
            // MatrixDimensionLable
            // 
            resources.ApplyResources(this.MatrixDimensionLable, "MatrixDimensionLable");
            this.MatrixDimensionLable.Name = "MatrixDimensionLable";
            // 
            // MatrixPanel
            // 
            resources.ApplyResources(this.MatrixPanel, "MatrixPanel");
            this.MatrixPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MatrixPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.MatrixPanel.Name = "MatrixPanel";
            // 
            // ValuesLable
            // 
            resources.ApplyResources(this.ValuesLable, "ValuesLable");
            this.ValuesLable.Name = "ValuesLable";
            // 
            // BorderingButton
            // 
            resources.ApplyResources(this.BorderingButton, "BorderingButton");
            this.BorderingButton.Name = "BorderingButton";
            this.BorderingButton.TabStop = true;
            this.BorderingButton.UseVisualStyleBackColor = true;
            // 
            // JordanGaussButton
            // 
            resources.ApplyResources(this.JordanGaussButton, "JordanGaussButton");
            this.JordanGaussButton.Name = "JordanGaussButton";
            this.JordanGaussButton.TabStop = true;
            this.JordanGaussButton.UseVisualStyleBackColor = true;
            // 
            // CalculationButton
            // 
            this.CalculationButton.BackColor = System.Drawing.Color.CornflowerBlue;
            resources.ApplyResources(this.CalculationButton, "CalculationButton");
            this.CalculationButton.Name = "CalculationButton";
            this.CalculationButton.UseVisualStyleBackColor = false;
            this.CalculationButton.Click += new System.EventHandler(this.CalculationButton_Click);
            // 
            // ClearButton
            // 
            resources.ApplyResources(this.ClearButton, "ClearButton");
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MethodLabel
            // 
            resources.ApplyResources(this.MethodLabel, "MethodLabel");
            this.MethodLabel.Name = "MethodLabel";
            // 
            // YourMatrixLabel
            // 
            resources.ApplyResources(this.YourMatrixLabel, "YourMatrixLabel");
            this.YourMatrixLabel.Name = "YourMatrixLabel";
            // 
            // TextLable
            // 
            resources.ApplyResources(this.TextLable, "TextLable");
            this.TextLable.Name = "TextLable";
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            // 
            // SaveToFileButton
            // 
            resources.ApplyResources(this.SaveToFileButton, "SaveToFileButton");
            this.SaveToFileButton.Name = "SaveToFileButton";
            this.SaveToFileButton.UseVisualStyleBackColor = true;
            this.SaveToFileButton.Click += new System.EventHandler(this.SaveToFileButton_Click);
            // 
            // RandomMatrixButton
            // 
            resources.ApplyResources(this.RandomMatrixButton, "RandomMatrixButton");
            this.RandomMatrixButton.Name = "RandomMatrixButton";
            this.RandomMatrixButton.UseVisualStyleBackColor = true;
            this.RandomMatrixButton.Click += new System.EventHandler(this.RandomMatrixButton_Click);
            // 
            // MatrixInverse
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RandomMatrixButton);
            this.Controls.Add(this.SaveToFileButton);
            this.Controls.Add(this.TextLable);
            this.Controls.Add(this.YourMatrixLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ValuesLable);
            this.Controls.Add(this.MethodLabel);
            this.Controls.Add(this.MatrixPanel);
            this.Controls.Add(this.MatrixDimensionLable);
            this.Controls.Add(this.MatrixDimension);
            this.Controls.Add(this.CalculationButton);
            this.Controls.Add(this.BorderingButton);
            this.Controls.Add(this.JordanGaussButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MatrixInverse";
            ((System.ComponentModel.ISupportInitialize)(this.MatrixDimension)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown MatrixDimension;
        private System.Windows.Forms.Label MatrixDimensionLable;
        private System.Windows.Forms.MessageBox messageBox1;
        private System.Windows.Forms.TableLayoutPanel MatrixPanel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label ValuesLable;
        private System.Windows.Forms.Button CalculationButton;
        private System.Windows.Forms.RadioButton BorderingButton;
        private System.Windows.Forms.RadioButton JordanGaussButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label MethodLabel;
        private System.Windows.Forms.Label YourMatrixLabel;
        private System.Windows.Forms.Label TextLable;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button SaveToFileButton;
        private System.Windows.Forms.Button RandomMatrixButton;
    }
}

