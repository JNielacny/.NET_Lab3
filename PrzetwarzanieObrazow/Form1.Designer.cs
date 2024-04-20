namespace PrzetwarzanieObrazow
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
            pictureBoxLoad = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            buttonLoad = new Button();
            buttonProcess = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxLoad
            // 
            pictureBoxLoad.Location = new Point(54, 155);
            pictureBoxLoad.Name = "pictureBoxLoad";
            pictureBoxLoad.Size = new Size(230, 294);
            pictureBoxLoad.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLoad.TabIndex = 0;
            pictureBoxLoad.TabStop = false;
            pictureBoxLoad.Click += pictureBoxLoad_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(432, 325);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 294);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(668, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(230, 294);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(432, 25);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(230, 294);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(668, 325);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(230, 294);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(101, 84);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(136, 65);
            buttonLoad.TabIndex = 5;
            buttonLoad.Text = "Load Image";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonProcess
            // 
            buttonProcess.Location = new Point(290, 285);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(136, 65);
            buttonProcess.TabIndex = 6;
            buttonProcess.Text = "Process Image";
            buttonProcess.UseVisualStyleBackColor = true;
            buttonProcess.Click += buttonProcess_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 645);
            Controls.Add(buttonProcess);
            Controls.Add(buttonLoad);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBoxLoad);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxLoad;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Button buttonLoad;
        private Button buttonProcess;
    }
}
