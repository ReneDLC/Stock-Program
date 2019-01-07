namespace RatesProgram
{
    partial class Application
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currencyPairListBox = new System.Windows.Forms.ListBox();
            this.selectedCurrencyPairLabel = new System.Windows.Forms.Label();
            this.selectedCurrencyPairTextBox = new System.Windows.Forms.TextBox();
            this.targetRateLabel = new System.Windows.Forms.Label();
            this.desiredTargetRateTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.startButtonLabel = new System.Windows.Forms.Label();
            this.pairAttributesTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // currencyPairListBox
            // 
            this.currencyPairListBox.FormattingEnabled = true;
            this.currencyPairListBox.ItemHeight = 16;
            this.currencyPairListBox.Location = new System.Drawing.Point(225, 10);
            this.currencyPairListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.currencyPairListBox.Name = "currencyPairListBox";
            this.currencyPairListBox.Size = new System.Drawing.Size(179, 564);
            this.currencyPairListBox.TabIndex = 0;
            this.currencyPairListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChange);
            // 
            // selectedCurrencyPairLabel
            // 
            this.selectedCurrencyPairLabel.AutoSize = true;
            this.selectedCurrencyPairLabel.Location = new System.Drawing.Point(8, 10);
            this.selectedCurrencyPairLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectedCurrencyPairLabel.Name = "selectedCurrencyPairLabel";
            this.selectedCurrencyPairLabel.Size = new System.Drawing.Size(150, 17);
            this.selectedCurrencyPairLabel.TabIndex = 1;
            this.selectedCurrencyPairLabel.Text = "Select a currency pair:";
            // 
            // selectedCurrencyPairTextBox
            // 
            this.selectedCurrencyPairTextBox.Location = new System.Drawing.Point(11, 28);
            this.selectedCurrencyPairTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectedCurrencyPairTextBox.Name = "selectedCurrencyPairTextBox";
            this.selectedCurrencyPairTextBox.ReadOnly = true;
            this.selectedCurrencyPairTextBox.Size = new System.Drawing.Size(187, 22);
            this.selectedCurrencyPairTextBox.TabIndex = 2;
            // 
            // targetRateLabel
            // 
            this.targetRateLabel.AutoSize = true;
            this.targetRateLabel.Location = new System.Drawing.Point(8, 65);
            this.targetRateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.targetRateLabel.Name = "targetRateLabel";
            this.targetRateLabel.Size = new System.Drawing.Size(129, 17);
            this.targetRateLabel.TabIndex = 3;
            this.targetRateLabel.Text = "Type in target rate:";
            // 
            // desiredTargetRateTextBox
            // 
            this.desiredTargetRateTextBox.Location = new System.Drawing.Point(11, 83);
            this.desiredTargetRateTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.desiredTargetRateTextBox.Name = "desiredTargetRateTextBox";
            this.desiredTargetRateTextBox.Size = new System.Drawing.Size(187, 22);
            this.desiredTargetRateTextBox.TabIndex = 4;
            this.desiredTargetRateTextBox.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(11, 139);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(185, 33);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // startButtonLabel
            // 
            this.startButtonLabel.AutoSize = true;
            this.startButtonLabel.Location = new System.Drawing.Point(8, 121);
            this.startButtonLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.startButtonLabel.Name = "startButtonLabel";
            this.startButtonLabel.Size = new System.Drawing.Size(99, 17);
            this.startButtonLabel.TabIndex = 6;
            this.startButtonLabel.Text = "Start program:";
            // 
            // pairAttributesTextBox
            // 
            this.pairAttributesTextBox.Location = new System.Drawing.Point(11, 195);
            this.pairAttributesTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pairAttributesTextBox.Multiline = true;
            this.pairAttributesTextBox.Name = "pairAttributesTextBox";
            this.pairAttributesTextBox.ReadOnly = true;
            this.pairAttributesTextBox.Size = new System.Drawing.Size(187, 379);
            this.pairAttributesTextBox.TabIndex = 7;
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 580);
            this.Controls.Add(this.pairAttributesTextBox);
            this.Controls.Add(this.startButtonLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.desiredTargetRateTextBox);
            this.Controls.Add(this.targetRateLabel);
            this.Controls.Add(this.selectedCurrencyPairTextBox);
            this.Controls.Add(this.selectedCurrencyPairLabel);
            this.Controls.Add(this.currencyPairListBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Application";
            this.Text = "Rate Notification";
            this.Load += new System.EventHandler(this.Application_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox currencyPairListBox;
        private System.Windows.Forms.Label selectedCurrencyPairLabel;
        private System.Windows.Forms.TextBox selectedCurrencyPairTextBox;
        private System.Windows.Forms.Label targetRateLabel;
        private System.Windows.Forms.TextBox desiredTargetRateTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label startButtonLabel;
        private System.Windows.Forms.TextBox pairAttributesTextBox;
    }
}

