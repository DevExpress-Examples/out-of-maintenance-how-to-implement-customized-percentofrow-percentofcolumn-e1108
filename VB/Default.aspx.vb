Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxPivotGrid

Namespace WebApplication4
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Private mode As String

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If ASPxRadioButtonList1.SelectedItem IsNot Nothing Then
				mode = Convert.ToString(ASPxRadioButtonList1.SelectedItem.Value)
				ASPxPivotGrid1.DataBind()
			End If
		End Sub

		Protected Sub ASPxPivotGrid1_CustomCellDisplayText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxPivotGrid.PivotCellDisplayTextEventArgs)
			If e.DataField.FieldName <> "Custom" Then
				Return
			End If
			Dim percentOfRow As Boolean = mode = "PercentOfRow"
			Dim pivot As ASPxPivotGrid = TryCast(sender, ASPxPivotGrid)
			Dim dField As PivotGridField = pivot.Fields("Quantity")
			Dim n As Object = e.GetCellValue(dField)
			If n Is Nothing Then
				Return
			End If
			Dim v As Object
			If percentOfRow Then
				If percentOfRow Then
					v = e.GetCellValue(GetFieldValues(e.GetColumnFields(), e, (1)), GetFieldValues(e.GetRowFields(), e, (0)), dField)
				Else
					v = e.GetCellValue(GetFieldValues(e.GetColumnFields(), e, (1)), GetFieldValues(e.GetRowFields(), e, (1)), dField)
				End If
			Else
				If percentOfRow Then
					v = e.GetCellValue(GetFieldValues(e.GetColumnFields(), e, (0)), GetFieldValues(e.GetRowFields(), e, (0)), dField)
				Else
					v = e.GetCellValue(GetFieldValues(e.GetColumnFields(), e, (0)), GetFieldValues(e.GetRowFields(), e, (1)), dField)
				End If
			End If
			If (Convert.ToDecimal(v) = 0) Then
				v = 1
			Else
				v = (Convert.ToDecimal(n) / Convert.ToDecimal(v))
			End If
			e.DisplayText = String.Format("{0:p0}", v)
		End Sub

		Private Function GetFieldValues(ByVal fields() As PivotGridField, ByVal e As PivotCellDisplayTextEventArgs, ByVal level As Integer) As Object()
			If fields.Length < level Then
				Return Nothing
			End If
			Dim values(fields.Length-level - 1) As Object
			For i As Integer = 0 To values.Length - 1
				values(i) = e.GetFieldValue(fields(i))
			Next i
			Return values
		End Function

	End Class

End Namespace
