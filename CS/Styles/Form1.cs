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



private void btnCharStyle_Click(object sender, EventArgs e)
{
    #region #cstyle
    CharacterStyle cstyle = richEditControl1.Document.CharacterStyles["MyCStyle"];
    if (cstyle == null)
    {
        cstyle = richEditControl1.Document.CharacterStyles.CreateNew();
        cstyle.Name = "MyCStyle";
        cstyle.Parent = richEditControl1.Document.CharacterStyles["Default Paragraph Font"];
        cstyle.ForeColor = Color.DarkOrange;
        cstyle.Strikeout = StrikeoutType.Double;
        cstyle.FontName = "Verdana";
        richEditControl1.Document.CharacterStyles.Add(cstyle);
    }
    DocumentRange r = richEditControl1.Document.Selection;
    CharacterProperties charProps =
        richEditControl1.Document.BeginUpdateCharacters(r);
    charProps.Style = cstyle;
    richEditControl1.Document.EndUpdateCharacters(charProps);
    #endregion #cstyle
}

private void btnParStyle_Click(object sender, EventArgs e)
{
    #region #pstyle
    ParagraphStyle pstyle = richEditControl1.Document.ParagraphStyles["MyPStyle"];
    if (pstyle == null)
    {
        pstyle = richEditControl1.Document.ParagraphStyles.CreateNew();
        pstyle.Name = "MyPStyle";
        pstyle.LineSpacingType = ParagraphLineSpacing.Double;
        pstyle.Alignment = ParagraphAlignment.Center;
        richEditControl1.Document.ParagraphStyles.Add(pstyle);
    }
    DocumentRange r = richEditControl1.Document.Selection;
    ParagraphProperties parProps =
        richEditControl1.Document.BeginUpdateParagraphs(r);
    parProps.Style = pstyle;
    richEditControl1.Document.EndUpdateParagraphs(parProps);
    #endregion #pstyle
}

private void btnLink_Click(object sender, EventArgs e)
{
    #region #lstyle
    ParagraphStyle lstyle = richEditControl1.Document.ParagraphStyles["MyLinkedPStyle"];
    if (lstyle == null)
    {
        lstyle = richEditControl1.Document.ParagraphStyles.CreateNew();
        lstyle.Name = "MyLinkedPStyle";
        lstyle.LineSpacingType = ParagraphLineSpacing.Single;
        lstyle.Alignment = ParagraphAlignment.Justify;
        richEditControl1.Document.ParagraphStyles.Add(lstyle);
    }
    CharacterStyle lcstyle = richEditControl1.Document.CharacterStyles.CreateNew();
    lcstyle.Name = "MyLinkedCStyle";
    richEditControl1.Document.CharacterStyles.Add(lcstyle);
    lcstyle.LinkedStyle = lstyle;

    lcstyle.ForeColor = Color.DarkGreen;
    lcstyle.Strikeout = StrikeoutType.Single;
    lcstyle.FontSize = 24;
    #endregion #lstyle
}
}
}