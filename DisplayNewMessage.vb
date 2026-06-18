Option Strict Off
Option Explicit On
Module DisplayNewMessage
	
	Public Sub DisplayNewMessages()
		On Error GoTo Err_Renamed
		Dim msg As String
		Exit Sub
        If VB6.Format(Now, "yy/mm/dd") < "05/31/01" Then
            msg = "Môùi:" & Chr(13)
            msg = msg & "        Baïn coù theå kieåm tra tình traïng caân ñoái cuûa caùc chöùng töø vaø söï khöû truøng tröôùc khi in baùo caùo." & Chr(13) & Chr(13)
            msg = msg & "Caùch laøm:" & Chr(13)
            msg = msg & "        Baïn choïn treân menu: Coâng cuï/Kieåm tra tính caân ñoái."
            DisplayMessage(True, msg, CStr(MsgBoxStyle.Information))
        End If
		Exit Sub
Err_Renamed: 
        MsgBox(Err.Description)
    End Sub
    Public Sub thongbao(ByVal thongbao As String)
        Dim frm As New frmThongbao

        frm.txtnoidung.Text = thongbao
        frm.ShowDialog()
    End Sub
End Module