Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
#Region "#usings"
Imports DevExpress.XtraRichEdit.API.Native
#End Region ' #usings

Namespace Styles
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()

            richEditControl1.LoadDocument("Styles.docx")
        End Sub



Private Sub btnCharacterStyle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCharStyle.Click
'    #Region "#cstyle"
    Dim cStyle As CharacterStyle = richEditControl1.Document.CharacterStyles("MyCharStyle")
    If cStyle Is Nothing Then
        cStyle = richEditControl1.Document.CharacterStyles.CreateNew()
        cStyle.Name = "MyCharStyle"
        cStyle.Parent = richEditControl1.Document.CharacterStyles("Default Paragraph Font")
        cStyle.ForeColor = Color.DarkOrange
        cStyle.Strikeout = StrikeoutType.Double
        cStyle.FontName = "Verdana"
        richEditControl1.Document.CharacterStyles.Add(cStyle)
    End If
    Dim r As DocumentRange = richEditControl1.Document.Selection
    Dim charProps As CharacterProperties = richEditControl1.Document.BeginUpdateCharacters(r)
    charProps.Style = cStyle
    richEditControl1.Document.EndUpdateCharacters(charProps)
'    #End Region ' #cstyle
End Sub

Private Sub btnParagraphStyle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnParStyle.Click
'    #Region "#pstyle"
    Dim pStyle As ParagraphStyle = richEditControl1.Document.ParagraphStyles("MyParStyle")
    If pStyle Is Nothing Then
        pStyle = richEditControl1.Document.ParagraphStyles.CreateNew()
        pStyle.Name = "MyParStyle"
        pStyle.LineSpacingType = ParagraphLineSpacing.Double
        pStyle.Alignment = ParagraphAlignment.Center
        richEditControl1.Document.ParagraphStyles.Add(pStyle)
    End If
    Dim r As DocumentRange = richEditControl1.Document.Selection
    Dim parProps As ParagraphProperties = richEditControl1.Document.BeginUpdateParagraphs(r)
    parProps.Style = pStyle
    richEditControl1.Document.EndUpdateParagraphs(parProps)
'    #End Region ' #pstyle
End Sub

Private Sub btnLinkedStyle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLink.Click
'    #Region "#lstyle"
    Dim linkedStyle As ParagraphStyle = richEditControl1.Document.ParagraphStyles("MyLinkedParStyle")
    If linkedStyle Is Nothing Then
        linkedStyle = richEditControl1.Document.ParagraphStyles.CreateNew()
        linkedStyle.Name = "MyLinkedParStyle"
        linkedStyle.LineSpacingType = ParagraphLineSpacing.Single
        linkedStyle.Alignment = ParagraphAlignment.Justify
        richEditControl1.Document.ParagraphStyles.Add(linkedStyle)
    End If
    Dim lcstyle As CharacterStyle = richEditControl1.Document.CharacterStyles.CreateNew()
    lcstyle.Name = "MyLinkedCharStyle"
    richEditControl1.Document.CharacterStyles.Add(lcstyle)
    lcstyle.LinkedStyle = linkedStyle

    lcstyle.ForeColor = Color.DarkGreen
    lcstyle.Strikeout = StrikeoutType.Single
    lcstyle.FontSize = 24
'    #End Region ' #lstyle
End Sub
    End Class
End Namespace