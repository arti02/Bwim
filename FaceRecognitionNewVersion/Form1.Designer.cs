
namespace FaceRecognitionNewVersion
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
			this.components = new System.ComponentModel.Container();
			this.start = new System.Windows.Forms.Button();
			this.imageBox1 = new Emgu.CV.UI.ImageBox();
			this.CameraBox = new Emgu.CV.UI.ImageBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.textName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CameraBox)).BeginInit();
			this.SuspendLayout();
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(635, 12);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(153, 41);
			this.start.TabIndex = 3;
			this.start.Text = "Start Detection and Recogniton";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.button1_Click);
			// 
			// imageBox1
			// 
			this.imageBox1.Location = new System.Drawing.Point(0, 0);
			this.imageBox1.Name = "imageBox1";
			this.imageBox1.Size = new System.Drawing.Size(0, 0);
			this.imageBox1.TabIndex = 2;
			this.imageBox1.TabStop = false;
			// 
			// CameraBox
			// 
			this.CameraBox.Location = new System.Drawing.Point(29, 12);
			this.CameraBox.Name = "CameraBox";
			this.CameraBox.Size = new System.Drawing.Size(545, 323);
			this.CameraBox.TabIndex = 2;
			this.CameraBox.TabStop = false;
			this.CameraBox.Click += new System.EventHandler(this.imageBox2_Click);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(635, 146);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(153, 39);
			this.saveButton.TabIndex = 4;
			this.saveButton.Text = "Save Face";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// textName
			// 
			this.textName.Location = new System.Drawing.Point(635, 78);
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(138, 20);
			this.textName.TabIndex = 5;
			this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(594, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Name";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textName);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.CameraBox);
			this.Controls.Add(this.imageBox1);
			this.Controls.Add(this.start);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CameraBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button start;
		private Emgu.CV.UI.ImageBox imageBox1;
		private Emgu.CV.UI.ImageBox CameraBox;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.Label label1;
	}
}

