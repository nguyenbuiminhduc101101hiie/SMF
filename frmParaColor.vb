Public Class frmParaColor

    Dim _font As System.Drawing.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)

    Private Sub cbobkColor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbobkColor.MouseClick
        If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.cbobkColor.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub cbocbkColor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbocbkColor.MouseClick
        If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.cbocbkColor.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub cbocfrColor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbocfrColor.MouseClick
        If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.cbocfrColor.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub cbosbkColor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbosbkColor.MouseClick
        If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.cbosbkColor.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub cbosfrColor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbosfrColor.MouseClick
        If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.cbosfrColor.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub frmParaColor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim oItems As PDSAListItemString
            Me.cboAlignCell.Items.Clear()

            oItems = New PDSAListItemString
            oItems.Value = "Not Set"
            oItems.ID = System.Windows.Forms.DataGridViewContentAlignment.NotSet
            Me.cboAlignCell.Items.Add(oItems)

            oItems = New PDSAListItemString
            oItems.Value = "Top Left"
            oItems.ID = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
            Me.cboAlignCell.Items.Add(oItems)

            oItems = New PDSAListItemString
            oItems.Value = "Top Right"
            oItems.ID = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            Me.cboAlignCell.Items.Add(oItems)

            oItems = New PDSAListItemString
            oItems.Value = "Top Center"
            oItems.ID = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
            Me.cboAlignCell.Items.Add(oItems)

            oItems = New PDSAListItemString
            oItems.Value = "Middle Left"
            oItems.ID = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            Me.cboAlignCell.Items.Add(oItems)

            oItems = New PDSAListItemString
            oItems.Value = "Middle Right"
            oItems.ID = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.cboAlignCell.Items.Add(oItems)

            oItems = New PDSAListItemString
            oItems.Value = "Middle Center"
            oItems.ID = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.cboAlignCell.Items.Add(oItems)

            oItems = New PDSAListItemString
            oItems.Value = "Bottom Left"
            oItems.ID = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
            Me.cboAlignCell.Items.Add(oItems)

            oItems = New PDSAListItemString
            oItems.Value = "Bottom Right"
            oItems.ID = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
            Me.cboAlignCell.Items.Add(oItems)

            oItems = New PDSAListItemString
            oItems.Value = "Bottom Center"
            oItems.ID = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
            Me.cboAlignCell.Items.Add(oItems)

            If objUserSetting.GetCParm("mbkColor") <> Nothing And objUserSetting.GetCParm("mcbkColor") <> Nothing And objUserSetting.GetCParm("mcfrColor") <> Nothing And objUserSetting.GetCParm("msbkColor") <> Nothing And objUserSetting.GetCParm("msfrColor") <> Nothing Then
                mbkColor = Color.FromArgb(objUserSetting.GetCParm("mbkColor"))
                mcbkColor = Color.FromArgb(objUserSetting.GetCParm("mcbkColor"))
                mcfrColor = Color.FromArgb(objUserSetting.GetCParm("mcfrColor"))
                msbkColor = Color.FromArgb(objUserSetting.GetCParm("msbkColor"))
                msfrColor = Color.FromArgb(objUserSetting.GetCParm("msfrColor"))



                mFont = New Font(objUserSetting.GetCParm("mFont").ToString, CInt(objUserSetting.GetCParm("mSize").ToString))
            End If
            Me.cbobkColor.BackColor = mbkColor
            Me.cbocbkColor.BackColor = mcbkColor
            Me.cbocfrColor.BackColor = mcfrColor
            Me.cbosbkColor.BackColor = msbkColor
            Me.cbosfrColor.BackColor = msfrColor
            If mResize = True Then
                Me.rdoTrue.Checked = True
            Else
                Me.rdoFalse.Checked = True
            End If
            Me.cboAlignCell.Text = FindIDValue(Me.cboAlignCell, mAlign)

            _font = mFont
            Dim st As String = _font.Name.ToString & ", " & _font.Size
            Me.cboFont.Text = st
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdGridOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGridOk.Click
        mAlign = FindValueID(Me.cboAlignCell, Me.cboAlignCell.Text)

        If Me.rdoTrue.Checked = True Then
            mResize = True
        Else
            mResize = False
        End If

        mbkColor = Me.cbobkColor.BackColor
        mcbkColor = Me.cbocbkColor.BackColor
        mcfrColor = Me.cbocfrColor.BackColor
        msbkColor = Me.cbosbkColor.BackColor
        msfrColor = Me.cbosfrColor.BackColor
        mFont = _font

        objUserSetting.SetCParm("mAlign", mAlign.ToString)

        objUserSetting.SetCParm("mbkColor", mbkColor.ToArgb)
        objUserSetting.SetCParm("mcbkColor", mcbkColor.ToArgb)
        objUserSetting.SetCParm("mcfrColor", mcfrColor.ToArgb)
        objUserSetting.SetCParm("msbkColor", msbkColor.ToArgb)
        objUserSetting.SetCParm("msfrColor", msfrColor.ToArgb)
        objUserSetting.SetCParm("mFont", mFont.Name)
        objUserSetting.SetCParm("mSize", mFont.Size)

        Me.Close()
    End Sub

    Private Sub cmdGridCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGridCancel.Click
        Me.Close()
    End Sub

    Private Sub cboFont_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboFont.MouseClick
        If Me.FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            _font = Me.FontDialog1.Font
            Me.cboFont.Text = _font.Name.ToString & ", " & _font.Size
        End If
    End Sub

    Private Sub cbobkColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbobkColor.SelectedIndexChanged

    End Sub

    Private Sub cbocfrColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocfrColor.SelectedIndexChanged

    End Sub
End Class