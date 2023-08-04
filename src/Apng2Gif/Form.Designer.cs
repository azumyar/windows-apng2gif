namespace Apng2Gif {
	partial class Form {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			label1 = new Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("メイリオ", 18F, FontStyle.Bold, GraphicsUnit.Point);
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(303, 36);
			label1.TabIndex = 0;
			label1.Text = "APNGをドラッグドロップ";
			label1.DragDrop += this.OnDragDrop;
			label1.DragEnter += this.OnDragEnter;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new SizeF(7F, 15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(464, 441);
			this.Controls.Add(label1);
			this.Name = "Form1";
			this.Text = "APNG変換";
			this.DragDrop += this.OnDragDrop;
			this.DragEnter += this.OnDragEnter;
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Label label1;
	}
}