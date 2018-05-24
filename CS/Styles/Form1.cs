using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#region #usings
using DevExpress.XtraRichEdit.API.Native;
#endregion #usings

namespace Styles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            richEditControl1.LoadDocument("Styles.docx");
        }



private void btnCharacterStyle_Click(object sender, EventArgs e)
{
    #region #cstyle
    CharacterStyle cStyle = richEditControl1.Document.CharacterStyles["MyCharStyle"];
    if (cStyle == null)
    {
        cStyle = richEditControl1.Document.CharacterStyles.CreateNew();
        cStyle.Name = "MyCharStyle";
        cStyle.Parent = richEditControl1.Document.CharacterStyles["Default Paragraph Font"];
        cStyle.ForeColor = Color.DarkOrange;
        cStyle.Strikeout = StrikeoutType.Double;
        cStyle.FontName = "Verdana";
        richEditControl1.Document.CharacterStyles.Add(cStyle);
    }
    DocumentRange r = richEditControl1.Document.Selection;
    CharacterProperties charProps =
        richEditControl1.Document.BeginUpdateCharacters(r);
    charProps.Style = cStyle;
    richEditControl1.Document.EndUpdateCharacters(charProps);
    #endregion #cstyle
}

private void btnParagraphStyle_Click(object sender, EventArgs e)
{
    #region #pstyle
    ParagraphStyle pStyle = richEditControl1.Document.ParagraphStyles["MyParStyle"];
    if (pStyle == null)
    {
        pStyle = richEditControl1.Document.ParagraphStyles.CreateNew();
        pStyle.Name = "MyParStyle";
        pStyle.LineSpacingType = ParagraphLineSpacing.Double;
        pStyle.Alignment = ParagraphAlignment.Center;
        richEditControl1.Document.ParagraphStyles.Add(pStyle);
    }
    DocumentRange r = richEditControl1.Document.Selection;
    ParagraphProperties parProps =
        richEditControl1.Document.BeginUpdateParagraphs(r);
    parProps.Style = pStyle;
    richEditControl1.Document.EndUpdateParagraphs(parProps);
    #endregion #pstyle
}

private void btnLinkedStyle_Click(object sender, EventArgs e)
{
    #region #lstyle
    ParagraphStyle linkedStyle = richEditControl1.Document.ParagraphStyles["MyLinkedParStyle"];
    if (linkedStyle == null)
    {
        linkedStyle = richEditControl1.Document.ParagraphStyles.CreateNew();
        linkedStyle.Name = "MyLinkedParStyle";
        linkedStyle.LineSpacingType = ParagraphLineSpacing.Single;
        linkedStyle.Alignment = ParagraphAlignment.Justify;
        richEditControl1.Document.ParagraphStyles.Add(linkedStyle);
    }
    CharacterStyle lcstyle = richEditControl1.Document.CharacterStyles.CreateNew();
    lcstyle.Name = "MyLinkedCharStyle";
    richEditControl1.Document.CharacterStyles.Add(lcstyle);
    lcstyle.LinkedStyle = linkedStyle;

    lcstyle.ForeColor = Color.DarkGreen;
    lcstyle.Strikeout = StrikeoutType.Single;
    lcstyle.FontSize = 24;
    #endregion #lstyle
}
}
}