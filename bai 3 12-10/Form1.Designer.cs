namespace bai_3_12_10
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
            components = new System.ComponentModel.Container();
            btnStartTask = new Button();
            progressBar1 = new ProgressBar();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar = new ToolStripProgressBar();
            lblStatus = new Label();
            lblElapsedTime = new Label();
            SuspendLayout();

            // btnStartTask
            btnStartTask.Location = new Point(50, 50);
            btnStartTask.Name = "btnStartTask";
            btnStartTask.Size = new Size(150, 40);
            btnStartTask.TabIndex = 0;
            btnStartTask.Text = "Bắt đầu tác vụ";
            btnStartTask.UseVisualStyleBackColor = true;
            btnStartTask.Click += BtnStartTask_Click;

            // progressBar1
            progressBar1.Location = new Point(50, 120);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(700, 40);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 1;

            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(50, 170);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Trạng thái: Sẵn sàng";

            // lblElapsedTime
            lblElapsedTime.AutoSize = true;
            lblElapsedTime.Location = new Point(50, 200);
            lblElapsedTime.Name = "lblElapsedTime";
            lblElapsedTime.Size = new Size(100, 20);
            lblElapsedTime.TabIndex = 3;
            lblElapsedTime.Text = "Thời gian: 0ms";

            // statusStrip1
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar });
            statusStrip1.Location = new Point(0, 420);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 30);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";

            // toolStripStatusLabel1
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(630, 25);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "Sẵn sàng";
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;

            // toolStripProgressBar
            toolStripProgressBar.AutoSize = false;
            toolStripProgressBar.Name = "toolStripProgressBar";
            toolStripProgressBar.Size = new Size(150, 20);
            toolStripProgressBar.Style = ProgressBarStyle.Continuous;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(lblElapsedTime);
            Controls.Add(lblStatus);
            Controls.Add(progressBar1);
            Controls.Add(btnStartTask);
            Name = "Form1";
            Text = "Async/Await & ProgressBar Demo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartTask;
        private ProgressBar progressBar1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar toolStripProgressBar;
        private Label lblStatus;
        private Label lblElapsedTime;
    }
}
