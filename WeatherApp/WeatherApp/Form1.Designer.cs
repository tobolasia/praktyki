namespace WeatherApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGetWeather = new Button();
            lblResult = new Label();
            txtCity = new TextBox();
            SuspendLayout();
            // 
            // btnGetWeather
            // 
            btnGetWeather.Location = new Point(80, 110);
            btnGetWeather.Name = "btnGetWeather";
            btnGetWeather.Size = new Size(94, 29);
            btnGetWeather.TabIndex = 0;
            btnGetWeather.Text = "Sprawdz";
            btnGetWeather.UseVisualStyleBackColor = true;
            btnGetWeather.Click += btnGetWeather_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(80, 171);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(60, 20);
            lblResult.TabIndex = 1;
            lblResult.Text = "Pogoda";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(80, 56);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(125, 27);
            txtCity.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtCity);
            Controls.Add(lblResult);
            Controls.Add(btnGetWeather);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGetWeather;
        private Label lblResult;
        private TextBox txtCity;
    }
}
