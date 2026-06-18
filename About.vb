Imports System.Net

Public NotInheritable Class About

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description '+ " " + UserLicense + " ( Key No.: " + KeyNo + " )"
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub cmdGetMac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetMac.Click
        '''' lay dia chi Mac
        Dim theNetworkInterfaces() As System.Net.NetworkInformation.NetworkInterface = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()

        For Each currentInterface As System.Net.NetworkInformation.NetworkInterface In theNetworkInterfaces

            If currentInterface.OperationalStatus = Net.NetworkInformation.OperationalStatus.Up And currentInterface.NetworkInterfaceType.ToString() = "Ethernet" Then


                MAC = currentInterface.GetPhysicalAddress().ToString()

                'DisplayMessage(True, "Description " & currentInterface.Description.ToString() & ControlChars.CrLf)

                'DisplayMessage(True, "Name " & currentInterface.Name.ToString() & ControlChars.CrLf)

                'DisplayMessage(True, "Speed " & currentInterface.Speed.ToString() & ControlChars.CrLf)

                'DisplayMessage(True, "NetworkInterfaceType  " & currentInterface.NetworkInterfaceType.ToString() & ControlChars.CrLf)

                'DisplayMessage(True, "OperationalStatus   " & currentInterface.OperationalStatus.ToString() & ControlChars.CrLf)


                'DisplayMessage(True, ControlChars.CrLf)
            End If

        Next
        DisplayMessage(True, "this number " & MAC & " is MAC Address!")
    End Sub
End Class
