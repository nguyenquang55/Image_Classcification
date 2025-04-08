namespace Image_Classcification
{
    partial class fMain
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
            panel1 = new Panel();
            tbClass = new TextBox();
            label1 = new Label();
            btnClasscify = new Button();
            btnUpload = new Button();
            pbOriginal = new PictureBox();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbOriginal).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(tbClass);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnClasscify);
            panel1.Controls.Add(btnUpload);
            panel1.Controls.Add(pbOriginal);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(959, 652);
            panel1.TabIndex = 0;
            // 
            // tbClass
            // 
            tbClass.Font = new Font("Consolas", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbClass.ForeColor = Color.RoyalBlue;
            tbClass.Location = new Point(306, 577);
            tbClass.Multiline = true;
            tbClass.Name = "tbClass";
            tbClass.ReadOnly = true;
            tbClass.Size = new Size(242, 72);
            tbClass.TabIndex = 5;
            tbClass.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Consolas", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(256, 25);
            label1.Name = "label1";
            label1.Size = new Size(416, 40);
            label1.TabIndex = 4;
            label1.Text = "Image Classcification";
            label1.Click += label1_Click;
            // 
            // btnClasscify
            // 
            btnClasscify.AutoSize = true;
            btnClasscify.Font = new Font("Consolas", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClasscify.ForeColor = Color.RoyalBlue;
            btnClasscify.Location = new Point(666, 595);
            btnClasscify.Name = "btnClasscify";
            btnClasscify.Size = new Size(139, 43);
            btnClasscify.TabIndex = 3;
            btnClasscify.Text = "Classcify";
            btnClasscify.UseVisualStyleBackColor = true;
            btnClasscify.Click += btnClasscify_Click;
            // 
            // btnUpload
            // 
            btnUpload.AutoSize = true;
            btnUpload.Font = new Font("Consolas", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpload.ForeColor = Color.RoyalBlue;
            btnUpload.Location = new Point(62, 595);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(136, 43);
            btnUpload.TabIndex = 2;
            btnUpload.Text = "Up Load";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // pbOriginal
            // 
            pbOriginal.BackColor = SystemColors.ActiveBorder;
            pbOriginal.Location = new Point(0, 68);
            pbOriginal.Name = "pbOriginal";
            pbOriginal.Size = new Size(956, 489);
            pbOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pbOriginal.TabIndex = 0;
            pbOriginal.TabStop = false;
            pbOriginal.Click += pbOriginal_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Location = new Point(1013, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(260, 664);
            panel2.TabIndex = 1;
            // 
            // fMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1285, 688);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "fMain";
            Text = "Form1";
            Load += fMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbOriginal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pbOriginal;
        private Panel panel2;
        private Label label1;
        private Button btnClasscify;
        private Button btnUpload;
        private TextBox tbClass;
    }
}
