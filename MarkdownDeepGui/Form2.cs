using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarkdownDeepGui
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void doUpdate()
        {
            this.txtSource.Text = m_Markdown.Transform(txtMarkdown.Text).Replace("\n", "\r\n");
            this.webPreview.DocumentText = this.txtSource.Text;
        }

        MarkdownDeep.Markdown m_Markdown = new MarkdownDeep.Markdown();

        private void txtMarkdown_TextChanged(object sender, EventArgs e)
        {
            doUpdate();
        }

        private void checkExtraMode_CheckedChanged(object sender, EventArgs e)
        {
            m_Markdown.ExtraMode = this.checkExtraMode.Checked;
            doUpdate();
        }

        MarkdownHighlighter highlighter;
        private void Form2_Shown(object sender, EventArgs e)
        {

            this.txtMarkdown.Text = "# Welcome to MarkdownDeep #\r\n\r\nType markdown text above, see formatted text below!";
            this.txtMarkdown.SetSelection(this.txtMarkdown.Text.Length, this.txtMarkdown.Text.Length);
            m_Markdown.ExtraMode = true;
            
            highlighter = new MarkdownHighlighter(this.txtMarkdown.Document);
            this.txtMarkdown.Highlighter = highlighter;
            this.txtMarkdown.ColorScheme = highlighter.MarkDownColorScheme;
            this.txtMarkdown.Document.EolCode = "\n";

            doUpdate();
        }

    }
}
