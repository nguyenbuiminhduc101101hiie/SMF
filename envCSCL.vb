Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.Compatibility

Module DataEnvironment_AccountEnv_Module
    Friend CSCLEnv As DataEnvironment_CSCLEnv = New DataEnvironment_CSCLEnv()
End Module

Friend Class DataEnvironment_CSCLEnv
    Inherits VB6.BaseDataEnvironment
    Public WithEvents CSCLConn As ADODB.Connection
    Public WithEvents CSCLSConn As ADODB.Connection
    Public WithEvents CSCLCConn As ADODB.Connection
    Public WithEvents Bldmt As ADODB.Connection
    Public WithEvents rsTransactions As ADODB.Recordset
    Private m_Transactions As ADODB.Command
    Public WithEvents rsTransDetail As ADODB.Recordset
    Private m_TransDetail As ADODB.Command
    Public WithEvents rsTransactionList As ADODB.Recordset
    Private m_TransactionList As ADODB.Command
    Public Sub New()
        MyBase.New()
        CSCLConn = New ADODB.Connection()
        CSCLConn.ConnectionString = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=;Initial Catalog=;Data Source="
        m_Connections.Add(CSCLConn, "AccountConn")
        CSCLSConn = New ADODB.Connection()
        CSCLSConn.ConnectionString = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=;Initial Catalog=;Data Source="
        m_Connections.Add(CSCLSConn, "CSCLSConn")
        CSCLCConn = New ADODB.Connection()
        CSCLCConn.ConnectionString = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=;Initial Catalog=;Data Source="
        m_Connections.Add(CSCLCConn, "CSCLCConn")
        Bldmt = New ADODB.Connection()
        Bldmt.ConnectionString = "Provider=SQLOLEDB.1;Password=;Persist Security Info=True;User ID=;Initial Catalog=;Data Source="
        m_Connections.Add(Bldmt, "Bldmt")
        m_Transactions = New ADODB.Command()
        rsTransactions = New ADODB.Recordset()
        m_Transactions.Name = "Transactions"
        m_Transactions.CommandText = "dbo.Transactions"
        m_Transactions.CommandType = ADODB.CommandTypeEnum.adCmdTable
        rsTransactions.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsTransactions.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rsTransactions.LockType = ADODB.LockTypeEnum.adLockReadOnly
        rsTransactions.Source = m_Transactions
        m_Commands.Add(m_Transactions, "Transactions")
        m_Recordsets.Add(rsTransactions, "Transactions")
        m_TransDetail = New ADODB.Command()
        rsTransDetail = New ADODB.Recordset()
        m_TransDetail.Name = "TransDetail"
        m_TransDetail.CommandText = "dbo.TransDetail"
        m_TransDetail.CommandType = ADODB.CommandTypeEnum.adCmdTable
        rsTransDetail.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsTransDetail.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rsTransDetail.LockType = ADODB.LockTypeEnum.adLockReadOnly
        rsTransDetail.Source = m_TransDetail
        m_Commands.Add(m_TransDetail, "TransDetail")
        m_Recordsets.Add(rsTransDetail, "TransDetail")
        m_TransactionList = New ADODB.Command()
        rsTransactionList = New ADODB.Recordset()
        m_TransactionList.Name = "TransactionList"
        m_TransactionList.CommandText = "SELECT DocDate FROM Transactions"
        m_TransactionList.CommandType = ADODB.CommandTypeEnum.adCmdText
        rsTransactionList.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsTransactionList.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rsTransactionList.LockType = ADODB.LockTypeEnum.adLockReadOnly
        rsTransactionList.Source = m_TransactionList
        m_Commands.Add(m_TransactionList, "TransactionList")
        m_Recordsets.Add(rsTransactionList, "TransactionList")
    End Sub
    Public Sub Transactions()
        If CSCLSConn.State = ADODB.ObjectStateEnum.adStateClosed Then
            CSCLSConn.Open()
        End If
        If rsTransactions.State = ADODB.ObjectStateEnum.adStateOpen Then
            rsTransactions.Close()
        End If
        m_Transactions.ActiveConnection = CSCLSConn
        rsTransactions.Open()
    End Sub
    Public Sub TransDetail()
        If CSCLSConn.State = ADODB.ObjectStateEnum.adStateClosed Then
            CSCLSConn.Open()
        End If
        If rsTransDetail.State = ADODB.ObjectStateEnum.adStateOpen Then
            rsTransDetail.Close()
        End If
        m_TransDetail.ActiveConnection = CSCLSConn
        rsTransDetail.Open()
    End Sub
    Public Sub TransactionList()
        If CSCLSConn.State = ADODB.ObjectStateEnum.adStateClosed Then
            CSCLSConn.Open()
        End If
        If rsTransactionList.State = ADODB.ObjectStateEnum.adStateOpen Then
            rsTransactionList.Close()
        End If
        m_TransactionList.ActiveConnection = CSCLSConn
        rsTransactionList.Open()
    End Sub
End Class