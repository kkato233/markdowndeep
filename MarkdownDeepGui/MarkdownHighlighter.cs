//=========================================================
using System;
using System.Collections.Generic;
using Sgry.Azuki;
using System.Linq;
using System.Drawing;

namespace MarkdownDeepGui
{
    using CC = CharClass;
    using System.Text.RegularExpressions;
    using Sgry.Azuki.Highlighter;
    using MarkdownDeep;
    using System.Text;

	/// <summary>
	/// A highlighter to highlight LaTeX.
	/// </summary>
    class MarkdownHighlighter : IHighlighter
	{
        public MarkdownHighlighter(Sgry.Azuki.Document doc) 
        {
            int begin = 0;
            int end = doc.Length;
            Highlight(doc, ref begin, ref end);
        }

        public class ColorSchemeExtention
        {
            public byte Key;
            public MarkdownDeep.BlockType BlockType;
            public MarkdownDeep.TokenType TokenType;
            public Color ForeColor;
            public Color BackColor;
        }

        public class ColorScheme2
        {
            public MarkdownDeep.BlockType BlockType;
            public MarkdownDeep.TokenType TokenType;
            public Color ForeColor;
            public Color BackColor;
        }

        int markDownSchemeBegin = 128;

        public List<ColorScheme2> GetColorScheme()
        {
            List<ColorScheme2> list = new List<ColorScheme2>()
            {
                new ColorScheme2() {
                    BlockType = MarkdownDeep.BlockType.h2,
                    ForeColor = System.Drawing.Color.Red,
                    BackColor = System.Drawing.Color.White,
                },
                new ColorScheme2() {
                    BlockType = MarkdownDeep.BlockType.hr,
                    ForeColor = System.Drawing.Color.Green,
                    BackColor = System.Drawing.Color.Brown,
                },
                new ColorScheme2() {
                    TokenType = MarkdownDeep.TokenType.open_strong,
                    ForeColor = System.Drawing.Color.Green,
                    BackColor = System.Drawing.Color.Brown,
                },

            };

            return list;
            
        }

        public List<ColorSchemeExtention> GetColorSchemExtentions()
        {
            List<ColorSchemeExtention> ans = new List<ColorSchemeExtention>();
            int n = markDownSchemeBegin;
            foreach (var item in GetColorScheme())
            {
                ColorSchemeExtention scheme = new ColorSchemeExtention()
                {
                    Key = (byte)n,
                    BlockType = item.BlockType,
                    TokenType = item.TokenType,
                    ForeColor = item.ForeColor,
                    BackColor = item.BackColor,
                };

                ans.Add(scheme);
                n++;
            }

            return ans;
        }

        MarkdownDeep.Markdown m_Markdown = new MarkdownDeep.Markdown();

