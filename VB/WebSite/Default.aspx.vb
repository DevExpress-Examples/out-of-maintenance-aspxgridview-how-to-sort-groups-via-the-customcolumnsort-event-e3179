Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web
Imports System.Collections

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub gridCustomers_CustomColumnDisplayText(ByVal sender As Object, ByVal e As ASPxGridViewColumnDisplayTextEventArgs)
		If e.Column.FieldName = "City" Then
			Dim groupLevel As Integer = gridCustomers.GetRowLevel(e.VisibleRowIndex)
			If groupLevel = e.Column.GroupIndex Then
				Dim city As String = gridCustomers.GetRowValues(e.VisibleRowIndex, "City").ToString()
				Dim country As String = gridCustomers.GetRowValues(e.VisibleRowIndex, "Country").ToString()
				e.DisplayText = city & " (" & country & ")"
			End If
		End If

	End Sub
	Protected Sub gridCustomers_CustomColumnSort(ByVal sender As Object, ByVal e As CustomColumnSortEventArgs)
		If e.Column IsNot Nothing And e.Column.FieldName = "City" Then
			Dim country1 As Object = e.GetRow1Value("Country")
			Dim country2 As Object = e.GetRow2Value("Country")
			Dim res As Integer = Comparer.Default.Compare(country1, country2)
			If res = 0 Then
				Dim city1 As Object = e.Value1
				Dim city2 As Object = e.Value2
				res = Comparer.Default.Compare(city1, city2)
			End If
			e.Result = res
			e.Handled = True
		End If
	End Sub
End Class
