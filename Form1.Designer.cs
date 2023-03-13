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
            pictureBox1 = new PictureBox();
            locationLabel = new Label();
            temperatureLabel = new Label();
            NetworkLoadingCircle = new PictureBox();
            humidityLabel = new Label();
            humidityPrecentLabel = new Label();
            descriptionLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NetworkLoadingCircle).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(90, 107);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // locationLabel
            // 
            locationLabel.Anchor = AnchorStyles.None;
            locationLabel.AutoSize = true;
            locationLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            locationLabel.Location = new Point(209, 44);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(125, 37);
            locationLabel.TabIndex = 1;
            locationLabel.Text = "Location:";
            locationLabel.TextAlign = ContentAlignment.MiddleCenter;
            locationLabel.Click += label1_Click;
            // 
            // temperatureLabel
            // 
            temperatureLabel.AutoSize = true;
            temperatureLabel.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            temperatureLabel.Location = new Point(207, 112);
            temperatureLabel.Name = "temperatureLabel";
            temperatureLabel.Size = new Size(63, 54);
            temperatureLabel.TabIndex = 2;
            temperatureLabel.Text = "℃";
            temperatureLabel.Click += label2_Click;
            // 
            // NetworkLoadingCircle
            // 
            NetworkLoadingCircle.Location = new Point(211, 117);
            NetworkLoadingCircle.Name = "NetworkLoadingCircle";
            NetworkLoadingCircle.Size = new Size(120, 120);
            NetworkLoadingCircle.SizeMode = PictureBoxSizeMode.StretchImage;
            NetworkLoadingCircle.TabIndex = 3;
            NetworkLoadingCircle.TabStop = false;
            // 
            // humidityLabel
            // 
            humidityLabel.AutoSize = true;
            humidityLabel.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            humidityLabel.Location = new Point(312, 124);
            humidityLabel.Name = "humidityLabel";
            humidityLabel.Size = new Size(113, 31);
            humidityLabel.TabIndex = 4;
            humidityLabel.Text = "Humidity:";
            humidityLabel.Click += label1_Click_1;
            // 
            // humidityPrecentLabel
            // 
            humidityPrecentLabel.AutoSize = true;
            humidityPrecentLabel.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            humidityPrecentLabel.Location = new Point(444, 112);
            humidityPrecentLabel.Name = "humidityPrecentLabel";
            humidityPrecentLabel.Size = new Size(56, 54);
            humidityPrecentLabel.TabIndex = 5;
            humidityPrecentLabel.Text = "%";
            humidityPrecentLabel.Click += label2_Click_1;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            descriptionLabel.Location = new Point(80, 176);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(0, 31);
            descriptionLabel.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(542, 355);
            Controls.Add(descriptionLabel);
            Controls.Add(humidityPrecentLabel);
            Controls.Add(humidityLabel);
            Controls.Add(temperatureLabel);
            Controls.Add(locationLabel);
            Controls.Add(pictureBox1);
            Controls.Add(NetworkLoadingCircle);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)NetworkLoadingCircle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label locationLabel;
        private Label temperatureLabel;
        private PictureBox NetworkLoadingCircle;
        private Label humidityLabel;
        private Label humidityPrecentLabel;
        private Label descriptionLabel;
    }
}