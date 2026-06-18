Module ObjectFunc
    Dim strQuery As String = ""

    Public Sub CopyValue(ByVal surcharge As SURCHARGE)
        Try
            Dim rs As New ADODB.Recordset

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM FreightSale_History "
            strQuery = strQuery & "WHERE HistoryId = '" & DefaultValue & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("HistoryID").Value = NewId()
                End If
                .Fields("FreightSale_ID").Value = "{" & surcharge.FreightSaleID & "}"
                .Fields("ContainerOutBoundNotifyId").Value = "{" & surcharge.ContainerOutBoundNotifyId & "}"
                .Fields("ChargeCode").Value = surcharge.ChargeCode
                .Fields("Charge").Value = surcharge.Charge
                .Fields("Unit").Value = surcharge.Unit
                .Fields("Kind").Value = surcharge.Kind
                .Fields("Freight").Value = surcharge.Freight

                .Fields("editable").Value = surcharge.val.Editable
                .Fields("continued").Value = surcharge.val.Continued
                .Fields("approve").Value = surcharge.val.Approve
                .Fields("userid").Value = surcharge.val.Userid
                .Fields("updatetime").Value = surcharge.val.Updatetime.Date

                .Update()

            End With
            rs.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
