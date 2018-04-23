Imports Microsoft.VisualBasic
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



Private Sub btnCharStyle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCharStyle.Click
'	#Region "#cstyle"
	Dim cstyle As CharacterStyle = richEditControl1.Document.CharacterStyles("MyCStyle")
	If cstyle Is Nothing Then
		cstyle = richEditControl1.Document.CharacterStyles.CreateNew()
		cstyle.Name = "MyCStyle"
		cstyle.Parent = richEditControl1.Document.CharacterStyles("Default Paragraph Font")
		cstyle.ForeColor = Color.DarkOrange
		cstyle.Strikeout = StrikeoutType.Double
		cstyle.FontName = "Verdana"
		richEditControl1.Document.CharacterStyles.Add(cstyle)
	End If
	Dim r As DocumentRange = richEditControl1.Document.Selection
	Dim charProps As CharacterProperties = richEditControl1.Document.BeginUpdateCharacters(r)
	charProps.Style = cstyle
	richEditControl1.Document.EndUpdateCharacters(charProps)
'	#End Region ' #cstyle
End Sub

Private Sub btnParStyle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnParStyle.Click
'	#Region "#pstyle"
	Dim pstyle As ParagraphStyle = richEditControl1.Document.ParagraphStyles("MyPStyle")
	If pstyle Is Nothing Then
		pstyle = richEditControl1.Document.ParagraphStyles.CreateNew()
		pstyle.Name = "MyPStyle"
		pstyle.LineSpacingType = ParagraphLineSpacing.Double
		pstyle.Alignment = ParagraphAlignment.Center
		richEditControl1.Document.ParagraphStyles.Add(pstyle)
	End If
	Dim r As DocumentRange = richEditControl1.Document.Selection
	Dim parProps As ParagraphProperties = richEditControl1.Document.BeginUpdateParagraphs(r)
	parProps.Style = pstyle
	richEditControl1.Document.EndUpdateParagraphs(parProps)
'	#End Region ' #pstyle
End Sub

Private Sub btnLink_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLink.Click
'	#Region "#lstyle"
	Dim lstyle As ParagraphStyle = richEditControl1.Document.ParagraphStyles("MyLinkedPStyle")
	If lstyle Is Nothing Then
		lstyle = richEditControl1.Document.ParagraphStyles.CreateNew()
		lstyle.Name = "MyLinkedPStyle"
		lstyle.LineSpacingType = ParagraphLineSpacing.Single
		lstyle.Alignment = ParagraphAlignment.Justify
		richEditControl1.Document.ParagraphStyles.Add(lstyle)
	End If
	Dim lcstyle As CharacterStyle = richEditControl1.Document.CharacterStyles.CreateNew()
	lcstyle.Name = "MyLinkedCStyle"
	richEditControl1.Document.CharacterStyles.Add(lcstyle)
	lcstyle.LinkedStyle = lstyle

	lcstyle.ForeColor = Color.DarkGreen
	lcstyle.Strikeout = StrikeoutType.Single
	lcstyle.FontSize = 24
'	#End Region ' #lstyle
End Sub
	End Class
End Namespace