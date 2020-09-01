namespace VisionCS
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonVision = new System.Windows.Forms.Button();
            this.ButtonLoadImage = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.Label_message = new System.Windows.Forms.Label();
            this.PictureBoxMain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonVision
            // 
            this.ButtonVision.Location = new System.Drawing.Point(134, 324);
            this.ButtonVision.Name = "ButtonVision";
            this.ButtonVision.Size = new System.Drawing.Size(186, 77);
            this.ButtonVision.TabIndex = 0;
            this.ButtonVision.Text = "히스토그램 평활화";
            this.ButtonVision.UseVisualStyleBackColor = true;
            this.ButtonVision.Click += new System.EventHandler(this.ButtonVision_Click);
            // 
            // ButtonLoadImage
            // 
            this.ButtonLoadImage.Location = new System.Drawing.Point(326, 324);
            this.ButtonLoadImage.Name = "ButtonLoadImage";
            this.ButtonLoadImage.Size = new System.Drawing.Size(183, 37);
            this.ButtonLoadImage.TabIndex = 1;
            this.ButtonLoadImage.Text = "이미지 읽어오기";
            this.ButtonLoadImage.UseVisualStyleBackColor = true;
            this.ButtonLoadImage.Click += new System.EventHandler(this.ButtonLoadImage_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(326, 367);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(183, 34);
            this.ButtonClose.TabIndex = 2;
            this.ButtonClose.Text = "종료";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // Label_message
            // 
            this.Label_message.AutoSize = true;
            this.Label_message.Location = new System.Drawing.Point(12, 324);
            this.Label_message.Name = "Label_message";
            this.Label_message.Size = new System.Drawing.Size(45, 15);
            this.Label_message.TabIndex = 3;
            this.Label_message.Text = "label1";
            // 
            // PictureBoxMain
            // 
            this.PictureBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBoxMain.Location = new System.Drawing.Point(15, 12);
            this.PictureBoxMain.Name = "PictureBoxMain";
            this.PictureBoxMain.Size = new System.Drawing.Size(494, 306);
            this.PictureBoxMain.TabIndex = 4;
            this.PictureBoxMain.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 407);
            this.Controls.Add(this.PictureBoxMain);
            this.Controls.Add(this.Label_message);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonLoadImage);
            this.Controls.Add(this.ButtonVision);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonVision;
        private System.Windows.Forms.Button ButtonLoadImage;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Label Label_message;
        private System.Windows.Forms.PictureBox PictureBoxMain;
    }
}

