Public Class frmCheckContainerOnboard

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Try
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtFilename.Text = Me.OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim ConnExcel As New OleDb.OleDbConnection()
        Try
            If Me.txtFilename.Text = "" Then
                MsgBox("The file name is invalid")
                Return
            End If
            If Me.txtSheetName.Text = "" Then
                MsgBox("This sheet Not belong to the file")
                Return
            End If
            Dim STRCONNE As String

            STRCONNE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & Me.txtFilename.Text & "; Extended Properties=""Excel 8.0;HDR=no;"""
            ConnExcel = New OleDb.OleDbConnection(STRCONNE)
            ConnExcel.Open()
            Dim strQuery As String
            strQuery = "Select * from [" & Me.txtSheetName.Text & "$] Where F3<>''"
            Dim CmdSelect As New OleDb.OleDbCommand(strQuery, ConnExcel)
            Dim dt As New DataTable
            Dim Count As Integer = 0
            Dim Adapter As New OleDb.OleDbDataAdapter(CmdSelect)
            Adapter.Fill(dt)
            Dim CurRow As Integer = 1 ' bỏ Qua Dòng đền titên vì dòng đâu là'CONTR NBR'
            For i As Integer = CurRow To dt.Rows.Count - 1
                Dim BLNO, ContainerNo, OceanVessel, OceanVoyNo As String
                BLNO = dt.Rows(i).Item("F2").ToString
                ContainerNo = dt.Rows(i).Item("F3").ToString

                Dim Temp() As String
                Temp = Strings.Split(dt.Rows(i).Item("F14").ToString.Trim, " ")
                OceanVessel = ""
                OceanVoyNo = ""
                If Temp.Length > 0 Then
                    OceanVoyNo = Temp(Temp.Length - 1)
                End If
                For j As Integer = 0 To Temp.Length - 2
                    OceanVessel &= Temp(j) & " "
                Next
                'strQuery = "Update ContainerManager Set Vessel_Outbound='" & Me.cboVessel.Text & "',VoyNo_Outbound='" & Me.txtVoyNo.Text & "',"
                'strQuery &= "BL_NO_Outbound='" & BLNO & "',OceanVessel='" & OceanVessel & "',OceanVoyno='" & OceanVoyNo & "',"
                'strQuery &= "OceanETD='" & dt.Rows(i).Item("F15").ToString & "',Port_Of_Discharge='" & dt.Rows(i).Item("F11").ToString & "' "
                'strQuery &= ""
                strQuery = "select * from ContainerManagerment Where Continued=1 And (DateOfOnboard Is NULL Or DateOfOnboard='') And Container_no='" & ContainerNo & "'"

                Dim rs As New ADODB.Recordset
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If rs.EOF Then
                    MsgBox("Data Error , Container No :" & ContainerNo & " Not in Database ")
                    rs.Close()
                    Continue For
                End If
                Count += 1
                With rs
                    .Fields("Vessel_Outbound").Value = Me.cboVessel.Text
                    .Fields("VoyNo_Outbound").Value = Me.txtVoyNo.Text
                    .Fields("BL_NO_Outbound").Value = BLNO
                    .Fields("DateOfOnBoard").Value = Me.dtpETA.Value.Date
                    '.Fields("OceanVoyno").Value = OceanVoyNo
                    '.Fields("OceanETD").Value = dt.Rows(i).Item("F15").ToString
                    .Fields("Port_Of_Discharge").Value = dt.Rows(i).Item("F11").ToString
                    .Update()
                End With
                rs.Close()


                'Dim Conn As New SqlClient.SqlConnection(strconnDG)
                'Conn.Open()
                'Dim Cmd As New SqlClient.SqlCommand(strQuery, Conn)
                'Cmd.CommandType = CommandType.Text
                'Cmd.CommandText = strQuery
                'Cmd.ExecuteNonQuery()
            Next
            MsgBox("Complete " & Count & " Container Updated")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select Vessel from Vessel Where Continued=1 Order by Vessel"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If Me.cboVessel.Items.Count > 0 Then
                Me.cboVessel.Items.Clear()
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.cboVessel.Items.Add(dt.Rows(i).Item("Vessel").ToString)
            Next
            If Me.cboVessel.Items.Count > 0 Then
                Me.cboVessel.SelectedIndex = 0
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmCheckContainerOnboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub
End Class