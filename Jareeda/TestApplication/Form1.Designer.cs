namespace TestApplication
{
    partial class Form1
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
            this.imageTest1 = new DevExpress.XtraEditors.PictureEdit();
            this.imageTest2 = new DevExpress.XtraEditors.PictureEdit();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.colorPickOld = new DevExpress.XtraEditors.ColorPickEdit();
            this.colorPickNew = new DevExpress.XtraEditors.ColorPickEdit();
            this.colorPicNotChange = new DevExpress.XtraEditors.ColorPickEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTest1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTest2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicNotChange.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageTest1
            // 
            this.imageTest1.EditValue = global::TestApplication.Properties.Resources.slider4;
            this.imageTest1.Location = new System.Drawing.Point(73, 83);
            this.imageTest1.Name = "imageTest1";
            this.imageTest1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.imageTest1.Size = new System.Drawing.Size(413, 349);
            this.imageTest1.TabIndex = 0;
            // 
            // imageTest2
            // 
            this.imageTest2.Location = new System.Drawing.Point(534, 83);
            this.imageTest2.Name = "imageTest2";
            this.imageTest2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.imageTest2.Size = new System.Drawing.Size(465, 349);
            this.imageTest2.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(414, 470);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(138, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // colorPickOld
            // 
            this.colorPickOld.EditValue = System.Drawing.Color.Empty;
            this.colorPickOld.Location = new System.Drawing.Point(71, 501);
            this.colorPickOld.Name = "colorPickOld";
            this.colorPickOld.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickOld.Size = new System.Drawing.Size(191, 20);
            this.colorPickOld.TabIndex = 3;
            // 
            // colorPickNew
            // 
            this.colorPickNew.EditValue = System.Drawing.Color.Empty;
            this.colorPickNew.Location = new System.Drawing.Point(71, 527);
            this.colorPickNew.Name = "colorPickNew";
            this.colorPickNew.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickNew.Size = new System.Drawing.Size(191, 20);
            this.colorPickNew.TabIndex = 4;
            // 
            // colorPicNotChange
            // 
            this.colorPicNotChange.EditValue = System.Drawing.Color.Empty;
            this.colorPicNotChange.Location = new System.Drawing.Point(73, 475);
            this.colorPicNotChange.Name = "colorPicNotChange";
            this.colorPicNotChange.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPicNotChange.Size = new System.Drawing.Size(191, 20);
            this.colorPicNotChange.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 713);
            this.Controls.Add(this.colorPicNotChange);
            this.Controls.Add(this.colorPickNew);
            this.Controls.Add(this.colorPickOld);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.imageTest2);
            this.Controls.Add(this.imageTest1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageTest1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTest2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicNotChange.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit imageTest1;
        private DevExpress.XtraEditors.PictureEdit imageTest2;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private DevExpress.XtraEditors.ColorPickEdit colorPickOld;
        private DevExpress.XtraEditors.ColorPickEdit colorPickNew;
        private DevExpress.XtraEditors.ColorPickEdit colorPicNotChange;
    }
}

