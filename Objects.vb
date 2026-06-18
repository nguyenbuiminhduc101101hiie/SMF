Module Objects

    Structure VALUES
        Dim Editable As Boolean
        Dim Continued As Boolean
        Dim Approve As Boolean
        Dim Userid As String
        Dim Updatetime As Date
    End Structure

    Structure SURCHARGE
        Dim FreightSaleID As String
        Dim ContainerOutBoundNotifyId As String
        Dim ChargeCode As String
        Dim Charge As String
        Dim Unit As String
        Dim Kind As String
        Dim Freight As Double

        Dim val As VALUES
    End Structure
End Module