        public void Highlight(Document doc, ref int dirtyBegin, ref int dirtyEnd)
        {
            if (dirtyBegin < 0 || doc.Length < dirtyBegin)
                throw new ArgumentOutOfRangeException("dirtyBegin");
            if (dirtyEnd < 0 || doc.Length < dirtyEnd)
                throw new ArgumentOutOfRangeException("dirtyEnd");

            int minPos = dirtyBegin;
            int maxPos = dirtyEnd;

            string text = doc.GetTextInRange(0, doc.Length);

            var blocks = m_Markdown.ProcessBlocks(text);

            for (int i = 0; i < doc.Length; i++)
            {
                doc.SetCharClass(i, CC.Normal);
            }

            // マークダウンによる解析を行いその結果を反映させる。
            byte[] data = new byte[text.Length];

            var schemaDic = this.GetColorSchemExtentions()
                .Where(r => r.BlockType != BlockType.Blank)
                .ToDictionary(r => r.BlockType);

            var schemaTokenDic = this.GetColorSchemExtentions()
                .Where(r => r.TokenType != TokenType.Text)
                .ToDictionary(r => r.TokenType);

            foreach (var items in blocks)
            {
                int begin = items.LineStart;
                int end = Math.Min(text.Length, items.LineStart + items.LineLength);
                ColorSchemeExtention bScheme;
                byte bType = 0;

                bool skipContents = false;

                if (items.BlockType == BlockType.html)
                {
                    Sgry.Azuki.Highlighter.Highlighters.Xml.Highlight(doc, ref begin, ref end);
                    skipContents = true;
                }
                else if (items.BlockType == BlockType.codeblock)
                {
                    Sgry.Azuki.Highlighter.Highlighters.CSharp.Highlight(doc, ref begin, ref end);
                    skipContents = true;
                }
                else if (schemaDic.TryGetValue(items.BlockType, out bScheme))
                {
                    bType = (byte)bScheme.Key;
                    for (int i = begin; i < end; i++)
                    {
                        data[i] = bType;
                        doc.SetCharClass(i, (CC)bType);
                    }
                }
                
                // Spanの要素を描画
                if (skipContents == false)
                {
                    StringBuilder sb = new StringBuilder();
                    
                    // Span の描画
                    items.Render(this.m_Markdown, sb);

                    var list = items.GetRenderPositionList();

                    // 開始と終了があるもの
                    foreach (var t in list)
                    {
                        begin = t.Start;
                        end = Math.Min(text.Length, t.Start + t.Len);
                        
                        // 終了位置の補正
                        if (t.TokenType == TokenType.opening_mark)
                        {
                            var endT = findNextToken(list, t, TokenType.closing_mark);
                            if (endT != null)
                            {
                                end = Math.Min(text.Length, endT.Start + endT.Len);
                            }
                        }
                        else if (t.TokenType == TokenType.open_em)
                        {
                            var endT = findNextToken(list, t, TokenType.close_em);
                            if (endT != null)
                            {
                                end = Math.Min(text.Length, endT.Start + endT.Len);
                            }
                        }
                        else if (t.TokenType == TokenType.open_strong)
                        {
                            var endT = findNextToken(list, t, TokenType.close_strong);
                            if (endT != null)
                            {
                                end = Math.Min(text.Length, endT.Start + endT.Len);
                            }
                        }
                        
                        if (schemaTokenDic.TryGetValue(t.TokenType, out bScheme))
                        {
                            bType = (byte)bScheme.Key;
                            for (int i = begin; i < end; i++)
                            {
                                data[i] = bType;
                                doc.SetCharClass(i, (CC)bType);
                            }
                        }
                    }
                }
            }
            
            dirtyBegin = 0;
            dirtyEnd = text.Length -1;

            return;
        }

        private RenderPosition findNextToken(List<RenderPosition> list, RenderPosition t, TokenType tokenType)
        {
            int startPos = list.IndexOf(t);
            var item = list.Skip(startPos + 1).Where(r => r.TokenType == tokenType).FirstOrDefault();
            return item;
        }

        /// <summary>
        /// この2つの数字に交わりがあるか調査する
        /// </summary>
        /// <param name="dirtyBegin"></param>
        /// <param name="dirtyEnd"></param>
        /// <param name="selectionStartIndex"></param>
        /// <param name="selectEndPos"></param>
        /// <returns></returns>
        private bool InSet(int dirtyBegin, int dirtyEnd, int selectionStartIndex, int selectEndPos)
        {
#if DEBUG
            if (dirtyEnd < dirtyBegin) throw new InvalidOperationException("");
            if (selectEndPos < selectionStartIndex) throw new InvalidOperationException("");
#endif
            if (selectEndPos < dirtyBegin) return false;
            if (selectEndPos < dirtyBegin) return false;

            return true;
        }

        public ColorScheme MarkDownColorScheme
        {
            get
            {
                if (_scheme == null)
                {
                    ColorScheme sc = new ColorScheme(ColorScheme.Default);
                    foreach (var item in GetColorSchemExtentions())
                    {
                        sc.SetColor((CharClass)item.Key, item.ForeColor, item.BackColor);
                    }
                    // テキストの色
                    sc.SetColor(CC.Normal, System.Drawing.Color.Black, System.Drawing.Color.White);
                    _scheme = sc;
                }

                return _scheme;
            }
        }
        ColorScheme _scheme;

        public bool CanUseHook
        {
            get { return false; }
        }

        public void Highlight(Document doc)
        {
            throw new NotImplementedException();
        }

        public HighlightHook HookProc
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
