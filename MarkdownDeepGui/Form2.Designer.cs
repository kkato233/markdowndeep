namespace MarkdownDeepGui
{
    partial class Form2
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
            Sgry.Azuki.FontInfo fontInfo3 = new Sgry.Azuki.FontInfo();
            this.checkExtraMode = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webPreview = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtMarkdown = new MarkdownDeepGui.AzukiText();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkExtraMode
            // 
            this.checkExtraMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkExtraMode.AutoSize = true;
            this.checkExtraMode.Checked = true;
            this.checkExtraMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkExtraMode.Location = new System.Drawing.Point(81, 358);
            this.checkExtraMode.Name = "checkExtraMode";
            this.checkExtraMode.Size = new System.Drawing.Size(82, 16);
            this.checkExtraMode.TabIndex = 5;
            this.checkExtraMode.Text = "E&xtra Mode";
            this.checkExtraMode.UseVisualStyleBackColor = true;
            this.checkExtraMode.CheckedChanged += new System.EventHandler(this.checkExtraMode_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 166);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 186);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webPreview);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(465, 160);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Preview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webPreview
            // 
            this.webPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webPreview.Location = new System.Drawing.Point(0, 0);
            this.webPreview.MinimumSize = new System.Drawing.Size(20, 18);
            this.webPreview.Name = "webPreview";
            this.webPreview.Size = new System.Drawing.Size(465, 154);
            this.webPreview.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtSource);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(465, 160);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Source";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.BackColor = System.Drawing.SystemColors.Window;
            this.txtSource.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(0, 0);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSource.Size = new System.Drawing.Size(465, 162);
            this.txtSource.TabIndex = 0;
            // 
            // txtMarkdown
            // 
            this.txtMarkdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtMarkdown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMarkdown.DrawingOption = ((Sgry.Azuki.DrawingOption)(((((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace | Sgry.Azuki.DrawingOption.DrawsTab) 
            | Sgry.Azuki.DrawingOption.DrawsEol) 
            | Sgry.Azuki.DrawingOption.HighlightCurrentLine) 
            | Sgry.Azuki.DrawingOption.ShowsLineNumber) 
            | Sgry.Azuki.DrawingOption.ShowsDirtBar) 
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
            this.txtMarkdown.FirstVisibleLine = 0;
            this.txtMarkdown.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            fontInfo3.Name = "MS UI Gothic";
            fontInfo3.Size = 9;
            fontInfo3.Style = System.Drawing.FontStyle.Regular;
            this.txtMarkdown.FontInfo = fontInfo3;
            this.txtMarkdown.ForeColor = System.Drawing.Color.Black;
            this.txtMarkdown.Location = new System.Drawing.Point(4, 13);
            this.txtMarkdown.Name = "txtMarkdown";
            this.txtMarkdown.ScrollPos = new System.Drawing.Point(0, 0);
            this.txtMarkdown.Size = new System.Drawing.Size(505, 147);
            this.txtMarkdown.TabIndex = 0;
            this.txtMarkdown.ViewWidth = 4129;
            this.txtMarkdown.TextChanged += new System.EventHandler(this.txtMarkdown_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 383);
            this.Controls.Add(this.checkExtraMode);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtMarkdown);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AzukiText txtMarkdown;
        private System.Windows.Forms.CheckBox checkExtraMode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser webPreview;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtSource;
    }
}