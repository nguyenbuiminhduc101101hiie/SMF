Public Class frmContainerDailyInventory
    Dim mFilter As String
    Dim inVentoryDate As Date
    Dim oTable As New DataTable
    Sub VisibleRow(ByVal dt As DataTable)
        Try
            Dim Tempdt As New DataTable
            Tempdt = dt.Copy

            For i As Integer = 0 To Tempdt.Rows.Count - 1
                If (Tempdt.Rows(i).Item("OverdueFull").ToString = "" And Tempdt.Rows(i).Item("OverdueEmpty").ToString = "") Then
                    Tempdt.Rows(i).Delete()
                    Continue For
                End If
                If Me.txtOverdueFull.Text.Trim <> "" And Tempdt.Rows(i).Item("OverdueFull").ToString <> "" Then
                    If Tempdt.Rows(i).Item("OverdueFull") < CDbl(Me.txtOverdueFull.Text) And Tempdt.Rows(i).Item("OverdueEmpty") = 0 Then
                        Tempdt.Rows(i).Delete()
                        Continue For
                    End If
                End If
                If Me.txtOverdueEmpty.Text.Trim <> "" And Tempdt.Rows(i).Item("OverdueEmpty").ToString <> "" Then
                    If Tempdt.Rows(i).Item("OverdueEmpty") < CDbl(Me.txtOverdueEmpty.Text) And Tempdt.Rows(i).Item("OverdueFull") = 0 Then
                        Tempdt.Rows(i).Delete()
                        Continue For
                    End If
                End If
            Next
            Me.dgdContainer.DataSource = Tempdt
            InsertAutoNumberToGrid(Me.dgdContainer)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryContainer(Optional ByVal argCriteria As String = "")
        Try
            Dim strQuery As String
            strQuery = "select  distinct bl_no_inbound as BLIB_NO,container_No,CTN_SIZE_TYPE as Container_Type, "
            strQuery &= " ContainerStatus=case "
            strQuery &= " when SoundContainer=1 then 'Sound Container' "
            'strQuery &= " when ToBeInSpected=1 then 'To be Inspected'"
            'strQuery &= " when DamageContainer=1 then 'Damage Container'"
            strQuery &= " when FullImport=1 then 'Full Import At Quay' End ,"
            'strQuery &= " when FullToConsignee=1 then 'full To Consignee'"
            'strQuery &= " when FullExport=1 then 'Full Export'"
            'strQuery &= " when EmptyToShipper=1 then 'EmptyToShipper'"
            'strQuery &= " when EmptyContainerReposit=1 then 'Empty Container Reposit' End,"

            strQuery &= " MaxDate =case "
            strQuery &= " when SoundContainer=1        then  FactOfReDelDate"
            'strQuery &= " when ToBeInSpected=1         then FactOfReDelDate"
            'strQuery &= " when DamageContainer=1       then FactOfReDelDate"
            strQuery &= " when FullImport=1            then Arrival_Date End,"
            'strQuery &= " when FullToConsignee=1       then FactOfDelDate"
            'strQuery &= " when FullExport=1            then FactOfReDelDate"
            'strQuery &= " when EmptyToShipper=1        then FactOfReDelDate"
            'strQuery &= " when EmptyContainerReposit=1 then FactOfReDelDate End, "
            'sửa ngày 8-1-2008  Convert(DateTime, FactOfDelDate)
            strQuery &= " case when FullImport=1 then datediff(day,Convert(DateTime,Arrival_Date),'" & Me.dtpChooseDate.Value.Date & "') else '' end  as OverdueFull,"
            'sửa ngày 8-1-2008  Convert(DateTime,DateOfEmptyContainerToShipper)
            strQuery &= " case when SoundContainer=1 then datediff(day,Convert(DateTime,FactOfReDelDate),'" & Me.dtpChooseDate.Value.Date & "')else '' end  as OverdueEmpty "
            strQuery &= " from Containermanagerment"
            strQuery &= " where Continued=1 And (BL_NO_OUTBOUND Is Null or BL_NO_OUTBOUND='') AND (DateofOnboard is NULL Or DateofOnboard='') And (SoundContainer =1 OR  FullImport=1) " ' OrToBeInSpected <> 0 OR DamageContainer <> 0 OR "
            'strQuery &= " FullExport <> 0 OR EmptyToShipper <> 0 OR EmptyContainerReposit <>0 )"
            If argCriteria <> "" Then
                strQuery &= argCriteria
            End If
            strQuery &= " order by bl_no_inbound"

            oTable = ReadTable(strQuery)
            Dim f As Double
            oTable.Columns.Add("NumberOfDays", f.GetType())

            For i As Integer = 0 To oTable.Rows.Count - 1

                If oTable.Rows(i).Item("MaxDate").ToString.Trim <> "" Then
                    Dim d As String
                    d = oTable.Rows(i).Item("MaxDate").ToString.Trim.Replace("12:00:00 AM", "").Trim
                    'If d = "3/28/2008" Then
                    '    DisplayMessage(True, "")
                    'End If

                    ' oTable.Rows(i).Item("NumberOfDays") = (inVentoryDate.ToOADate - d.ToOADate)
                End If

            Next
            VisibleRow(oTable)
            InsertAutoNumberToGrid(Me.dgdContainer)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmContainerDailyInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inVentoryDate = Now().Date
        QueryContainer()
        SetDefaultGrid(Me.dgdContainer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        InsertAutoNumberToGrid(Me.dgdContainer)
        'Dim d1 As Date
    End Sub

    Private Sub dtpChooseDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpChooseDate.ValueChanged
        inVentoryDate = Me.dtpChooseDate.Value.Date
        QueryContainer()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            If Me.dgdContainer.Rows.Count > 0 Then
                ' SetMenu(False)
                ExportExecel(Me.dgdContainer, Me)
                'SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Try
            Dim strQuery As String
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryContainer("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub txtOverdueFull_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOverdueFull.Leave
        VisibleRow(oTable)
    End Sub
    Private Sub txtOverdueEmpty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOverdueEmpty.Leave
        VisibleRow(oTable)
    End Sub

    Private Sub dgdContainer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContainer.CellContentClick

    End Sub
End Class