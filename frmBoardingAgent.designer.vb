<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoardingAgent
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBoardingAgent))
Me.cmdFind = New System.Windows.Forms.Button
Me.FindBoardingAgent = New System.Windows.Forms.TextBox
Me.cboFind = New System.Windows.Forms.ComboBox
Me.MenuStrip = New System.Windows.Forms.MenuStrip
Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
Me.ExportExcelFromToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.mnuReport = New System.Windows.Forms.ToolStripMenuItem
Me.DeclarationOfDepartureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.ForeignVesselApplicaitonForArrivalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.PermissionForForeignVesselToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
Me.dgdBoardingAgent = New System.Windows.Forms.DataGridView
Me.BoardingagentID = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.shipCode = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.Vessel = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.VoyageNoOnArrival = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.VoyageNoOnDeparture = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ServiceTerm = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.OperatorName = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.AgentName = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.OwnerName = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DateOfArrivalAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.TimeOfArrivalAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.CaptionNameAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.NumOfCrewAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.NumOfPassengersAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.PositionOfShipInPortAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.PurposeToPortAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.KindOfCargoAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FOAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DOAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FWAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DateOfArrivalPilotStationAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.TimeOfArrivalPilotStationAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DateOfArrivalPilotOnboardAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.TimeOfArrivalPilotOnboardAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DateOfBerthAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.TimeOfBerthAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.foreDraftAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.AfterDraftAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ActualDisplacementAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.LastDateOfArrivalAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.PreviousPortAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.Dis_LoadPortAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.NextPortAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DateCommencingOperationAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.TimeCommencingOperationAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20GPAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40GPAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20HCAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40HCAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E45HCAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20RFAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40RFAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20RHAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40RHAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E45RHAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20FRAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40FRAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20HGAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40HGAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40GHAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20OTAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40OTAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20TKAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40TKAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ECNTRAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ETEUAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ETONSAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20GPAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40GPAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20HCAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40HCAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F45HCAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20RFAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40RFAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20RHAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40RHAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F45RHAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20FRAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40FRAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20HGAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40HGAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40GHAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20OTAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40OTAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20TKAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40TKAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FCNTRAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FTEUAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FTONSAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoCNTRAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoTONSAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoCLASSAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.OtherConcerningRequirementOfShipAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.RemaksAD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.CaptionNameDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.NumOfCrewDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.NumOfPassengersDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.PositionOfShipInPortDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.PurposeToPortDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.KindOfCargoDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FODD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DODD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FWDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DateOfArrivalPilotStationDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.TimeOfArrivalPilotStationDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DateOfArrivalPilotOnboardDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.TimeOfArrivalPilotOnboardDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DateOfBerthDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.TimeOfBerthDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.foreDraftDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.AfterDraftDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ActualDisplacementDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.LastDateOfArrivalDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.PreviousPortDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.Dis_LoadPortDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.NextPortDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DateCommencingOperationDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.TimeCommencingOperationDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20GPDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40GPDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20HCDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40HCDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E45HCDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20RFDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40RFDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20RHDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40RHDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E45RHDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20FRDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40FRDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20HGDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40HGDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40GHDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20OTDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40OTDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20TKDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40TKDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ECNTRDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ETEUDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ETONSDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20GPDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40GPDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20HCDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40HCDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F45HCDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20RFDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40RFDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20RHDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40RHDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F45RHDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20FRDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40FRDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20HGDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40HGDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40GHDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20OTDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40OTDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20TKDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40TKDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FCNTRDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FTEUDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FTONSDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoCNTRDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoTONSDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoCLASSDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.OtherConcerningRequirementOfShipDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.RemarksDD = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20GPAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40GPAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20HCAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40HCAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E45HCAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20RFAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40RFAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20RHAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40RHAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E45RHAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20FRAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40FRAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20HGAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40HGAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40GHAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20OTAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40OTAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20TKAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40TKAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ECNTRAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ETEUAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ETONSAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20GPAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40GPAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20HCAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40HCAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F45HCAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20RFAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40RFAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20RHAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40RHAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F45RHAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20FRAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40FRAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20HGAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40HGAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40GHAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20OTAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40OTAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20TKAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40TKAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FCNTRAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FTEUAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FTONSAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoCNTRAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoTONSAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoCLASSAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.OtherConcerningRequirementOfShipAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.RemaksAD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20GPDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40GPDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20HCDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40HCDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E45HCDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20RFDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40RFDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20RHDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40RHDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E45RHDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20FRDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40FRDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20HGDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40HGDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40GHDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20OTDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40OTDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E20TKDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.E40TKDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ECNTRDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ETEUDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ETONSDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20GPDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40GPDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20HCDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40HCDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F45HCDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20RFDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40RFDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20RHDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40RHDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F45RHDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20FRDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40FRDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20HGDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40HGDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40GHDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20OTDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40OTDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F20TKDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.F40TKDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FCNTRDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FTEUDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.FTONSDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoCNTRDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoTONSDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DangerousInboundCargoCLASSDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.OtherConcerningRequirementOfShipDD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ApplicationForArrivalDate = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.TheApprovalPort = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.ApproveArrival = New System.Windows.Forms.DataGridViewCheckBoxColumn
Me.Editable = New System.Windows.Forms.DataGridViewCheckBoxColumn
Me.Continued = New System.Windows.Forms.DataGridViewCheckBoxColumn
Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
Me.UserUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.fraUpdate = New System.Windows.Forms.TabControl
Me.TabPage5 = New System.Windows.Forms.TabPage
Me.Label1 = New System.Windows.Forms.Label
Me.Label152 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.Label151 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.Label144 = New System.Windows.Forms.Label
Me.Label251 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.lbldescriptionShipper = New System.Windows.Forms.Label
Me.txtServiceTerm = New System.Windows.Forms.TextBox
Me.txtOwnerName = New System.Windows.Forms.TextBox
Me.txtApplicationForArrivalDate = New System.Windows.Forms.TextBox
Me.txtTheApprovalPort = New System.Windows.Forms.TextBox
Me.txtAgentName = New System.Windows.Forms.TextBox
Me.txtOperatorName = New System.Windows.Forms.TextBox
Me.txtshipCode = New System.Windows.Forms.TextBox
Me.txtVoyageDeparture = New System.Windows.Forms.TextBox
Me.txtVoyageArrival = New System.Windows.Forms.TextBox
Me.cboVessel = New System.Windows.Forms.ComboBox
Me.lblShipper = New System.Windows.Forms.Label
Me.tbcSailingSchedule = New System.Windows.Forms.TabPage
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.lbl = New System.Windows.Forms.TabPage
Me.GroupBox25 = New System.Windows.Forms.GroupBox
Me.dtpDateOfArrivalAD = New System.Windows.Forms.DateTimePicker
Me.chkApproveETA = New System.Windows.Forms.CheckBox
Me.Label252 = New System.Windows.Forms.Label
Me.txtTimeOfArrivalAD = New System.Windows.Forms.TextBox
Me.txtDateOfArrivalAD = New System.Windows.Forms.TextBox
Me.Label253 = New System.Windows.Forms.Label
Me.GroupBox4 = New System.Windows.Forms.GroupBox
Me.dtpDateOfBerthAD = New System.Windows.Forms.DateTimePicker
Me.Label17 = New System.Windows.Forms.Label
Me.txtDateOfBerthAD = New System.Windows.Forms.TextBox
Me.txtTimeOfBerthAD = New System.Windows.Forms.TextBox
Me.Label18 = New System.Windows.Forms.Label
Me.GroupBox3 = New System.Windows.Forms.GroupBox
Me.dtpDateOfArrivalPilotOnboardAD = New System.Windows.Forms.DateTimePicker
Me.Label15 = New System.Windows.Forms.Label
Me.txtTimeOfArrivalPilotOnboardAD = New System.Windows.Forms.TextBox
Me.txtDateOfArrivalPilotOnboardAD = New System.Windows.Forms.TextBox
Me.Label16 = New System.Windows.Forms.Label
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.Label13 = New System.Windows.Forms.Label
Me.txtFOAD = New System.Windows.Forms.TextBox
Me.txtFWAD = New System.Windows.Forms.TextBox
Me.lblFWAD = New System.Windows.Forms.Label
Me.txtDOAD = New System.Windows.Forms.TextBox
Me.Label14 = New System.Windows.Forms.Label
Me.Label12 = New System.Windows.Forms.Label
Me.Label11 = New System.Windows.Forms.Label
Me.Label10 = New System.Windows.Forms.Label
Me.Label9 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.txtKindofCargoAD = New System.Windows.Forms.TextBox
Me.txtPurposetoportAD = New System.Windows.Forms.TextBox
Me.txtPositionOfShipInPortAD = New System.Windows.Forms.TextBox
Me.txtNumOfPassengersAD = New System.Windows.Forms.TextBox
Me.txtCaptionNameAD = New System.Windows.Forms.TextBox
Me.txtNumOfCrewAD = New System.Windows.Forms.TextBox
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.dtpdateofarrivalPilotStationAD = New System.Windows.Forms.DateTimePicker
Me.Label5 = New System.Windows.Forms.Label
Me.txtdateofarrivalPilotStationAD = New System.Windows.Forms.TextBox
Me.txtTimeOfArrivalPilotStationAD = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.TabPage1 = New System.Windows.Forms.TabPage
Me.GroupBox6 = New System.Windows.Forms.GroupBox
Me.dtpDateCommencingOperationAD = New System.Windows.Forms.DateTimePicker
Me.Label26 = New System.Windows.Forms.Label
Me.txtTimeCommencingOperationAD = New System.Windows.Forms.TextBox
Me.txtDateCommencingOperationAD = New System.Windows.Forms.TextBox
Me.Label27 = New System.Windows.Forms.Label
Me.GroupBox5 = New System.Windows.Forms.GroupBox
Me.Label25 = New System.Windows.Forms.Label
Me.Label24 = New System.Windows.Forms.Label
Me.Label23 = New System.Windows.Forms.Label
Me.cboNextPortAD = New System.Windows.Forms.TextBox
Me.cboDis_LoadPortAD = New System.Windows.Forms.TextBox
Me.cboPreviousPortAD = New System.Windows.Forms.TextBox
Me.Label19 = New System.Windows.Forms.Label
Me.Label20 = New System.Windows.Forms.Label
Me.Label21 = New System.Windows.Forms.Label
Me.Label22 = New System.Windows.Forms.Label
Me.txtLastDateOfArrivalAD = New System.Windows.Forms.TextBox
Me.txtActualDisplacementAD = New System.Windows.Forms.TextBox
Me.txtAfterDraftAD = New System.Windows.Forms.TextBox
Me.txtForeDraftAD = New System.Windows.Forms.TextBox
Me.TabPage2 = New System.Windows.Forms.TabPage
Me.TabControl3 = New System.Windows.Forms.TabControl
Me.TabPage6 = New System.Windows.Forms.TabPage
Me.txtE45RHAD = New System.Windows.Forms.TextBox
Me.txtE40RHAD = New System.Windows.Forms.TextBox
Me.txtE20RHAD = New System.Windows.Forms.TextBox
Me.txtE40RFAD = New System.Windows.Forms.TextBox
Me.txtE20RFAD = New System.Windows.Forms.TextBox
Me.txtE40HCAD = New System.Windows.Forms.TextBox
Me.txtE45HCAD = New System.Windows.Forms.TextBox
Me.txtE20HCAD = New System.Windows.Forms.TextBox
Me.txtE40GPAD = New System.Windows.Forms.TextBox
Me.txtE20GPAD = New System.Windows.Forms.TextBox
Me.GroupBox7 = New System.Windows.Forms.GroupBox
Me.Label49 = New System.Windows.Forms.Label
Me.Label47 = New System.Windows.Forms.Label
Me.Label48 = New System.Windows.Forms.Label
Me.TXTETONSAD = New System.Windows.Forms.TextBox
Me.TXTETEUAD = New System.Windows.Forms.TextBox
Me.TXTECNTRAD = New System.Windows.Forms.TextBox
Me.Label46 = New System.Windows.Forms.Label
Me.Label37 = New System.Windows.Forms.Label
Me.Label36 = New System.Windows.Forms.Label
Me.Label42 = New System.Windows.Forms.Label
Me.Label32 = New System.Windows.Forms.Label
Me.Label45 = New System.Windows.Forms.Label
Me.Label41 = New System.Windows.Forms.Label
Me.Label35 = New System.Windows.Forms.Label
Me.Label44 = New System.Windows.Forms.Label
Me.Label31 = New System.Windows.Forms.Label
Me.Label34 = New System.Windows.Forms.Label
Me.Label39 = New System.Windows.Forms.Label
Me.Label28 = New System.Windows.Forms.Label
Me.Label43 = New System.Windows.Forms.Label
Me.Label40 = New System.Windows.Forms.Label
Me.Label33 = New System.Windows.Forms.Label
Me.Label30 = New System.Windows.Forms.Label
Me.Label38 = New System.Windows.Forms.Label
Me.Label29 = New System.Windows.Forms.Label
Me.txtE40TKAD = New System.Windows.Forms.TextBox
Me.txtE20TKAD = New System.Windows.Forms.TextBox
Me.txtE40OTAD = New System.Windows.Forms.TextBox
Me.txtE40GHAD = New System.Windows.Forms.TextBox
Me.txtE20OTAD = New System.Windows.Forms.TextBox
Me.txtE40HGAD = New System.Windows.Forms.TextBox
Me.txtE20HGAD = New System.Windows.Forms.TextBox
Me.txtE40FRAD = New System.Windows.Forms.TextBox
Me.txtE20FRAD = New System.Windows.Forms.TextBox
Me.TabPage7 = New System.Windows.Forms.TabPage
Me.txtF40TKAD = New System.Windows.Forms.TextBox
Me.txtF20TKAD = New System.Windows.Forms.TextBox
Me.txtF40OTAD = New System.Windows.Forms.TextBox
Me.txtF20OTAD = New System.Windows.Forms.TextBox
Me.txtF40GHAD = New System.Windows.Forms.TextBox
Me.txtF40HGAD = New System.Windows.Forms.TextBox
Me.txtF20HGAD = New System.Windows.Forms.TextBox
Me.txtF40FRAD = New System.Windows.Forms.TextBox
Me.txtF20FRAD = New System.Windows.Forms.TextBox
Me.txtF45RHAD = New System.Windows.Forms.TextBox
Me.txtF40RHAD = New System.Windows.Forms.TextBox
Me.txtF20RHAD = New System.Windows.Forms.TextBox
Me.txtF40RFAD = New System.Windows.Forms.TextBox
Me.txtF20RFAD = New System.Windows.Forms.TextBox
Me.txtF45HCAD = New System.Windows.Forms.TextBox
Me.txtF40HCAD = New System.Windows.Forms.TextBox
Me.txtF20HCAD = New System.Windows.Forms.TextBox
Me.txtF40GPAD = New System.Windows.Forms.TextBox
Me.txtF20GPAD = New System.Windows.Forms.TextBox
Me.Label76 = New System.Windows.Forms.Label
Me.Label75 = New System.Windows.Forms.Label
Me.txtRemaksAD = New System.Windows.Forms.TextBox
Me.txtOtherConcerningRequirementOfShipAD = New System.Windows.Forms.TextBox
Me.GroupBox9 = New System.Windows.Forms.GroupBox
Me.txtDangerousInboundCargoTONSAD = New System.Windows.Forms.TextBox
Me.txtDangerousInboundCargoCLASSAD = New System.Windows.Forms.TextBox
Me.txtDangerousInboundCargoCNTRAD = New System.Windows.Forms.TextBox
Me.Label72 = New System.Windows.Forms.Label
Me.Label73 = New System.Windows.Forms.Label
Me.Label74 = New System.Windows.Forms.Label
Me.GroupBox8 = New System.Windows.Forms.GroupBox
Me.txtFTONAD = New System.Windows.Forms.TextBox
Me.txtFTEUAD = New System.Windows.Forms.TextBox
Me.txtFCNTRAD = New System.Windows.Forms.TextBox
Me.Label50 = New System.Windows.Forms.Label
Me.Label51 = New System.Windows.Forms.Label
Me.Label52 = New System.Windows.Forms.Label
Me.Label53 = New System.Windows.Forms.Label
Me.Label54 = New System.Windows.Forms.Label
Me.Label55 = New System.Windows.Forms.Label
Me.Label56 = New System.Windows.Forms.Label
Me.Label57 = New System.Windows.Forms.Label
Me.Label58 = New System.Windows.Forms.Label
Me.Label59 = New System.Windows.Forms.Label
Me.Label60 = New System.Windows.Forms.Label
Me.Label61 = New System.Windows.Forms.Label
Me.Label62 = New System.Windows.Forms.Label
Me.Label63 = New System.Windows.Forms.Label
Me.Label64 = New System.Windows.Forms.Label
Me.Label65 = New System.Windows.Forms.Label
Me.Label66 = New System.Windows.Forms.Label
Me.Label67 = New System.Windows.Forms.Label
Me.Label68 = New System.Windows.Forms.Label
Me.Label69 = New System.Windows.Forms.Label
Me.Label70 = New System.Windows.Forms.Label
Me.Label71 = New System.Windows.Forms.Label
Me.TabPage11 = New System.Windows.Forms.TabPage
Me.TabControl5 = New System.Windows.Forms.TabControl
Me.TabPage12 = New System.Windows.Forms.TabPage
Me.txtE40TKAD1 = New System.Windows.Forms.TextBox
Me.txtE20TKAD1 = New System.Windows.Forms.TextBox
Me.txtE40OTAD1 = New System.Windows.Forms.TextBox
Me.txtE20OTAD1 = New System.Windows.Forms.TextBox
Me.txtE40GHAD1 = New System.Windows.Forms.TextBox
Me.txtE40HGAD1 = New System.Windows.Forms.TextBox
Me.txtE20HGAD1 = New System.Windows.Forms.TextBox
Me.txtE40FRAD1 = New System.Windows.Forms.TextBox
Me.txtE20FRAD1 = New System.Windows.Forms.TextBox
Me.txtE45RHAD1 = New System.Windows.Forms.TextBox
Me.txtE40RHAD1 = New System.Windows.Forms.TextBox
Me.txtE20RHAD1 = New System.Windows.Forms.TextBox
Me.txtE40RFAD1 = New System.Windows.Forms.TextBox
Me.txtE20RFAD1 = New System.Windows.Forms.TextBox
Me.txtE45HCAD1 = New System.Windows.Forms.TextBox
Me.txtE40HCAD1 = New System.Windows.Forms.TextBox
Me.txtE20HCAD1 = New System.Windows.Forms.TextBox
Me.txtE40GPAD1 = New System.Windows.Forms.TextBox
Me.txtE20GPAD1 = New System.Windows.Forms.TextBox
Me.GroupBox19 = New System.Windows.Forms.GroupBox
Me.txtETONAD1 = New System.Windows.Forms.TextBox
Me.txtETEUAD1 = New System.Windows.Forms.TextBox
Me.txtECNTRAD1 = New System.Windows.Forms.TextBox
Me.Label153 = New System.Windows.Forms.Label
Me.Label154 = New System.Windows.Forms.Label
Me.Label155 = New System.Windows.Forms.Label
Me.Label156 = New System.Windows.Forms.Label
Me.Label157 = New System.Windows.Forms.Label
Me.Label158 = New System.Windows.Forms.Label
Me.Label159 = New System.Windows.Forms.Label
Me.Label160 = New System.Windows.Forms.Label
Me.Label161 = New System.Windows.Forms.Label
Me.Label162 = New System.Windows.Forms.Label
Me.Label163 = New System.Windows.Forms.Label
Me.Label164 = New System.Windows.Forms.Label
Me.Label165 = New System.Windows.Forms.Label
Me.Label166 = New System.Windows.Forms.Label
Me.Label167 = New System.Windows.Forms.Label
Me.Label168 = New System.Windows.Forms.Label
Me.Label169 = New System.Windows.Forms.Label
Me.Label170 = New System.Windows.Forms.Label
Me.Label171 = New System.Windows.Forms.Label
Me.Label172 = New System.Windows.Forms.Label
Me.Label173 = New System.Windows.Forms.Label
Me.Label174 = New System.Windows.Forms.Label
Me.TabPage13 = New System.Windows.Forms.TabPage
Me.txtRemaksAD1 = New System.Windows.Forms.TextBox
Me.txtOtherConcerningRequirementOfShipAD1 = New System.Windows.Forms.TextBox
Me.txtF40TKAD1 = New System.Windows.Forms.TextBox
Me.txtF20TKAD1 = New System.Windows.Forms.TextBox
Me.txtF40OTAD1 = New System.Windows.Forms.TextBox
Me.txtF20OTAD1 = New System.Windows.Forms.TextBox
Me.txtF40GHAD1 = New System.Windows.Forms.TextBox
Me.txtF40HGAD1 = New System.Windows.Forms.TextBox
Me.txtF20HGAD1 = New System.Windows.Forms.TextBox
Me.txtF40FRAD1 = New System.Windows.Forms.TextBox
Me.txtF20FRAD1 = New System.Windows.Forms.TextBox
Me.txtF45RHAD1 = New System.Windows.Forms.TextBox
Me.txtF40RHAD1 = New System.Windows.Forms.TextBox
Me.txtF20RHAD1 = New System.Windows.Forms.TextBox
Me.txtF40RFAD1 = New System.Windows.Forms.TextBox
Me.txtF20RFAD1 = New System.Windows.Forms.TextBox
Me.txtF45HCAD1 = New System.Windows.Forms.TextBox
Me.txtF40HCAD1 = New System.Windows.Forms.TextBox
Me.txtF20HCAD1 = New System.Windows.Forms.TextBox
Me.txtF40GPAD1 = New System.Windows.Forms.TextBox
Me.txtF20GPAD1 = New System.Windows.Forms.TextBox
Me.Label175 = New System.Windows.Forms.Label
Me.Label176 = New System.Windows.Forms.Label
Me.GroupBox20 = New System.Windows.Forms.GroupBox
Me.txtDangerousInboundCargoCLASSAD1 = New System.Windows.Forms.TextBox
Me.DangerousInboundCargoTEUAD1 = New System.Windows.Forms.TextBox
Me.txtDangerousInboundCargoCNTRAD1 = New System.Windows.Forms.TextBox
Me.Label177 = New System.Windows.Forms.Label
Me.Label178 = New System.Windows.Forms.Label
Me.Label179 = New System.Windows.Forms.Label
Me.GroupBox21 = New System.Windows.Forms.GroupBox
Me.txtFTONAD1 = New System.Windows.Forms.TextBox
Me.txtFTEUAD1 = New System.Windows.Forms.TextBox
Me.txtFCNTRAD1 = New System.Windows.Forms.TextBox
Me.Label180 = New System.Windows.Forms.Label
Me.Label181 = New System.Windows.Forms.Label
Me.Label182 = New System.Windows.Forms.Label
Me.Label183 = New System.Windows.Forms.Label
Me.Label184 = New System.Windows.Forms.Label
Me.Label185 = New System.Windows.Forms.Label
Me.Label186 = New System.Windows.Forms.Label
Me.Label187 = New System.Windows.Forms.Label
Me.Label188 = New System.Windows.Forms.Label
Me.Label189 = New System.Windows.Forms.Label
Me.Label190 = New System.Windows.Forms.Label
Me.Label191 = New System.Windows.Forms.Label
Me.Label192 = New System.Windows.Forms.Label
Me.Label193 = New System.Windows.Forms.Label
Me.Label194 = New System.Windows.Forms.Label
Me.Label195 = New System.Windows.Forms.Label
Me.Label196 = New System.Windows.Forms.Label
Me.Label197 = New System.Windows.Forms.Label
Me.Label198 = New System.Windows.Forms.Label
Me.Label199 = New System.Windows.Forms.Label
Me.Label200 = New System.Windows.Forms.Label
Me.Label201 = New System.Windows.Forms.Label
Me.ETASailingSchedule = New System.Windows.Forms.TabPage
Me.TabControl2 = New System.Windows.Forms.TabControl
Me.TabPage3 = New System.Windows.Forms.TabPage
Me.txtKindOfCargoDD = New System.Windows.Forms.TextBox
Me.txtPurposeToPortDD = New System.Windows.Forms.TextBox
Me.txtPositionOfShipInPortDD = New System.Windows.Forms.TextBox
Me.txtNumOfPassengersDD = New System.Windows.Forms.TextBox
Me.txtNumOfCrewDD = New System.Windows.Forms.TextBox
Me.txtCaptionNameDD = New System.Windows.Forms.TextBox
Me.GroupBox10 = New System.Windows.Forms.GroupBox
Me.dtpDateOfBerthDD = New System.Windows.Forms.DateTimePicker
Me.txtTimeOfBerthDD = New System.Windows.Forms.TextBox
Me.txtDateOfBerthDD = New System.Windows.Forms.TextBox
Me.Label77 = New System.Windows.Forms.Label
Me.Label78 = New System.Windows.Forms.Label
Me.GroupBox11 = New System.Windows.Forms.GroupBox
Me.dtpDateOfArrivalPilotOnboardDD = New System.Windows.Forms.DateTimePicker
Me.txtTimeOfArrivalPilotOnboardDD = New System.Windows.Forms.TextBox
Me.txtDateOfArrivalPilotOnboardDD = New System.Windows.Forms.TextBox
Me.Label79 = New System.Windows.Forms.Label
Me.Label80 = New System.Windows.Forms.Label
Me.GroupBox12 = New System.Windows.Forms.GroupBox
Me.txtFWDD = New System.Windows.Forms.TextBox
Me.txtDODD = New System.Windows.Forms.TextBox
Me.txtFODD = New System.Windows.Forms.TextBox
Me.Label81 = New System.Windows.Forms.Label
Me.Label82 = New System.Windows.Forms.Label
Me.Label83 = New System.Windows.Forms.Label
Me.Label84 = New System.Windows.Forms.Label
Me.Label85 = New System.Windows.Forms.Label
Me.Label86 = New System.Windows.Forms.Label
Me.Label87 = New System.Windows.Forms.Label
Me.Label88 = New System.Windows.Forms.Label
Me.Label89 = New System.Windows.Forms.Label
Me.GroupBox13 = New System.Windows.Forms.GroupBox
Me.dtpDateOfArrivalPilotStationDD = New System.Windows.Forms.DateTimePicker
Me.txtTimeOfArrivalPilotStationDD = New System.Windows.Forms.TextBox
Me.txtDateOfArrivalPilotStationDD = New System.Windows.Forms.TextBox
Me.Label90 = New System.Windows.Forms.Label
Me.Label91 = New System.Windows.Forms.Label
Me.TabPage4 = New System.Windows.Forms.TabPage
Me.txtLastDateOfArrivalDD = New System.Windows.Forms.TextBox
Me.txtActualDisplacementDD = New System.Windows.Forms.TextBox
Me.txtAfterDraftDD = New System.Windows.Forms.TextBox
Me.txtforeDraftDD = New System.Windows.Forms.TextBox
Me.GroupBox14 = New System.Windows.Forms.GroupBox
Me.dtpDateCommencingOperationDD = New System.Windows.Forms.DateTimePicker
Me.txtTimeCommencingOperationDD = New System.Windows.Forms.TextBox
Me.txtDateCommencingOperationDD = New System.Windows.Forms.TextBox
Me.Label92 = New System.Windows.Forms.Label
Me.Label93 = New System.Windows.Forms.Label
Me.GroupBox15 = New System.Windows.Forms.GroupBox
Me.cboNextPortDD = New System.Windows.Forms.TextBox
Me.cboDis_LoadPortDD = New System.Windows.Forms.TextBox
Me.cboPreviousPortDD = New System.Windows.Forms.TextBox
Me.Label94 = New System.Windows.Forms.Label
Me.Label95 = New System.Windows.Forms.Label
Me.Label96 = New System.Windows.Forms.Label
Me.Label97 = New System.Windows.Forms.Label
Me.Label98 = New System.Windows.Forms.Label
Me.Label99 = New System.Windows.Forms.Label
Me.Label100 = New System.Windows.Forms.Label
Me.TabPage8 = New System.Windows.Forms.TabPage
Me.TabControl4 = New System.Windows.Forms.TabControl
Me.TabPage9 = New System.Windows.Forms.TabPage
Me.txtE20TKDD = New System.Windows.Forms.TextBox
Me.txtE40TKDD = New System.Windows.Forms.TextBox
Me.txtE40OTDD = New System.Windows.Forms.TextBox
Me.txtE20OTDD = New System.Windows.Forms.TextBox
Me.txtE40GHDD = New System.Windows.Forms.TextBox
Me.txtE40HGDD = New System.Windows.Forms.TextBox
Me.txtE20HGDD = New System.Windows.Forms.TextBox
Me.txtE40FRDD = New System.Windows.Forms.TextBox
Me.txtE20FRDD = New System.Windows.Forms.TextBox
Me.txtE45RHDD = New System.Windows.Forms.TextBox
Me.txtE40RHDD = New System.Windows.Forms.TextBox
Me.txtE20RHDD = New System.Windows.Forms.TextBox
Me.txtE40RFDD = New System.Windows.Forms.TextBox
Me.txtE20RFDD = New System.Windows.Forms.TextBox
Me.txtE45HCDD = New System.Windows.Forms.TextBox
Me.txtE40HCDD = New System.Windows.Forms.TextBox
Me.txtE20HCDD = New System.Windows.Forms.TextBox
Me.txtE40GPDD = New System.Windows.Forms.TextBox
Me.txtE20GPDD = New System.Windows.Forms.TextBox
Me.GroupBox16 = New System.Windows.Forms.GroupBox
Me.txtETONDD = New System.Windows.Forms.TextBox
Me.txtETEUDD = New System.Windows.Forms.TextBox
Me.txtECNTRDD = New System.Windows.Forms.TextBox
Me.Label101 = New System.Windows.Forms.Label
Me.Label102 = New System.Windows.Forms.Label
Me.Label103 = New System.Windows.Forms.Label
Me.Label104 = New System.Windows.Forms.Label
Me.Label105 = New System.Windows.Forms.Label
Me.Label106 = New System.Windows.Forms.Label
Me.Label107 = New System.Windows.Forms.Label
Me.Label108 = New System.Windows.Forms.Label
Me.Label109 = New System.Windows.Forms.Label
Me.Label110 = New System.Windows.Forms.Label
Me.Label111 = New System.Windows.Forms.Label
Me.Label112 = New System.Windows.Forms.Label
Me.Label113 = New System.Windows.Forms.Label
Me.Label114 = New System.Windows.Forms.Label
Me.Label115 = New System.Windows.Forms.Label
Me.Label116 = New System.Windows.Forms.Label
Me.Label117 = New System.Windows.Forms.Label
Me.Label118 = New System.Windows.Forms.Label
Me.Label119 = New System.Windows.Forms.Label
Me.Label120 = New System.Windows.Forms.Label
Me.Label121 = New System.Windows.Forms.Label
Me.Label122 = New System.Windows.Forms.Label
Me.TabPage10 = New System.Windows.Forms.TabPage
Me.txtRemarksDD = New System.Windows.Forms.TextBox
Me.txtOtherConcerningRequirementOfShipDD = New System.Windows.Forms.TextBox
Me.txtF40TKDD = New System.Windows.Forms.TextBox
Me.txtF20TKDD = New System.Windows.Forms.TextBox
Me.txtF40OTDD = New System.Windows.Forms.TextBox
Me.txtF20OTDD = New System.Windows.Forms.TextBox
Me.txtF40GHDD = New System.Windows.Forms.TextBox
Me.txtF40HGDD = New System.Windows.Forms.TextBox
Me.txtF20HGDD = New System.Windows.Forms.TextBox
Me.txtF40FRDD = New System.Windows.Forms.TextBox
Me.txtF20FRDD = New System.Windows.Forms.TextBox
Me.txtF45RHDD = New System.Windows.Forms.TextBox
Me.txtF40RHDD = New System.Windows.Forms.TextBox
Me.txtF20RHDD = New System.Windows.Forms.TextBox
Me.txtF40RFDD = New System.Windows.Forms.TextBox
Me.txtF20RFDD = New System.Windows.Forms.TextBox
Me.txtF45HCDD = New System.Windows.Forms.TextBox
Me.txtF40HCDD = New System.Windows.Forms.TextBox
Me.txtF20HCDD = New System.Windows.Forms.TextBox
Me.txtF40GPDD = New System.Windows.Forms.TextBox
Me.txtF20GPDD = New System.Windows.Forms.TextBox
Me.Label123 = New System.Windows.Forms.Label
Me.Label124 = New System.Windows.Forms.Label
Me.GroupBox17 = New System.Windows.Forms.GroupBox
Me.txtDangerousInboundCargoCLASSDD = New System.Windows.Forms.TextBox
Me.txtDangerousInboundCargoTONSDD = New System.Windows.Forms.TextBox
Me.txtDangerousInboundCargoCNTRDD = New System.Windows.Forms.TextBox
Me.Label125 = New System.Windows.Forms.Label
Me.Label126 = New System.Windows.Forms.Label
Me.Label127 = New System.Windows.Forms.Label
Me.GroupBox18 = New System.Windows.Forms.GroupBox
Me.txtFTONDD = New System.Windows.Forms.TextBox
Me.txtFTEUDD = New System.Windows.Forms.TextBox
Me.txtFCNTRDD = New System.Windows.Forms.TextBox
Me.Label128 = New System.Windows.Forms.Label
Me.Label129 = New System.Windows.Forms.Label
Me.Label130 = New System.Windows.Forms.Label
Me.Label131 = New System.Windows.Forms.Label
Me.Label132 = New System.Windows.Forms.Label
Me.Label133 = New System.Windows.Forms.Label
Me.Label134 = New System.Windows.Forms.Label
Me.Label135 = New System.Windows.Forms.Label
Me.Label136 = New System.Windows.Forms.Label
Me.Label137 = New System.Windows.Forms.Label
Me.Label138 = New System.Windows.Forms.Label
Me.Label139 = New System.Windows.Forms.Label
Me.Label140 = New System.Windows.Forms.Label
Me.Label141 = New System.Windows.Forms.Label
Me.Label142 = New System.Windows.Forms.Label
Me.Label143 = New System.Windows.Forms.Label
Me.Label145 = New System.Windows.Forms.Label
Me.Label146 = New System.Windows.Forms.Label
Me.Label147 = New System.Windows.Forms.Label
Me.Label148 = New System.Windows.Forms.Label
Me.Label149 = New System.Windows.Forms.Label
Me.Label150 = New System.Windows.Forms.Label
Me.TabPage14 = New System.Windows.Forms.TabPage
Me.TabControl6 = New System.Windows.Forms.TabControl
Me.TabPage15 = New System.Windows.Forms.TabPage
Me.txtE40TKDD1 = New System.Windows.Forms.TextBox
Me.txtE20TKDD1 = New System.Windows.Forms.TextBox
Me.txtE40OTDD1 = New System.Windows.Forms.TextBox
Me.txtE20OTDD1 = New System.Windows.Forms.TextBox
Me.txtE40GHDD1 = New System.Windows.Forms.TextBox
Me.txtE40HGDD1 = New System.Windows.Forms.TextBox
Me.txtE20HGDD1 = New System.Windows.Forms.TextBox
Me.txtE20FRDD1 = New System.Windows.Forms.TextBox
Me.txtE40FRDD1 = New System.Windows.Forms.TextBox
Me.txtE45RHDD1 = New System.Windows.Forms.TextBox
Me.txtE40RHDD1 = New System.Windows.Forms.TextBox
Me.txtE20RHDD1 = New System.Windows.Forms.TextBox
Me.txtE40RFDD1 = New System.Windows.Forms.TextBox
Me.txtE20RFDD1 = New System.Windows.Forms.TextBox
Me.txtE45HCDD1 = New System.Windows.Forms.TextBox
Me.txtE40HCDD1 = New System.Windows.Forms.TextBox
Me.txtE20HCDD1 = New System.Windows.Forms.TextBox
Me.txtE40GPDD1 = New System.Windows.Forms.TextBox
Me.txtE20GPDD1 = New System.Windows.Forms.TextBox
Me.GroupBox22 = New System.Windows.Forms.GroupBox
Me.txtETONDD1 = New System.Windows.Forms.TextBox
Me.txtETEUDD1 = New System.Windows.Forms.TextBox
Me.txtECNTRDD1 = New System.Windows.Forms.TextBox
Me.Label202 = New System.Windows.Forms.Label
Me.Label203 = New System.Windows.Forms.Label
Me.Label204 = New System.Windows.Forms.Label
Me.Label205 = New System.Windows.Forms.Label
Me.Label206 = New System.Windows.Forms.Label
Me.Label207 = New System.Windows.Forms.Label
Me.Label208 = New System.Windows.Forms.Label
Me.Label209 = New System.Windows.Forms.Label
Me.Label210 = New System.Windows.Forms.Label
Me.Label211 = New System.Windows.Forms.Label
Me.Label212 = New System.Windows.Forms.Label
Me.Label213 = New System.Windows.Forms.Label
Me.Label214 = New System.Windows.Forms.Label
Me.Label215 = New System.Windows.Forms.Label
Me.Label216 = New System.Windows.Forms.Label
Me.Label217 = New System.Windows.Forms.Label
Me.Label218 = New System.Windows.Forms.Label
Me.Label219 = New System.Windows.Forms.Label
Me.Label220 = New System.Windows.Forms.Label
Me.Label221 = New System.Windows.Forms.Label
Me.Label222 = New System.Windows.Forms.Label
Me.Label223 = New System.Windows.Forms.Label
Me.TabPage16 = New System.Windows.Forms.TabPage
Me.txtRemarksDD1 = New System.Windows.Forms.TextBox
Me.txtOtherConcerningRequirementOfShipDD1 = New System.Windows.Forms.TextBox
Me.txtF40TKDD1 = New System.Windows.Forms.TextBox
Me.txtF20TKDD1 = New System.Windows.Forms.TextBox
Me.txtF40OTDD1 = New System.Windows.Forms.TextBox
Me.txtF20OTDD1 = New System.Windows.Forms.TextBox
Me.txtF40GHDD1 = New System.Windows.Forms.TextBox
Me.txtF40HGDD1 = New System.Windows.Forms.TextBox
Me.txtF20HGDD1 = New System.Windows.Forms.TextBox
Me.txtF40FRDD1 = New System.Windows.Forms.TextBox
Me.txtF20FRDD1 = New System.Windows.Forms.TextBox
Me.txtF45RHDD1 = New System.Windows.Forms.TextBox
Me.txtF40RHDD1 = New System.Windows.Forms.TextBox
Me.txtF20RHDD1 = New System.Windows.Forms.TextBox
Me.txtF40RFDD1 = New System.Windows.Forms.TextBox
Me.txtF20RFDD1 = New System.Windows.Forms.TextBox
Me.txtF45HCDD1 = New System.Windows.Forms.TextBox
Me.txtF40HCDD1 = New System.Windows.Forms.TextBox
Me.txtF20HCDD1 = New System.Windows.Forms.TextBox
Me.txtF40GPDD1 = New System.Windows.Forms.TextBox
Me.txtF20GPDD1 = New System.Windows.Forms.TextBox
Me.Label224 = New System.Windows.Forms.Label
Me.Label225 = New System.Windows.Forms.Label
Me.GroupBox23 = New System.Windows.Forms.GroupBox
Me.txtDangerousInboundCargoCLASSDD1 = New System.Windows.Forms.TextBox
Me.txtDangerousInboundCargoTONSDD1 = New System.Windows.Forms.TextBox
Me.txtDangerousInboundCargoCNTRDD1 = New System.Windows.Forms.TextBox
Me.Label226 = New System.Windows.Forms.Label
Me.Label227 = New System.Windows.Forms.Label
Me.Label228 = New System.Windows.Forms.Label
Me.GroupBox24 = New System.Windows.Forms.GroupBox
Me.txtFTONDD1 = New System.Windows.Forms.TextBox
Me.txtFTEUDD1 = New System.Windows.Forms.TextBox
Me.txtFCNTRDD1 = New System.Windows.Forms.TextBox
Me.Label229 = New System.Windows.Forms.Label
Me.Label230 = New System.Windows.Forms.Label
Me.Label231 = New System.Windows.Forms.Label
Me.Label232 = New System.Windows.Forms.Label
Me.Label233 = New System.Windows.Forms.Label
Me.Label234 = New System.Windows.Forms.Label
Me.Label235 = New System.Windows.Forms.Label
Me.Label236 = New System.Windows.Forms.Label
Me.Label237 = New System.Windows.Forms.Label
Me.Label238 = New System.Windows.Forms.Label
Me.Label239 = New System.Windows.Forms.Label
Me.Label240 = New System.Windows.Forms.Label
Me.Label241 = New System.Windows.Forms.Label
Me.Label242 = New System.Windows.Forms.Label
Me.Label243 = New System.Windows.Forms.Label
Me.Label244 = New System.Windows.Forms.Label
Me.Label245 = New System.Windows.Forms.Label
Me.Label246 = New System.Windows.Forms.Label
Me.Label247 = New System.Windows.Forms.Label
Me.Label248 = New System.Windows.Forms.Label
Me.Label249 = New System.Windows.Forms.Label
Me.Label250 = New System.Windows.Forms.Label
Me.cxtPort = New System.Windows.Forms.ContextMenuStrip(Me.components)
Me.cxtsmnuPort = New System.Windows.Forms.ToolStripMenuItem
Me.ctmnuPrice = New System.Windows.Forms.ContextMenuStrip(Me.components)
Me.ctmnuAdd = New System.Windows.Forms.ToolStripMenuItem
Me.ctmnuEdit = New System.Windows.Forms.ToolStripMenuItem
Me.ctmnuDel = New System.Windows.Forms.ToolStripMenuItem
Me.cxtPortTranship = New System.Windows.Forms.ContextMenuStrip(Me.components)
Me.cxtsmnuPortTranship = New System.Windows.Forms.ToolStripMenuItem
Me.cmdCancel = New System.Windows.Forms.Button
Me.cmdOk = New System.Windows.Forms.Button
Me.MenuStrip.SuspendLayout
CType(Me.dgdBoardingAgent,System.ComponentModel.ISupportInitialize).BeginInit
Me.fraUpdate.SuspendLayout
Me.TabPage5.SuspendLayout
Me.tbcSailingSchedule.SuspendLayout
Me.TabControl1.SuspendLayout
Me.lbl.SuspendLayout
Me.GroupBox25.SuspendLayout
Me.GroupBox4.SuspendLayout
Me.GroupBox3.SuspendLayout
Me.GroupBox2.SuspendLayout
Me.GroupBox1.SuspendLayout
Me.TabPage1.SuspendLayout
Me.GroupBox6.SuspendLayout
Me.GroupBox5.SuspendLayout
Me.TabPage2.SuspendLayout
Me.TabControl3.SuspendLayout
Me.TabPage6.SuspendLayout
Me.GroupBox7.SuspendLayout
Me.TabPage7.SuspendLayout
Me.GroupBox9.SuspendLayout
Me.GroupBox8.SuspendLayout
Me.TabPage11.SuspendLayout
Me.TabControl5.SuspendLayout
Me.TabPage12.SuspendLayout
Me.GroupBox19.SuspendLayout
Me.TabPage13.SuspendLayout
Me.GroupBox20.SuspendLayout
Me.GroupBox21.SuspendLayout
Me.ETASailingSchedule.SuspendLayout
Me.TabControl2.SuspendLayout
Me.TabPage3.SuspendLayout
Me.GroupBox10.SuspendLayout
Me.GroupBox11.SuspendLayout
Me.GroupBox12.SuspendLayout
Me.GroupBox13.SuspendLayout
Me.TabPage4.SuspendLayout
Me.GroupBox14.SuspendLayout
Me.GroupBox15.SuspendLayout
Me.TabPage8.SuspendLayout
Me.TabControl4.SuspendLayout
Me.TabPage9.SuspendLayout
Me.GroupBox16.SuspendLayout
Me.TabPage10.SuspendLayout
Me.GroupBox17.SuspendLayout
Me.GroupBox18.SuspendLayout
Me.TabPage14.SuspendLayout
Me.TabControl6.SuspendLayout
Me.TabPage15.SuspendLayout
Me.GroupBox22.SuspendLayout
Me.TabPage16.SuspendLayout
Me.GroupBox23.SuspendLayout
Me.GroupBox24.SuspendLayout
Me.cxtPort.SuspendLayout
Me.ctmnuPrice.SuspendLayout
Me.cxtPortTranship.SuspendLayout
Me.SuspendLayout
'
'cmdFind
'
Me.cmdFind.ForeColor = System.Drawing.Color.Blue
Me.cmdFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.cmdFind.Location = New System.Drawing.Point(595, 25)
Me.cmdFind.Name = "cmdFind"
Me.cmdFind.Size = New System.Drawing.Size(77, 21)
Me.cmdFind.TabIndex = 9
Me.cmdFind.Text = "&Find"
Me.cmdFind.UseVisualStyleBackColor = true
'
'FindBoardingAgent
'
Me.FindBoardingAgent.Font = New System.Drawing.Font("Arial", 8.25!)
Me.FindBoardingAgent.Location = New System.Drawing.Point(171, 25)
Me.FindBoardingAgent.Name = "FindBoardingAgent"
Me.FindBoardingAgent.Size = New System.Drawing.Size(396, 20)
Me.FindBoardingAgent.TabIndex = 8
'
'cboFind
'
Me.cboFind.Font = New System.Drawing.Font("Arial", 8.25!)
Me.cboFind.FormattingEnabled = true
Me.cboFind.Location = New System.Drawing.Point(12, 25)
Me.cboFind.Name = "cboFind"
Me.cboFind.Size = New System.Drawing.Size(143, 22)
Me.cboFind.TabIndex = 7
'
'MenuStrip
'
Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuExportExcel, Me.ExportExcelFromToolStripMenuItem, Me.mnuReport, Me.smnuExit})
Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
Me.MenuStrip.Name = "MenuStrip"
Me.MenuStrip.Size = New System.Drawing.Size(804, 24)
Me.MenuStrip.TabIndex = 6
Me.MenuStrip.Text = "MenuStrip"
'
'smnuSearch
'
Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
Me.smnuSearch.Name = "smnuSearch"
Me.smnuSearch.Size = New System.Drawing.Size(52, 20)
Me.smnuSearch.Text = "Search"
'
'smnuAdd
'
Me.smnuAdd.ForeColor = System.Drawing.Color.Maroon
Me.smnuAdd.Name = "smnuAdd"
Me.smnuAdd.Size = New System.Drawing.Size(40, 20)
Me.smnuAdd.Text = "&New"
'
'smnuEdit
'
Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
Me.smnuEdit.Name = "smnuEdit"
Me.smnuEdit.Size = New System.Drawing.Size(37, 20)
Me.smnuEdit.Text = "&Edit"
'
'smnuDelete
'
Me.smnuDelete.ForeColor = System.Drawing.Color.Maroon
Me.smnuDelete.Name = "smnuDelete"
Me.smnuDelete.Size = New System.Drawing.Size(50, 20)
Me.smnuDelete.Text = "&Delete"
'
'smnuExportExcel
'
Me.smnuExportExcel.ForeColor = System.Drawing.Color.Maroon
Me.smnuExportExcel.Name = "smnuExportExcel"
Me.smnuExportExcel.Size = New System.Drawing.Size(79, 20)
Me.smnuExportExcel.Text = "Export Excel"
'
'ExportExcelFromToolStripMenuItem
'
Me.ExportExcelFromToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
Me.ExportExcelFromToolStripMenuItem.Name = "ExportExcelFromToolStripMenuItem"
Me.ExportExcelFromToolStripMenuItem.Size = New System.Drawing.Size(111, 20)
Me.ExportExcelFromToolStripMenuItem.Text = "Export Excel(From)"
'
'mnuReport
'
Me.mnuReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeclarationOfDepartureToolStripMenuItem, Me.ForeignVesselApplicaitonForArrivalToolStripMenuItem, Me.PermissionForForeignVesselToolStripMenuItem})
Me.mnuReport.ForeColor = System.Drawing.Color.Maroon
Me.mnuReport.Name = "mnuReport"
Me.mnuReport.Size = New System.Drawing.Size(52, 20)
Me.mnuReport.Text = "Report"
'
'DeclarationOfDepartureToolStripMenuItem
'
Me.DeclarationOfDepartureToolStripMenuItem.Name = "DeclarationOfDepartureToolStripMenuItem"
Me.DeclarationOfDepartureToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
Me.DeclarationOfDepartureToolStripMenuItem.Text = "Declaration Of Arrival && Departure"
'
'ForeignVesselApplicaitonForArrivalToolStripMenuItem
'
Me.ForeignVesselApplicaitonForArrivalToolStripMenuItem.Name = "ForeignVesselApplicaitonForArrivalToolStripMenuItem"
Me.ForeignVesselApplicaitonForArrivalToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
Me.ForeignVesselApplicaitonForArrivalToolStripMenuItem.Text = "Foreign Vessel Applicaiton For Arrival"
'
'PermissionForForeignVesselToolStripMenuItem
'
Me.PermissionForForeignVesselToolStripMenuItem.Name = "PermissionForForeignVesselToolStripMenuItem"
Me.PermissionForForeignVesselToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
Me.PermissionForForeignVesselToolStripMenuItem.Text = "Permission for Foreign Vessel"
'
'smnuExit
'
Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
Me.smnuExit.Name = "smnuExit"
Me.smnuExit.Size = New System.Drawing.Size(37, 20)
Me.smnuExit.Text = "E&xit"
'
'dgdBoardingAgent
'
Me.dgdBoardingAgent.AllowUserToAddRows = false
Me.dgdBoardingAgent.AllowUserToDeleteRows = false
Me.dgdBoardingAgent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
Me.dgdBoardingAgent.BackgroundColor = System.Drawing.Color.DarkSlateGray
DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.dgdBoardingAgent.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
Me.dgdBoardingAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.dgdBoardingAgent.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BoardingagentID, Me.shipCode, Me.Vessel, Me.VoyageNoOnArrival, Me.VoyageNoOnDeparture, Me.ServiceTerm, Me.OperatorName, Me.AgentName, Me.OwnerName, Me.DateOfArrivalAD, Me.TimeOfArrivalAD, Me.CaptionNameAD, Me.NumOfCrewAD, Me.NumOfPassengersAD, Me.PositionOfShipInPortAD, Me.PurposeToPortAD, Me.KindOfCargoAD, Me.FOAD, Me.DOAD, Me.FWAD, Me.DateOfArrivalPilotStationAD, Me.TimeOfArrivalPilotStationAD, Me.DateOfArrivalPilotOnboardAD, Me.TimeOfArrivalPilotOnboardAD, Me.DateOfBerthAD, Me.TimeOfBerthAD, Me.foreDraftAD, Me.AfterDraftAD, Me.ActualDisplacementAD, Me.LastDateOfArrivalAD, Me.PreviousPortAD, Me.Dis_LoadPortAD, Me.NextPortAD, Me.DateCommencingOperationAD, Me.TimeCommencingOperationAD, Me.E20GPAD, Me.E40GPAD, Me.E20HCAD, Me.E40HCAD, Me.E45HCAD, Me.E20RFAD, Me.E40RFAD, Me.E20RHAD, Me.E40RHAD, Me.E45RHAD, Me.E20FRAD, Me.E40FRAD, Me.E20HGAD, Me.E40HGAD, Me.E40GHAD, Me.E20OTAD, Me.E40OTAD, Me.E20TKAD, Me.E40TKAD, Me.ECNTRAD, Me.ETEUAD, Me.ETONSAD, Me.F20GPAD, Me.F40GPAD, Me.F20HCAD, Me.F40HCAD, Me.F45HCAD, Me.F20RFAD, Me.F40RFAD, Me.F20RHAD, Me.F40RHAD, Me.F45RHAD, Me.F20FRAD, Me.F40FRAD, Me.F20HGAD, Me.F40HGAD, Me.F40GHAD, Me.F20OTAD, Me.F40OTAD, Me.F20TKAD, Me.F40TKAD, Me.FCNTRAD, Me.FTEUAD, Me.FTONSAD, Me.DangerousInboundCargoCNTRAD, Me.DangerousInboundCargoTONSAD, Me.DangerousInboundCargoCLASSAD, Me.OtherConcerningRequirementOfShipAD, Me.RemaksAD, Me.CaptionNameDD, Me.NumOfCrewDD, Me.NumOfPassengersDD, Me.PositionOfShipInPortDD, Me.PurposeToPortDD, Me.KindOfCargoDD, Me.FODD, Me.DODD, Me.FWDD, Me.DateOfArrivalPilotStationDD, Me.TimeOfArrivalPilotStationDD, Me.DateOfArrivalPilotOnboardDD, Me.TimeOfArrivalPilotOnboardDD, Me.DateOfBerthDD, Me.TimeOfBerthDD, Me.foreDraftDD, Me.AfterDraftDD, Me.ActualDisplacementDD, Me.LastDateOfArrivalDD, Me.PreviousPortDD, Me.Dis_LoadPortDD, Me.NextPortDD, Me.DateCommencingOperationDD, Me.TimeCommencingOperationDD, Me.E20GPDD, Me.E40GPDD, Me.E20HCDD, Me.E40HCDD, Me.E45HCDD, Me.E20RFDD, Me.E40RFDD, Me.E20RHDD, Me.E40RHDD, Me.E45RHDD, Me.E20FRDD, Me.E40FRDD, Me.E20HGDD, Me.E40HGDD, Me.E40GHDD, Me.E20OTDD, Me.E40OTDD, Me.E20TKDD, Me.E40TKDD, Me.ECNTRDD, Me.ETEUDD, Me.ETONSDD, Me.F20GPDD, Me.F40GPDD, Me.F20HCDD, Me.F40HCDD, Me.F45HCDD, Me.F20RFDD, Me.F40RFDD, Me.F20RHDD, Me.F40RHDD, Me.F45RHDD, Me.F20FRDD, Me.F40FRDD, Me.F20HGDD, Me.F40HGDD, Me.F40GHDD, Me.F20OTDD, Me.F40OTDD, Me.F20TKDD, Me.F40TKDD, Me.FCNTRDD, Me.FTEUDD, Me.FTONSDD, Me.DangerousInboundCargoCNTRDD, Me.DangerousInboundCargoTONSDD, Me.DangerousInboundCargoCLASSDD, Me.OtherConcerningRequirementOfShipDD, Me.RemarksDD, Me.E20GPAD1, Me.E40GPAD1, Me.E20HCAD1, Me.E40HCAD1, Me.E45HCAD1, Me.E20RFAD1, Me.E40RFAD1, Me.E20RHAD1, Me.E40RHAD1, Me.E45RHAD1, Me.E20FRAD1, Me.E40FRAD1, Me.E20HGAD1, Me.E40HGAD1, Me.E40GHAD1, Me.E20OTAD1, Me.E40OTAD1, Me.E20TKAD1, Me.E40TKAD1, Me.ECNTRAD1, Me.ETEUAD1, Me.ETONSAD1, Me.F20GPAD1, Me.F40GPAD1, Me.F20HCAD1, Me.F40HCAD1, Me.F45HCAD1, Me.F20RFAD1, Me.F40RFAD1, Me.F20RHAD1, Me.F40RHAD1, Me.F45RHAD1, Me.F20FRAD1, Me.F40FRAD1, Me.F20HGAD1, Me.F40HGAD1, Me.F40GHAD1, Me.F20OTAD1, Me.F40OTAD1, Me.F20TKAD1, Me.F40TKAD1, Me.FCNTRAD1, Me.FTEUAD1, Me.FTONSAD1, Me.DangerousInboundCargoCNTRAD1, Me.DangerousInboundCargoTONSAD1, Me.DangerousInboundCargoCLASSAD1, Me.OtherConcerningRequirementOfShipAD1, Me.RemaksAD1, Me.E20GPDD1, Me.E40GPDD1, Me.E20HCDD1, Me.E40HCDD1, Me.E45HCDD1, Me.E20RFDD1, Me.E40RFDD1, Me.E20RHDD1, Me.E40RHDD1, Me.E45RHDD1, Me.E20FRDD1, Me.E40FRDD1, Me.E20HGDD1, Me.E40HGDD1, Me.E40GHDD1, Me.E20OTDD1, Me.E40OTDD1, Me.E20TKDD1, Me.E40TKDD1, Me.ECNTRDD1, Me.ETEUDD1, Me.ETONSDD1, Me.F20GPDD1, Me.F40GPDD1, Me.F20HCDD1, Me.F40HCDD1, Me.F45HCDD1, Me.F20RFDD1, Me.F40RFDD1, Me.F20RHDD1, Me.F40RHDD1, Me.F45RHDD1, Me.F20FRDD1, Me.F40FRDD1, Me.F20HGDD1, Me.F40HGDD1, Me.F40GHDD1, Me.F20OTDD1, Me.F40OTDD1, Me.F20TKDD1, Me.F40TKDD1, Me.FCNTRDD1, Me.FTEUDD1, Me.FTONSDD1, Me.DangerousInboundCargoCNTRDD1, Me.DangerousInboundCargoTONSDD1, Me.DangerousInboundCargoCLASSDD1, Me.OtherConcerningRequirementOfShipDD1, Me.ApplicationForArrivalDate, Me.TheApprovalPort, Me.ApproveArrival, Me.Editable, Me.Continued, Me.Approve, Me.UserUpdate, Me.UpdateTime})
DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
Me.dgdBoardingAgent.DefaultCellStyle = DataGridViewCellStyle2
Me.dgdBoardingAgent.Location = New System.Drawing.Point(12, 51)
Me.dgdBoardingAgent.Name = "dgdBoardingAgent"
DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon
DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.dgdBoardingAgent.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
Me.dgdBoardingAgent.Size = New System.Drawing.Size(776, 130)
Me.dgdBoardingAgent.TabIndex = 20
'
'BoardingagentID
'
Me.BoardingagentID.DataPropertyName = "BoardingagentID"
Me.BoardingagentID.HeaderText = "BoardingagentID"
Me.BoardingagentID.Name = "BoardingagentID"
Me.BoardingagentID.Visible = false
'
'shipCode
'
Me.shipCode.DataPropertyName = "shipCode"
Me.shipCode.HeaderText = "Ship Code"
Me.shipCode.Name = "shipCode"
'
'Vessel
'
Me.Vessel.DataPropertyName = "Vessel"
Me.Vessel.HeaderText = "Vessel"
Me.Vessel.Name = "Vessel"
'
'VoyageNoOnArrival
'
Me.VoyageNoOnArrival.DataPropertyName = "VoyageNoOnArrival"
Me.VoyageNoOnArrival.HeaderText = "Voyage No On Arrival"
Me.VoyageNoOnArrival.Name = "VoyageNoOnArrival"
'
'VoyageNoOnDeparture
'
Me.VoyageNoOnDeparture.DataPropertyName = "VoyageNoOnDeparture"
Me.VoyageNoOnDeparture.HeaderText = "Voyage No On Departure"
Me.VoyageNoOnDeparture.Name = "VoyageNoOnDeparture"
'
'ServiceTerm
'
Me.ServiceTerm.DataPropertyName = "ServiceTerm"
Me.ServiceTerm.HeaderText = "Service Term"
Me.ServiceTerm.Name = "ServiceTerm"
'
'OperatorName
'
Me.OperatorName.DataPropertyName = "OperatorName"
Me.OperatorName.HeaderText = "Operator Name"
Me.OperatorName.Name = "OperatorName"
'
'AgentName
'
Me.AgentName.DataPropertyName = "AgentName"
Me.AgentName.HeaderText = "Agent Name"
Me.AgentName.Name = "AgentName"
'
'OwnerName
'
Me.OwnerName.DataPropertyName = "OwnerName"
Me.OwnerName.HeaderText = "Owner Name"
Me.OwnerName.Name = "OwnerName"
'
'DateOfArrivalAD
'
Me.DateOfArrivalAD.DataPropertyName = "DateOfArrivalAD"
Me.DateOfArrivalAD.HeaderText = "Date Of Arrival(AD)"
Me.DateOfArrivalAD.Name = "DateOfArrivalAD"
'
'TimeOfArrivalAD
'
Me.TimeOfArrivalAD.DataPropertyName = "TimeOfArrivalAD"
Me.TimeOfArrivalAD.HeaderText = "Time Of Arrival (AD)"
Me.TimeOfArrivalAD.Name = "TimeOfArrivalAD"
'
'CaptionNameAD
'
Me.CaptionNameAD.DataPropertyName = "CaptionNameAD"
Me.CaptionNameAD.HeaderText = "Captain Name (AD)"
Me.CaptionNameAD.Name = "CaptionNameAD"
'
'NumOfCrewAD
'
Me.NumOfCrewAD.DataPropertyName = "NumOfCrewAD"
Me.NumOfCrewAD.HeaderText = "Num Of Crew (AD)"
Me.NumOfCrewAD.Name = "NumOfCrewAD"
'
'NumOfPassengersAD
'
Me.NumOfPassengersAD.DataPropertyName = "NumOfPassengersAD"
Me.NumOfPassengersAD.HeaderText = "Num Of Passengers (AD)"
Me.NumOfPassengersAD.Name = "NumOfPassengersAD"
'
'PositionOfShipInPortAD
'
Me.PositionOfShipInPortAD.DataPropertyName = "PositionOfShipInPortAD"
Me.PositionOfShipInPortAD.HeaderText = "Position Of Ship InPort (AD)"
Me.PositionOfShipInPortAD.Name = "PositionOfShipInPortAD"
'
'PurposeToPortAD
'
Me.PurposeToPortAD.DataPropertyName = "PurposeToPortAD"
Me.PurposeToPortAD.HeaderText = "Purpose To Port(AD)"
Me.PurposeToPortAD.Name = "PurposeToPortAD"
'
'KindOfCargoAD
'
Me.KindOfCargoAD.DataPropertyName = "KindOfCargoAD"
Me.KindOfCargoAD.HeaderText = "Kind Of Cargo(AD)"
Me.KindOfCargoAD.Name = "KindOfCargoAD"
'
'FOAD
'
Me.FOAD.DataPropertyName = "FOAD"
Me.FOAD.HeaderText = "FO (AD)"
Me.FOAD.Name = "FOAD"
'
'DOAD
'
Me.DOAD.DataPropertyName = "DOAD"
Me.DOAD.HeaderText = "DO (AD)"
Me.DOAD.Name = "DOAD"
'
'FWAD
'
Me.FWAD.DataPropertyName = "FWAD"
Me.FWAD.HeaderText = "FW(AD)"
Me.FWAD.Name = "FWAD"
'
'DateOfArrivalPilotStationAD
'
Me.DateOfArrivalPilotStationAD.DataPropertyName = "DateOfArrivalPilotStationAD"
Me.DateOfArrivalPilotStationAD.HeaderText = "Date Of Arrival Pilot Station (AD)"
Me.DateOfArrivalPilotStationAD.Name = "DateOfArrivalPilotStationAD"
'
'TimeOfArrivalPilotStationAD
'
Me.TimeOfArrivalPilotStationAD.DataPropertyName = "TimeOfArrivalPilotStationAD"
Me.TimeOfArrivalPilotStationAD.HeaderText = "Time Of Arrival Pilot Station (AD)"
Me.TimeOfArrivalPilotStationAD.Name = "TimeOfArrivalPilotStationAD"
'
'DateOfArrivalPilotOnboardAD
'
Me.DateOfArrivalPilotOnboardAD.DataPropertyName = "DateOfArrivalPilotOnboardAD"
Me.DateOfArrivalPilotOnboardAD.HeaderText = "Date Of Arrival Pilot Onboard (AD)"
Me.DateOfArrivalPilotOnboardAD.Name = "DateOfArrivalPilotOnboardAD"
'
'TimeOfArrivalPilotOnboardAD
'
Me.TimeOfArrivalPilotOnboardAD.DataPropertyName = "TimeOfArrivalPilotOnboardAD"
Me.TimeOfArrivalPilotOnboardAD.HeaderText = "Time Of Arrival Pilot Onboard (AD)"
Me.TimeOfArrivalPilotOnboardAD.Name = "TimeOfArrivalPilotOnboardAD"
'
'DateOfBerthAD
'
Me.DateOfBerthAD.DataPropertyName = "DateOfBerthAD"
Me.DateOfBerthAD.HeaderText = "Date Of Berth (AD)"
Me.DateOfBerthAD.Name = "DateOfBerthAD"
'
'TimeOfBerthAD
'
Me.TimeOfBerthAD.DataPropertyName = "TimeOfBerthAD"
Me.TimeOfBerthAD.HeaderText = "Time Of Berth (AD)"
Me.TimeOfBerthAD.Name = "TimeOfBerthAD"
'
'foreDraftAD
'
Me.foreDraftAD.DataPropertyName = "foreDraftAD"
Me.foreDraftAD.HeaderText = "fore Draft (AD)"
Me.foreDraftAD.Name = "foreDraftAD"
'
'AfterDraftAD
'
Me.AfterDraftAD.DataPropertyName = "AfterDraftAD"
Me.AfterDraftAD.HeaderText = "After Draft (AD)"
Me.AfterDraftAD.Name = "AfterDraftAD"
'
'ActualDisplacementAD
'
Me.ActualDisplacementAD.DataPropertyName = "ActualDisplacementAD"
Me.ActualDisplacementAD.HeaderText = "Actual Displacement (AD)"
Me.ActualDisplacementAD.Name = "ActualDisplacementAD"
'
'LastDateOfArrivalAD
'
Me.LastDateOfArrivalAD.DataPropertyName = "LastDateOfArrivalAD"
Me.LastDateOfArrivalAD.HeaderText = "Last Date Of Arrival (AD)"
Me.LastDateOfArrivalAD.Name = "LastDateOfArrivalAD"
'
'PreviousPortAD
'
Me.PreviousPortAD.DataPropertyName = "PreviousPortAD"
Me.PreviousPortAD.HeaderText = "Previous Port (AD)"
Me.PreviousPortAD.Name = "PreviousPortAD"
'
'Dis_LoadPortAD
'
Me.Dis_LoadPortAD.DataPropertyName = "Dis_LoadPortAD"
Me.Dis_LoadPortAD.HeaderText = "Dis_Load Port (AD)"
Me.Dis_LoadPortAD.Name = "Dis_LoadPortAD"
'
'NextPortAD
'
Me.NextPortAD.DataPropertyName = "NextPortAD"
Me.NextPortAD.HeaderText = "Next Port (AD)"
Me.NextPortAD.Name = "NextPortAD"
'
'DateCommencingOperationAD
'
Me.DateCommencingOperationAD.DataPropertyName = "DateCommencingOperationAD"
Me.DateCommencingOperationAD.HeaderText = "Date Commencing Operation (AD)"
Me.DateCommencingOperationAD.Name = "DateCommencingOperationAD"
'
'TimeCommencingOperationAD
'
Me.TimeCommencingOperationAD.DataPropertyName = "TimeCommencingOperationAD"
Me.TimeCommencingOperationAD.HeaderText = "Time Commencing Operation (AD)"
Me.TimeCommencingOperationAD.Name = "TimeCommencingOperationAD"
'
'E20GPAD
'
Me.E20GPAD.DataPropertyName = "E20GPAD"
Me.E20GPAD.HeaderText = "E20GPAD"
Me.E20GPAD.Name = "E20GPAD"
'
'E40GPAD
'
Me.E40GPAD.DataPropertyName = "E40GPAD"
Me.E40GPAD.HeaderText = "E40GPAD"
Me.E40GPAD.Name = "E40GPAD"
'
'E20HCAD
'
Me.E20HCAD.DataPropertyName = "E20HCAD"
Me.E20HCAD.HeaderText = "E20HCAD"
Me.E20HCAD.Name = "E20HCAD"
'
'E40HCAD
'
Me.E40HCAD.DataPropertyName = "E40HCAD"
Me.E40HCAD.HeaderText = "E40HCAD"
Me.E40HCAD.Name = "E40HCAD"
'
'E45HCAD
'
Me.E45HCAD.DataPropertyName = "E45HCAD"
Me.E45HCAD.HeaderText = "E45HCAD"
Me.E45HCAD.Name = "E45HCAD"
'
'E20RFAD
'
Me.E20RFAD.DataPropertyName = "E20RFAD"
Me.E20RFAD.HeaderText = "E20RFAD"
Me.E20RFAD.Name = "E20RFAD"
'
'E40RFAD
'
Me.E40RFAD.DataPropertyName = "E40RFAD"
Me.E40RFAD.HeaderText = "E40RFAD"
Me.E40RFAD.Name = "E40RFAD"
'
'E20RHAD
'
Me.E20RHAD.DataPropertyName = "E20RHAD"
Me.E20RHAD.HeaderText = "E20RHAD"
Me.E20RHAD.Name = "E20RHAD"
'
'E40RHAD
'
Me.E40RHAD.DataPropertyName = "E40RHAD"
Me.E40RHAD.HeaderText = "E40RHAD"
Me.E40RHAD.Name = "E40RHAD"
'
'E45RHAD
'
Me.E45RHAD.DataPropertyName = "E45RHAD"
Me.E45RHAD.HeaderText = "E45RHAD"
Me.E45RHAD.Name = "E45RHAD"
'
'E20FRAD
'
Me.E20FRAD.DataPropertyName = "E20FRAD"
Me.E20FRAD.HeaderText = "E20FRAD"
Me.E20FRAD.Name = "E20FRAD"
'
'E40FRAD
'
Me.E40FRAD.DataPropertyName = "E40FRAD"
Me.E40FRAD.HeaderText = "E40FRAD"
Me.E40FRAD.Name = "E40FRAD"
'
'E20HGAD
'
Me.E20HGAD.DataPropertyName = "E20HGAD"
Me.E20HGAD.HeaderText = "E20HGAD"
Me.E20HGAD.Name = "E20HGAD"
'
'E40HGAD
'
Me.E40HGAD.DataPropertyName = "E40HGAD"
Me.E40HGAD.HeaderText = "E40HGAD"
Me.E40HGAD.Name = "E40HGAD"
'
'E40GHAD
'
Me.E40GHAD.DataPropertyName = "E40GHAD"
Me.E40GHAD.HeaderText = "E40GHAD"
Me.E40GHAD.Name = "E40GHAD"
'
'E20OTAD
'
Me.E20OTAD.DataPropertyName = "E20OTAD"
Me.E20OTAD.HeaderText = "E20OTAD"
Me.E20OTAD.Name = "E20OTAD"
'
'E40OTAD
'
Me.E40OTAD.DataPropertyName = "E40OTAD"
Me.E40OTAD.HeaderText = "E40OTAD"
Me.E40OTAD.Name = "E40OTAD"
'
'E20TKAD
'
Me.E20TKAD.DataPropertyName = "E20TKAD"
Me.E20TKAD.HeaderText = "E20TKAD"
Me.E20TKAD.Name = "E20TKAD"
'
'E40TKAD
'
Me.E40TKAD.DataPropertyName = "E40TKAD"
Me.E40TKAD.HeaderText = "E40TKAD"
Me.E40TKAD.Name = "E40TKAD"
'
'ECNTRAD
'
Me.ECNTRAD.DataPropertyName = "ECNTRAD"
Me.ECNTRAD.HeaderText = "ECNTRAD"
Me.ECNTRAD.Name = "ECNTRAD"
'
'ETEUAD
'
Me.ETEUAD.DataPropertyName = "ETEUAD"
Me.ETEUAD.HeaderText = "ETEUAD"
Me.ETEUAD.Name = "ETEUAD"
'
'ETONSAD
'
Me.ETONSAD.DataPropertyName = "ETONSAD"
Me.ETONSAD.HeaderText = "ETONSAD"
Me.ETONSAD.Name = "ETONSAD"
'
'F20GPAD
'
Me.F20GPAD.DataPropertyName = "F20GPAD"
Me.F20GPAD.HeaderText = "F20GPAD"
Me.F20GPAD.Name = "F20GPAD"
'
'F40GPAD
'
Me.F40GPAD.DataPropertyName = "F40GPAD"
Me.F40GPAD.HeaderText = "F40GPAD"
Me.F40GPAD.Name = "F40GPAD"
'
'F20HCAD
'
Me.F20HCAD.DataPropertyName = "F20HCAD"
Me.F20HCAD.HeaderText = "F20HCAD"
Me.F20HCAD.Name = "F20HCAD"
'
'F40HCAD
'
Me.F40HCAD.DataPropertyName = "F40HCAD"
Me.F40HCAD.HeaderText = "F40HCAD"
Me.F40HCAD.Name = "F40HCAD"
'
'F45HCAD
'
Me.F45HCAD.DataPropertyName = "F45HCAD"
Me.F45HCAD.HeaderText = "F45HCAD"
Me.F45HCAD.Name = "F45HCAD"
'
'F20RFAD
'
Me.F20RFAD.DataPropertyName = "F20RFAD"
Me.F20RFAD.HeaderText = "F20RFAD"
Me.F20RFAD.Name = "F20RFAD"
'
'F40RFAD
'
Me.F40RFAD.DataPropertyName = "F40RFAD"
Me.F40RFAD.HeaderText = "F40RFAD"
Me.F40RFAD.Name = "F40RFAD"
'
'F20RHAD
'
Me.F20RHAD.DataPropertyName = "F20RHAD"
Me.F20RHAD.HeaderText = "F20RHAD"
Me.F20RHAD.Name = "F20RHAD"
'
'F40RHAD
'
Me.F40RHAD.DataPropertyName = "F40RHAD"
Me.F40RHAD.HeaderText = "F40RHAD"
Me.F40RHAD.Name = "F40RHAD"
'
'F45RHAD
'
Me.F45RHAD.DataPropertyName = "F45RHAD"
Me.F45RHAD.HeaderText = "F45RHAD"
Me.F45RHAD.Name = "F45RHAD"
'
'F20FRAD
'
Me.F20FRAD.DataPropertyName = "F20FRAD"
Me.F20FRAD.HeaderText = "F20FRAD"
Me.F20FRAD.Name = "F20FRAD"
'
'F40FRAD
'
Me.F40FRAD.DataPropertyName = "F40FRAD"
Me.F40FRAD.HeaderText = "F40FRAD"
Me.F40FRAD.Name = "F40FRAD"
'
'F20HGAD
'
Me.F20HGAD.DataPropertyName = "F20HGAD"
Me.F20HGAD.HeaderText = "F20HGAD"
Me.F20HGAD.Name = "F20HGAD"
'
'F40HGAD
'
Me.F40HGAD.DataPropertyName = "F40HGAD"
Me.F40HGAD.HeaderText = "F40HGAD"
Me.F40HGAD.Name = "F40HGAD"
'
'F40GHAD
'
Me.F40GHAD.DataPropertyName = "F40GHAD"
Me.F40GHAD.HeaderText = "F40GHAD"
Me.F40GHAD.Name = "F40GHAD"
'
'F20OTAD
'
Me.F20OTAD.DataPropertyName = "F20OTAD"
Me.F20OTAD.HeaderText = "F20OTAD"
Me.F20OTAD.Name = "F20OTAD"
'
'F40OTAD
'
Me.F40OTAD.DataPropertyName = "F40OTAD"
Me.F40OTAD.HeaderText = "F40OTAD"
Me.F40OTAD.Name = "F40OTAD"
'
'F20TKAD
'
Me.F20TKAD.DataPropertyName = "F20TKAD"
Me.F20TKAD.HeaderText = "F20TKAD"
Me.F20TKAD.Name = "F20TKAD"
'
'F40TKAD
'
Me.F40TKAD.DataPropertyName = "F40TKAD"
Me.F40TKAD.HeaderText = "F40TKAD"
Me.F40TKAD.Name = "F40TKAD"
'
'FCNTRAD
'
Me.FCNTRAD.DataPropertyName = "FCNTRAD"
Me.FCNTRAD.HeaderText = "FCNTRAD"
Me.FCNTRAD.Name = "FCNTRAD"
'
'FTEUAD
'
Me.FTEUAD.DataPropertyName = "FTEUAD"
Me.FTEUAD.HeaderText = "FTEUAD"
Me.FTEUAD.Name = "FTEUAD"
'
'FTONSAD
'
Me.FTONSAD.DataPropertyName = "FTONSAD"
Me.FTONSAD.HeaderText = "FTONSAD"
Me.FTONSAD.Name = "FTONSAD"
'
'DangerousInboundCargoCNTRAD
'
Me.DangerousInboundCargoCNTRAD.DataPropertyName = "DangerousInboundCargoCNTRAD"
Me.DangerousInboundCargoCNTRAD.HeaderText = "DangerousInboundCargoCNTRAD"
Me.DangerousInboundCargoCNTRAD.Name = "DangerousInboundCargoCNTRAD"
Me.DangerousInboundCargoCNTRAD.Visible = false
'
'DangerousInboundCargoTONSAD
'
Me.DangerousInboundCargoTONSAD.DataPropertyName = "DangerousInboundCargoTONSAD"
Me.DangerousInboundCargoTONSAD.HeaderText = "DangerousInboundCargoTONSAD"
Me.DangerousInboundCargoTONSAD.Name = "DangerousInboundCargoTONSAD"
Me.DangerousInboundCargoTONSAD.Visible = false
'
'DangerousInboundCargoCLASSAD
'
Me.DangerousInboundCargoCLASSAD.DataPropertyName = "DangerousInboundCargoCLASSAD"
Me.DangerousInboundCargoCLASSAD.HeaderText = "DangerousInboundCargoCLASSAD"
Me.DangerousInboundCargoCLASSAD.Name = "DangerousInboundCargoCLASSAD"
Me.DangerousInboundCargoCLASSAD.Visible = false
'
'OtherConcerningRequirementOfShipAD
'
Me.OtherConcerningRequirementOfShipAD.DataPropertyName = "OtherConcerningRequirementOfShipAD"
Me.OtherConcerningRequirementOfShipAD.HeaderText = "OtherConcerningRequirementOfShipAD"
Me.OtherConcerningRequirementOfShipAD.Name = "OtherConcerningRequirementOfShipAD"
'
'RemaksAD
'
Me.RemaksAD.DataPropertyName = "RemaksAD"
Me.RemaksAD.HeaderText = "RemaksAD"
Me.RemaksAD.Name = "RemaksAD"
'
'CaptionNameDD
'
Me.CaptionNameDD.DataPropertyName = "CaptionNameDD"
Me.CaptionNameDD.HeaderText = "Captain Name DD"
Me.CaptionNameDD.Name = "CaptionNameDD"
'
'NumOfCrewDD
'
Me.NumOfCrewDD.DataPropertyName = "NumOfCrewDD"
Me.NumOfCrewDD.HeaderText = "NumOfCrewDD"
Me.NumOfCrewDD.Name = "NumOfCrewDD"
'
'NumOfPassengersDD
'
Me.NumOfPassengersDD.DataPropertyName = "NumOfPassengersDD"
Me.NumOfPassengersDD.HeaderText = "NumOfPassengersDD"
Me.NumOfPassengersDD.Name = "NumOfPassengersDD"
'
'PositionOfShipInPortDD
'
Me.PositionOfShipInPortDD.DataPropertyName = "PositionOfShipInPortDD"
Me.PositionOfShipInPortDD.HeaderText = "PositionOfShipInPortDD"
Me.PositionOfShipInPortDD.Name = "PositionOfShipInPortDD"
'
'PurposeToPortDD
'
Me.PurposeToPortDD.DataPropertyName = "PurposeToPortDD"
Me.PurposeToPortDD.HeaderText = "PurposeToPortDD"
Me.PurposeToPortDD.Name = "PurposeToPortDD"
'
'KindOfCargoDD
'
Me.KindOfCargoDD.DataPropertyName = "KindOfCargoDD"
Me.KindOfCargoDD.HeaderText = "KindOfCargoDD"
Me.KindOfCargoDD.Name = "KindOfCargoDD"
'
'FODD
'
Me.FODD.DataPropertyName = "FODD"
Me.FODD.HeaderText = "FODD"
Me.FODD.Name = "FODD"
'
'DODD
'
Me.DODD.DataPropertyName = "DODD"
Me.DODD.HeaderText = "DODD"
Me.DODD.Name = "DODD"
'
'FWDD
'
Me.FWDD.DataPropertyName = "FWDD"
Me.FWDD.HeaderText = "FWDD"
Me.FWDD.Name = "FWDD"
'
'DateOfArrivalPilotStationDD
'
Me.DateOfArrivalPilotStationDD.DataPropertyName = "DateOfArrivalPilotStationDD"
Me.DateOfArrivalPilotStationDD.HeaderText = "Date Of Arrival Pilot Station (DD)"
Me.DateOfArrivalPilotStationDD.Name = "DateOfArrivalPilotStationDD"
'
'TimeOfArrivalPilotStationDD
'
Me.TimeOfArrivalPilotStationDD.DataPropertyName = "TimeOfArrivalPilotStationDD"
Me.TimeOfArrivalPilotStationDD.HeaderText = "Time Of Arrival Pilot Station (DD)"
Me.TimeOfArrivalPilotStationDD.Name = "TimeOfArrivalPilotStationDD"
'
'DateOfArrivalPilotOnboardDD
'
Me.DateOfArrivalPilotOnboardDD.DataPropertyName = "DateOfArrivalPilotOnboardDD"
Me.DateOfArrivalPilotOnboardDD.HeaderText = "Date Of departure (Pilot)"
Me.DateOfArrivalPilotOnboardDD.Name = "DateOfArrivalPilotOnboardDD"
'
'TimeOfArrivalPilotOnboardDD
'
Me.TimeOfArrivalPilotOnboardDD.DataPropertyName = "TimeOfArrivalPilotOnboardDD"
Me.TimeOfArrivalPilotOnboardDD.HeaderText = "Time Of departure (Pilot)"
Me.TimeOfArrivalPilotOnboardDD.Name = "TimeOfArrivalPilotOnboardDD"
'
'DateOfBerthDD
'
Me.DateOfBerthDD.DataPropertyName = "DateOfBerthDD"
Me.DateOfBerthDD.HeaderText = "Date Of departure (Berth)"
Me.DateOfBerthDD.Name = "DateOfBerthDD"
'
'TimeOfBerthDD
'
Me.TimeOfBerthDD.DataPropertyName = "TimeOfBerthDD"
Me.TimeOfBerthDD.HeaderText = "Time Of departure (Berth)"
Me.TimeOfBerthDD.Name = "TimeOfBerthDD"
'
'foreDraftDD
'
Me.foreDraftDD.DataPropertyName = "foreDraftDD"
Me.foreDraftDD.HeaderText = "fore Draft (DD)"
Me.foreDraftDD.Name = "foreDraftDD"
'
'AfterDraftDD
'
Me.AfterDraftDD.DataPropertyName = "AfterDraftDD"
Me.AfterDraftDD.HeaderText = "After Draft (DD)"
Me.AfterDraftDD.Name = "AfterDraftDD"
'
'ActualDisplacementDD
'
Me.ActualDisplacementDD.DataPropertyName = "ActualDisplacementDD"
Me.ActualDisplacementDD.HeaderText = "Actual Displacement (DD)"
Me.ActualDisplacementDD.Name = "ActualDisplacementDD"
'
'LastDateOfArrivalDD
'
Me.LastDateOfArrivalDD.DataPropertyName = "LastDateOfArrivalDD"
Me.LastDateOfArrivalDD.HeaderText = "Last Date Of Arrival (DD)"
Me.LastDateOfArrivalDD.Name = "LastDateOfArrivalDD"
'
'PreviousPortDD
'
Me.PreviousPortDD.DataPropertyName = "PreviousPortDD"
Me.PreviousPortDD.HeaderText = "Previous Port (DD)"
Me.PreviousPortDD.Name = "PreviousPortDD"
'
'Dis_LoadPortDD
'
Me.Dis_LoadPortDD.DataPropertyName = "Dis_LoadPortDD"
Me.Dis_LoadPortDD.HeaderText = "Dis_Load Port (DD)"
Me.Dis_LoadPortDD.Name = "Dis_LoadPortDD"
'
'NextPortDD
'
Me.NextPortDD.DataPropertyName = "NextPortDD"
Me.NextPortDD.HeaderText = "Next Port (DD)"
Me.NextPortDD.Name = "NextPortDD"
'
'DateCommencingOperationDD
'
Me.DateCommencingOperationDD.DataPropertyName = "DateCommencingOperationDD"
Me.DateCommencingOperationDD.HeaderText = "Date Commencing Operation (DD)"
Me.DateCommencingOperationDD.Name = "DateCommencingOperationDD"
'
'TimeCommencingOperationDD
'
Me.TimeCommencingOperationDD.DataPropertyName = "TimeCommencingOperationDD"
Me.TimeCommencingOperationDD.HeaderText = "Time Commencing Operation (DD)"
Me.TimeCommencingOperationDD.Name = "TimeCommencingOperationDD"
'
'E20GPDD
'
Me.E20GPDD.DataPropertyName = "E20GPDD"
Me.E20GPDD.HeaderText = "E20GPDD"
Me.E20GPDD.Name = "E20GPDD"
'
'E40GPDD
'
Me.E40GPDD.DataPropertyName = "E40GPDD"
Me.E40GPDD.HeaderText = "E40GPDD"
Me.E40GPDD.Name = "E40GPDD"
'
'E20HCDD
'
Me.E20HCDD.DataPropertyName = "E20HCDD"
Me.E20HCDD.HeaderText = "E20HCDD"
Me.E20HCDD.Name = "E20HCDD"
'
'E40HCDD
'
Me.E40HCDD.DataPropertyName = "E40HCDD"
Me.E40HCDD.HeaderText = "E40HCDD"
Me.E40HCDD.Name = "E40HCDD"
'
'E45HCDD
'
Me.E45HCDD.DataPropertyName = "E45HCDD"
Me.E45HCDD.HeaderText = "E45HCDD"
Me.E45HCDD.Name = "E45HCDD"
'
'E20RFDD
'
Me.E20RFDD.DataPropertyName = "E20RFDD"
Me.E20RFDD.HeaderText = "E20RFDD"
Me.E20RFDD.Name = "E20RFDD"
'
'E40RFDD
'
Me.E40RFDD.DataPropertyName = "E40RFDD"
Me.E40RFDD.HeaderText = "E40RFDD"
Me.E40RFDD.Name = "E40RFDD"
'
'E20RHDD
'
Me.E20RHDD.DataPropertyName = "E20RHDD"
Me.E20RHDD.HeaderText = "E20RHDD"
Me.E20RHDD.Name = "E20RHDD"
'
'E40RHDD
'
Me.E40RHDD.DataPropertyName = "E40RHDD"
Me.E40RHDD.HeaderText = "E40RHDD"
Me.E40RHDD.Name = "E40RHDD"
'
'E45RHDD
'
Me.E45RHDD.DataPropertyName = "E45RHDD"
Me.E45RHDD.HeaderText = "E45RHDD"
Me.E45RHDD.Name = "E45RHDD"
'
'E20FRDD
'
Me.E20FRDD.DataPropertyName = "E20FRDD"
Me.E20FRDD.HeaderText = "E20FRDD"
Me.E20FRDD.Name = "E20FRDD"
'
'E40FRDD
'
Me.E40FRDD.DataPropertyName = "E40FRDD"
Me.E40FRDD.HeaderText = "E40FRDD"
Me.E40FRDD.Name = "E40FRDD"
'
'E20HGDD
'
Me.E20HGDD.DataPropertyName = "E20HGDD"
Me.E20HGDD.HeaderText = "E20HGDD"
Me.E20HGDD.Name = "E20HGDD"
'
'E40HGDD
'
Me.E40HGDD.DataPropertyName = "E40HGDD"
Me.E40HGDD.HeaderText = "E40HGDD"
Me.E40HGDD.Name = "E40HGDD"
'
'E40GHDD
'
Me.E40GHDD.DataPropertyName = "E40GHDD"
Me.E40GHDD.HeaderText = "E40GHDD"
Me.E40GHDD.Name = "E40GHDD"
'
'E20OTDD
'
Me.E20OTDD.DataPropertyName = "E20OTDD"
Me.E20OTDD.HeaderText = "E20OTDD"
Me.E20OTDD.Name = "E20OTDD"
'
'E40OTDD
'
Me.E40OTDD.DataPropertyName = "E40OTDD"
Me.E40OTDD.HeaderText = "E40OTDD"
Me.E40OTDD.Name = "E40OTDD"
'
'E20TKDD
'
Me.E20TKDD.DataPropertyName = "E20TKDD"
Me.E20TKDD.HeaderText = "E20TKDD"
Me.E20TKDD.Name = "E20TKDD"
'
'E40TKDD
'
Me.E40TKDD.DataPropertyName = "E40TKDD"
Me.E40TKDD.HeaderText = "E40TKDD"
Me.E40TKDD.Name = "E40TKDD"
'
'ECNTRDD
'
Me.ECNTRDD.DataPropertyName = "ECNTRDD"
Me.ECNTRDD.HeaderText = "ECNTRDD"
Me.ECNTRDD.Name = "ECNTRDD"
'
'ETEUDD
'
Me.ETEUDD.DataPropertyName = "ETEUDD"
Me.ETEUDD.HeaderText = "ETEUDD"
Me.ETEUDD.Name = "ETEUDD"
'
'ETONSDD
'
Me.ETONSDD.DataPropertyName = "ETONSDD"
Me.ETONSDD.HeaderText = "ETONSDD"
Me.ETONSDD.Name = "ETONSDD"
'
'F20GPDD
'
Me.F20GPDD.DataPropertyName = "F20GPDD"
Me.F20GPDD.HeaderText = "F20GPDD"
Me.F20GPDD.Name = "F20GPDD"
'
'F40GPDD
'
Me.F40GPDD.DataPropertyName = "F40GPDD"
Me.F40GPDD.HeaderText = "F40GPDD"
Me.F40GPDD.Name = "F40GPDD"
'
'F20HCDD
'
Me.F20HCDD.DataPropertyName = "F20HCDD"
Me.F20HCDD.HeaderText = "F20HCDD"
Me.F20HCDD.Name = "F20HCDD"
'
'F40HCDD
'
Me.F40HCDD.DataPropertyName = "F40HCDD"
Me.F40HCDD.HeaderText = "F40HCDD"
Me.F40HCDD.Name = "F40HCDD"
'
'F45HCDD
'
Me.F45HCDD.DataPropertyName = "F45HCDD"
Me.F45HCDD.HeaderText = "F45HCDD"
Me.F45HCDD.Name = "F45HCDD"
'
'F20RFDD
'
Me.F20RFDD.DataPropertyName = "F20RFDD"
Me.F20RFDD.HeaderText = "F20RFDD"
Me.F20RFDD.Name = "F20RFDD"
'
'F40RFDD
'
Me.F40RFDD.DataPropertyName = "F40RFDD"
Me.F40RFDD.HeaderText = "F40RFDD"
Me.F40RFDD.Name = "F40RFDD"
'
'F20RHDD
'
Me.F20RHDD.DataPropertyName = "F20RHDD"
Me.F20RHDD.HeaderText = "F20RHDD"
Me.F20RHDD.Name = "F20RHDD"
'
'F40RHDD
'
Me.F40RHDD.DataPropertyName = "F40RHDD"
Me.F40RHDD.HeaderText = "F40RHDD"
Me.F40RHDD.Name = "F40RHDD"
'
'F45RHDD
'
Me.F45RHDD.DataPropertyName = "F45RHDD"
Me.F45RHDD.HeaderText = "F45RHDD"
Me.F45RHDD.Name = "F45RHDD"
'
'F20FRDD
'
Me.F20FRDD.DataPropertyName = "F20FRDD"
Me.F20FRDD.HeaderText = "F20FRDD"
Me.F20FRDD.Name = "F20FRDD"
'
'F40FRDD
'
Me.F40FRDD.DataPropertyName = "F40FRDD"
Me.F40FRDD.HeaderText = "F40FRDD"
Me.F40FRDD.Name = "F40FRDD"
'
'F20HGDD
'
Me.F20HGDD.DataPropertyName = "F20HGDD"
Me.F20HGDD.HeaderText = "F20HGDD"
Me.F20HGDD.Name = "F20HGDD"
'
'F40HGDD
'
Me.F40HGDD.DataPropertyName = "F40HGDD"
Me.F40HGDD.HeaderText = "F40HGDD"
Me.F40HGDD.Name = "F40HGDD"
'
'F40GHDD
'
Me.F40GHDD.DataPropertyName = "F40GHDD"
Me.F40GHDD.HeaderText = "F40GHDD"
Me.F40GHDD.Name = "F40GHDD"
'
'F20OTDD
'
Me.F20OTDD.DataPropertyName = "F20OTDD"
Me.F20OTDD.HeaderText = "F20OTDD"
Me.F20OTDD.Name = "F20OTDD"
'
'F40OTDD
'
Me.F40OTDD.DataPropertyName = "F40OTDD"
Me.F40OTDD.HeaderText = "F40OTDD"
Me.F40OTDD.Name = "F40OTDD"
'
'F20TKDD
'
Me.F20TKDD.DataPropertyName = "F20TKDD"
Me.F20TKDD.HeaderText = "F20TKDD"
Me.F20TKDD.Name = "F20TKDD"
'
'F40TKDD
'
Me.F40TKDD.DataPropertyName = "F40TKDD"
Me.F40TKDD.HeaderText = "F40TKDD"
Me.F40TKDD.Name = "F40TKDD"
'
'FCNTRDD
'
Me.FCNTRDD.DataPropertyName = "FCNTRDD"
Me.FCNTRDD.HeaderText = "FCNTRDD"
Me.FCNTRDD.Name = "FCNTRDD"
'
'FTEUDD
'
Me.FTEUDD.DataPropertyName = "FTEUDD"
Me.FTEUDD.HeaderText = "FTEUDD"
Me.FTEUDD.Name = "FTEUDD"
'
'FTONSDD
'
Me.FTONSDD.DataPropertyName = "FTONSDD"
Me.FTONSDD.HeaderText = "FTONSDD"
Me.FTONSDD.Name = "FTONSDD"
'
'DangerousInboundCargoCNTRDD
'
Me.DangerousInboundCargoCNTRDD.DataPropertyName = "DangerousInboundCargoCNTRDD"
Me.DangerousInboundCargoCNTRDD.HeaderText = "DangerousInboundCargoCNTRDD"
Me.DangerousInboundCargoCNTRDD.Name = "DangerousInboundCargoCNTRDD"
Me.DangerousInboundCargoCNTRDD.Visible = false
'
'DangerousInboundCargoTONSDD
'
Me.DangerousInboundCargoTONSDD.DataPropertyName = "DangerousInboundCargoTONSDD"
Me.DangerousInboundCargoTONSDD.HeaderText = "DangerousInboundCargoTONSDD"
Me.DangerousInboundCargoTONSDD.Name = "DangerousInboundCargoTONSDD"
Me.DangerousInboundCargoTONSDD.Visible = false
'
'DangerousInboundCargoCLASSDD
'
Me.DangerousInboundCargoCLASSDD.DataPropertyName = "DangerousInboundCargoCLASSDD"
Me.DangerousInboundCargoCLASSDD.HeaderText = "DangerousInboundCargoCLASSDD"
Me.DangerousInboundCargoCLASSDD.Name = "DangerousInboundCargoCLASSDD"
Me.DangerousInboundCargoCLASSDD.Visible = false
'
'OtherConcerningRequirementOfShipDD
'
Me.OtherConcerningRequirementOfShipDD.DataPropertyName = "OtherConcerningRequirementOfShipDD"
Me.OtherConcerningRequirementOfShipDD.HeaderText = "OtherConcerningRequirementOfShipDD"
Me.OtherConcerningRequirementOfShipDD.Name = "OtherConcerningRequirementOfShipDD"
'
'RemarksDD
'
Me.RemarksDD.DataPropertyName = "RemarksDD"
Me.RemarksDD.HeaderText = "RemarksDD"
Me.RemarksDD.Name = "RemarksDD"
'
'E20GPAD1
'
Me.E20GPAD1.DataPropertyName = "E20GPAD1"
Me.E20GPAD1.HeaderText = "E20GPAD1"
Me.E20GPAD1.Name = "E20GPAD1"
'
'E40GPAD1
'
Me.E40GPAD1.DataPropertyName = "E40GPAD1"
Me.E40GPAD1.HeaderText = "E40GPAD1"
Me.E40GPAD1.Name = "E40GPAD1"
'
'E20HCAD1
'
Me.E20HCAD1.DataPropertyName = "E20HCAD1"
Me.E20HCAD1.HeaderText = "E20HCAD1"
Me.E20HCAD1.Name = "E20HCAD1"
'
'E40HCAD1
'
Me.E40HCAD1.DataPropertyName = "E40HCAD1"
Me.E40HCAD1.HeaderText = "E40HCAD1"
Me.E40HCAD1.Name = "E40HCAD1"
'
'E45HCAD1
'
Me.E45HCAD1.DataPropertyName = "E45HCAD1"
Me.E45HCAD1.HeaderText = "E45HCAD1"
Me.E45HCAD1.Name = "E45HCAD1"
'
'E20RFAD1
'
Me.E20RFAD1.DataPropertyName = "E20RFAD1"
Me.E20RFAD1.HeaderText = "E20RFAD1"
Me.E20RFAD1.Name = "E20RFAD1"
'
'E40RFAD1
'
Me.E40RFAD1.DataPropertyName = "E40RFAD1"
Me.E40RFAD1.HeaderText = "E40RFAD1"
Me.E40RFAD1.Name = "E40RFAD1"
'
'E20RHAD1
'
Me.E20RHAD1.DataPropertyName = "E20RHAD1"
Me.E20RHAD1.HeaderText = "E20RHAD1"
Me.E20RHAD1.Name = "E20RHAD1"
'
'E40RHAD1
'
Me.E40RHAD1.DataPropertyName = "E40RHAD1"
Me.E40RHAD1.HeaderText = "E40RHAD1"
Me.E40RHAD1.Name = "E40RHAD1"
'
'E45RHAD1
'
Me.E45RHAD1.DataPropertyName = "E45RHAD1"
Me.E45RHAD1.HeaderText = "E45RHAD1"
Me.E45RHAD1.Name = "E45RHAD1"
'
'E20FRAD1
'
Me.E20FRAD1.DataPropertyName = "E20FRAD1"
Me.E20FRAD1.HeaderText = "E20FRAD1"
Me.E20FRAD1.Name = "E20FRAD1"
'
'E40FRAD1
'
Me.E40FRAD1.DataPropertyName = "E40FRAD1"
Me.E40FRAD1.HeaderText = "E40FRAD1"
Me.E40FRAD1.Name = "E40FRAD1"
'
'E20HGAD1
'
Me.E20HGAD1.DataPropertyName = "E20HGAD1"
Me.E20HGAD1.HeaderText = "E20HGAD1"
Me.E20HGAD1.Name = "E20HGAD1"
'
'E40HGAD1
'
Me.E40HGAD1.DataPropertyName = "E40HGAD1"
Me.E40HGAD1.HeaderText = "E40HGAD1"
Me.E40HGAD1.Name = "E40HGAD1"
'
'E40GHAD1
'
Me.E40GHAD1.DataPropertyName = "E40GHAD1"
Me.E40GHAD1.HeaderText = "E40GHAD1"
Me.E40GHAD1.Name = "E40GHAD1"
'
'E20OTAD1
'
Me.E20OTAD1.DataPropertyName = "E20OTAD1"
Me.E20OTAD1.HeaderText = "E20OTAD1"
Me.E20OTAD1.Name = "E20OTAD1"
'
'E40OTAD1
'
Me.E40OTAD1.DataPropertyName = "E40OTAD1"
Me.E40OTAD1.HeaderText = "E40OTAD1"
Me.E40OTAD1.Name = "E40OTAD1"
'
'E20TKAD1
'
Me.E20TKAD1.DataPropertyName = "E20TKAD1"
Me.E20TKAD1.HeaderText = "E20TKAD1"
Me.E20TKAD1.Name = "E20TKAD1"
'
'E40TKAD1
'
Me.E40TKAD1.DataPropertyName = "E40TKAD1"
Me.E40TKAD1.HeaderText = "E40TKAD1"
Me.E40TKAD1.Name = "E40TKAD1"
'
'ECNTRAD1
'
Me.ECNTRAD1.DataPropertyName = "ECNTRAD1"
Me.ECNTRAD1.HeaderText = "ECNTRAD1"
Me.ECNTRAD1.Name = "ECNTRAD1"
'
'ETEUAD1
'
Me.ETEUAD1.DataPropertyName = "ETEUAD1"
Me.ETEUAD1.HeaderText = "ETEUAD1"
Me.ETEUAD1.Name = "ETEUAD1"
'
'ETONSAD1
'
Me.ETONSAD1.DataPropertyName = "ETONSAD1"
Me.ETONSAD1.HeaderText = "ETONSAD1"
Me.ETONSAD1.Name = "ETONSAD1"
'
'F20GPAD1
'
Me.F20GPAD1.DataPropertyName = "F20GPAD1"
Me.F20GPAD1.HeaderText = "F20GPAD1"
Me.F20GPAD1.Name = "F20GPAD1"
'
'F40GPAD1
'
Me.F40GPAD1.DataPropertyName = "F40GPAD1"
Me.F40GPAD1.HeaderText = "F40GPAD1"
Me.F40GPAD1.Name = "F40GPAD1"
'
'F20HCAD1
'
Me.F20HCAD1.DataPropertyName = "F20HCAD1"
Me.F20HCAD1.HeaderText = "F20HCAD1"
Me.F20HCAD1.Name = "F20HCAD1"
'
'F40HCAD1
'
Me.F40HCAD1.DataPropertyName = "F40HCAD1"
Me.F40HCAD1.HeaderText = "F40HCAD1"
Me.F40HCAD1.Name = "F40HCAD1"
'
'F45HCAD1
'
Me.F45HCAD1.DataPropertyName = "F45HCAD1"
Me.F45HCAD1.HeaderText = "F45HCAD1"
Me.F45HCAD1.Name = "F45HCAD1"
'
'F20RFAD1
'
Me.F20RFAD1.DataPropertyName = "F20RFAD1"
Me.F20RFAD1.HeaderText = "F20RFAD1"
Me.F20RFAD1.Name = "F20RFAD1"
'
'F40RFAD1
'
Me.F40RFAD1.DataPropertyName = "F40RFAD1"
Me.F40RFAD1.HeaderText = "F40RFAD1"
Me.F40RFAD1.Name = "F40RFAD1"
'
'F20RHAD1
'
Me.F20RHAD1.DataPropertyName = "F20RHAD1"
Me.F20RHAD1.HeaderText = "F20RHAD1"
Me.F20RHAD1.Name = "F20RHAD1"
'
'F40RHAD1
'
Me.F40RHAD1.DataPropertyName = "F40RHAD1"
Me.F40RHAD1.HeaderText = "F40RHAD1"
Me.F40RHAD1.Name = "F40RHAD1"
'
'F45RHAD1
'
Me.F45RHAD1.DataPropertyName = "F45RHAD1"
Me.F45RHAD1.HeaderText = "F45RHAD1"
Me.F45RHAD1.Name = "F45RHAD1"
'
'F20FRAD1
'
Me.F20FRAD1.DataPropertyName = "F20FRAD1"
Me.F20FRAD1.HeaderText = "F20FRAD1"
Me.F20FRAD1.Name = "F20FRAD1"
'
'F40FRAD1
'
Me.F40FRAD1.DataPropertyName = "F40FRAD1"
Me.F40FRAD1.HeaderText = "F40FRAD1"
Me.F40FRAD1.Name = "F40FRAD1"
'
'F20HGAD1
'
Me.F20HGAD1.DataPropertyName = "F20HGAD1"
Me.F20HGAD1.HeaderText = "F20HGAD1"
Me.F20HGAD1.Name = "F20HGAD1"
'
'F40HGAD1
'
Me.F40HGAD1.DataPropertyName = "F40HGAD1"
Me.F40HGAD1.HeaderText = "F40HGAD1"
Me.F40HGAD1.Name = "F40HGAD1"
'
'F40GHAD1
'
Me.F40GHAD1.DataPropertyName = "F40GHAD1"
Me.F40GHAD1.HeaderText = "F40GHAD1"
Me.F40GHAD1.Name = "F40GHAD1"
'
'F20OTAD1
'
Me.F20OTAD1.DataPropertyName = "F20OTAD1"
Me.F20OTAD1.HeaderText = "F20OTAD1"
Me.F20OTAD1.Name = "F20OTAD1"
'
'F40OTAD1
'
Me.F40OTAD1.DataPropertyName = "F40OTAD1"
Me.F40OTAD1.HeaderText = "F40OTAD1"
Me.F40OTAD1.Name = "F40OTAD1"
'
'F20TKAD1
'
Me.F20TKAD1.DataPropertyName = "F20TKAD1"
Me.F20TKAD1.HeaderText = "F20TKAD1"
Me.F20TKAD1.Name = "F20TKAD1"
'
'F40TKAD1
'
Me.F40TKAD1.DataPropertyName = "F40TKAD1"
Me.F40TKAD1.HeaderText = "F40TKAD1"
Me.F40TKAD1.Name = "F40TKAD1"
'
'FCNTRAD1
'
Me.FCNTRAD1.DataPropertyName = "FCNTRAD1"
Me.FCNTRAD1.HeaderText = "FCNTRAD1"
Me.FCNTRAD1.Name = "FCNTRAD1"
'
'FTEUAD1
'
Me.FTEUAD1.DataPropertyName = "FTEUAD1"
Me.FTEUAD1.HeaderText = "FTEUAD1"
Me.FTEUAD1.Name = "FTEUAD1"
'
'FTONSAD1
'
Me.FTONSAD1.DataPropertyName = "FTONSAD1"
Me.FTONSAD1.HeaderText = "FTONSAD1"
Me.FTONSAD1.Name = "FTONSAD1"
'
'DangerousInboundCargoCNTRAD1
'
Me.DangerousInboundCargoCNTRAD1.DataPropertyName = "DangerousInboundCargoCNTRAD1"
Me.DangerousInboundCargoCNTRAD1.HeaderText = "DangerousInboundCargoCNTRAD1"
Me.DangerousInboundCargoCNTRAD1.Name = "DangerousInboundCargoCNTRAD1"
Me.DangerousInboundCargoCNTRAD1.Visible = false
'
'DangerousInboundCargoTONSAD1
'
Me.DangerousInboundCargoTONSAD1.DataPropertyName = "DangerousInboundCargoTONSAD1"
Me.DangerousInboundCargoTONSAD1.HeaderText = "DangerousInboundCargoTONSAD1"
Me.DangerousInboundCargoTONSAD1.Name = "DangerousInboundCargoTONSAD1"
Me.DangerousInboundCargoTONSAD1.Visible = false
'
'DangerousInboundCargoCLASSAD1
'
Me.DangerousInboundCargoCLASSAD1.DataPropertyName = "DangerousInboundCargoCLASSAD1"
Me.DangerousInboundCargoCLASSAD1.HeaderText = "DangerousInboundCargoCLASSAD1"
Me.DangerousInboundCargoCLASSAD1.Name = "DangerousInboundCargoCLASSAD1"
Me.DangerousInboundCargoCLASSAD1.Visible = false
'
'OtherConcerningRequirementOfShipAD1
'
Me.OtherConcerningRequirementOfShipAD1.DataPropertyName = "OtherConcerningRequirementOfShipAD1"
Me.OtherConcerningRequirementOfShipAD1.HeaderText = "OtherConcerningRequirementOfShipAD1"
Me.OtherConcerningRequirementOfShipAD1.Name = "OtherConcerningRequirementOfShipAD1"
'
'RemaksAD1
'
Me.RemaksAD1.DataPropertyName = "RemaksAD1"
Me.RemaksAD1.HeaderText = "RemaksAD1"
Me.RemaksAD1.Name = "RemaksAD1"
'
'E20GPDD1
'
Me.E20GPDD1.DataPropertyName = "E20GPDD1"
Me.E20GPDD1.HeaderText = "E20GPDD1"
Me.E20GPDD1.Name = "E20GPDD1"
'
'E40GPDD1
'
Me.E40GPDD1.DataPropertyName = "E40GPDD1"
Me.E40GPDD1.HeaderText = "E40GPDD1"
Me.E40GPDD1.Name = "E40GPDD1"
'
'E20HCDD1
'
Me.E20HCDD1.DataPropertyName = "E20HCDD1"
Me.E20HCDD1.HeaderText = "E20HCDD1"
Me.E20HCDD1.Name = "E20HCDD1"
'
'E40HCDD1
'
Me.E40HCDD1.DataPropertyName = "E40HCDD1"
Me.E40HCDD1.HeaderText = "E40HCDD1"
Me.E40HCDD1.Name = "E40HCDD1"
'
'E45HCDD1
'
Me.E45HCDD1.DataPropertyName = "E45HCDD1"
Me.E45HCDD1.HeaderText = "E45HCDD1"
Me.E45HCDD1.Name = "E45HCDD1"
'
'E20RFDD1
'
Me.E20RFDD1.DataPropertyName = "E20RFDD1"
Me.E20RFDD1.HeaderText = "E20RFDD1"
Me.E20RFDD1.Name = "E20RFDD1"
'
'E40RFDD1
'
Me.E40RFDD1.DataPropertyName = "E40RFDD1"
Me.E40RFDD1.HeaderText = "E40RFDD1"
Me.E40RFDD1.Name = "E40RFDD1"
'
'E20RHDD1
'
Me.E20RHDD1.DataPropertyName = "E20RHDD1"
Me.E20RHDD1.HeaderText = "E20RHDD1"
Me.E20RHDD1.Name = "E20RHDD1"
'
'E40RHDD1
'
Me.E40RHDD1.DataPropertyName = "E40RHDD1"
Me.E40RHDD1.HeaderText = "E40RHDD1"
Me.E40RHDD1.Name = "E40RHDD1"
'
'E45RHDD1
'
Me.E45RHDD1.DataPropertyName = "E45RHDD1"
Me.E45RHDD1.HeaderText = "E45RHDD1"
Me.E45RHDD1.Name = "E45RHDD1"
'
'E20FRDD1
'
Me.E20FRDD1.DataPropertyName = "E20FRDD1"
Me.E20FRDD1.HeaderText = "E20FRDD1"
Me.E20FRDD1.Name = "E20FRDD1"
'
'E40FRDD1
'
Me.E40FRDD1.DataPropertyName = "E40FRDD1"
Me.E40FRDD1.HeaderText = "E40FRDD1"
Me.E40FRDD1.Name = "E40FRDD1"
'
'E20HGDD1
'
Me.E20HGDD1.DataPropertyName = "E20HGDD1"
Me.E20HGDD1.HeaderText = "E20HGDD1"
Me.E20HGDD1.Name = "E20HGDD1"
'
'E40HGDD1
'
Me.E40HGDD1.DataPropertyName = "E40HGDD1"
Me.E40HGDD1.HeaderText = "E40HGDD1"
Me.E40HGDD1.Name = "E40HGDD1"
'
'E40GHDD1
'
Me.E40GHDD1.DataPropertyName = "E40GHDD1"
Me.E40GHDD1.HeaderText = "E40GHDD1"
Me.E40GHDD1.Name = "E40GHDD1"
'
'E20OTDD1
'
Me.E20OTDD1.DataPropertyName = "E20OTDD1"
Me.E20OTDD1.HeaderText = "E20OTDD1"
Me.E20OTDD1.Name = "E20OTDD1"
'
'E40OTDD1
'
Me.E40OTDD1.DataPropertyName = "E40OTDD1"
Me.E40OTDD1.HeaderText = "E40OTDD1"
Me.E40OTDD1.Name = "E40OTDD1"
'
'E20TKDD1
'
Me.E20TKDD1.DataPropertyName = "E20TKDD1"
Me.E20TKDD1.HeaderText = "E20TKDD1"
Me.E20TKDD1.Name = "E20TKDD1"
'
'E40TKDD1
'
Me.E40TKDD1.DataPropertyName = "E40TKDD1"
Me.E40TKDD1.HeaderText = "E40TKDD1"
Me.E40TKDD1.Name = "E40TKDD1"
'
'ECNTRDD1
'
Me.ECNTRDD1.DataPropertyName = "ECNTRDD1"
Me.ECNTRDD1.HeaderText = "ECNTRDD1"
Me.ECNTRDD1.Name = "ECNTRDD1"
'
'ETEUDD1
'
Me.ETEUDD1.DataPropertyName = "ETEUDD1"
Me.ETEUDD1.HeaderText = "ETEUDD1"
Me.ETEUDD1.Name = "ETEUDD1"
'
'ETONSDD1
'
Me.ETONSDD1.DataPropertyName = "ETONSDD1"
Me.ETONSDD1.HeaderText = "ETONSDD1"
Me.ETONSDD1.Name = "ETONSDD1"
'
'F20GPDD1
'
Me.F20GPDD1.DataPropertyName = "F20GPDD1"
Me.F20GPDD1.HeaderText = "F20GPDD1"
Me.F20GPDD1.Name = "F20GPDD1"
'
'F40GPDD1
'
Me.F40GPDD1.DataPropertyName = "F40GPDD1"
Me.F40GPDD1.HeaderText = "F40GPDD1"
Me.F40GPDD1.Name = "F40GPDD1"
'
'F20HCDD1
'
Me.F20HCDD1.DataPropertyName = "F20HCDD1"
Me.F20HCDD1.HeaderText = "F20HCDD1"
Me.F20HCDD1.Name = "F20HCDD1"
'
'F40HCDD1
'
Me.F40HCDD1.DataPropertyName = "F40HCDD1"
Me.F40HCDD1.HeaderText = "F40HCDD1"
Me.F40HCDD1.Name = "F40HCDD1"
'
'F45HCDD1
'
Me.F45HCDD1.DataPropertyName = "F45HCDD1"
Me.F45HCDD1.HeaderText = "F45HCDD1"
Me.F45HCDD1.Name = "F45HCDD1"
'
'F20RFDD1
'
Me.F20RFDD1.DataPropertyName = "F20RFDD1"
Me.F20RFDD1.HeaderText = "F20RFDD1"
Me.F20RFDD1.Name = "F20RFDD1"
'
'F40RFDD1
'
Me.F40RFDD1.DataPropertyName = "F40RFDD1"
Me.F40RFDD1.HeaderText = "F40RFDD1"
Me.F40RFDD1.Name = "F40RFDD1"
'
'F20RHDD1
'
Me.F20RHDD1.DataPropertyName = "F20RHDD1"
Me.F20RHDD1.HeaderText = "F20RHDD1"
Me.F20RHDD1.Name = "F20RHDD1"
'
'F40RHDD1
'
Me.F40RHDD1.DataPropertyName = "F40RHDD1"
Me.F40RHDD1.HeaderText = "F40RHDD1"
Me.F40RHDD1.Name = "F40RHDD1"
'
'F45RHDD1
'
Me.F45RHDD1.DataPropertyName = "F45RHDD1"
Me.F45RHDD1.HeaderText = "F45RHDD1"
Me.F45RHDD1.Name = "F45RHDD1"
'
'F20FRDD1
'
Me.F20FRDD1.DataPropertyName = "F20FRDD1"
Me.F20FRDD1.HeaderText = "F20FRDD1"
Me.F20FRDD1.Name = "F20FRDD1"
'
'F40FRDD1
'
Me.F40FRDD1.DataPropertyName = "F40FRDD1"
Me.F40FRDD1.HeaderText = "F40FRDD1"
Me.F40FRDD1.Name = "F40FRDD1"
'
'F20HGDD1
'
Me.F20HGDD1.DataPropertyName = "F20HGDD1"
Me.F20HGDD1.HeaderText = "F20HGDD1"
Me.F20HGDD1.Name = "F20HGDD1"
'
'F40HGDD1
'
Me.F40HGDD1.DataPropertyName = "F40HGDD1"
Me.F40HGDD1.HeaderText = "F40HGDD1"
Me.F40HGDD1.Name = "F40HGDD1"
'
'F40GHDD1
'
Me.F40GHDD1.DataPropertyName = "F40GHDD1"
Me.F40GHDD1.HeaderText = "F40GHDD1"
Me.F40GHDD1.Name = "F40GHDD1"
'
'F20OTDD1
'
Me.F20OTDD1.DataPropertyName = "F20OTDD1"
Me.F20OTDD1.HeaderText = "F20OTDD1"
Me.F20OTDD1.Name = "F20OTDD1"
'
'F40OTDD1
'
Me.F40OTDD1.DataPropertyName = "F40OTDD1"
Me.F40OTDD1.HeaderText = "F40OTDD1"
Me.F40OTDD1.Name = "F40OTDD1"
'
'F20TKDD1
'
Me.F20TKDD1.DataPropertyName = "F20TKDD1"
Me.F20TKDD1.HeaderText = "F20TKDD1"
Me.F20TKDD1.Name = "F20TKDD1"
'
'F40TKDD1
'
Me.F40TKDD1.DataPropertyName = "F40TKDD1"
Me.F40TKDD1.HeaderText = "F40TKDD1"
Me.F40TKDD1.Name = "F40TKDD1"
'
'FCNTRDD1
'
Me.FCNTRDD1.DataPropertyName = "FCNTRDD1"
Me.FCNTRDD1.HeaderText = "FCNTRDD1"
Me.FCNTRDD1.Name = "FCNTRDD1"
'
'FTEUDD1
'
Me.FTEUDD1.DataPropertyName = "FTEUDD1"
Me.FTEUDD1.HeaderText = "FTEUDD1"
Me.FTEUDD1.Name = "FTEUDD1"
'
'FTONSDD1
'
Me.FTONSDD1.DataPropertyName = "FTONSDD1"
Me.FTONSDD1.HeaderText = "FTONSDD1"
Me.FTONSDD1.Name = "FTONSDD1"
'
'DangerousInboundCargoCNTRDD1
'
Me.DangerousInboundCargoCNTRDD1.DataPropertyName = "DangerousInboundCargoCNTRDD1"
Me.DangerousInboundCargoCNTRDD1.HeaderText = "DangerousInboundCargoCNTRDD1"
Me.DangerousInboundCargoCNTRDD1.Name = "DangerousInboundCargoCNTRDD1"
Me.DangerousInboundCargoCNTRDD1.Visible = false
'
'DangerousInboundCargoTONSDD1
'
Me.DangerousInboundCargoTONSDD1.DataPropertyName = "DangerousInboundCargoTONSDD1"
Me.DangerousInboundCargoTONSDD1.HeaderText = "DangerousInboundCargoTONSDD1"
Me.DangerousInboundCargoTONSDD1.Name = "DangerousInboundCargoTONSDD1"
Me.DangerousInboundCargoTONSDD1.Visible = false
'
'DangerousInboundCargoCLASSDD1
'
Me.DangerousInboundCargoCLASSDD1.DataPropertyName = "DangerousInboundCargoCLASSDD1"
Me.DangerousInboundCargoCLASSDD1.HeaderText = "DangerousInboundCargoCLASSDD1"
Me.DangerousInboundCargoCLASSDD1.Name = "DangerousInboundCargoCLASSDD1"
Me.DangerousInboundCargoCLASSDD1.Visible = false
'
'OtherConcerningRequirementOfShipDD1
'
Me.OtherConcerningRequirementOfShipDD1.DataPropertyName = "OtherConcerningRequirementOfShipDD1"
Me.OtherConcerningRequirementOfShipDD1.HeaderText = "OtherConcerningRequirementOfShipDD1"
Me.OtherConcerningRequirementOfShipDD1.Name = "OtherConcerningRequirementOfShipDD1"
'
'ApplicationForArrivalDate
'
Me.ApplicationForArrivalDate.DataPropertyName = "ApplicationForArrivalDate"
Me.ApplicationForArrivalDate.HeaderText = "ApplicationForArrivalDate"
Me.ApplicationForArrivalDate.Name = "ApplicationForArrivalDate"
'
'TheApprovalPort
'
Me.TheApprovalPort.DataPropertyName = "TheApprovalPort"
Me.TheApprovalPort.HeaderText = "TheApprovalPort"
Me.TheApprovalPort.Name = "TheApprovalPort"
'
'ApproveArrival
'
Me.ApproveArrival.DataPropertyName = "ApproveETA"
Me.ApproveArrival.HeaderText = "Approve Arrival"
Me.ApproveArrival.Name = "ApproveArrival"
Me.ApproveArrival.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
Me.ApproveArrival.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
'
'Editable
'
Me.Editable.DataPropertyName = "Editable"
Me.Editable.HeaderText = "Editable"
Me.Editable.Name = "Editable"
Me.Editable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
Me.Editable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
Me.Editable.Visible = false
'
'Continued
'
Me.Continued.DataPropertyName = "Continued"
Me.Continued.HeaderText = "Continued"
Me.Continued.Name = "Continued"
Me.Continued.Visible = false
'
'Approve
'
Me.Approve.DataPropertyName = "Approve"
Me.Approve.HeaderText = "Approve"
Me.Approve.Name = "Approve"
'
'UserUpdate
'
Me.UserUpdate.DataPropertyName = "UserID"
Me.UserUpdate.HeaderText = "User Update"
Me.UserUpdate.Name = "UserUpdate"
'
'UpdateTime
'
Me.UpdateTime.DataPropertyName = "UpdatTime"
Me.UpdateTime.HeaderText = "UpdateTime"
Me.UpdateTime.Name = "UpdateTime"
'
'fraUpdate
'
Me.fraUpdate.Controls.Add(Me.TabPage5)
Me.fraUpdate.Controls.Add(Me.tbcSailingSchedule)
Me.fraUpdate.Controls.Add(Me.ETASailingSchedule)
Me.fraUpdate.Location = New System.Drawing.Point(14, 189)
Me.fraUpdate.Name = "fraUpdate"
Me.fraUpdate.SelectedIndex = 0
Me.fraUpdate.ShowToolTips = true
Me.fraUpdate.Size = New System.Drawing.Size(776, 281)
Me.fraUpdate.TabIndex = 21
'
'TabPage5
'
Me.TabPage5.Controls.Add(Me.Label1)
Me.TabPage5.Controls.Add(Me.Label152)
Me.TabPage5.Controls.Add(Me.Label4)
Me.TabPage5.Controls.Add(Me.Label151)
Me.TabPage5.Controls.Add(Me.Label3)
Me.TabPage5.Controls.Add(Me.Label144)
Me.TabPage5.Controls.Add(Me.Label251)
Me.TabPage5.Controls.Add(Me.Label2)
Me.TabPage5.Controls.Add(Me.lbldescriptionShipper)
Me.TabPage5.Controls.Add(Me.txtServiceTerm)
Me.TabPage5.Controls.Add(Me.txtOwnerName)
Me.TabPage5.Controls.Add(Me.txtApplicationForArrivalDate)
Me.TabPage5.Controls.Add(Me.txtTheApprovalPort)
Me.TabPage5.Controls.Add(Me.txtAgentName)
Me.TabPage5.Controls.Add(Me.txtOperatorName)
Me.TabPage5.Controls.Add(Me.txtshipCode)
Me.TabPage5.Controls.Add(Me.txtVoyageDeparture)
Me.TabPage5.Controls.Add(Me.txtVoyageArrival)
Me.TabPage5.Controls.Add(Me.cboVessel)
Me.TabPage5.Controls.Add(Me.lblShipper)
Me.TabPage5.Location = New System.Drawing.Point(4, 22)
Me.TabPage5.Name = "TabPage5"
Me.TabPage5.Size = New System.Drawing.Size(768, 255)
Me.TabPage5.TabIndex = 4
Me.TabPage5.Text = "Vessel Info"
Me.TabPage5.UseVisualStyleBackColor = true
'
'Label1
'
Me.Label1.AutoSize = true
Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label1.Location = New System.Drawing.Point(51, 67)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(72, 13)
Me.Label1.TabIndex = 137
Me.Label1.Text = "Service term :"
'
'Label152
'
Me.Label152.AutoSize = true
Me.Label152.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label152.Location = New System.Drawing.Point(68, 196)
Me.Label152.Name = "Label152"
Me.Label152.Size = New System.Drawing.Size(98, 13)
Me.Label152.TabIndex = 138
Me.Label152.Text = "The Approval port :"
'
'Label4
'
Me.Label4.AutoSize = true
Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label4.Location = New System.Drawing.Point(48, 144)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(75, 13)
Me.Label4.TabIndex = 138
Me.Label4.Text = "Owner Name :"
'
'Label151
'
Me.Label151.AutoSize = true
Me.Label151.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label151.Location = New System.Drawing.Point(55, 170)
Me.Label151.Name = "Label151"
Me.Label151.Size = New System.Drawing.Size(111, 13)
Me.Label151.TabIndex = 138
Me.Label151.Text = "Application for arrival :"
'
'Label3
'
Me.Label3.AutoSize = true
Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label3.Location = New System.Drawing.Point(51, 118)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(72, 13)
Me.Label3.TabIndex = 138
Me.Label3.Text = "Agent Name :"
'
'Label144
'
Me.Label144.AutoSize = true
Me.Label144.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label144.Location = New System.Drawing.Point(38, 92)
Me.Label144.Name = "Label144"
Me.Label144.Size = New System.Drawing.Size(85, 13)
Me.Label144.TabIndex = 138
Me.Label144.Text = "Operator Name :"
'
'Label251
'
Me.Label251.AutoSize = true
Me.Label251.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label251.Location = New System.Drawing.Point(330, 14)
Me.Label251.Name = "Label251"
Me.Label251.Size = New System.Drawing.Size(62, 13)
Me.Label251.TabIndex = 139
Me.Label251.Text = "Ship Code :"
'
'Label2
'
Me.Label2.AutoSize = true
Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label2.Location = New System.Drawing.Point(271, 40)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(119, 13)
Me.Label2.TabIndex = 139
Me.Label2.Text = "Voyage No. Departure :"
'
'lbldescriptionShipper
'
Me.lbldescriptionShipper.AutoSize = true
Me.lbldescriptionShipper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.lbldescriptionShipper.Location = New System.Drawing.Point(22, 40)
Me.lbldescriptionShipper.Name = "lbldescriptionShipper"
Me.lbldescriptionShipper.Size = New System.Drawing.Size(101, 13)
Me.lbldescriptionShipper.TabIndex = 139
Me.lbldescriptionShipper.Text = "Voyage No. Arrival :"
'
'txtServiceTerm
'
Me.txtServiceTerm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtServiceTerm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtServiceTerm.ForeColor = System.Drawing.Color.Blue
Me.txtServiceTerm.Location = New System.Drawing.Point(125, 63)
Me.txtServiceTerm.Name = "txtServiceTerm"
Me.txtServiceTerm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtServiceTerm.Size = New System.Drawing.Size(380, 20)
Me.txtServiceTerm.TabIndex = 134
'
'txtOwnerName
'
Me.txtOwnerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtOwnerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtOwnerName.ForeColor = System.Drawing.Color.Blue
Me.txtOwnerName.Location = New System.Drawing.Point(125, 141)
Me.txtOwnerName.Name = "txtOwnerName"
Me.txtOwnerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtOwnerName.Size = New System.Drawing.Size(380, 20)
Me.txtOwnerName.TabIndex = 129
'
'txtApplicationForArrivalDate
'
Me.txtApplicationForArrivalDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtApplicationForArrivalDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtApplicationForArrivalDate.ForeColor = System.Drawing.Color.Blue
Me.txtApplicationForArrivalDate.Location = New System.Drawing.Point(168, 167)
Me.txtApplicationForArrivalDate.Name = "txtApplicationForArrivalDate"
Me.txtApplicationForArrivalDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtApplicationForArrivalDate.Size = New System.Drawing.Size(337, 20)
Me.txtApplicationForArrivalDate.TabIndex = 129
'
'txtTheApprovalPort
'
Me.txtTheApprovalPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtTheApprovalPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtTheApprovalPort.ForeColor = System.Drawing.Color.Blue
Me.txtTheApprovalPort.Location = New System.Drawing.Point(168, 193)
Me.txtTheApprovalPort.Name = "txtTheApprovalPort"
Me.txtTheApprovalPort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTheApprovalPort.Size = New System.Drawing.Size(337, 20)
Me.txtTheApprovalPort.TabIndex = 129
'
'txtAgentName
'
Me.txtAgentName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtAgentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtAgentName.ForeColor = System.Drawing.Color.Blue
Me.txtAgentName.Location = New System.Drawing.Point(125, 115)
Me.txtAgentName.Name = "txtAgentName"
Me.txtAgentName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtAgentName.Size = New System.Drawing.Size(380, 20)
Me.txtAgentName.TabIndex = 129
'
'txtOperatorName
'
Me.txtOperatorName.AcceptsReturn = true
Me.txtOperatorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtOperatorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtOperatorName.ForeColor = System.Drawing.Color.Blue
Me.txtOperatorName.Location = New System.Drawing.Point(125, 89)
Me.txtOperatorName.Name = "txtOperatorName"
Me.txtOperatorName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtOperatorName.Size = New System.Drawing.Size(380, 20)
Me.txtOperatorName.TabIndex = 129
'
'txtshipCode
'
Me.txtshipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtshipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtshipCode.ForeColor = System.Drawing.Color.Blue
Me.txtshipCode.Location = New System.Drawing.Point(392, 12)
Me.txtshipCode.Name = "txtshipCode"
Me.txtshipCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtshipCode.Size = New System.Drawing.Size(113, 20)
Me.txtshipCode.TabIndex = 133
'
'txtVoyageDeparture
'
Me.txtVoyageDeparture.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtVoyageDeparture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtVoyageDeparture.ForeColor = System.Drawing.Color.Blue
Me.txtVoyageDeparture.Location = New System.Drawing.Point(392, 37)
Me.txtVoyageDeparture.Name = "txtVoyageDeparture"
Me.txtVoyageDeparture.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtVoyageDeparture.Size = New System.Drawing.Size(113, 20)
Me.txtVoyageDeparture.TabIndex = 133
'
'txtVoyageArrival
'
Me.txtVoyageArrival.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtVoyageArrival.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtVoyageArrival.ForeColor = System.Drawing.Color.Blue
Me.txtVoyageArrival.Location = New System.Drawing.Point(125, 37)
Me.txtVoyageArrival.Name = "txtVoyageArrival"
Me.txtVoyageArrival.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtVoyageArrival.Size = New System.Drawing.Size(123, 20)
Me.txtVoyageArrival.TabIndex = 133
'
'cboVessel
'
Me.cboVessel.ForeColor = System.Drawing.Color.Blue
Me.cboVessel.FormattingEnabled = true
Me.cboVessel.Location = New System.Drawing.Point(125, 10)
Me.cboVessel.Name = "cboVessel"
Me.cboVessel.Size = New System.Drawing.Size(202, 21)
Me.cboVessel.TabIndex = 130
'
'lblShipper
'
Me.lblShipper.AutoSize = true
Me.lblShipper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.lblShipper.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.lblShipper.Location = New System.Drawing.Point(48, 14)
Me.lblShipper.Name = "lblShipper"
Me.lblShipper.Size = New System.Drawing.Size(75, 13)
Me.lblShipper.TabIndex = 135
Me.lblShipper.Text = "Vessel Name :"
Me.lblShipper.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'tbcSailingSchedule
'
Me.tbcSailingSchedule.Controls.Add(Me.TabControl1)
Me.tbcSailingSchedule.ForeColor = System.Drawing.Color.Maroon
Me.tbcSailingSchedule.Location = New System.Drawing.Point(4, 22)
Me.tbcSailingSchedule.Name = "tbcSailingSchedule"
Me.tbcSailingSchedule.Padding = New System.Windows.Forms.Padding(3)
Me.tbcSailingSchedule.Size = New System.Drawing.Size(768, 255)
Me.tbcSailingSchedule.TabIndex = 2
Me.tbcSailingSchedule.Text = "Arrival Declare"
Me.tbcSailingSchedule.ToolTipText = "Lịch Tàu Đi"
Me.tbcSailingSchedule.UseVisualStyleBackColor = true
'
'TabControl1
'
Me.TabControl1.Controls.Add(Me.lbl)
Me.TabControl1.Controls.Add(Me.TabPage1)
Me.TabControl1.Controls.Add(Me.TabPage2)
Me.TabControl1.Controls.Add(Me.TabPage11)
Me.TabControl1.Location = New System.Drawing.Point(6, 6)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(761, 243)
Me.TabControl1.TabIndex = 0
'
'lbl
'
Me.lbl.Controls.Add(Me.GroupBox25)
Me.lbl.Controls.Add(Me.GroupBox4)
Me.lbl.Controls.Add(Me.GroupBox3)
Me.lbl.Controls.Add(Me.GroupBox2)
Me.lbl.Controls.Add(Me.Label12)
Me.lbl.Controls.Add(Me.Label11)
Me.lbl.Controls.Add(Me.Label10)
Me.lbl.Controls.Add(Me.Label9)
Me.lbl.Controls.Add(Me.Label8)
Me.lbl.Controls.Add(Me.Label7)
Me.lbl.Controls.Add(Me.txtKindofCargoAD)
Me.lbl.Controls.Add(Me.txtPurposetoportAD)
Me.lbl.Controls.Add(Me.txtPositionOfShipInPortAD)
Me.lbl.Controls.Add(Me.txtNumOfPassengersAD)
Me.lbl.Controls.Add(Me.txtCaptionNameAD)
Me.lbl.Controls.Add(Me.txtNumOfCrewAD)
Me.lbl.Controls.Add(Me.GroupBox1)
Me.lbl.Location = New System.Drawing.Point(4, 22)
Me.lbl.Name = "lbl"
Me.lbl.Padding = New System.Windows.Forms.Padding(3)
Me.lbl.Size = New System.Drawing.Size(753, 217)
Me.lbl.TabIndex = 0
Me.lbl.Text = "Arrival detail 1"
Me.lbl.UseVisualStyleBackColor = true
'
'GroupBox25
'
Me.GroupBox25.Controls.Add(Me.dtpDateOfArrivalAD)
Me.GroupBox25.Controls.Add(Me.chkApproveETA)
Me.GroupBox25.Controls.Add(Me.Label252)
Me.GroupBox25.Controls.Add(Me.txtTimeOfArrivalAD)
Me.GroupBox25.Controls.Add(Me.txtDateOfArrivalAD)
Me.GroupBox25.Controls.Add(Me.Label253)
Me.GroupBox25.Location = New System.Drawing.Point(3, 135)
Me.GroupBox25.Name = "GroupBox25"
Me.GroupBox25.Size = New System.Drawing.Size(305, 79)
Me.GroupBox25.TabIndex = 143
Me.GroupBox25.TabStop = false
Me.GroupBox25.Text = "Arrival"
'
'dtpDateOfArrivalAD
'
Me.dtpDateOfArrivalAD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpDateOfArrivalAD.Location = New System.Drawing.Point(134, 18)
Me.dtpDateOfArrivalAD.Name = "dtpDateOfArrivalAD"
Me.dtpDateOfArrivalAD.Size = New System.Drawing.Size(95, 20)
Me.dtpDateOfArrivalAD.TabIndex = 146
'
'chkApproveETA
'
Me.chkApproveETA.AutoSize = true
Me.chkApproveETA.Location = New System.Drawing.Point(143, 53)
Me.chkApproveETA.Name = "chkApproveETA"
Me.chkApproveETA.Size = New System.Drawing.Size(90, 17)
Me.chkApproveETA.TabIndex = 145
Me.chkApproveETA.Text = "Approve ETA"
Me.chkApproveETA.UseVisualStyleBackColor = true
'
'Label252
'
Me.Label252.AutoSize = true
Me.Label252.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label252.Location = New System.Drawing.Point(15, 23)
Me.Label252.Name = "Label252"
Me.Label252.Size = New System.Drawing.Size(36, 13)
Me.Label252.TabIndex = 141
Me.Label252.Text = "Date :"
'
'txtTimeOfArrivalAD
'
Me.txtTimeOfArrivalAD.AcceptsReturn = true
Me.txtTimeOfArrivalAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtTimeOfArrivalAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtTimeOfArrivalAD.ForeColor = System.Drawing.Color.Blue
Me.txtTimeOfArrivalAD.Location = New System.Drawing.Point(54, 50)
Me.txtTimeOfArrivalAD.Name = "txtTimeOfArrivalAD"
Me.txtTimeOfArrivalAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTimeOfArrivalAD.Size = New System.Drawing.Size(58, 20)
Me.txtTimeOfArrivalAD.TabIndex = 139
'
'txtDateOfArrivalAD
'
Me.txtDateOfArrivalAD.AcceptsReturn = true
Me.txtDateOfArrivalAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtDateOfArrivalAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtDateOfArrivalAD.ForeColor = System.Drawing.Color.Blue
Me.txtDateOfArrivalAD.Location = New System.Drawing.Point(55, 19)
Me.txtDateOfArrivalAD.Name = "txtDateOfArrivalAD"
Me.txtDateOfArrivalAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtDateOfArrivalAD.Size = New System.Drawing.Size(73, 20)
Me.txtDateOfArrivalAD.TabIndex = 139
'
'Label253
'
Me.Label253.AutoSize = true
Me.Label253.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label253.Location = New System.Drawing.Point(17, 52)
Me.Label253.Name = "Label253"
Me.Label253.Size = New System.Drawing.Size(36, 13)
Me.Label253.TabIndex = 142
Me.Label253.Text = "Time :"
'
'GroupBox4
'
Me.GroupBox4.Controls.Add(Me.dtpDateOfBerthAD)
Me.GroupBox4.Controls.Add(Me.Label17)
Me.GroupBox4.Controls.Add(Me.txtDateOfBerthAD)
Me.GroupBox4.Controls.Add(Me.txtTimeOfBerthAD)
Me.GroupBox4.Controls.Add(Me.Label18)
Me.GroupBox4.Location = New System.Drawing.Point(314, 56)
Me.GroupBox4.Name = "GroupBox4"
Me.GroupBox4.Size = New System.Drawing.Size(358, 54)
Me.GroupBox4.TabIndex = 144
Me.GroupBox4.TabStop = false
Me.GroupBox4.Text = "Date && Time of  Berth"
'
'dtpDateOfBerthAD
'
Me.dtpDateOfBerthAD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpDateOfBerthAD.Location = New System.Drawing.Point(126, 21)
Me.dtpDateOfBerthAD.Name = "dtpDateOfBerthAD"
Me.dtpDateOfBerthAD.Size = New System.Drawing.Size(89, 20)
Me.dtpDateOfBerthAD.TabIndex = 146
'
'Label17
'
Me.Label17.AutoSize = true
Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label17.Location = New System.Drawing.Point(11, 23)
Me.Label17.Name = "Label17"
Me.Label17.Size = New System.Drawing.Size(36, 13)
Me.Label17.TabIndex = 141
Me.Label17.Text = "Date :"
'
'txtDateOfBerthAD
'
Me.txtDateOfBerthAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtDateOfBerthAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtDateOfBerthAD.ForeColor = System.Drawing.Color.Blue
Me.txtDateOfBerthAD.Location = New System.Drawing.Point(49, 20)
Me.txtDateOfBerthAD.Name = "txtDateOfBerthAD"
Me.txtDateOfBerthAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtDateOfBerthAD.Size = New System.Drawing.Size(73, 20)
Me.txtDateOfBerthAD.TabIndex = 140
'
'txtTimeOfBerthAD
'
Me.txtTimeOfBerthAD.AcceptsReturn = true
Me.txtTimeOfBerthAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtTimeOfBerthAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtTimeOfBerthAD.ForeColor = System.Drawing.Color.Blue
Me.txtTimeOfBerthAD.Location = New System.Drawing.Point(272, 16)
Me.txtTimeOfBerthAD.Name = "txtTimeOfBerthAD"
Me.txtTimeOfBerthAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTimeOfBerthAD.Size = New System.Drawing.Size(58, 20)
Me.txtTimeOfBerthAD.TabIndex = 139
'
'Label18
'
Me.Label18.AutoSize = true
Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label18.Location = New System.Drawing.Point(233, 19)
Me.Label18.Name = "Label18"
Me.Label18.Size = New System.Drawing.Size(36, 13)
Me.Label18.TabIndex = 142
Me.Label18.Text = "Time :"
'
'GroupBox3
'
Me.GroupBox3.Controls.Add(Me.dtpDateOfArrivalPilotOnboardAD)
Me.GroupBox3.Controls.Add(Me.Label15)
Me.GroupBox3.Controls.Add(Me.txtTimeOfArrivalPilotOnboardAD)
Me.GroupBox3.Controls.Add(Me.txtDateOfArrivalPilotOnboardAD)
Me.GroupBox3.Controls.Add(Me.Label16)
Me.GroupBox3.Location = New System.Drawing.Point(314, 112)
Me.GroupBox3.Name = "GroupBox3"
Me.GroupBox3.Size = New System.Drawing.Size(357, 54)
Me.GroupBox3.TabIndex = 143
Me.GroupBox3.TabStop = false
Me.GroupBox3.Text = "Date && Time of  Pilot Onboard"
'
'dtpDateOfArrivalPilotOnboardAD
'
Me.dtpDateOfArrivalPilotOnboardAD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpDateOfArrivalPilotOnboardAD.Location = New System.Drawing.Point(126, 20)
Me.dtpDateOfArrivalPilotOnboardAD.Name = "dtpDateOfArrivalPilotOnboardAD"
Me.dtpDateOfArrivalPilotOnboardAD.Size = New System.Drawing.Size(89, 20)
Me.dtpDateOfArrivalPilotOnboardAD.TabIndex = 146
'
'Label15
'
Me.Label15.AutoSize = true
Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label15.Location = New System.Drawing.Point(13, 23)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(36, 13)
Me.Label15.TabIndex = 141
Me.Label15.Text = "Date :"
'
'txtTimeOfArrivalPilotOnboardAD
'
Me.txtTimeOfArrivalPilotOnboardAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtTimeOfArrivalPilotOnboardAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtTimeOfArrivalPilotOnboardAD.ForeColor = System.Drawing.Color.Blue
Me.txtTimeOfArrivalPilotOnboardAD.Location = New System.Drawing.Point(272, 19)
Me.txtTimeOfArrivalPilotOnboardAD.Name = "txtTimeOfArrivalPilotOnboardAD"
Me.txtTimeOfArrivalPilotOnboardAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTimeOfArrivalPilotOnboardAD.Size = New System.Drawing.Size(58, 20)
Me.txtTimeOfArrivalPilotOnboardAD.TabIndex = 140
'
'txtDateOfArrivalPilotOnboardAD
'
Me.txtDateOfArrivalPilotOnboardAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtDateOfArrivalPilotOnboardAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtDateOfArrivalPilotOnboardAD.ForeColor = System.Drawing.Color.Blue
Me.txtDateOfArrivalPilotOnboardAD.Location = New System.Drawing.Point(51, 20)
Me.txtDateOfArrivalPilotOnboardAD.Name = "txtDateOfArrivalPilotOnboardAD"
Me.txtDateOfArrivalPilotOnboardAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtDateOfArrivalPilotOnboardAD.Size = New System.Drawing.Size(73, 20)
Me.txtDateOfArrivalPilotOnboardAD.TabIndex = 140
'
'Label16
'
Me.Label16.AutoSize = true
Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label16.Location = New System.Drawing.Point(233, 22)
Me.Label16.Name = "Label16"
Me.Label16.Size = New System.Drawing.Size(36, 13)
Me.Label16.TabIndex = 142
Me.Label16.Text = "Time :"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.Label13)
Me.GroupBox2.Controls.Add(Me.txtFOAD)
Me.GroupBox2.Controls.Add(Me.txtFWAD)
Me.GroupBox2.Controls.Add(Me.lblFWAD)
Me.GroupBox2.Controls.Add(Me.txtDOAD)
Me.GroupBox2.Controls.Add(Me.Label14)
Me.GroupBox2.Location = New System.Drawing.Point(314, 170)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(358, 45)
Me.GroupBox2.TabIndex = 143
Me.GroupBox2.TabStop = false
Me.GroupBox2.Text = "Declare of arrival (MTs)"
'
'Label13
'
Me.Label13.AutoSize = true
Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label13.Location = New System.Drawing.Point(31, 20)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(27, 13)
Me.Label13.TabIndex = 141
Me.Label13.Text = "FO :"
'
'txtFOAD
'
Me.txtFOAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtFOAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtFOAD.ForeColor = System.Drawing.Color.Blue
Me.txtFOAD.Location = New System.Drawing.Point(60, 17)
Me.txtFOAD.Name = "txtFOAD"
Me.txtFOAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtFOAD.Size = New System.Drawing.Size(64, 20)
Me.txtFOAD.TabIndex = 140
'
'txtFWAD
'
Me.txtFWAD.AcceptsReturn = true
Me.txtFWAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtFWAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtFWAD.ForeColor = System.Drawing.Color.Blue
Me.txtFWAD.Location = New System.Drawing.Point(161, 17)
Me.txtFWAD.Name = "txtFWAD"
Me.txtFWAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtFWAD.Size = New System.Drawing.Size(64, 20)
Me.txtFWAD.TabIndex = 139
'
'lblFWAD
'
Me.lblFWAD.AutoSize = true
Me.lblFWAD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.lblFWAD.Location = New System.Drawing.Point(128, 20)
Me.lblFWAD.Name = "lblFWAD"
Me.lblFWAD.Size = New System.Drawing.Size(30, 13)
Me.lblFWAD.TabIndex = 142
Me.lblFWAD.Text = "FW :"
'
'txtDOAD
'
Me.txtDOAD.AcceptsReturn = true
Me.txtDOAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtDOAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtDOAD.ForeColor = System.Drawing.Color.Blue
Me.txtDOAD.Location = New System.Drawing.Point(272, 17)
Me.txtDOAD.Name = "txtDOAD"
Me.txtDOAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtDOAD.Size = New System.Drawing.Size(64, 20)
Me.txtDOAD.TabIndex = 139
'
'Label14
'
Me.Label14.AutoSize = true
Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label14.Location = New System.Drawing.Point(241, 20)
Me.Label14.Name = "Label14"
Me.Label14.Size = New System.Drawing.Size(29, 13)
Me.Label14.TabIndex = 142
Me.Label14.Text = "DO :"
'
'Label12
'
Me.Label12.AutoSize = true
Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label12.Location = New System.Drawing.Point(48, 113)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(77, 13)
Me.Label12.TabIndex = 143
Me.Label12.Text = "Kind of Cargo :"
'
'Label11
'
Me.Label11.AutoSize = true
Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label11.Location = New System.Drawing.Point(40, 93)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(85, 13)
Me.Label11.TabIndex = 143
Me.Label11.Text = "Purpose to port :"
'
'Label10
'
Me.Label10.AutoSize = true
Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label10.Location = New System.Drawing.Point(8, 73)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(118, 13)
Me.Label10.TabIndex = 143
Me.Label10.Text = "Possition of Ship (port) :"
'
'Label9
'
Me.Label9.AutoSize = true
Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label9.Location = New System.Drawing.Point(35, 53)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(91, 13)
Me.Label9.TabIndex = 143
Me.Label9.Text = "Number of Pass. :"
'
'Label8
'
Me.Label8.AutoSize = true
Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label8.Location = New System.Drawing.Point(37, 31)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(89, 13)
Me.Label8.TabIndex = 143
Me.Label8.Text = "Number of Crew :"
'
'Label7
'
Me.Label7.AutoSize = true
Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label7.Location = New System.Drawing.Point(61, 11)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(64, 13)
Me.Label7.TabIndex = 143
Me.Label7.Text = "Capt name :"
'
'txtKindofCargoAD
'
Me.txtKindofCargoAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtKindofCargoAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtKindofCargoAD.ForeColor = System.Drawing.Color.Blue
Me.txtKindofCargoAD.Location = New System.Drawing.Point(129, 109)
Me.txtKindofCargoAD.Name = "txtKindofCargoAD"
Me.txtKindofCargoAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtKindofCargoAD.Size = New System.Drawing.Size(179, 20)
Me.txtKindofCargoAD.TabIndex = 142
'
'txtPurposetoportAD
'
Me.txtPurposetoportAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtPurposetoportAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtPurposetoportAD.ForeColor = System.Drawing.Color.Blue
Me.txtPurposetoportAD.Location = New System.Drawing.Point(129, 89)
Me.txtPurposetoportAD.Name = "txtPurposetoportAD"
Me.txtPurposetoportAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtPurposetoportAD.Size = New System.Drawing.Size(179, 20)
Me.txtPurposetoportAD.TabIndex = 142
'
'txtPositionOfShipInPortAD
'
Me.txtPositionOfShipInPortAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtPositionOfShipInPortAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtPositionOfShipInPortAD.ForeColor = System.Drawing.Color.Blue
Me.txtPositionOfShipInPortAD.Location = New System.Drawing.Point(129, 69)
Me.txtPositionOfShipInPortAD.Name = "txtPositionOfShipInPortAD"
Me.txtPositionOfShipInPortAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtPositionOfShipInPortAD.Size = New System.Drawing.Size(179, 20)
Me.txtPositionOfShipInPortAD.TabIndex = 142
'
'txtNumOfPassengersAD
'
Me.txtNumOfPassengersAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtNumOfPassengersAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtNumOfPassengersAD.ForeColor = System.Drawing.Color.Blue
Me.txtNumOfPassengersAD.Location = New System.Drawing.Point(129, 49)
Me.txtNumOfPassengersAD.Name = "txtNumOfPassengersAD"
Me.txtNumOfPassengersAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtNumOfPassengersAD.Size = New System.Drawing.Size(179, 20)
Me.txtNumOfPassengersAD.TabIndex = 142
'
'txtCaptionNameAD
'
Me.txtCaptionNameAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtCaptionNameAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtCaptionNameAD.ForeColor = System.Drawing.Color.Blue
Me.txtCaptionNameAD.Location = New System.Drawing.Point(129, 9)
Me.txtCaptionNameAD.Name = "txtCaptionNameAD"
Me.txtCaptionNameAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtCaptionNameAD.Size = New System.Drawing.Size(179, 20)
Me.txtCaptionNameAD.TabIndex = 142
'
'txtNumOfCrewAD
'
Me.txtNumOfCrewAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtNumOfCrewAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtNumOfCrewAD.ForeColor = System.Drawing.Color.Blue
Me.txtNumOfCrewAD.Location = New System.Drawing.Point(129, 29)
Me.txtNumOfCrewAD.Name = "txtNumOfCrewAD"
Me.txtNumOfCrewAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtNumOfCrewAD.Size = New System.Drawing.Size(179, 20)
Me.txtNumOfCrewAD.TabIndex = 142
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.dtpdateofarrivalPilotStationAD)
Me.GroupBox1.Controls.Add(Me.Label5)
Me.GroupBox1.Controls.Add(Me.txtdateofarrivalPilotStationAD)
Me.GroupBox1.Controls.Add(Me.txtTimeOfArrivalPilotStationAD)
Me.GroupBox1.Controls.Add(Me.Label6)
Me.GroupBox1.Location = New System.Drawing.Point(314, 7)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(358, 48)
Me.GroupBox1.TabIndex = 0
Me.GroupBox1.TabStop = false
Me.GroupBox1.Text = "D/T of Arrival Pilot Station"
'
'dtpdateofarrivalPilotStationAD
'
Me.dtpdateofarrivalPilotStationAD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpdateofarrivalPilotStationAD.Location = New System.Drawing.Point(126, 19)
Me.dtpdateofarrivalPilotStationAD.Name = "dtpdateofarrivalPilotStationAD"
Me.dtpdateofarrivalPilotStationAD.Size = New System.Drawing.Size(89, 20)
Me.dtpdateofarrivalPilotStationAD.TabIndex = 146
'
'Label5
'
Me.Label5.AutoSize = true
Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label5.Location = New System.Drawing.Point(12, 22)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(36, 13)
Me.Label5.TabIndex = 141
Me.Label5.Text = "Date :"
'
'txtdateofarrivalPilotStationAD
'
Me.txtdateofarrivalPilotStationAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtdateofarrivalPilotStationAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtdateofarrivalPilotStationAD.ForeColor = System.Drawing.Color.Blue
Me.txtdateofarrivalPilotStationAD.Location = New System.Drawing.Point(50, 19)
Me.txtdateofarrivalPilotStationAD.Name = "txtdateofarrivalPilotStationAD"
Me.txtdateofarrivalPilotStationAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtdateofarrivalPilotStationAD.Size = New System.Drawing.Size(73, 20)
Me.txtdateofarrivalPilotStationAD.TabIndex = 140
'
'txtTimeOfArrivalPilotStationAD
'
Me.txtTimeOfArrivalPilotStationAD.AcceptsReturn = true
Me.txtTimeOfArrivalPilotStationAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtTimeOfArrivalPilotStationAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtTimeOfArrivalPilotStationAD.ForeColor = System.Drawing.Color.Blue
Me.txtTimeOfArrivalPilotStationAD.Location = New System.Drawing.Point(272, 16)
Me.txtTimeOfArrivalPilotStationAD.Name = "txtTimeOfArrivalPilotStationAD"
Me.txtTimeOfArrivalPilotStationAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTimeOfArrivalPilotStationAD.Size = New System.Drawing.Size(58, 20)
Me.txtTimeOfArrivalPilotStationAD.TabIndex = 139
'
'Label6
'
Me.Label6.AutoSize = true
Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label6.Location = New System.Drawing.Point(233, 19)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(36, 13)
Me.Label6.TabIndex = 142
Me.Label6.Text = "Time :"
'
'TabPage1
'
Me.TabPage1.Controls.Add(Me.GroupBox6)
Me.TabPage1.Controls.Add(Me.GroupBox5)
Me.TabPage1.Controls.Add(Me.Label19)
Me.TabPage1.Controls.Add(Me.Label20)
Me.TabPage1.Controls.Add(Me.Label21)
Me.TabPage1.Controls.Add(Me.Label22)
Me.TabPage1.Controls.Add(Me.txtLastDateOfArrivalAD)
Me.TabPage1.Controls.Add(Me.txtActualDisplacementAD)
Me.TabPage1.Controls.Add(Me.txtAfterDraftAD)
Me.TabPage1.Controls.Add(Me.txtForeDraftAD)
Me.TabPage1.Location = New System.Drawing.Point(4, 22)
Me.TabPage1.Name = "TabPage1"
Me.TabPage1.Size = New System.Drawing.Size(753, 217)
Me.TabPage1.TabIndex = 2
Me.TabPage1.Text = "Arrival detail 2"
Me.TabPage1.UseVisualStyleBackColor = true
'
'GroupBox6
'
Me.GroupBox6.Controls.Add(Me.dtpDateCommencingOperationAD)
Me.GroupBox6.Controls.Add(Me.Label26)
Me.GroupBox6.Controls.Add(Me.txtTimeCommencingOperationAD)
Me.GroupBox6.Controls.Add(Me.txtDateCommencingOperationAD)
Me.GroupBox6.Controls.Add(Me.Label27)
Me.GroupBox6.Location = New System.Drawing.Point(386, 17)
Me.GroupBox6.Name = "GroupBox6"
Me.GroupBox6.Size = New System.Drawing.Size(240, 80)
Me.GroupBox6.TabIndex = 153
Me.GroupBox6.TabStop = false
Me.GroupBox6.Text = "Commencing Operation"
'
'dtpDateCommencingOperationAD
'
Me.dtpDateCommencingOperationAD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpDateCommencingOperationAD.Location = New System.Drawing.Point(135, 23)
Me.dtpDateCommencingOperationAD.Name = "dtpDateCommencingOperationAD"
Me.dtpDateCommencingOperationAD.Size = New System.Drawing.Size(92, 20)
Me.dtpDateCommencingOperationAD.TabIndex = 143
'
'Label26
'
Me.Label26.AutoSize = true
Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label26.Location = New System.Drawing.Point(22, 23)
Me.Label26.Name = "Label26"
Me.Label26.Size = New System.Drawing.Size(36, 13)
Me.Label26.TabIndex = 141
Me.Label26.Text = "Date :"
'
'txtTimeCommencingOperationAD
'
Me.txtTimeCommencingOperationAD.AcceptsReturn = true
Me.txtTimeCommencingOperationAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtTimeCommencingOperationAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtTimeCommencingOperationAD.ForeColor = System.Drawing.Color.Blue
Me.txtTimeCommencingOperationAD.Location = New System.Drawing.Point(60, 48)
Me.txtTimeCommencingOperationAD.Name = "txtTimeCommencingOperationAD"
Me.txtTimeCommencingOperationAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTimeCommencingOperationAD.Size = New System.Drawing.Size(53, 20)
Me.txtTimeCommencingOperationAD.TabIndex = 139
'
'txtDateCommencingOperationAD
'
Me.txtDateCommencingOperationAD.AcceptsReturn = true
Me.txtDateCommencingOperationAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtDateCommencingOperationAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtDateCommencingOperationAD.ForeColor = System.Drawing.Color.Blue
Me.txtDateCommencingOperationAD.Location = New System.Drawing.Point(60, 23)
Me.txtDateCommencingOperationAD.Name = "txtDateCommencingOperationAD"
Me.txtDateCommencingOperationAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtDateCommencingOperationAD.Size = New System.Drawing.Size(73, 20)
Me.txtDateCommencingOperationAD.TabIndex = 139
'
'Label27
'
Me.Label27.AutoSize = true
Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label27.Location = New System.Drawing.Point(22, 48)
Me.Label27.Name = "Label27"
Me.Label27.Size = New System.Drawing.Size(36, 13)
Me.Label27.TabIndex = 142
Me.Label27.Text = "Time :"
'
'GroupBox5
'
Me.GroupBox5.Controls.Add(Me.Label25)
Me.GroupBox5.Controls.Add(Me.Label24)
Me.GroupBox5.Controls.Add(Me.Label23)
Me.GroupBox5.Controls.Add(Me.cboNextPortAD)
Me.GroupBox5.Controls.Add(Me.cboDis_LoadPortAD)
Me.GroupBox5.Controls.Add(Me.cboPreviousPortAD)
Me.GroupBox5.Location = New System.Drawing.Point(31, 121)
Me.GroupBox5.Name = "GroupBox5"
Me.GroupBox5.Size = New System.Drawing.Size(519, 71)
Me.GroupBox5.TabIndex = 152
Me.GroupBox5.TabStop = false
Me.GroupBox5.Text = "Brief Particular of voyage on arrival (Previous and subsequent ports of call)"
'
'Label25
'
Me.Label25.AutoSize = true
Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label25.Location = New System.Drawing.Point(352, 20)
Me.Label25.Name = "Label25"
Me.Label25.Size = New System.Drawing.Size(57, 13)
Me.Label25.TabIndex = 150
Me.Label25.Text = "Next Port :"
'
'Label24
'
Me.Label24.AutoSize = true
Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label24.Location = New System.Drawing.Point(193, 20)
Me.Label24.Name = "Label24"
Me.Label24.Size = New System.Drawing.Size(79, 13)
Me.Label24.TabIndex = 150
Me.Label24.Text = "Dis/Load Port :"
'
'Label23
'
Me.Label23.AutoSize = true
Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label23.Location = New System.Drawing.Point(25, 20)
Me.Label23.Name = "Label23"
Me.Label23.Size = New System.Drawing.Size(76, 13)
Me.Label23.TabIndex = 150
Me.Label23.Text = "Previous Port :"
'
'cboNextPortAD
'
Me.cboNextPortAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.cboNextPortAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.cboNextPortAD.ForeColor = System.Drawing.Color.Blue
Me.cboNextPortAD.Location = New System.Drawing.Point(356, 36)
Me.cboNextPortAD.Name = "cboNextPortAD"
Me.cboNextPortAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.cboNextPortAD.Size = New System.Drawing.Size(120, 20)
Me.cboNextPortAD.TabIndex = 145
'
'cboDis_LoadPortAD
'
Me.cboDis_LoadPortAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.cboDis_LoadPortAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.cboDis_LoadPortAD.ForeColor = System.Drawing.Color.Blue
Me.cboDis_LoadPortAD.Location = New System.Drawing.Point(197, 36)
Me.cboDis_LoadPortAD.Name = "cboDis_LoadPortAD"
Me.cboDis_LoadPortAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.cboDis_LoadPortAD.Size = New System.Drawing.Size(120, 20)
Me.cboDis_LoadPortAD.TabIndex = 145
'
'cboPreviousPortAD
'
Me.cboPreviousPortAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.cboPreviousPortAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.cboPreviousPortAD.ForeColor = System.Drawing.Color.Blue
Me.cboPreviousPortAD.Location = New System.Drawing.Point(28, 36)
Me.cboPreviousPortAD.Name = "cboPreviousPortAD"
Me.cboPreviousPortAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.cboPreviousPortAD.Size = New System.Drawing.Size(120, 20)
Me.cboPreviousPortAD.TabIndex = 145
'
'Label19
'
Me.Label19.AutoSize = true
Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label19.Location = New System.Drawing.Point(28, 98)
Me.Label19.Name = "Label19"
Me.Label19.Size = New System.Drawing.Size(169, 13)
Me.Label19.TabIndex = 149
Me.Label19.Text = "Date of arrival or Transit VietNam :"
'
'Label20
'
Me.Label20.AutoSize = true
Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label20.Location = New System.Drawing.Point(86, 72)
Me.Label20.Name = "Label20"
Me.Label20.Size = New System.Drawing.Size(110, 13)
Me.Label20.TabIndex = 148
Me.Label20.Text = "Actual Displacement :"
'
'Label21
'
Me.Label21.AutoSize = true
Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label21.Location = New System.Drawing.Point(135, 46)
Me.Label21.Name = "Label21"
Me.Label21.Size = New System.Drawing.Size(61, 13)
Me.Label21.TabIndex = 151
Me.Label21.Text = "After Draft :"
'
'Label22
'
Me.Label22.AutoSize = true
Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label22.Location = New System.Drawing.Point(136, 20)
Me.Label22.Name = "Label22"
Me.Label22.Size = New System.Drawing.Size(60, 13)
Me.Label22.TabIndex = 150
Me.Label22.Text = "Fore Draft :"
'
'txtLastDateOfArrivalAD
'
Me.txtLastDateOfArrivalAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtLastDateOfArrivalAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtLastDateOfArrivalAD.ForeColor = System.Drawing.Color.Blue
Me.txtLastDateOfArrivalAD.Location = New System.Drawing.Point(199, 95)
Me.txtLastDateOfArrivalAD.Name = "txtLastDateOfArrivalAD"
Me.txtLastDateOfArrivalAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtLastDateOfArrivalAD.Size = New System.Drawing.Size(179, 20)
Me.txtLastDateOfArrivalAD.TabIndex = 145
'
'txtActualDisplacementAD
'
Me.txtActualDisplacementAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtActualDisplacementAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtActualDisplacementAD.ForeColor = System.Drawing.Color.Blue
Me.txtActualDisplacementAD.Location = New System.Drawing.Point(199, 69)
Me.txtActualDisplacementAD.Name = "txtActualDisplacementAD"
Me.txtActualDisplacementAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtActualDisplacementAD.Size = New System.Drawing.Size(179, 20)
Me.txtActualDisplacementAD.TabIndex = 144
'
'txtAfterDraftAD
'
Me.txtAfterDraftAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtAfterDraftAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtAfterDraftAD.ForeColor = System.Drawing.Color.Blue
Me.txtAfterDraftAD.Location = New System.Drawing.Point(199, 43)
Me.txtAfterDraftAD.Name = "txtAfterDraftAD"
Me.txtAfterDraftAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtAfterDraftAD.Size = New System.Drawing.Size(179, 20)
Me.txtAfterDraftAD.TabIndex = 147
'
'txtForeDraftAD
'
Me.txtForeDraftAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtForeDraftAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtForeDraftAD.ForeColor = System.Drawing.Color.Blue
Me.txtForeDraftAD.Location = New System.Drawing.Point(199, 17)
Me.txtForeDraftAD.Name = "txtForeDraftAD"
Me.txtForeDraftAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtForeDraftAD.Size = New System.Drawing.Size(179, 20)
Me.txtForeDraftAD.TabIndex = 146
'
'TabPage2
'
Me.TabPage2.Controls.Add(Me.TabControl3)
Me.TabPage2.Location = New System.Drawing.Point(4, 22)
Me.TabPage2.Name = "TabPage2"
Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage2.Size = New System.Drawing.Size(753, 217)
Me.TabPage2.TabIndex = 1
Me.TabPage2.Text = "Arrival Cargo"
Me.TabPage2.UseVisualStyleBackColor = true
'
'TabControl3
'
Me.TabControl3.Controls.Add(Me.TabPage6)
Me.TabControl3.Controls.Add(Me.TabPage7)
Me.TabControl3.Location = New System.Drawing.Point(6, 6)
Me.TabControl3.Name = "TabControl3"
Me.TabControl3.SelectedIndex = 0
Me.TabControl3.Size = New System.Drawing.Size(741, 205)
Me.TabControl3.TabIndex = 0
'
'TabPage6
'
Me.TabPage6.Controls.Add(Me.txtE45RHAD)
Me.TabPage6.Controls.Add(Me.txtE40RHAD)
Me.TabPage6.Controls.Add(Me.txtE20RHAD)
Me.TabPage6.Controls.Add(Me.txtE40RFAD)
Me.TabPage6.Controls.Add(Me.txtE20RFAD)
Me.TabPage6.Controls.Add(Me.txtE40HCAD)
Me.TabPage6.Controls.Add(Me.txtE45HCAD)
Me.TabPage6.Controls.Add(Me.txtE20HCAD)
Me.TabPage6.Controls.Add(Me.txtE40GPAD)
Me.TabPage6.Controls.Add(Me.txtE20GPAD)
Me.TabPage6.Controls.Add(Me.GroupBox7)
Me.TabPage6.Controls.Add(Me.Label46)
Me.TabPage6.Controls.Add(Me.Label37)
Me.TabPage6.Controls.Add(Me.Label36)
Me.TabPage6.Controls.Add(Me.Label42)
Me.TabPage6.Controls.Add(Me.Label32)
Me.TabPage6.Controls.Add(Me.Label45)
Me.TabPage6.Controls.Add(Me.Label41)
Me.TabPage6.Controls.Add(Me.Label35)
Me.TabPage6.Controls.Add(Me.Label44)
Me.TabPage6.Controls.Add(Me.Label31)
Me.TabPage6.Controls.Add(Me.Label34)
Me.TabPage6.Controls.Add(Me.Label39)
Me.TabPage6.Controls.Add(Me.Label28)
Me.TabPage6.Controls.Add(Me.Label43)
Me.TabPage6.Controls.Add(Me.Label40)
Me.TabPage6.Controls.Add(Me.Label33)
Me.TabPage6.Controls.Add(Me.Label30)
Me.TabPage6.Controls.Add(Me.Label38)
Me.TabPage6.Controls.Add(Me.Label29)
Me.TabPage6.Controls.Add(Me.txtE40TKAD)
Me.TabPage6.Controls.Add(Me.txtE20TKAD)
Me.TabPage6.Controls.Add(Me.txtE40OTAD)
Me.TabPage6.Controls.Add(Me.txtE40GHAD)
Me.TabPage6.Controls.Add(Me.txtE20OTAD)
Me.TabPage6.Controls.Add(Me.txtE40HGAD)
Me.TabPage6.Controls.Add(Me.txtE20HGAD)
Me.TabPage6.Controls.Add(Me.txtE40FRAD)
Me.TabPage6.Controls.Add(Me.txtE20FRAD)
Me.TabPage6.Location = New System.Drawing.Point(4, 22)
Me.TabPage6.Name = "TabPage6"
Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage6.Size = New System.Drawing.Size(733, 179)
Me.TabPage6.TabIndex = 0
Me.TabPage6.Text = "Empty Inbound Local  Container"
Me.TabPage6.UseVisualStyleBackColor = true
'
'txtE45RHAD
'
Me.txtE45RHAD.Location = New System.Drawing.Point(420, 25)
Me.txtE45RHAD.Name = "txtE45RHAD"
Me.txtE45RHAD.Size = New System.Drawing.Size(37, 20)
Me.txtE45RHAD.TabIndex = 150
'
'txtE40RHAD
'
Me.txtE40RHAD.Location = New System.Drawing.Point(377, 25)
Me.txtE40RHAD.Name = "txtE40RHAD"
Me.txtE40RHAD.Size = New System.Drawing.Size(37, 20)
Me.txtE40RHAD.TabIndex = 150
'
'txtE20RHAD
'
Me.txtE20RHAD.Location = New System.Drawing.Point(334, 25)
Me.txtE20RHAD.Name = "txtE20RHAD"
Me.txtE20RHAD.Size = New System.Drawing.Size(37, 20)
Me.txtE20RHAD.TabIndex = 150
'
'txtE40RFAD
'
Me.txtE40RFAD.Location = New System.Drawing.Point(289, 25)
Me.txtE40RFAD.Name = "txtE40RFAD"
Me.txtE40RFAD.Size = New System.Drawing.Size(37, 20)
Me.txtE40RFAD.TabIndex = 150
'
'txtE20RFAD
'
Me.txtE20RFAD.Location = New System.Drawing.Point(245, 25)
Me.txtE20RFAD.Name = "txtE20RFAD"
Me.txtE20RFAD.Size = New System.Drawing.Size(37, 20)
Me.txtE20RFAD.TabIndex = 150
'
'txtE40HCAD
'
Me.txtE40HCAD.Location = New System.Drawing.Point(151, 25)
Me.txtE40HCAD.Name = "txtE40HCAD"
Me.txtE40HCAD.Size = New System.Drawing.Size(37, 20)
Me.txtE40HCAD.TabIndex = 150
'
'txtE45HCAD
'
Me.txtE45HCAD.Location = New System.Drawing.Point(194, 25)
Me.txtE45HCAD.Name = "txtE45HCAD"
Me.txtE45HCAD.Size = New System.Drawing.Size(37, 20)
Me.txtE45HCAD.TabIndex = 150
'
'txtE20HCAD
'
Me.txtE20HCAD.Location = New System.Drawing.Point(108, 25)
Me.txtE20HCAD.Name = "txtE20HCAD"
Me.txtE20HCAD.Size = New System.Drawing.Size(37, 20)
Me.txtE20HCAD.TabIndex = 150
'
'txtE40GPAD
'
Me.txtE40GPAD.Location = New System.Drawing.Point(61, 25)
Me.txtE40GPAD.Name = "txtE40GPAD"
Me.txtE40GPAD.Size = New System.Drawing.Size(37, 20)
Me.txtE40GPAD.TabIndex = 149
'
'txtE20GPAD
'
Me.txtE20GPAD.Location = New System.Drawing.Point(17, 25)
Me.txtE20GPAD.Name = "txtE20GPAD"
Me.txtE20GPAD.Size = New System.Drawing.Size(37, 20)
Me.txtE20GPAD.TabIndex = 149
'
'GroupBox7
'
Me.GroupBox7.Controls.Add(Me.Label49)
Me.GroupBox7.Controls.Add(Me.Label47)
Me.GroupBox7.Controls.Add(Me.Label48)
Me.GroupBox7.Controls.Add(Me.TXTETONSAD)
Me.GroupBox7.Controls.Add(Me.TXTETEUAD)
Me.GroupBox7.Controls.Add(Me.TXTECNTRAD)
Me.GroupBox7.Location = New System.Drawing.Point(473, 29)
Me.GroupBox7.Name = "GroupBox7"
Me.GroupBox7.Size = New System.Drawing.Size(199, 66)
Me.GroupBox7.TabIndex = 148
Me.GroupBox7.TabStop = false
'
'Label49
'
Me.Label49.AutoSize = true
Me.Label49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label49.Location = New System.Drawing.Point(132, 19)
Me.Label49.Name = "Label49"
Me.Label49.Size = New System.Drawing.Size(37, 13)
Me.Label49.TabIndex = 147
Me.Label49.Text = "TONS"
'
'Label47
'
Me.Label47.AutoSize = true
Me.Label47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label47.Location = New System.Drawing.Point(86, 19)
Me.Label47.Name = "Label47"
Me.Label47.Size = New System.Drawing.Size(29, 13)
Me.Label47.TabIndex = 147
Me.Label47.Text = "TEU"
'
'Label48
'
Me.Label48.AutoSize = true
Me.Label48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label48.Location = New System.Drawing.Point(30, 19)
Me.Label48.Name = "Label48"
Me.Label48.Size = New System.Drawing.Size(37, 13)
Me.Label48.TabIndex = 147
Me.Label48.Text = "CTNR"
'
'TXTETONSAD
'
Me.TXTETONSAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TXTETONSAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.TXTETONSAD.ForeColor = System.Drawing.Color.Blue
Me.TXTETONSAD.Location = New System.Drawing.Point(132, 35)
Me.TXTETONSAD.Name = "TXTETONSAD"
Me.TXTETONSAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.TXTETONSAD.Size = New System.Drawing.Size(37, 20)
Me.TXTETONSAD.TabIndex = 145
'
'TXTETEUAD
'
Me.TXTETEUAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TXTETEUAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.TXTETEUAD.ForeColor = System.Drawing.Color.Blue
Me.TXTETEUAD.Location = New System.Drawing.Point(84, 35)
Me.TXTETEUAD.Name = "TXTETEUAD"
Me.TXTETEUAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.TXTETEUAD.Size = New System.Drawing.Size(37, 20)
Me.TXTETEUAD.TabIndex = 145
'
'TXTECNTRAD
'
Me.TXTECNTRAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TXTECNTRAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.TXTECNTRAD.ForeColor = System.Drawing.Color.Blue
Me.TXTECNTRAD.Location = New System.Drawing.Point(33, 35)
Me.TXTECNTRAD.Name = "TXTECNTRAD"
Me.TXTECNTRAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.TXTECNTRAD.Size = New System.Drawing.Size(37, 20)
Me.TXTECNTRAD.TabIndex = 145
'
'Label46
'
Me.Label46.AutoSize = true
Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label46.Location = New System.Drawing.Point(377, 59)
Me.Label46.Name = "Label46"
Me.Label46.Size = New System.Drawing.Size(33, 13)
Me.Label46.TabIndex = 147
Me.Label46.Text = "40TK"
'
'Label37
'
Me.Label37.AutoSize = true
Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label37.Location = New System.Drawing.Point(420, 9)
Me.Label37.Name = "Label37"
Me.Label37.Size = New System.Drawing.Size(35, 13)
Me.Label37.TabIndex = 147
Me.Label37.Text = "45RH"
'
'Label36
'
Me.Label36.AutoSize = true
Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label36.Location = New System.Drawing.Point(377, 9)
Me.Label36.Name = "Label36"
Me.Label36.Size = New System.Drawing.Size(35, 13)
Me.Label36.TabIndex = 147
Me.Label36.Text = "40RH"
'
'Label42
'
Me.Label42.AutoSize = true
Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label42.Location = New System.Drawing.Point(196, 59)
Me.Label42.Name = "Label42"
Me.Label42.Size = New System.Drawing.Size(35, 13)
Me.Label42.TabIndex = 147
Me.Label42.Text = "40GH"
'
'Label32
'
Me.Label32.AutoSize = true
Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label32.Location = New System.Drawing.Point(195, 9)
Me.Label32.Name = "Label32"
Me.Label32.Size = New System.Drawing.Size(34, 13)
Me.Label32.TabIndex = 147
Me.Label32.Text = "45HC"
'
'Label45
'
Me.Label45.AutoSize = true
Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label45.Location = New System.Drawing.Point(290, 59)
Me.Label45.Name = "Label45"
Me.Label45.Size = New System.Drawing.Size(34, 13)
Me.Label45.TabIndex = 147
Me.Label45.Text = "40OT"
'
'Label41
'
Me.Label41.AutoSize = true
Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label41.Location = New System.Drawing.Point(153, 59)
Me.Label41.Name = "Label41"
Me.Label41.Size = New System.Drawing.Size(35, 13)
Me.Label41.TabIndex = 147
Me.Label41.Text = "40HG"
'
'Label35
'
Me.Label35.AutoSize = true
Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label35.Location = New System.Drawing.Point(290, 9)
Me.Label35.Name = "Label35"
Me.Label35.Size = New System.Drawing.Size(33, 13)
Me.Label35.TabIndex = 147
Me.Label35.Text = "40RF"
'
'Label44
'
Me.Label44.AutoSize = true
Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label44.Location = New System.Drawing.Point(334, 59)
Me.Label44.Name = "Label44"
Me.Label44.Size = New System.Drawing.Size(33, 13)
Me.Label44.TabIndex = 147
Me.Label44.Text = "20TK"
'
'Label31
'
Me.Label31.AutoSize = true
Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label31.Location = New System.Drawing.Point(152, 9)
Me.Label31.Name = "Label31"
Me.Label31.Size = New System.Drawing.Size(34, 13)
Me.Label31.TabIndex = 147
Me.Label31.Text = "40HC"
'
'Label34
'
Me.Label34.AutoSize = true
Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label34.Location = New System.Drawing.Point(334, 9)
Me.Label34.Name = "Label34"
Me.Label34.Size = New System.Drawing.Size(35, 13)
Me.Label34.TabIndex = 147
Me.Label34.Text = "20RH"
'
'Label39
'
Me.Label39.AutoSize = true
Me.Label39.ForeColor = System.Drawing.Color.Maroon
Me.Label39.Location = New System.Drawing.Point(61, 59)
Me.Label39.Name = "Label39"
Me.Label39.Size = New System.Drawing.Size(33, 13)
Me.Label39.TabIndex = 147
Me.Label39.Text = "40FR"
'
'Label28
'
Me.Label28.AutoSize = true
Me.Label28.ForeColor = System.Drawing.Color.Gold
Me.Label28.Location = New System.Drawing.Point(61, 9)
Me.Label28.Name = "Label28"
Me.Label28.Size = New System.Drawing.Size(34, 13)
Me.Label28.TabIndex = 147
Me.Label28.Text = "40GP"
'
'Label43
'
Me.Label43.AutoSize = true
Me.Label43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label43.Location = New System.Drawing.Point(247, 59)
Me.Label43.Name = "Label43"
Me.Label43.Size = New System.Drawing.Size(34, 13)
Me.Label43.TabIndex = 147
Me.Label43.Text = "20OT"
'
'Label40
'
Me.Label40.AutoSize = true
Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label40.Location = New System.Drawing.Point(109, 59)
Me.Label40.Name = "Label40"
Me.Label40.Size = New System.Drawing.Size(35, 13)
Me.Label40.TabIndex = 147
Me.Label40.Text = "20HG"
'
'Label33
'
Me.Label33.AutoSize = true
Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label33.Location = New System.Drawing.Point(247, 9)
Me.Label33.Name = "Label33"
Me.Label33.Size = New System.Drawing.Size(33, 13)
Me.Label33.TabIndex = 147
Me.Label33.Text = "20RF"
'
'Label30
'
Me.Label30.AutoSize = true
Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label30.Location = New System.Drawing.Point(109, 9)
Me.Label30.Name = "Label30"
Me.Label30.Size = New System.Drawing.Size(34, 13)
Me.Label30.TabIndex = 147
Me.Label30.Text = "20HC"
'
'Label38
'
Me.Label38.AutoSize = true
Me.Label38.ForeColor = System.Drawing.Color.Maroon
Me.Label38.Location = New System.Drawing.Point(18, 59)
Me.Label38.Name = "Label38"
Me.Label38.Size = New System.Drawing.Size(33, 13)
Me.Label38.TabIndex = 147
Me.Label38.Text = "20FR"
'
'Label29
'
Me.Label29.AutoSize = true
Me.Label29.ForeColor = System.Drawing.Color.Gold
Me.Label29.Location = New System.Drawing.Point(18, 9)
Me.Label29.Name = "Label29"
Me.Label29.Size = New System.Drawing.Size(34, 13)
Me.Label29.TabIndex = 147
Me.Label29.Text = "20GP"
'
'txtE40TKAD
'
Me.txtE40TKAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtE40TKAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtE40TKAD.ForeColor = System.Drawing.Color.Blue
Me.txtE40TKAD.Location = New System.Drawing.Point(377, 75)
Me.txtE40TKAD.Name = "txtE40TKAD"
Me.txtE40TKAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtE40TKAD.Size = New System.Drawing.Size(37, 20)
Me.txtE40TKAD.TabIndex = 145
'
'txtE20TKAD
'
Me.txtE20TKAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtE20TKAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtE20TKAD.ForeColor = System.Drawing.Color.Blue
Me.txtE20TKAD.Location = New System.Drawing.Point(334, 75)
Me.txtE20TKAD.Name = "txtE20TKAD"
Me.txtE20TKAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtE20TKAD.Size = New System.Drawing.Size(37, 20)
Me.txtE20TKAD.TabIndex = 145
'
'txtE40OTAD
'
Me.txtE40OTAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtE40OTAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtE40OTAD.ForeColor = System.Drawing.Color.Blue
Me.txtE40OTAD.Location = New System.Drawing.Point(289, 75)
Me.txtE40OTAD.Name = "txtE40OTAD"
Me.txtE40OTAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtE40OTAD.Size = New System.Drawing.Size(37, 20)
Me.txtE40OTAD.TabIndex = 145
'
'txtE40GHAD
'
Me.txtE40GHAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtE40GHAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtE40GHAD.ForeColor = System.Drawing.Color.Blue
Me.txtE40GHAD.Location = New System.Drawing.Point(194, 75)
Me.txtE40GHAD.Name = "txtE40GHAD"
Me.txtE40GHAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtE40GHAD.Size = New System.Drawing.Size(37, 20)
Me.txtE40GHAD.TabIndex = 145
'
'txtE20OTAD
'
Me.txtE20OTAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtE20OTAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtE20OTAD.ForeColor = System.Drawing.Color.Blue
Me.txtE20OTAD.Location = New System.Drawing.Point(245, 75)
Me.txtE20OTAD.Name = "txtE20OTAD"
Me.txtE20OTAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtE20OTAD.Size = New System.Drawing.Size(37, 20)
Me.txtE20OTAD.TabIndex = 145
'
'txtE40HGAD
'
Me.txtE40HGAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtE40HGAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtE40HGAD.ForeColor = System.Drawing.Color.Blue
Me.txtE40HGAD.Location = New System.Drawing.Point(150, 75)
Me.txtE40HGAD.Name = "txtE40HGAD"
Me.txtE40HGAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtE40HGAD.Size = New System.Drawing.Size(37, 20)
Me.txtE40HGAD.TabIndex = 145
'
'txtE20HGAD
'
Me.txtE20HGAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtE20HGAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtE20HGAD.ForeColor = System.Drawing.Color.Blue
Me.txtE20HGAD.Location = New System.Drawing.Point(108, 75)
Me.txtE20HGAD.Name = "txtE20HGAD"
Me.txtE20HGAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtE20HGAD.Size = New System.Drawing.Size(37, 20)
Me.txtE20HGAD.TabIndex = 145
'
'txtE40FRAD
'
Me.txtE40FRAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtE40FRAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtE40FRAD.ForeColor = System.Drawing.Color.Blue
Me.txtE40FRAD.Location = New System.Drawing.Point(61, 75)
Me.txtE40FRAD.Name = "txtE40FRAD"
Me.txtE40FRAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtE40FRAD.Size = New System.Drawing.Size(37, 20)
Me.txtE40FRAD.TabIndex = 145
'
'txtE20FRAD
'
Me.txtE20FRAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtE20FRAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtE20FRAD.ForeColor = System.Drawing.Color.Blue
Me.txtE20FRAD.Location = New System.Drawing.Point(17, 75)
Me.txtE20FRAD.Name = "txtE20FRAD"
Me.txtE20FRAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtE20FRAD.Size = New System.Drawing.Size(37, 20)
Me.txtE20FRAD.TabIndex = 145
'
'TabPage7
'
Me.TabPage7.Controls.Add(Me.txtF40TKAD)
Me.TabPage7.Controls.Add(Me.txtF20TKAD)
Me.TabPage7.Controls.Add(Me.txtF40OTAD)
Me.TabPage7.Controls.Add(Me.txtF20OTAD)
Me.TabPage7.Controls.Add(Me.txtF40GHAD)
Me.TabPage7.Controls.Add(Me.txtF40HGAD)
Me.TabPage7.Controls.Add(Me.txtF20HGAD)
Me.TabPage7.Controls.Add(Me.txtF40FRAD)
Me.TabPage7.Controls.Add(Me.txtF20FRAD)
Me.TabPage7.Controls.Add(Me.txtF45RHAD)
Me.TabPage7.Controls.Add(Me.txtF40RHAD)
Me.TabPage7.Controls.Add(Me.txtF20RHAD)
Me.TabPage7.Controls.Add(Me.txtF40RFAD)
Me.TabPage7.Controls.Add(Me.txtF20RFAD)
Me.TabPage7.Controls.Add(Me.txtF45HCAD)
Me.TabPage7.Controls.Add(Me.txtF40HCAD)
Me.TabPage7.Controls.Add(Me.txtF20HCAD)
Me.TabPage7.Controls.Add(Me.txtF40GPAD)
Me.TabPage7.Controls.Add(Me.txtF20GPAD)
Me.TabPage7.Controls.Add(Me.Label76)
Me.TabPage7.Controls.Add(Me.Label75)
Me.TabPage7.Controls.Add(Me.txtRemaksAD)
Me.TabPage7.Controls.Add(Me.txtOtherConcerningRequirementOfShipAD)
Me.TabPage7.Controls.Add(Me.GroupBox9)
Me.TabPage7.Controls.Add(Me.GroupBox8)
Me.TabPage7.Controls.Add(Me.Label53)
Me.TabPage7.Controls.Add(Me.Label54)
Me.TabPage7.Controls.Add(Me.Label55)
Me.TabPage7.Controls.Add(Me.Label56)
Me.TabPage7.Controls.Add(Me.Label57)
Me.TabPage7.Controls.Add(Me.Label58)
Me.TabPage7.Controls.Add(Me.Label59)
Me.TabPage7.Controls.Add(Me.Label60)
Me.TabPage7.Controls.Add(Me.Label61)
Me.TabPage7.Controls.Add(Me.Label62)
Me.TabPage7.Controls.Add(Me.Label63)
Me.TabPage7.Controls.Add(Me.Label64)
Me.TabPage7.Controls.Add(Me.Label65)
Me.TabPage7.Controls.Add(Me.Label66)
Me.TabPage7.Controls.Add(Me.Label67)
Me.TabPage7.Controls.Add(Me.Label68)
Me.TabPage7.Controls.Add(Me.Label69)
Me.TabPage7.Controls.Add(Me.Label70)
Me.TabPage7.Controls.Add(Me.Label71)
Me.TabPage7.Location = New System.Drawing.Point(4, 22)
Me.TabPage7.Name = "TabPage7"
Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage7.Size = New System.Drawing.Size(733, 179)
Me.TabPage7.TabIndex = 1
Me.TabPage7.Text = "Full Inbound Local Container"
Me.TabPage7.UseVisualStyleBackColor = true
'
'txtF40TKAD
'
Me.txtF40TKAD.Location = New System.Drawing.Point(376, 67)
Me.txtF40TKAD.Name = "txtF40TKAD"
Me.txtF40TKAD.Size = New System.Drawing.Size(33, 20)
Me.txtF40TKAD.TabIndex = 191
'
'txtF20TKAD
'
Me.txtF20TKAD.Location = New System.Drawing.Point(337, 67)
Me.txtF20TKAD.Name = "txtF20TKAD"
Me.txtF20TKAD.Size = New System.Drawing.Size(33, 20)
Me.txtF20TKAD.TabIndex = 191
'
'txtF40OTAD
'
Me.txtF40OTAD.Location = New System.Drawing.Point(291, 67)
Me.txtF40OTAD.Name = "txtF40OTAD"
Me.txtF40OTAD.Size = New System.Drawing.Size(33, 20)
Me.txtF40OTAD.TabIndex = 191
'
'txtF20OTAD
'
Me.txtF20OTAD.Location = New System.Drawing.Point(248, 67)
Me.txtF20OTAD.Name = "txtF20OTAD"
Me.txtF20OTAD.Size = New System.Drawing.Size(33, 20)
Me.txtF20OTAD.TabIndex = 191
'
'txtF40GHAD
'
Me.txtF40GHAD.Location = New System.Drawing.Point(197, 67)
Me.txtF40GHAD.Name = "txtF40GHAD"
Me.txtF40GHAD.Size = New System.Drawing.Size(33, 20)
Me.txtF40GHAD.TabIndex = 191
'
'txtF40HGAD
'
Me.txtF40HGAD.Location = New System.Drawing.Point(153, 67)
Me.txtF40HGAD.Name = "txtF40HGAD"
Me.txtF40HGAD.Size = New System.Drawing.Size(33, 20)
Me.txtF40HGAD.TabIndex = 191
'
'txtF20HGAD
'
Me.txtF20HGAD.Location = New System.Drawing.Point(111, 67)
Me.txtF20HGAD.Name = "txtF20HGAD"
Me.txtF20HGAD.Size = New System.Drawing.Size(33, 20)
Me.txtF20HGAD.TabIndex = 191
'
'txtF40FRAD
'
Me.txtF40FRAD.Location = New System.Drawing.Point(61, 67)
Me.txtF40FRAD.Name = "txtF40FRAD"
Me.txtF40FRAD.Size = New System.Drawing.Size(33, 20)
Me.txtF40FRAD.TabIndex = 191
'
'txtF20FRAD
'
Me.txtF20FRAD.Location = New System.Drawing.Point(16, 67)
Me.txtF20FRAD.Name = "txtF20FRAD"
Me.txtF20FRAD.Size = New System.Drawing.Size(33, 20)
Me.txtF20FRAD.TabIndex = 191
'
'txtF45RHAD
'
Me.txtF45RHAD.Location = New System.Drawing.Point(423, 23)
Me.txtF45RHAD.Name = "txtF45RHAD"
Me.txtF45RHAD.Size = New System.Drawing.Size(33, 20)
Me.txtF45RHAD.TabIndex = 191
'
'txtF40RHAD
'
Me.txtF40RHAD.Location = New System.Drawing.Point(378, 23)
Me.txtF40RHAD.Name = "txtF40RHAD"
Me.txtF40RHAD.Size = New System.Drawing.Size(33, 20)
Me.txtF40RHAD.TabIndex = 191
'
'txtF20RHAD
'
Me.txtF20RHAD.Location = New System.Drawing.Point(335, 23)
Me.txtF20RHAD.Name = "txtF20RHAD"
Me.txtF20RHAD.Size = New System.Drawing.Size(33, 20)
Me.txtF20RHAD.TabIndex = 191
'
'txtF40RFAD
'
Me.txtF40RFAD.Location = New System.Drawing.Point(294, 23)
Me.txtF40RFAD.Name = "txtF40RFAD"
Me.txtF40RFAD.Size = New System.Drawing.Size(33, 20)
Me.txtF40RFAD.TabIndex = 191
'
'txtF20RFAD
'
Me.txtF20RFAD.Location = New System.Drawing.Point(251, 23)
Me.txtF20RFAD.Name = "txtF20RFAD"
Me.txtF20RFAD.Size = New System.Drawing.Size(33, 20)
Me.txtF20RFAD.TabIndex = 191
'
'txtF45HCAD
'
Me.txtF45HCAD.Location = New System.Drawing.Point(200, 23)
Me.txtF45HCAD.Name = "txtF45HCAD"
Me.txtF45HCAD.Size = New System.Drawing.Size(33, 20)
Me.txtF45HCAD.TabIndex = 191
'
'txtF40HCAD
'
Me.txtF40HCAD.Location = New System.Drawing.Point(153, 23)
Me.txtF40HCAD.Name = "txtF40HCAD"
Me.txtF40HCAD.Size = New System.Drawing.Size(33, 20)
Me.txtF40HCAD.TabIndex = 191
'
'txtF20HCAD
'
Me.txtF20HCAD.Location = New System.Drawing.Point(113, 23)
Me.txtF20HCAD.Name = "txtF20HCAD"
Me.txtF20HCAD.Size = New System.Drawing.Size(33, 20)
Me.txtF20HCAD.TabIndex = 191
'
'txtF40GPAD
'
Me.txtF40GPAD.Location = New System.Drawing.Point(61, 23)
Me.txtF40GPAD.Name = "txtF40GPAD"
Me.txtF40GPAD.Size = New System.Drawing.Size(33, 20)
Me.txtF40GPAD.TabIndex = 191
'
'txtF20GPAD
'
Me.txtF20GPAD.Location = New System.Drawing.Point(16, 23)
Me.txtF20GPAD.Name = "txtF20GPAD"
Me.txtF20GPAD.Size = New System.Drawing.Size(33, 20)
Me.txtF20GPAD.TabIndex = 191
'
'Label76
'
Me.Label76.AutoSize = true
Me.Label76.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label76.Location = New System.Drawing.Point(18, 135)
Me.Label76.Name = "Label76"
Me.Label76.Size = New System.Drawing.Size(55, 13)
Me.Label76.TabIndex = 190
Me.Label76.Text = "Remarks :"
'
'Label75
'
Me.Label75.AutoSize = true
Me.Label75.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label75.Location = New System.Drawing.Point(17, 95)
Me.Label75.Name = "Label75"
Me.Label75.Size = New System.Drawing.Size(187, 13)
Me.Label75.TabIndex = 190
Me.Label75.Text = "Other concerning requirement of ship :"
'
'txtRemaksAD
'
Me.txtRemaksAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtRemaksAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtRemaksAD.ForeColor = System.Drawing.Color.Blue
Me.txtRemaksAD.Location = New System.Drawing.Point(20, 151)
Me.txtRemaksAD.Name = "txtRemaksAD"
Me.txtRemaksAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtRemaksAD.Size = New System.Drawing.Size(393, 20)
Me.txtRemaksAD.TabIndex = 189
'
'txtOtherConcerningRequirementOfShipAD
'
Me.txtOtherConcerningRequirementOfShipAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtOtherConcerningRequirementOfShipAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
Me.txtOtherConcerningRequirementOfShipAD.ForeColor = System.Drawing.Color.Blue
Me.txtOtherConcerningRequirementOfShipAD.Location = New System.Drawing.Point(20, 111)
Me.txtOtherConcerningRequirementOfShipAD.Name = "txtOtherConcerningRequirementOfShipAD"
Me.txtOtherConcerningRequirementOfShipAD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtOtherConcerningRequirementOfShipAD.Size = New System.Drawing.Size(393, 20)
Me.txtOtherConcerningRequirementOfShipAD.TabIndex = 189
'
'GroupBox9
'
Me.GroupBox9.Controls.Add(Me.txtDangerousInboundCargoTONSAD)
Me.GroupBox9.Controls.Add(Me.txtDangerousInboundCargoCLASSAD)
Me.GroupBox9.Controls.Add(Me.txtDangerousInboundCargoCNTRAD)
Me.GroupBox9.Controls.Add(Me.Label72)
Me.GroupBox9.Controls.Add(Me.Label73)
Me.GroupBox9.Controls.Add(Me.Label74)
Me.GroupBox9.Location = New System.Drawing.Point(474, 86)
Me.GroupBox9.Name = "GroupBox9"
Me.GroupBox9.Size = New System.Drawing.Size(199, 66)
Me.GroupBox9.TabIndex = 188
Me.GroupBox9.TabStop = false
Me.GroupBox9.Text = "Dangerous Inbound Cargo"
'
'txtDangerousInboundCargoTONSAD
'
Me.txtDangerousInboundCargoTONSAD.Location = New System.Drawing.Point(85, 35)
Me.txtDangerousInboundCargoTONSAD.Name = "txtDangerousInboundCargoTONSAD"
Me.txtDangerousInboundCargoTONSAD.Size = New System.Drawing.Size(48, 20)
Me.txtDangerousInboundCargoTONSAD.TabIndex = 191
'
'txtDangerousInboundCargoCLASSAD
'
Me.txtDangerousInboundCargoCLASSAD.Location = New System.Drawing.Point(133, 35)
Me.txtDangerousInboundCargoCLASSAD.Name = "txtDangerousInboundCargoCLASSAD"
Me.txtDangerousInboundCargoCLASSAD.Size = New System.Drawing.Size(48, 20)
Me.txtDangerousInboundCargoCLASSAD.TabIndex = 191
'
'txtDangerousInboundCargoCNTRAD
'
Me.txtDangerousInboundCargoCNTRAD.Location = New System.Drawing.Point(33, 35)
Me.txtDangerousInboundCargoCNTRAD.Name = "txtDangerousInboundCargoCNTRAD"
Me.txtDangerousInboundCargoCNTRAD.Size = New System.Drawing.Size(48, 20)
Me.txtDangerousInboundCargoCNTRAD.TabIndex = 191
'
'Label72
'
Me.Label72.AutoSize = true
Me.Label72.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label72.Location = New System.Drawing.Point(134, 19)
Me.Label72.Name = "Label72"
Me.Label72.Size = New System.Drawing.Size(32, 13)
Me.Label72.TabIndex = 147
Me.Label72.Text = "Class"
'
'Label73
'
Me.Label73.AutoSize = true
Me.Label73.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label73.Location = New System.Drawing.Point(86, 19)
Me.Label73.Name = "Label73"
Me.Label73.Size = New System.Drawing.Size(29, 13)
Me.Label73.TabIndex = 147
Me.Label73.Text = "TEU"
'
'Label74
'
Me.Label74.AutoSize = true
Me.Label74.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label74.Location = New System.Drawing.Point(30, 19)
Me.Label74.Name = "Label74"
Me.Label74.Size = New System.Drawing.Size(37, 13)
Me.Label74.TabIndex = 147
Me.Label74.Text = "CTNR"
'
'GroupBox8
'
Me.GroupBox8.Controls.Add(Me.txtFTONAD)
Me.GroupBox8.Controls.Add(Me.txtFTEUAD)
Me.GroupBox8.Controls.Add(Me.txtFCNTRAD)
Me.GroupBox8.Controls.Add(Me.Label50)
Me.GroupBox8.Controls.Add(Me.Label51)
Me.GroupBox8.Controls.Add(Me.Label52)
Me.GroupBox8.Location = New System.Drawing.Point(474, 7)
Me.GroupBox8.Name = "GroupBox8"
Me.GroupBox8.Size = New System.Drawing.Size(199, 66)
Me.GroupBox8.TabIndex = 187
Me.GroupBox8.TabStop = false
'
'txtFTONAD
'
Me.txtFTONAD.Location = New System.Drawing.Point(133, 40)
Me.txtFTONAD.Name = "txtFTONAD"
Me.txtFTONAD.Size = New System.Drawing.Size(45, 20)
Me.txtFTONAD.TabIndex = 191
'
'txtFTEUAD
'
Me.txtFTEUAD.Location = New System.Drawing.Point(83, 40)
Me.txtFTEUAD.Name = "txtFTEUAD"
Me.txtFTEUAD.Size = New System.Drawing.Size(45, 20)
Me.txtFTEUAD.TabIndex = 191
'
'txtFCNTRAD
'
Me.txtFCNTRAD.Location = New System.Drawing.Point(33, 40)
Me.txtFCNTRAD.Name = "txtFCNTRAD"
Me.txtFCNTRAD.Size = New System.Drawing.Size(45, 20)
Me.txtFCNTRAD.TabIndex = 191
'
'Label50
'
Me.Label50.AutoSize = true
Me.Label50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label50.Location = New System.Drawing.Point(132, 19)
Me.Label50.Name = "Label50"
Me.Label50.Size = New System.Drawing.Size(37, 13)
Me.Label50.TabIndex = 147
Me.Label50.Text = "TONS"
'
'Label51
'
Me.Label51.AutoSize = true
Me.Label51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label51.Location = New System.Drawing.Point(86, 19)
Me.Label51.Name = "Label51"
Me.Label51.Size = New System.Drawing.Size(29, 13)
Me.Label51.TabIndex = 147
Me.Label51.Text = "TEU"
'
'Label52
'
Me.Label52.AutoSize = true
Me.Label52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label52.Location = New System.Drawing.Point(30, 19)
Me.Label52.Name = "Label52"
Me.Label52.Size = New System.Drawing.Size(37, 13)
Me.Label52.TabIndex = 147
Me.Label52.Text = "CTNR"
'
'Label53
'
Me.Label53.AutoSize = true
Me.Label53.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label53.Location = New System.Drawing.Point(378, 51)
Me.Label53.Name = "Label53"
Me.Label53.Size = New System.Drawing.Size(33, 13)
Me.Label53.TabIndex = 174
Me.Label53.Text = "40TK"
'
'Label54
'
Me.Label54.AutoSize = true
Me.Label54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label54.Location = New System.Drawing.Point(421, 7)
Me.Label54.Name = "Label54"
Me.Label54.Size = New System.Drawing.Size(35, 13)
Me.Label54.TabIndex = 173
Me.Label54.Text = "45RH"
'
'Label55
'
Me.Label55.AutoSize = true
Me.Label55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label55.Location = New System.Drawing.Point(378, 7)
Me.Label55.Name = "Label55"
Me.Label55.Size = New System.Drawing.Size(35, 13)
Me.Label55.TabIndex = 176
Me.Label55.Text = "40RH"
'
'Label56
'
Me.Label56.AutoSize = true
Me.Label56.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label56.Location = New System.Drawing.Point(197, 51)
Me.Label56.Name = "Label56"
Me.Label56.Size = New System.Drawing.Size(35, 13)
Me.Label56.TabIndex = 175
Me.Label56.Text = "40GH"
'
'Label57
'
Me.Label57.AutoSize = true
Me.Label57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label57.Location = New System.Drawing.Point(196, 7)
Me.Label57.Name = "Label57"
Me.Label57.Size = New System.Drawing.Size(34, 13)
Me.Label57.TabIndex = 172
Me.Label57.Text = "45HC"
'
'Label58
'
Me.Label58.AutoSize = true
Me.Label58.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label58.Location = New System.Drawing.Point(291, 51)
Me.Label58.Name = "Label58"
Me.Label58.Size = New System.Drawing.Size(34, 13)
Me.Label58.TabIndex = 169
Me.Label58.Text = "40OT"
'
'Label59
'
Me.Label59.AutoSize = true
Me.Label59.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label59.Location = New System.Drawing.Point(154, 51)
Me.Label59.Name = "Label59"
Me.Label59.Size = New System.Drawing.Size(35, 13)
Me.Label59.TabIndex = 168
Me.Label59.Text = "40HG"
'
'Label60
'
Me.Label60.AutoSize = true
Me.Label60.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label60.Location = New System.Drawing.Point(291, 7)
Me.Label60.Name = "Label60"
Me.Label60.Size = New System.Drawing.Size(33, 13)
Me.Label60.TabIndex = 171
Me.Label60.Text = "40RF"
'
'Label61
'
Me.Label61.AutoSize = true
Me.Label61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label61.Location = New System.Drawing.Point(335, 51)
Me.Label61.Name = "Label61"
Me.Label61.Size = New System.Drawing.Size(33, 13)
Me.Label61.TabIndex = 170
Me.Label61.Text = "20TK"
'
'Label62
'
Me.Label62.AutoSize = true
Me.Label62.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label62.Location = New System.Drawing.Point(153, 7)
Me.Label62.Name = "Label62"
Me.Label62.Size = New System.Drawing.Size(34, 13)
Me.Label62.TabIndex = 177
Me.Label62.Text = "40HC"
'
'Label63
'
Me.Label63.AutoSize = true
Me.Label63.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label63.Location = New System.Drawing.Point(335, 7)
Me.Label63.Name = "Label63"
Me.Label63.Size = New System.Drawing.Size(35, 13)
Me.Label63.TabIndex = 184
Me.Label63.Text = "20RH"
'
'Label64
'
Me.Label64.AutoSize = true
Me.Label64.ForeColor = System.Drawing.Color.Maroon
Me.Label64.Location = New System.Drawing.Point(62, 51)
Me.Label64.Name = "Label64"
Me.Label64.Size = New System.Drawing.Size(33, 13)
Me.Label64.TabIndex = 183
Me.Label64.Text = "40FR"
'
'Label65
'
Me.Label65.AutoSize = true
Me.Label65.ForeColor = System.Drawing.Color.Gold
Me.Label65.Location = New System.Drawing.Point(62, 7)
Me.Label65.Name = "Label65"
Me.Label65.Size = New System.Drawing.Size(34, 13)
Me.Label65.TabIndex = 186
Me.Label65.Text = "40GP"
'
'Label66
'
Me.Label66.AutoSize = true
Me.Label66.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label66.Location = New System.Drawing.Point(248, 51)
Me.Label66.Name = "Label66"
Me.Label66.Size = New System.Drawing.Size(34, 13)
Me.Label66.TabIndex = 185
Me.Label66.Text = "20OT"
'
'Label67
'
Me.Label67.AutoSize = true
Me.Label67.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label67.Location = New System.Drawing.Point(111, 51)
Me.Label67.Name = "Label67"
Me.Label67.Size = New System.Drawing.Size(35, 13)
Me.Label67.TabIndex = 182
Me.Label67.Text = "20HG"
'
'Label68
'
Me.Label68.AutoSize = true
Me.Label68.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label68.Location = New System.Drawing.Point(248, 7)
Me.Label68.Name = "Label68"
Me.Label68.Size = New System.Drawing.Size(33, 13)
Me.Label68.TabIndex = 179
Me.Label68.Text = "20RF"
'
'Label69
'
Me.Label69.AutoSize = true
Me.Label69.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label69.Location = New System.Drawing.Point(110, 7)
Me.Label69.Name = "Label69"
Me.Label69.Size = New System.Drawing.Size(34, 13)
Me.Label69.TabIndex = 178
Me.Label69.Text = "20HC"
'
'Label70
'
Me.Label70.AutoSize = true
Me.Label70.ForeColor = System.Drawing.Color.Maroon
Me.Label70.Location = New System.Drawing.Point(19, 51)
Me.Label70.Name = "Label70"
Me.Label70.Size = New System.Drawing.Size(33, 13)
Me.Label70.TabIndex = 180
Me.Label70.Text = "20FR"
'
'Label71
'
Me.Label71.AutoSize = true
Me.Label71.ForeColor = System.Drawing.Color.Gold
Me.Label71.Location = New System.Drawing.Point(19, 7)
Me.Label71.Name = "Label71"
Me.Label71.Size = New System.Drawing.Size(34, 13)
Me.Label71.TabIndex = 181
Me.Label71.Text = "20GP"
'
'TabPage11
'
Me.TabPage11.Controls.Add(Me.TabControl5)
Me.TabPage11.Location = New System.Drawing.Point(4, 22)
Me.TabPage11.Name = "TabPage11"
Me.TabPage11.Size = New System.Drawing.Size(753, 217)
Me.TabPage11.TabIndex = 3
Me.TabPage11.Text = "Transit Inbound Cargo"
Me.TabPage11.UseVisualStyleBackColor = true
'
'TabControl5
'
Me.TabControl5.Controls.Add(Me.TabPage12)
Me.TabControl5.Controls.Add(Me.TabPage13)
Me.TabControl5.Location = New System.Drawing.Point(6, 6)
Me.TabControl5.Name = "TabControl5"
Me.TabControl5.SelectedIndex = 0
Me.TabControl5.Size = New System.Drawing.Size(741, 205)
Me.TabControl5.TabIndex = 1
'
'TabPage12
'
Me.TabPage12.Controls.Add(Me.txtE40TKAD1)
Me.TabPage12.Controls.Add(Me.txtE20TKAD1)
Me.TabPage12.Controls.Add(Me.txtE40OTAD1)
Me.TabPage12.Controls.Add(Me.txtE20OTAD1)
Me.TabPage12.Controls.Add(Me.txtE40GHAD1)
Me.TabPage12.Controls.Add(Me.txtE40HGAD1)
Me.TabPage12.Controls.Add(Me.txtE20HGAD1)
Me.TabPage12.Controls.Add(Me.txtE40FRAD1)
Me.TabPage12.Controls.Add(Me.txtE20FRAD1)
Me.TabPage12.Controls.Add(Me.txtE45RHAD1)
Me.TabPage12.Controls.Add(Me.txtE40RHAD1)
Me.TabPage12.Controls.Add(Me.txtE20RHAD1)
Me.TabPage12.Controls.Add(Me.txtE40RFAD1)
Me.TabPage12.Controls.Add(Me.txtE20RFAD1)
Me.TabPage12.Controls.Add(Me.txtE45HCAD1)
Me.TabPage12.Controls.Add(Me.txtE40HCAD1)
Me.TabPage12.Controls.Add(Me.txtE20HCAD1)
Me.TabPage12.Controls.Add(Me.txtE40GPAD1)
Me.TabPage12.Controls.Add(Me.txtE20GPAD1)
Me.TabPage12.Controls.Add(Me.GroupBox19)
Me.TabPage12.Controls.Add(Me.Label156)
Me.TabPage12.Controls.Add(Me.Label157)
Me.TabPage12.Controls.Add(Me.Label158)
Me.TabPage12.Controls.Add(Me.Label159)
Me.TabPage12.Controls.Add(Me.Label160)
Me.TabPage12.Controls.Add(Me.Label161)
Me.TabPage12.Controls.Add(Me.Label162)
Me.TabPage12.Controls.Add(Me.Label163)
Me.TabPage12.Controls.Add(Me.Label164)
Me.TabPage12.Controls.Add(Me.Label165)
Me.TabPage12.Controls.Add(Me.Label166)
Me.TabPage12.Controls.Add(Me.Label167)
Me.TabPage12.Controls.Add(Me.Label168)
Me.TabPage12.Controls.Add(Me.Label169)
Me.TabPage12.Controls.Add(Me.Label170)
Me.TabPage12.Controls.Add(Me.Label171)
Me.TabPage12.Controls.Add(Me.Label172)
Me.TabPage12.Controls.Add(Me.Label173)
Me.TabPage12.Controls.Add(Me.Label174)
Me.TabPage12.Location = New System.Drawing.Point(4, 22)
Me.TabPage12.Name = "TabPage12"
Me.TabPage12.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage12.Size = New System.Drawing.Size(733, 179)
Me.TabPage12.TabIndex = 0
Me.TabPage12.Text = "Empty Transit Inbound Container"
Me.TabPage12.UseVisualStyleBackColor = true
'
'txtE40TKAD1
'
Me.txtE40TKAD1.Location = New System.Drawing.Point(380, 75)
Me.txtE40TKAD1.Name = "txtE40TKAD1"
Me.txtE40TKAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40TKAD1.TabIndex = 148
'
'txtE20TKAD1
'
Me.txtE20TKAD1.Location = New System.Drawing.Point(334, 75)
Me.txtE20TKAD1.Name = "txtE20TKAD1"
Me.txtE20TKAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20TKAD1.TabIndex = 148
'
'txtE40OTAD1
'
Me.txtE40OTAD1.Location = New System.Drawing.Point(293, 75)
Me.txtE40OTAD1.Name = "txtE40OTAD1"
Me.txtE40OTAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40OTAD1.TabIndex = 148
'
'txtE20OTAD1
'
Me.txtE20OTAD1.Location = New System.Drawing.Point(245, 75)
Me.txtE20OTAD1.Name = "txtE20OTAD1"
Me.txtE20OTAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20OTAD1.TabIndex = 148
'
'txtE40GHAD1
'
Me.txtE40GHAD1.Location = New System.Drawing.Point(198, 75)
Me.txtE40GHAD1.Name = "txtE40GHAD1"
Me.txtE40GHAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40GHAD1.TabIndex = 148
'
'txtE40HGAD1
'
Me.txtE40HGAD1.Location = New System.Drawing.Point(153, 75)
Me.txtE40HGAD1.Name = "txtE40HGAD1"
Me.txtE40HGAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40HGAD1.TabIndex = 148
'
'txtE20HGAD1
'
Me.txtE20HGAD1.Location = New System.Drawing.Point(108, 75)
Me.txtE20HGAD1.Name = "txtE20HGAD1"
Me.txtE20HGAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20HGAD1.TabIndex = 148
'
'txtE40FRAD1
'
Me.txtE40FRAD1.Location = New System.Drawing.Point(59, 75)
Me.txtE40FRAD1.Name = "txtE40FRAD1"
Me.txtE40FRAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40FRAD1.TabIndex = 148
'
'txtE20FRAD1
'
Me.txtE20FRAD1.Location = New System.Drawing.Point(17, 75)
Me.txtE20FRAD1.Name = "txtE20FRAD1"
Me.txtE20FRAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20FRAD1.TabIndex = 148
'
'txtE45RHAD1
'
Me.txtE45RHAD1.Location = New System.Drawing.Point(418, 25)
Me.txtE45RHAD1.Name = "txtE45RHAD1"
Me.txtE45RHAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE45RHAD1.TabIndex = 148
'
'txtE40RHAD1
'
Me.txtE40RHAD1.Location = New System.Drawing.Point(377, 25)
Me.txtE40RHAD1.Name = "txtE40RHAD1"
Me.txtE40RHAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40RHAD1.TabIndex = 148
'
'txtE20RHAD1
'
Me.txtE20RHAD1.Location = New System.Drawing.Point(337, 25)
Me.txtE20RHAD1.Name = "txtE20RHAD1"
Me.txtE20RHAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20RHAD1.TabIndex = 148
'
'txtE40RFAD1
'
Me.txtE40RFAD1.Location = New System.Drawing.Point(293, 25)
Me.txtE40RFAD1.Name = "txtE40RFAD1"
Me.txtE40RFAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40RFAD1.TabIndex = 148
'
'txtE20RFAD1
'
Me.txtE20RFAD1.Location = New System.Drawing.Point(245, 25)
Me.txtE20RFAD1.Name = "txtE20RFAD1"
Me.txtE20RFAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20RFAD1.TabIndex = 148
'
'txtE45HCAD1
'
Me.txtE45HCAD1.Location = New System.Drawing.Point(198, 25)
Me.txtE45HCAD1.Name = "txtE45HCAD1"
Me.txtE45HCAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE45HCAD1.TabIndex = 148
'
'txtE40HCAD1
'
Me.txtE40HCAD1.Location = New System.Drawing.Point(151, 25)
Me.txtE40HCAD1.Name = "txtE40HCAD1"
Me.txtE40HCAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40HCAD1.TabIndex = 148
'
'txtE20HCAD1
'
Me.txtE20HCAD1.Location = New System.Drawing.Point(110, 25)
Me.txtE20HCAD1.Name = "txtE20HCAD1"
Me.txtE20HCAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20HCAD1.TabIndex = 148
'
'txtE40GPAD1
'
Me.txtE40GPAD1.Location = New System.Drawing.Point(60, 25)
Me.txtE40GPAD1.Name = "txtE40GPAD1"
Me.txtE40GPAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40GPAD1.TabIndex = 148
'
'txtE20GPAD1
'
Me.txtE20GPAD1.Location = New System.Drawing.Point(17, 25)
Me.txtE20GPAD1.Name = "txtE20GPAD1"
Me.txtE20GPAD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20GPAD1.TabIndex = 148
'
'GroupBox19
'
Me.GroupBox19.Controls.Add(Me.txtETONAD1)
Me.GroupBox19.Controls.Add(Me.txtETEUAD1)
Me.GroupBox19.Controls.Add(Me.txtECNTRAD1)
Me.GroupBox19.Controls.Add(Me.Label153)
Me.GroupBox19.Controls.Add(Me.Label154)
Me.GroupBox19.Controls.Add(Me.Label155)
Me.GroupBox19.Location = New System.Drawing.Point(473, 29)
Me.GroupBox19.Name = "GroupBox19"
Me.GroupBox19.Size = New System.Drawing.Size(199, 66)
Me.GroupBox19.TabIndex = 148
Me.GroupBox19.TabStop = false
'
'txtETONAD1
'
Me.txtETONAD1.Location = New System.Drawing.Point(135, 40)
Me.txtETONAD1.Name = "txtETONAD1"
Me.txtETONAD1.Size = New System.Drawing.Size(35, 20)
Me.txtETONAD1.TabIndex = 148
'
'txtETEUAD1
'
Me.txtETEUAD1.Location = New System.Drawing.Point(84, 40)
Me.txtETEUAD1.Name = "txtETEUAD1"
Me.txtETEUAD1.Size = New System.Drawing.Size(35, 20)
Me.txtETEUAD1.TabIndex = 148
'
'txtECNTRAD1
'
Me.txtECNTRAD1.Location = New System.Drawing.Point(32, 40)
Me.txtECNTRAD1.Name = "txtECNTRAD1"
Me.txtECNTRAD1.Size = New System.Drawing.Size(35, 20)
Me.txtECNTRAD1.TabIndex = 148
'
'Label153
'
Me.Label153.AutoSize = true
Me.Label153.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label153.Location = New System.Drawing.Point(132, 19)
Me.Label153.Name = "Label153"
Me.Label153.Size = New System.Drawing.Size(37, 13)
Me.Label153.TabIndex = 147
Me.Label153.Text = "TONS"
'
'Label154
'
Me.Label154.AutoSize = true
Me.Label154.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label154.Location = New System.Drawing.Point(86, 19)
Me.Label154.Name = "Label154"
Me.Label154.Size = New System.Drawing.Size(29, 13)
Me.Label154.TabIndex = 147
Me.Label154.Text = "TEU"
'
'Label155
'
Me.Label155.AutoSize = true
Me.Label155.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label155.Location = New System.Drawing.Point(30, 19)
Me.Label155.Name = "Label155"
Me.Label155.Size = New System.Drawing.Size(37, 13)
Me.Label155.TabIndex = 147
Me.Label155.Text = "CTNR"
'
'Label156
'
Me.Label156.AutoSize = true
Me.Label156.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label156.Location = New System.Drawing.Point(377, 59)
Me.Label156.Name = "Label156"
Me.Label156.Size = New System.Drawing.Size(33, 13)
Me.Label156.TabIndex = 147
Me.Label156.Text = "40TK"
'
'Label157
'
Me.Label157.AutoSize = true
Me.Label157.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label157.Location = New System.Drawing.Point(420, 9)
Me.Label157.Name = "Label157"
Me.Label157.Size = New System.Drawing.Size(35, 13)
Me.Label157.TabIndex = 147
Me.Label157.Text = "45RH"
'
'Label158
'
Me.Label158.AutoSize = true
Me.Label158.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label158.Location = New System.Drawing.Point(377, 9)
Me.Label158.Name = "Label158"
Me.Label158.Size = New System.Drawing.Size(35, 13)
Me.Label158.TabIndex = 147
Me.Label158.Text = "40RH"
'
'Label159
'
Me.Label159.AutoSize = true
Me.Label159.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label159.Location = New System.Drawing.Point(196, 59)
Me.Label159.Name = "Label159"
Me.Label159.Size = New System.Drawing.Size(35, 13)
Me.Label159.TabIndex = 147
Me.Label159.Text = "40GH"
'
'Label160
'
Me.Label160.AutoSize = true
Me.Label160.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label160.Location = New System.Drawing.Point(195, 9)
Me.Label160.Name = "Label160"
Me.Label160.Size = New System.Drawing.Size(34, 13)
Me.Label160.TabIndex = 147
Me.Label160.Text = "45HC"
'
'Label161
'
Me.Label161.AutoSize = true
Me.Label161.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label161.Location = New System.Drawing.Point(290, 59)
Me.Label161.Name = "Label161"
Me.Label161.Size = New System.Drawing.Size(34, 13)
Me.Label161.TabIndex = 147
Me.Label161.Text = "40OT"
'
'Label162
'
Me.Label162.AutoSize = true
Me.Label162.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label162.Location = New System.Drawing.Point(153, 59)
Me.Label162.Name = "Label162"
Me.Label162.Size = New System.Drawing.Size(35, 13)
Me.Label162.TabIndex = 147
Me.Label162.Text = "40HG"
'
'Label163
'
Me.Label163.AutoSize = true
Me.Label163.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label163.Location = New System.Drawing.Point(290, 9)
Me.Label163.Name = "Label163"
Me.Label163.Size = New System.Drawing.Size(33, 13)
Me.Label163.TabIndex = 147
Me.Label163.Text = "40RF"
'
'Label164
'
Me.Label164.AutoSize = true
Me.Label164.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label164.Location = New System.Drawing.Point(334, 59)
Me.Label164.Name = "Label164"
Me.Label164.Size = New System.Drawing.Size(33, 13)
Me.Label164.TabIndex = 147
Me.Label164.Text = "20TK"
'
'Label165
'
Me.Label165.AutoSize = true
Me.Label165.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label165.Location = New System.Drawing.Point(152, 9)
Me.Label165.Name = "Label165"
Me.Label165.Size = New System.Drawing.Size(34, 13)
Me.Label165.TabIndex = 147
Me.Label165.Text = "40HC"
'
'Label166
'
Me.Label166.AutoSize = true
Me.Label166.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label166.Location = New System.Drawing.Point(334, 9)
Me.Label166.Name = "Label166"
Me.Label166.Size = New System.Drawing.Size(35, 13)
Me.Label166.TabIndex = 147
Me.Label166.Text = "20RH"
'
'Label167
'
Me.Label167.AutoSize = true
Me.Label167.ForeColor = System.Drawing.Color.Maroon
Me.Label167.Location = New System.Drawing.Point(61, 59)
Me.Label167.Name = "Label167"
Me.Label167.Size = New System.Drawing.Size(33, 13)
Me.Label167.TabIndex = 147
Me.Label167.Text = "40FR"
'
'Label168
'
Me.Label168.AutoSize = true
Me.Label168.ForeColor = System.Drawing.Color.Gold
Me.Label168.Location = New System.Drawing.Point(61, 9)
Me.Label168.Name = "Label168"
Me.Label168.Size = New System.Drawing.Size(34, 13)
Me.Label168.TabIndex = 147
Me.Label168.Text = "40GP"
'
'Label169
'
Me.Label169.AutoSize = true
Me.Label169.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label169.Location = New System.Drawing.Point(247, 59)
Me.Label169.Name = "Label169"
Me.Label169.Size = New System.Drawing.Size(34, 13)
Me.Label169.TabIndex = 147
Me.Label169.Text = "20OT"
'
'Label170
'
Me.Label170.AutoSize = true
Me.Label170.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label170.Location = New System.Drawing.Point(110, 59)
Me.Label170.Name = "Label170"
Me.Label170.Size = New System.Drawing.Size(35, 13)
Me.Label170.TabIndex = 147
Me.Label170.Text = "20HG"
'
'Label171
'
Me.Label171.AutoSize = true
Me.Label171.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label171.Location = New System.Drawing.Point(247, 9)
Me.Label171.Name = "Label171"
Me.Label171.Size = New System.Drawing.Size(33, 13)
Me.Label171.TabIndex = 147
Me.Label171.Text = "20RF"
'
'Label172
'
Me.Label172.AutoSize = true
Me.Label172.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label172.Location = New System.Drawing.Point(109, 9)
Me.Label172.Name = "Label172"
Me.Label172.Size = New System.Drawing.Size(34, 13)
Me.Label172.TabIndex = 147
Me.Label172.Text = "20HC"
'
'Label173
'
Me.Label173.AutoSize = true
Me.Label173.ForeColor = System.Drawing.Color.Maroon
Me.Label173.Location = New System.Drawing.Point(18, 59)
Me.Label173.Name = "Label173"
Me.Label173.Size = New System.Drawing.Size(33, 13)
Me.Label173.TabIndex = 147
Me.Label173.Text = "20FR"
'
'Label174
'
Me.Label174.AutoSize = true
Me.Label174.ForeColor = System.Drawing.Color.Gold
Me.Label174.Location = New System.Drawing.Point(18, 9)
Me.Label174.Name = "Label174"
Me.Label174.Size = New System.Drawing.Size(34, 13)
Me.Label174.TabIndex = 147
Me.Label174.Text = "20GP"
'
'TabPage13
'
Me.TabPage13.Controls.Add(Me.txtRemaksAD1)
Me.TabPage13.Controls.Add(Me.txtOtherConcerningRequirementOfShipAD1)
Me.TabPage13.Controls.Add(Me.txtF40TKAD1)
Me.TabPage13.Controls.Add(Me.txtF20TKAD1)
Me.TabPage13.Controls.Add(Me.txtF40OTAD1)
Me.TabPage13.Controls.Add(Me.txtF20OTAD1)
Me.TabPage13.Controls.Add(Me.txtF40GHAD1)
Me.TabPage13.Controls.Add(Me.txtF40HGAD1)
Me.TabPage13.Controls.Add(Me.txtF20HGAD1)
Me.TabPage13.Controls.Add(Me.txtF40FRAD1)
Me.TabPage13.Controls.Add(Me.txtF20FRAD1)
Me.TabPage13.Controls.Add(Me.txtF45RHAD1)
Me.TabPage13.Controls.Add(Me.txtF40RHAD1)
Me.TabPage13.Controls.Add(Me.txtF20RHAD1)
Me.TabPage13.Controls.Add(Me.txtF40RFAD1)
Me.TabPage13.Controls.Add(Me.txtF20RFAD1)
Me.TabPage13.Controls.Add(Me.txtF45HCAD1)
Me.TabPage13.Controls.Add(Me.txtF40HCAD1)
Me.TabPage13.Controls.Add(Me.txtF20HCAD1)
Me.TabPage13.Controls.Add(Me.txtF40GPAD1)
Me.TabPage13.Controls.Add(Me.txtF20GPAD1)
Me.TabPage13.Controls.Add(Me.Label175)
Me.TabPage13.Controls.Add(Me.Label176)
Me.TabPage13.Controls.Add(Me.GroupBox20)
Me.TabPage13.Controls.Add(Me.GroupBox21)
Me.TabPage13.Controls.Add(Me.Label183)
Me.TabPage13.Controls.Add(Me.Label184)
Me.TabPage13.Controls.Add(Me.Label185)
Me.TabPage13.Controls.Add(Me.Label186)
Me.TabPage13.Controls.Add(Me.Label187)
Me.TabPage13.Controls.Add(Me.Label188)
Me.TabPage13.Controls.Add(Me.Label189)
Me.TabPage13.Controls.Add(Me.Label190)
Me.TabPage13.Controls.Add(Me.Label191)
Me.TabPage13.Controls.Add(Me.Label192)
Me.TabPage13.Controls.Add(Me.Label193)
Me.TabPage13.Controls.Add(Me.Label194)
Me.TabPage13.Controls.Add(Me.Label195)
Me.TabPage13.Controls.Add(Me.Label196)
Me.TabPage13.Controls.Add(Me.Label197)
Me.TabPage13.Controls.Add(Me.Label198)
Me.TabPage13.Controls.Add(Me.Label199)
Me.TabPage13.Controls.Add(Me.Label200)
Me.TabPage13.Controls.Add(Me.Label201)
Me.TabPage13.Location = New System.Drawing.Point(4, 22)
Me.TabPage13.Name = "TabPage13"
Me.TabPage13.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage13.Size = New System.Drawing.Size(733, 179)
Me.TabPage13.TabIndex = 1
Me.TabPage13.Text = "Full Transit Inbound Container"
Me.TabPage13.UseVisualStyleBackColor = true
'
'txtRemaksAD1
'
Me.txtRemaksAD1.Location = New System.Drawing.Point(17, 151)
Me.txtRemaksAD1.Name = "txtRemaksAD1"
Me.txtRemaksAD1.Size = New System.Drawing.Size(391, 20)
Me.txtRemaksAD1.TabIndex = 191
'
'txtOtherConcerningRequirementOfShipAD1
'
Me.txtOtherConcerningRequirementOfShipAD1.Location = New System.Drawing.Point(20, 112)
Me.txtOtherConcerningRequirementOfShipAD1.Name = "txtOtherConcerningRequirementOfShipAD1"
Me.txtOtherConcerningRequirementOfShipAD1.Size = New System.Drawing.Size(391, 20)
Me.txtOtherConcerningRequirementOfShipAD1.TabIndex = 191
'
'txtF40TKAD1
'
Me.txtF40TKAD1.Location = New System.Drawing.Point(377, 67)
Me.txtF40TKAD1.Name = "txtF40TKAD1"
Me.txtF40TKAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF40TKAD1.TabIndex = 191
'
'txtF20TKAD1
'
Me.txtF20TKAD1.Location = New System.Drawing.Point(336, 67)
Me.txtF20TKAD1.Name = "txtF20TKAD1"
Me.txtF20TKAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF20TKAD1.TabIndex = 191
'
'txtF40OTAD1
'
Me.txtF40OTAD1.Location = New System.Drawing.Point(294, 67)
Me.txtF40OTAD1.Name = "txtF40OTAD1"
Me.txtF40OTAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF40OTAD1.TabIndex = 191
'
'txtF20OTAD1
'
Me.txtF20OTAD1.Location = New System.Drawing.Point(246, 67)
Me.txtF20OTAD1.Name = "txtF20OTAD1"
Me.txtF20OTAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF20OTAD1.TabIndex = 191
'
'txtF40GHAD1
'
Me.txtF40GHAD1.Location = New System.Drawing.Point(194, 67)
Me.txtF40GHAD1.Name = "txtF40GHAD1"
Me.txtF40GHAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF40GHAD1.TabIndex = 191
'
'txtF40HGAD1
'
Me.txtF40HGAD1.Location = New System.Drawing.Point(157, 67)
Me.txtF40HGAD1.Name = "txtF40HGAD1"
Me.txtF40HGAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF40HGAD1.TabIndex = 191
'
'txtF20HGAD1
'
Me.txtF20HGAD1.Location = New System.Drawing.Point(111, 67)
Me.txtF20HGAD1.Name = "txtF20HGAD1"
Me.txtF20HGAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF20HGAD1.TabIndex = 191
'
'txtF40FRAD1
'
Me.txtF40FRAD1.Location = New System.Drawing.Point(59, 67)
Me.txtF40FRAD1.Name = "txtF40FRAD1"
Me.txtF40FRAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF40FRAD1.TabIndex = 191
'
'txtF20FRAD1
'
Me.txtF20FRAD1.Location = New System.Drawing.Point(17, 67)
Me.txtF20FRAD1.Name = "txtF20FRAD1"
Me.txtF20FRAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF20FRAD1.TabIndex = 191
'
'txtF45RHAD1
'
Me.txtF45RHAD1.Location = New System.Drawing.Point(419, 23)
Me.txtF45RHAD1.Name = "txtF45RHAD1"
Me.txtF45RHAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF45RHAD1.TabIndex = 191
'
'txtF40RHAD1
'
Me.txtF40RHAD1.Location = New System.Drawing.Point(377, 23)
Me.txtF40RHAD1.Name = "txtF40RHAD1"
Me.txtF40RHAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF40RHAD1.TabIndex = 191
'
'txtF20RHAD1
'
Me.txtF20RHAD1.Location = New System.Drawing.Point(336, 23)
Me.txtF20RHAD1.Name = "txtF20RHAD1"
Me.txtF20RHAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF20RHAD1.TabIndex = 191
'
'txtF40RFAD1
'
Me.txtF40RFAD1.Location = New System.Drawing.Point(294, 23)
Me.txtF40RFAD1.Name = "txtF40RFAD1"
Me.txtF40RFAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF40RFAD1.TabIndex = 191
'
'txtF20RFAD1
'
Me.txtF20RFAD1.Location = New System.Drawing.Point(242, 23)
Me.txtF20RFAD1.Name = "txtF20RFAD1"
Me.txtF20RFAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF20RFAD1.TabIndex = 191
'
'txtF45HCAD1
'
Me.txtF45HCAD1.Location = New System.Drawing.Point(200, 23)
Me.txtF45HCAD1.Name = "txtF45HCAD1"
Me.txtF45HCAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF45HCAD1.TabIndex = 191
'
'txtF40HCAD1
'
Me.txtF40HCAD1.Location = New System.Drawing.Point(157, 23)
Me.txtF40HCAD1.Name = "txtF40HCAD1"
Me.txtF40HCAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF40HCAD1.TabIndex = 191
'
'txtF20HCAD1
'
Me.txtF20HCAD1.Location = New System.Drawing.Point(114, 23)
Me.txtF20HCAD1.Name = "txtF20HCAD1"
Me.txtF20HCAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF20HCAD1.TabIndex = 191
'
'txtF40GPAD1
'
Me.txtF40GPAD1.Location = New System.Drawing.Point(60, 26)
Me.txtF40GPAD1.Name = "txtF40GPAD1"
Me.txtF40GPAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF40GPAD1.TabIndex = 191
'
'txtF20GPAD1
'
Me.txtF20GPAD1.Location = New System.Drawing.Point(17, 23)
Me.txtF20GPAD1.Name = "txtF20GPAD1"
Me.txtF20GPAD1.Size = New System.Drawing.Size(36, 20)
Me.txtF20GPAD1.TabIndex = 191
'
'Label175
'
Me.Label175.AutoSize = true
Me.Label175.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label175.Location = New System.Drawing.Point(18, 135)
Me.Label175.Name = "Label175"
Me.Label175.Size = New System.Drawing.Size(52, 13)
Me.Label175.TabIndex = 190
Me.Label175.Text = "Remaks :"
'
'Label176
'
Me.Label176.AutoSize = true
Me.Label176.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label176.Location = New System.Drawing.Point(17, 95)
Me.Label176.Name = "Label176"
Me.Label176.Size = New System.Drawing.Size(187, 13)
Me.Label176.TabIndex = 190
Me.Label176.Text = "Other concerning requirement of ship :"
'
'GroupBox20
'
Me.GroupBox20.Controls.Add(Me.txtDangerousInboundCargoCLASSAD1)
Me.GroupBox20.Controls.Add(Me.DangerousInboundCargoTEUAD1)
Me.GroupBox20.Controls.Add(Me.txtDangerousInboundCargoCNTRAD1)
Me.GroupBox20.Controls.Add(Me.Label177)
Me.GroupBox20.Controls.Add(Me.Label178)
Me.GroupBox20.Controls.Add(Me.Label179)
Me.GroupBox20.Location = New System.Drawing.Point(474, 86)
Me.GroupBox20.Name = "GroupBox20"
Me.GroupBox20.Size = New System.Drawing.Size(199, 66)
Me.GroupBox20.TabIndex = 188
Me.GroupBox20.TabStop = false
Me.GroupBox20.Text = "Dangerous Inbound Cargo"
'
'txtDangerousInboundCargoCLASSAD1
'
Me.txtDangerousInboundCargoCLASSAD1.Location = New System.Drawing.Point(130, 40)
Me.txtDangerousInboundCargoCLASSAD1.Name = "txtDangerousInboundCargoCLASSAD1"
Me.txtDangerousInboundCargoCLASSAD1.Size = New System.Drawing.Size(36, 20)
Me.txtDangerousInboundCargoCLASSAD1.TabIndex = 191
'
'DangerousInboundCargoTEUAD1
'
Me.DangerousInboundCargoTEUAD1.Location = New System.Drawing.Point(83, 40)
Me.DangerousInboundCargoTEUAD1.Name = "DangerousInboundCargoTEUAD1"
Me.DangerousInboundCargoTEUAD1.Size = New System.Drawing.Size(36, 20)
Me.DangerousInboundCargoTEUAD1.TabIndex = 191
'
'txtDangerousInboundCargoCNTRAD1
'
Me.txtDangerousInboundCargoCNTRAD1.Location = New System.Drawing.Point(31, 40)
Me.txtDangerousInboundCargoCNTRAD1.Name = "txtDangerousInboundCargoCNTRAD1"
Me.txtDangerousInboundCargoCNTRAD1.Size = New System.Drawing.Size(36, 20)
Me.txtDangerousInboundCargoCNTRAD1.TabIndex = 191
'
'Label177
'
Me.Label177.AutoSize = true
Me.Label177.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label177.Location = New System.Drawing.Point(134, 19)
Me.Label177.Name = "Label177"
Me.Label177.Size = New System.Drawing.Size(32, 13)
Me.Label177.TabIndex = 147
Me.Label177.Text = "Class"
'
'Label178
'
Me.Label178.AutoSize = true
Me.Label178.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label178.Location = New System.Drawing.Point(86, 19)
Me.Label178.Name = "Label178"
Me.Label178.Size = New System.Drawing.Size(29, 13)
Me.Label178.TabIndex = 147
Me.Label178.Text = "TEU"
'
'Label179
'
Me.Label179.AutoSize = true
Me.Label179.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label179.Location = New System.Drawing.Point(30, 19)
Me.Label179.Name = "Label179"
Me.Label179.Size = New System.Drawing.Size(37, 13)
Me.Label179.TabIndex = 147
Me.Label179.Text = "CTNR"
'
'GroupBox21
'
Me.GroupBox21.Controls.Add(Me.txtFTONAD1)
Me.GroupBox21.Controls.Add(Me.txtFTEUAD1)
Me.GroupBox21.Controls.Add(Me.txtFCNTRAD1)
Me.GroupBox21.Controls.Add(Me.Label180)
Me.GroupBox21.Controls.Add(Me.Label181)
Me.GroupBox21.Controls.Add(Me.Label182)
Me.GroupBox21.Location = New System.Drawing.Point(474, 7)
Me.GroupBox21.Name = "GroupBox21"
Me.GroupBox21.Size = New System.Drawing.Size(199, 66)
Me.GroupBox21.TabIndex = 187
Me.GroupBox21.TabStop = false
'
'txtFTONAD1
'
Me.txtFTONAD1.Location = New System.Drawing.Point(133, 37)
Me.txtFTONAD1.Name = "txtFTONAD1"
Me.txtFTONAD1.Size = New System.Drawing.Size(36, 20)
Me.txtFTONAD1.TabIndex = 191
'
'txtFTEUAD1
'
Me.txtFTEUAD1.Location = New System.Drawing.Point(83, 37)
Me.txtFTEUAD1.Name = "txtFTEUAD1"
Me.txtFTEUAD1.Size = New System.Drawing.Size(36, 20)
Me.txtFTEUAD1.TabIndex = 191
'
'txtFCNTRAD1
'
Me.txtFCNTRAD1.Location = New System.Drawing.Point(31, 35)
Me.txtFCNTRAD1.Name = "txtFCNTRAD1"
Me.txtFCNTRAD1.Size = New System.Drawing.Size(36, 20)
Me.txtFCNTRAD1.TabIndex = 191
'
'Label180
'
Me.Label180.AutoSize = true
Me.Label180.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label180.Location = New System.Drawing.Point(132, 19)
Me.Label180.Name = "Label180"
Me.Label180.Size = New System.Drawing.Size(37, 13)
Me.Label180.TabIndex = 147
Me.Label180.Text = "TONS"
'
'Label181
'
Me.Label181.AutoSize = true
Me.Label181.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label181.Location = New System.Drawing.Point(86, 19)
Me.Label181.Name = "Label181"
Me.Label181.Size = New System.Drawing.Size(29, 13)
Me.Label181.TabIndex = 147
Me.Label181.Text = "TEU"
'
'Label182
'
Me.Label182.AutoSize = true
Me.Label182.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label182.Location = New System.Drawing.Point(30, 19)
Me.Label182.Name = "Label182"
Me.Label182.Size = New System.Drawing.Size(37, 13)
Me.Label182.TabIndex = 147
Me.Label182.Text = "CTNR"
'
'Label183
'
Me.Label183.AutoSize = true
Me.Label183.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label183.Location = New System.Drawing.Point(378, 51)
Me.Label183.Name = "Label183"
Me.Label183.Size = New System.Drawing.Size(33, 13)
Me.Label183.TabIndex = 174
Me.Label183.Text = "40TK"
'
'Label184
'
Me.Label184.AutoSize = true
Me.Label184.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label184.Location = New System.Drawing.Point(421, 7)
Me.Label184.Name = "Label184"
Me.Label184.Size = New System.Drawing.Size(35, 13)
Me.Label184.TabIndex = 173
Me.Label184.Text = "45RH"
'
'Label185
'
Me.Label185.AutoSize = true
Me.Label185.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label185.Location = New System.Drawing.Point(378, 7)
Me.Label185.Name = "Label185"
Me.Label185.Size = New System.Drawing.Size(35, 13)
Me.Label185.TabIndex = 176
Me.Label185.Text = "40RH"
'
'Label186
'
Me.Label186.AutoSize = true
Me.Label186.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label186.Location = New System.Drawing.Point(197, 51)
Me.Label186.Name = "Label186"
Me.Label186.Size = New System.Drawing.Size(35, 13)
Me.Label186.TabIndex = 175
Me.Label186.Text = "40GH"
'
'Label187
'
Me.Label187.AutoSize = true
Me.Label187.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label187.Location = New System.Drawing.Point(196, 7)
Me.Label187.Name = "Label187"
Me.Label187.Size = New System.Drawing.Size(34, 13)
Me.Label187.TabIndex = 172
Me.Label187.Text = "45HC"
'
'Label188
'
Me.Label188.AutoSize = true
Me.Label188.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label188.Location = New System.Drawing.Point(291, 51)
Me.Label188.Name = "Label188"
Me.Label188.Size = New System.Drawing.Size(34, 13)
Me.Label188.TabIndex = 169
Me.Label188.Text = "40OT"
'
'Label189
'
Me.Label189.AutoSize = true
Me.Label189.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label189.Location = New System.Drawing.Point(154, 51)
Me.Label189.Name = "Label189"
Me.Label189.Size = New System.Drawing.Size(35, 13)
Me.Label189.TabIndex = 168
Me.Label189.Text = "40HG"
'
'Label190
'
Me.Label190.AutoSize = true
Me.Label190.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label190.Location = New System.Drawing.Point(291, 7)
Me.Label190.Name = "Label190"
Me.Label190.Size = New System.Drawing.Size(33, 13)
Me.Label190.TabIndex = 171
Me.Label190.Text = "40RF"
'
'Label191
'
Me.Label191.AutoSize = true
Me.Label191.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label191.Location = New System.Drawing.Point(335, 51)
Me.Label191.Name = "Label191"
Me.Label191.Size = New System.Drawing.Size(33, 13)
Me.Label191.TabIndex = 170
Me.Label191.Text = "20TK"
'
'Label192
'
Me.Label192.AutoSize = true
Me.Label192.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label192.Location = New System.Drawing.Point(153, 7)
Me.Label192.Name = "Label192"
Me.Label192.Size = New System.Drawing.Size(34, 13)
Me.Label192.TabIndex = 177
Me.Label192.Text = "40HC"
'
'Label193
'
Me.Label193.AutoSize = true
Me.Label193.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label193.Location = New System.Drawing.Point(335, 7)
Me.Label193.Name = "Label193"
Me.Label193.Size = New System.Drawing.Size(35, 13)
Me.Label193.TabIndex = 184
Me.Label193.Text = "20RH"
'
'Label194
'
Me.Label194.AutoSize = true
Me.Label194.ForeColor = System.Drawing.Color.Maroon
Me.Label194.Location = New System.Drawing.Point(62, 51)
Me.Label194.Name = "Label194"
Me.Label194.Size = New System.Drawing.Size(33, 13)
Me.Label194.TabIndex = 183
Me.Label194.Text = "40FR"
'
'Label195
'
Me.Label195.AutoSize = true
Me.Label195.ForeColor = System.Drawing.Color.Gold
Me.Label195.Location = New System.Drawing.Point(62, 7)
Me.Label195.Name = "Label195"
Me.Label195.Size = New System.Drawing.Size(34, 13)
Me.Label195.TabIndex = 186
Me.Label195.Text = "40GP"
'
'Label196
'
Me.Label196.AutoSize = true
Me.Label196.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label196.Location = New System.Drawing.Point(248, 51)
Me.Label196.Name = "Label196"
Me.Label196.Size = New System.Drawing.Size(34, 13)
Me.Label196.TabIndex = 185
Me.Label196.Text = "20OT"
'
'Label197
'
Me.Label197.AutoSize = true
Me.Label197.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label197.Location = New System.Drawing.Point(111, 51)
Me.Label197.Name = "Label197"
Me.Label197.Size = New System.Drawing.Size(35, 13)
Me.Label197.TabIndex = 182
Me.Label197.Text = "20HG"
'
'Label198
'
Me.Label198.AutoSize = true
Me.Label198.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label198.Location = New System.Drawing.Point(248, 7)
Me.Label198.Name = "Label198"
Me.Label198.Size = New System.Drawing.Size(33, 13)
Me.Label198.TabIndex = 179
Me.Label198.Text = "20RF"
'
'Label199
'
Me.Label199.AutoSize = true
Me.Label199.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label199.Location = New System.Drawing.Point(110, 7)
Me.Label199.Name = "Label199"
Me.Label199.Size = New System.Drawing.Size(34, 13)
Me.Label199.TabIndex = 178
Me.Label199.Text = "20HC"
'
'Label200
'
Me.Label200.AutoSize = true
Me.Label200.ForeColor = System.Drawing.Color.Maroon
Me.Label200.Location = New System.Drawing.Point(19, 51)
Me.Label200.Name = "Label200"
Me.Label200.Size = New System.Drawing.Size(33, 13)
Me.Label200.TabIndex = 180
Me.Label200.Text = "20FR"
'
'Label201
'
Me.Label201.AutoSize = true
Me.Label201.ForeColor = System.Drawing.Color.Gold
Me.Label201.Location = New System.Drawing.Point(19, 7)
Me.Label201.Name = "Label201"
Me.Label201.Size = New System.Drawing.Size(34, 13)
Me.Label201.TabIndex = 181
Me.Label201.Text = "20GP"
'
'ETASailingSchedule
'
Me.ETASailingSchedule.Controls.Add(Me.TabControl2)
Me.ETASailingSchedule.Location = New System.Drawing.Point(4, 22)
Me.ETASailingSchedule.Name = "ETASailingSchedule"
Me.ETASailingSchedule.Size = New System.Drawing.Size(768, 255)
Me.ETASailingSchedule.TabIndex = 3
Me.ETASailingSchedule.Text = "Departure Declare"
Me.ETASailingSchedule.UseVisualStyleBackColor = true
'
'TabControl2
'
Me.TabControl2.Controls.Add(Me.TabPage3)
Me.TabControl2.Controls.Add(Me.TabPage4)
Me.TabControl2.Controls.Add(Me.TabPage8)
Me.TabControl2.Controls.Add(Me.TabPage14)
Me.TabControl2.Location = New System.Drawing.Point(4, 6)
Me.TabControl2.Name = "TabControl2"
Me.TabControl2.SelectedIndex = 0
Me.TabControl2.Size = New System.Drawing.Size(761, 243)
Me.TabControl2.TabIndex = 1
'
'TabPage3
'
Me.TabPage3.Controls.Add(Me.txtKindOfCargoDD)
Me.TabPage3.Controls.Add(Me.txtPurposeToPortDD)
Me.TabPage3.Controls.Add(Me.txtPositionOfShipInPortDD)
Me.TabPage3.Controls.Add(Me.txtNumOfPassengersDD)
Me.TabPage3.Controls.Add(Me.txtNumOfCrewDD)
Me.TabPage3.Controls.Add(Me.txtCaptionNameDD)
Me.TabPage3.Controls.Add(Me.GroupBox10)
Me.TabPage3.Controls.Add(Me.GroupBox11)
Me.TabPage3.Controls.Add(Me.GroupBox12)
Me.TabPage3.Controls.Add(Me.Label84)
Me.TabPage3.Controls.Add(Me.Label85)
Me.TabPage3.Controls.Add(Me.Label86)
Me.TabPage3.Controls.Add(Me.Label87)
Me.TabPage3.Controls.Add(Me.Label88)
Me.TabPage3.Controls.Add(Me.Label89)
Me.TabPage3.Controls.Add(Me.GroupBox13)
Me.TabPage3.Location = New System.Drawing.Point(4, 22)
Me.TabPage3.Name = "TabPage3"
Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage3.Size = New System.Drawing.Size(753, 217)
Me.TabPage3.TabIndex = 0
Me.TabPage3.Text = "Departure detail 1"
Me.TabPage3.UseVisualStyleBackColor = true
'
'txtKindOfCargoDD
'
Me.txtKindOfCargoDD.Location = New System.Drawing.Point(132, 107)
Me.txtKindOfCargoDD.Name = "txtKindOfCargoDD"
Me.txtKindOfCargoDD.Size = New System.Drawing.Size(209, 20)
Me.txtKindOfCargoDD.TabIndex = 143
'
'txtPurposeToPortDD
'
Me.txtPurposeToPortDD.Location = New System.Drawing.Point(131, 87)
Me.txtPurposeToPortDD.Name = "txtPurposeToPortDD"
Me.txtPurposeToPortDD.Size = New System.Drawing.Size(209, 20)
Me.txtPurposeToPortDD.TabIndex = 143
'
'txtPositionOfShipInPortDD
'
Me.txtPositionOfShipInPortDD.Location = New System.Drawing.Point(131, 67)
Me.txtPositionOfShipInPortDD.Name = "txtPositionOfShipInPortDD"
Me.txtPositionOfShipInPortDD.Size = New System.Drawing.Size(209, 20)
Me.txtPositionOfShipInPortDD.TabIndex = 143
'
'txtNumOfPassengersDD
'
Me.txtNumOfPassengersDD.Location = New System.Drawing.Point(131, 47)
Me.txtNumOfPassengersDD.Name = "txtNumOfPassengersDD"
Me.txtNumOfPassengersDD.Size = New System.Drawing.Size(209, 20)
Me.txtNumOfPassengersDD.TabIndex = 143
'
'txtNumOfCrewDD
'
Me.txtNumOfCrewDD.Location = New System.Drawing.Point(131, 27)
Me.txtNumOfCrewDD.Name = "txtNumOfCrewDD"
Me.txtNumOfCrewDD.Size = New System.Drawing.Size(209, 20)
Me.txtNumOfCrewDD.TabIndex = 143
'
'txtCaptionNameDD
'
Me.txtCaptionNameDD.Location = New System.Drawing.Point(131, 7)
Me.txtCaptionNameDD.Name = "txtCaptionNameDD"
Me.txtCaptionNameDD.Size = New System.Drawing.Size(209, 20)
Me.txtCaptionNameDD.TabIndex = 143
'
'GroupBox10
'
Me.GroupBox10.Controls.Add(Me.dtpDateOfBerthDD)
Me.GroupBox10.Controls.Add(Me.txtTimeOfBerthDD)
Me.GroupBox10.Controls.Add(Me.txtDateOfBerthDD)
Me.GroupBox10.Controls.Add(Me.Label77)
Me.GroupBox10.Controls.Add(Me.Label78)
Me.GroupBox10.Location = New System.Drawing.Point(377, 139)
Me.GroupBox10.Name = "GroupBox10"
Me.GroupBox10.Size = New System.Drawing.Size(333, 53)
Me.GroupBox10.TabIndex = 144
Me.GroupBox10.TabStop = false
Me.GroupBox10.Text = "Date & Time of  departure (Berth)"
'
'dtpDateOfBerthDD
'
Me.dtpDateOfBerthDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpDateOfBerthDD.Location = New System.Drawing.Point(128, 19)
Me.dtpDateOfBerthDD.Name = "dtpDateOfBerthDD"
Me.dtpDateOfBerthDD.Size = New System.Drawing.Size(90, 20)
Me.dtpDateOfBerthDD.TabIndex = 144
'
'txtTimeOfBerthDD
'
Me.txtTimeOfBerthDD.Location = New System.Drawing.Point(272, 20)
Me.txtTimeOfBerthDD.Name = "txtTimeOfBerthDD"
Me.txtTimeOfBerthDD.Size = New System.Drawing.Size(53, 20)
Me.txtTimeOfBerthDD.TabIndex = 143
'
'txtDateOfBerthDD
'
Me.txtDateOfBerthDD.Location = New System.Drawing.Point(49, 20)
Me.txtDateOfBerthDD.Name = "txtDateOfBerthDD"
Me.txtDateOfBerthDD.Size = New System.Drawing.Size(73, 20)
Me.txtDateOfBerthDD.TabIndex = 143
'
'Label77
'
Me.Label77.AutoSize = true
Me.Label77.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label77.Location = New System.Drawing.Point(7, 23)
Me.Label77.Name = "Label77"
Me.Label77.Size = New System.Drawing.Size(36, 13)
Me.Label77.TabIndex = 141
Me.Label77.Text = "Date :"
'
'Label78
'
Me.Label78.AutoSize = true
Me.Label78.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label78.Location = New System.Drawing.Point(232, 22)
Me.Label78.Name = "Label78"
Me.Label78.Size = New System.Drawing.Size(36, 13)
Me.Label78.TabIndex = 142
Me.Label78.Text = "Time :"
'
'GroupBox11
'
Me.GroupBox11.Controls.Add(Me.dtpDateOfArrivalPilotOnboardDD)
Me.GroupBox11.Controls.Add(Me.txtTimeOfArrivalPilotOnboardDD)
Me.GroupBox11.Controls.Add(Me.txtDateOfArrivalPilotOnboardDD)
Me.GroupBox11.Controls.Add(Me.Label79)
Me.GroupBox11.Controls.Add(Me.Label80)
Me.GroupBox11.Location = New System.Drawing.Point(377, 74)
Me.GroupBox11.Name = "GroupBox11"
Me.GroupBox11.Size = New System.Drawing.Size(333, 53)
Me.GroupBox11.TabIndex = 143
Me.GroupBox11.TabStop = false
Me.GroupBox11.Text = "Date & Time of  departure (Pilot)"
'
'dtpDateOfArrivalPilotOnboardDD
'
Me.dtpDateOfArrivalPilotOnboardDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpDateOfArrivalPilotOnboardDD.Location = New System.Drawing.Point(128, 19)
Me.dtpDateOfArrivalPilotOnboardDD.Name = "dtpDateOfArrivalPilotOnboardDD"
Me.dtpDateOfArrivalPilotOnboardDD.Size = New System.Drawing.Size(90, 20)
Me.dtpDateOfArrivalPilotOnboardDD.TabIndex = 144
'
'txtTimeOfArrivalPilotOnboardDD
'
Me.txtTimeOfArrivalPilotOnboardDD.Location = New System.Drawing.Point(272, 17)
Me.txtTimeOfArrivalPilotOnboardDD.Name = "txtTimeOfArrivalPilotOnboardDD"
Me.txtTimeOfArrivalPilotOnboardDD.Size = New System.Drawing.Size(53, 20)
Me.txtTimeOfArrivalPilotOnboardDD.TabIndex = 143
'
'txtDateOfArrivalPilotOnboardDD
'
Me.txtDateOfArrivalPilotOnboardDD.Location = New System.Drawing.Point(49, 20)
Me.txtDateOfArrivalPilotOnboardDD.Name = "txtDateOfArrivalPilotOnboardDD"
Me.txtDateOfArrivalPilotOnboardDD.Size = New System.Drawing.Size(73, 20)
Me.txtDateOfArrivalPilotOnboardDD.TabIndex = 143
'
'Label79
'
Me.Label79.AutoSize = true
Me.Label79.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label79.Location = New System.Drawing.Point(7, 23)
Me.Label79.Name = "Label79"
Me.Label79.Size = New System.Drawing.Size(36, 13)
Me.Label79.TabIndex = 141
Me.Label79.Text = "Date :"
'
'Label80
'
Me.Label80.AutoSize = true
Me.Label80.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label80.Location = New System.Drawing.Point(232, 20)
Me.Label80.Name = "Label80"
Me.Label80.Size = New System.Drawing.Size(36, 13)
Me.Label80.TabIndex = 142
Me.Label80.Text = "Time :"
'
'GroupBox12
'
Me.GroupBox12.Controls.Add(Me.txtFWDD)
Me.GroupBox12.Controls.Add(Me.txtDODD)
Me.GroupBox12.Controls.Add(Me.txtFODD)
Me.GroupBox12.Controls.Add(Me.Label81)
Me.GroupBox12.Controls.Add(Me.Label82)
Me.GroupBox12.Controls.Add(Me.Label83)
Me.GroupBox12.Location = New System.Drawing.Point(6, 139)
Me.GroupBox12.Name = "GroupBox12"
Me.GroupBox12.Size = New System.Drawing.Size(364, 53)
Me.GroupBox12.TabIndex = 143
Me.GroupBox12.TabStop = false
Me.GroupBox12.Text = "Declare of departure (MTs)"
'
'txtFWDD
'
Me.txtFWDD.Location = New System.Drawing.Point(271, 22)
Me.txtFWDD.Name = "txtFWDD"
Me.txtFWDD.Size = New System.Drawing.Size(80, 20)
Me.txtFWDD.TabIndex = 143
'
'txtDODD
'
Me.txtDODD.Location = New System.Drawing.Point(152, 22)
Me.txtDODD.Name = "txtDODD"
Me.txtDODD.Size = New System.Drawing.Size(80, 20)
Me.txtDODD.TabIndex = 143
'
'txtFODD
'
Me.txtFODD.Location = New System.Drawing.Point(34, 22)
Me.txtFODD.Name = "txtFODD"
Me.txtFODD.Size = New System.Drawing.Size(80, 20)
Me.txtFODD.TabIndex = 143
'
'Label81
'
Me.Label81.AutoSize = true
Me.Label81.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label81.Location = New System.Drawing.Point(7, 25)
Me.Label81.Name = "Label81"
Me.Label81.Size = New System.Drawing.Size(27, 13)
Me.Label81.TabIndex = 141
Me.Label81.Text = "FO :"
'
'Label82
'
Me.Label82.AutoSize = true
Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label82.Location = New System.Drawing.Point(240, 25)
Me.Label82.Name = "Label82"
Me.Label82.Size = New System.Drawing.Size(30, 13)
Me.Label82.TabIndex = 142
Me.Label82.Text = "FW :"
'
'Label83
'
Me.Label83.AutoSize = true
Me.Label83.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label83.Location = New System.Drawing.Point(123, 25)
Me.Label83.Name = "Label83"
Me.Label83.Size = New System.Drawing.Size(29, 13)
Me.Label83.TabIndex = 142
Me.Label83.Text = "DO :"
'
'Label84
'
Me.Label84.AutoSize = true
Me.Label84.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label84.Location = New System.Drawing.Point(50, 112)
Me.Label84.Name = "Label84"
Me.Label84.Size = New System.Drawing.Size(77, 13)
Me.Label84.TabIndex = 143
Me.Label84.Text = "Kind of Cargo :"
'
'Label85
'
Me.Label85.AutoSize = true
Me.Label85.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label85.Location = New System.Drawing.Point(42, 93)
Me.Label85.Name = "Label85"
Me.Label85.Size = New System.Drawing.Size(85, 13)
Me.Label85.TabIndex = 143
Me.Label85.Text = "Purpose to port :"
'
'Label86
'
Me.Label86.AutoSize = true
Me.Label86.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label86.Location = New System.Drawing.Point(0, 72)
Me.Label86.Name = "Label86"
Me.Label86.Size = New System.Drawing.Size(129, 13)
Me.Label86.TabIndex = 143
Me.Label86.Text = "Possition of Ship (in port) :"
'
'Label87
'
Me.Label87.AutoSize = true
Me.Label87.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label87.Location = New System.Drawing.Point(37, 51)
Me.Label87.Name = "Label87"
Me.Label87.Size = New System.Drawing.Size(91, 13)
Me.Label87.TabIndex = 143
Me.Label87.Text = "Number of Pass. :"
'
'Label88
'
Me.Label88.AutoSize = true
Me.Label88.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label88.Location = New System.Drawing.Point(39, 30)
Me.Label88.Name = "Label88"
Me.Label88.Size = New System.Drawing.Size(89, 13)
Me.Label88.TabIndex = 143
Me.Label88.Text = "Number of Crew :"
'
'Label89
'
Me.Label89.AutoSize = true
Me.Label89.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label89.Location = New System.Drawing.Point(63, 9)
Me.Label89.Name = "Label89"
Me.Label89.Size = New System.Drawing.Size(64, 13)
Me.Label89.TabIndex = 143
Me.Label89.Text = "Capt name :"
'
'GroupBox13
'
Me.GroupBox13.Controls.Add(Me.dtpDateOfArrivalPilotStationDD)
Me.GroupBox13.Controls.Add(Me.txtTimeOfArrivalPilotStationDD)
Me.GroupBox13.Controls.Add(Me.txtDateOfArrivalPilotStationDD)
Me.GroupBox13.Controls.Add(Me.Label90)
Me.GroupBox13.Controls.Add(Me.Label91)
Me.GroupBox13.Location = New System.Drawing.Point(377, 7)
Me.GroupBox13.Name = "GroupBox13"
Me.GroupBox13.Size = New System.Drawing.Size(333, 53)
Me.GroupBox13.TabIndex = 0
Me.GroupBox13.TabStop = false
Me.GroupBox13.Text = "D/T of Departure"
'
'dtpDateOfArrivalPilotStationDD
'
Me.dtpDateOfArrivalPilotStationDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpDateOfArrivalPilotStationDD.Location = New System.Drawing.Point(128, 23)
Me.dtpDateOfArrivalPilotStationDD.Name = "dtpDateOfArrivalPilotStationDD"
Me.dtpDateOfArrivalPilotStationDD.Size = New System.Drawing.Size(90, 20)
Me.dtpDateOfArrivalPilotStationDD.TabIndex = 144
'
'txtTimeOfArrivalPilotStationDD
'
Me.txtTimeOfArrivalPilotStationDD.Location = New System.Drawing.Point(272, 23)
Me.txtTimeOfArrivalPilotStationDD.Name = "txtTimeOfArrivalPilotStationDD"
Me.txtTimeOfArrivalPilotStationDD.Size = New System.Drawing.Size(53, 20)
Me.txtTimeOfArrivalPilotStationDD.TabIndex = 143
'
'txtDateOfArrivalPilotStationDD
'
Me.txtDateOfArrivalPilotStationDD.Location = New System.Drawing.Point(49, 23)
Me.txtDateOfArrivalPilotStationDD.Name = "txtDateOfArrivalPilotStationDD"
Me.txtDateOfArrivalPilotStationDD.Size = New System.Drawing.Size(73, 20)
Me.txtDateOfArrivalPilotStationDD.TabIndex = 143
'
'Label90
'
Me.Label90.AutoSize = true
Me.Label90.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label90.Location = New System.Drawing.Point(7, 23)
Me.Label90.Name = "Label90"
Me.Label90.Size = New System.Drawing.Size(36, 13)
Me.Label90.TabIndex = 141
Me.Label90.Text = "Date :"
'
'Label91
'
Me.Label91.AutoSize = true
Me.Label91.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label91.Location = New System.Drawing.Point(232, 23)
Me.Label91.Name = "Label91"
Me.Label91.Size = New System.Drawing.Size(36, 13)
Me.Label91.TabIndex = 142
Me.Label91.Text = "Time :"
'
'TabPage4
'
Me.TabPage4.Controls.Add(Me.txtLastDateOfArrivalDD)
Me.TabPage4.Controls.Add(Me.txtActualDisplacementDD)
Me.TabPage4.Controls.Add(Me.txtAfterDraftDD)
Me.TabPage4.Controls.Add(Me.txtforeDraftDD)
Me.TabPage4.Controls.Add(Me.GroupBox14)
Me.TabPage4.Controls.Add(Me.GroupBox15)
Me.TabPage4.Controls.Add(Me.Label97)
Me.TabPage4.Controls.Add(Me.Label98)
Me.TabPage4.Controls.Add(Me.Label99)
Me.TabPage4.Controls.Add(Me.Label100)
Me.TabPage4.Location = New System.Drawing.Point(4, 22)
Me.TabPage4.Name = "TabPage4"
Me.TabPage4.Size = New System.Drawing.Size(753, 217)
Me.TabPage4.TabIndex = 2
Me.TabPage4.Text = "Departure detail 2"
Me.TabPage4.UseVisualStyleBackColor = true
'
'txtLastDateOfArrivalDD
'
Me.txtLastDateOfArrivalDD.Location = New System.Drawing.Point(197, 95)
Me.txtLastDateOfArrivalDD.Name = "txtLastDateOfArrivalDD"
Me.txtLastDateOfArrivalDD.Size = New System.Drawing.Size(177, 20)
Me.txtLastDateOfArrivalDD.TabIndex = 143
'
'txtActualDisplacementDD
'
Me.txtActualDisplacementDD.Location = New System.Drawing.Point(197, 69)
Me.txtActualDisplacementDD.Name = "txtActualDisplacementDD"
Me.txtActualDisplacementDD.Size = New System.Drawing.Size(177, 20)
Me.txtActualDisplacementDD.TabIndex = 143
'
'txtAfterDraftDD
'
Me.txtAfterDraftDD.Location = New System.Drawing.Point(197, 42)
Me.txtAfterDraftDD.Name = "txtAfterDraftDD"
Me.txtAfterDraftDD.Size = New System.Drawing.Size(177, 20)
Me.txtAfterDraftDD.TabIndex = 143
'
'txtforeDraftDD
'
Me.txtforeDraftDD.Location = New System.Drawing.Point(197, 16)
Me.txtforeDraftDD.Name = "txtforeDraftDD"
Me.txtforeDraftDD.Size = New System.Drawing.Size(177, 20)
Me.txtforeDraftDD.TabIndex = 143
'
'GroupBox14
'
Me.GroupBox14.Controls.Add(Me.dtpDateCommencingOperationDD)
Me.GroupBox14.Controls.Add(Me.txtTimeCommencingOperationDD)
Me.GroupBox14.Controls.Add(Me.txtDateCommencingOperationDD)
Me.GroupBox14.Controls.Add(Me.Label92)
Me.GroupBox14.Controls.Add(Me.Label93)
Me.GroupBox14.Location = New System.Drawing.Point(386, 17)
Me.GroupBox14.Name = "GroupBox14"
Me.GroupBox14.Size = New System.Drawing.Size(241, 80)
Me.GroupBox14.TabIndex = 153
Me.GroupBox14.TabStop = false
Me.GroupBox14.Text = "Commencing Operation (Finish)"
'
'dtpDateCommencingOperationDD
'
Me.dtpDateCommencingOperationDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpDateCommencingOperationDD.Location = New System.Drawing.Point(138, 20)
Me.dtpDateCommencingOperationDD.Name = "dtpDateCommencingOperationDD"
Me.dtpDateCommencingOperationDD.Size = New System.Drawing.Size(92, 20)
Me.dtpDateCommencingOperationDD.TabIndex = 144
'
'txtTimeCommencingOperationDD
'
Me.txtTimeCommencingOperationDD.Location = New System.Drawing.Point(58, 46)
Me.txtTimeCommencingOperationDD.Name = "txtTimeCommencingOperationDD"
Me.txtTimeCommencingOperationDD.Size = New System.Drawing.Size(53, 20)
Me.txtTimeCommencingOperationDD.TabIndex = 143
'
'txtDateCommencingOperationDD
'
Me.txtDateCommencingOperationDD.Location = New System.Drawing.Point(58, 20)
Me.txtDateCommencingOperationDD.Name = "txtDateCommencingOperationDD"
Me.txtDateCommencingOperationDD.Size = New System.Drawing.Size(73, 20)
Me.txtDateCommencingOperationDD.TabIndex = 143
'
'Label92
'
Me.Label92.AutoSize = true
Me.Label92.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label92.Location = New System.Drawing.Point(22, 23)
Me.Label92.Name = "Label92"
Me.Label92.Size = New System.Drawing.Size(36, 13)
Me.Label92.TabIndex = 141
Me.Label92.Text = "Date :"
'
'Label93
'
Me.Label93.AutoSize = true
Me.Label93.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label93.Location = New System.Drawing.Point(22, 48)
Me.Label93.Name = "Label93"
Me.Label93.Size = New System.Drawing.Size(36, 13)
Me.Label93.TabIndex = 142
Me.Label93.Text = "Time :"
'
'GroupBox15
'
Me.GroupBox15.Controls.Add(Me.cboNextPortDD)
Me.GroupBox15.Controls.Add(Me.cboDis_LoadPortDD)
Me.GroupBox15.Controls.Add(Me.cboPreviousPortDD)
Me.GroupBox15.Controls.Add(Me.Label94)
Me.GroupBox15.Controls.Add(Me.Label95)
Me.GroupBox15.Controls.Add(Me.Label96)
Me.GroupBox15.Location = New System.Drawing.Point(31, 121)
Me.GroupBox15.Name = "GroupBox15"
Me.GroupBox15.Size = New System.Drawing.Size(519, 71)
Me.GroupBox15.TabIndex = 152
Me.GroupBox15.TabStop = false
Me.GroupBox15.Text = "Brief Particular of voyage on arrival (Previous and subsequent ports of call)"
'
'cboNextPortDD
'
Me.cboNextPortDD.Location = New System.Drawing.Point(355, 36)
Me.cboNextPortDD.Name = "cboNextPortDD"
Me.cboNextPortDD.Size = New System.Drawing.Size(122, 20)
Me.cboNextPortDD.TabIndex = 143
'
'cboDis_LoadPortDD
'
Me.cboDis_LoadPortDD.Location = New System.Drawing.Point(196, 36)
Me.cboDis_LoadPortDD.Name = "cboDis_LoadPortDD"
Me.cboDis_LoadPortDD.Size = New System.Drawing.Size(122, 20)
Me.cboDis_LoadPortDD.TabIndex = 143
'
'cboPreviousPortDD
'
Me.cboPreviousPortDD.Location = New System.Drawing.Point(28, 37)
Me.cboPreviousPortDD.Name = "cboPreviousPortDD"
Me.cboPreviousPortDD.Size = New System.Drawing.Size(122, 20)
Me.cboPreviousPortDD.TabIndex = 143
'
'Label94
'
Me.Label94.AutoSize = true
Me.Label94.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label94.Location = New System.Drawing.Point(352, 20)
Me.Label94.Name = "Label94"
Me.Label94.Size = New System.Drawing.Size(57, 13)
Me.Label94.TabIndex = 150
Me.Label94.Text = "Next Port :"
'
'Label95
'
Me.Label95.AutoSize = true
Me.Label95.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label95.Location = New System.Drawing.Point(193, 20)
Me.Label95.Name = "Label95"
Me.Label95.Size = New System.Drawing.Size(79, 13)
Me.Label95.TabIndex = 150
Me.Label95.Text = "Dis/Load Port :"
'
'Label96
'
Me.Label96.AutoSize = true
Me.Label96.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label96.Location = New System.Drawing.Point(25, 20)
Me.Label96.Name = "Label96"
Me.Label96.Size = New System.Drawing.Size(76, 13)
Me.Label96.TabIndex = 150
Me.Label96.Text = "Previous Port :"
'
'Label97
'
Me.Label97.AutoSize = true
Me.Label97.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label97.Location = New System.Drawing.Point(28, 98)
Me.Label97.Name = "Label97"
Me.Label97.Size = New System.Drawing.Size(169, 13)
Me.Label97.TabIndex = 149
Me.Label97.Text = "Date of arrival or Transit VietNam :"
'
'Label98
'
Me.Label98.AutoSize = true
Me.Label98.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label98.Location = New System.Drawing.Point(86, 72)
Me.Label98.Name = "Label98"
Me.Label98.Size = New System.Drawing.Size(110, 13)
Me.Label98.TabIndex = 148
Me.Label98.Text = "Actual Displacement :"
'
'Label99
'
Me.Label99.AutoSize = true
Me.Label99.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label99.Location = New System.Drawing.Point(135, 46)
Me.Label99.Name = "Label99"
Me.Label99.Size = New System.Drawing.Size(61, 13)
Me.Label99.TabIndex = 151
Me.Label99.Text = "After Draft :"
'
'Label100
'
Me.Label100.AutoSize = true
Me.Label100.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label100.Location = New System.Drawing.Point(136, 20)
Me.Label100.Name = "Label100"
Me.Label100.Size = New System.Drawing.Size(60, 13)
Me.Label100.TabIndex = 150
Me.Label100.Text = "Fore Draft :"
'
'TabPage8
'
Me.TabPage8.Controls.Add(Me.TabControl4)
Me.TabPage8.Location = New System.Drawing.Point(4, 22)
Me.TabPage8.Name = "TabPage8"
Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage8.Size = New System.Drawing.Size(753, 217)
Me.TabPage8.TabIndex = 1
Me.TabPage8.Text = "Departure Cargo"
Me.TabPage8.UseVisualStyleBackColor = true
'
'TabControl4
'
Me.TabControl4.Controls.Add(Me.TabPage9)
Me.TabControl4.Controls.Add(Me.TabPage10)
Me.TabControl4.Location = New System.Drawing.Point(6, 6)
Me.TabControl4.Name = "TabControl4"
Me.TabControl4.SelectedIndex = 0
Me.TabControl4.Size = New System.Drawing.Size(741, 205)
Me.TabControl4.TabIndex = 0
'
'TabPage9
'
Me.TabPage9.Controls.Add(Me.txtE20TKDD)
Me.TabPage9.Controls.Add(Me.txtE40TKDD)
Me.TabPage9.Controls.Add(Me.txtE40OTDD)
Me.TabPage9.Controls.Add(Me.txtE20OTDD)
Me.TabPage9.Controls.Add(Me.txtE40GHDD)
Me.TabPage9.Controls.Add(Me.txtE40HGDD)
Me.TabPage9.Controls.Add(Me.txtE20HGDD)
Me.TabPage9.Controls.Add(Me.txtE40FRDD)
Me.TabPage9.Controls.Add(Me.txtE20FRDD)
Me.TabPage9.Controls.Add(Me.txtE45RHDD)
Me.TabPage9.Controls.Add(Me.txtE40RHDD)
Me.TabPage9.Controls.Add(Me.txtE20RHDD)
Me.TabPage9.Controls.Add(Me.txtE40RFDD)
Me.TabPage9.Controls.Add(Me.txtE20RFDD)
Me.TabPage9.Controls.Add(Me.txtE45HCDD)
Me.TabPage9.Controls.Add(Me.txtE40HCDD)
Me.TabPage9.Controls.Add(Me.txtE20HCDD)
Me.TabPage9.Controls.Add(Me.txtE40GPDD)
Me.TabPage9.Controls.Add(Me.txtE20GPDD)
Me.TabPage9.Controls.Add(Me.GroupBox16)
Me.TabPage9.Controls.Add(Me.Label104)
Me.TabPage9.Controls.Add(Me.Label105)
Me.TabPage9.Controls.Add(Me.Label106)
Me.TabPage9.Controls.Add(Me.Label107)
Me.TabPage9.Controls.Add(Me.Label108)
Me.TabPage9.Controls.Add(Me.Label109)
Me.TabPage9.Controls.Add(Me.Label110)
Me.TabPage9.Controls.Add(Me.Label111)
Me.TabPage9.Controls.Add(Me.Label112)
Me.TabPage9.Controls.Add(Me.Label113)
Me.TabPage9.Controls.Add(Me.Label114)
Me.TabPage9.Controls.Add(Me.Label115)
Me.TabPage9.Controls.Add(Me.Label116)
Me.TabPage9.Controls.Add(Me.Label117)
Me.TabPage9.Controls.Add(Me.Label118)
Me.TabPage9.Controls.Add(Me.Label119)
Me.TabPage9.Controls.Add(Me.Label120)
Me.TabPage9.Controls.Add(Me.Label121)
Me.TabPage9.Controls.Add(Me.Label122)
Me.TabPage9.Location = New System.Drawing.Point(4, 22)
Me.TabPage9.Name = "TabPage9"
Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage9.Size = New System.Drawing.Size(733, 179)
Me.TabPage9.TabIndex = 0
Me.TabPage9.Text = "Empty Outbound Local  Container"
Me.TabPage9.UseVisualStyleBackColor = true
'
'txtE20TKDD
'
Me.txtE20TKDD.Location = New System.Drawing.Point(336, 75)
Me.txtE20TKDD.Name = "txtE20TKDD"
Me.txtE20TKDD.Size = New System.Drawing.Size(33, 20)
Me.txtE20TKDD.TabIndex = 1
'
'txtE40TKDD
'
Me.txtE40TKDD.Location = New System.Drawing.Point(379, 75)
Me.txtE40TKDD.Name = "txtE40TKDD"
Me.txtE40TKDD.Size = New System.Drawing.Size(33, 20)
Me.txtE40TKDD.TabIndex = 1
'
'txtE40OTDD
'
Me.txtE40OTDD.Location = New System.Drawing.Point(295, 75)
Me.txtE40OTDD.Name = "txtE40OTDD"
Me.txtE40OTDD.Size = New System.Drawing.Size(33, 20)
Me.txtE40OTDD.TabIndex = 1
'
'txtE20OTDD
'
Me.txtE20OTDD.Location = New System.Drawing.Point(251, 75)
Me.txtE20OTDD.Name = "txtE20OTDD"
Me.txtE20OTDD.Size = New System.Drawing.Size(33, 20)
Me.txtE20OTDD.TabIndex = 1
'
'txtE40GHDD
'
Me.txtE40GHDD.Location = New System.Drawing.Point(196, 75)
Me.txtE40GHDD.Name = "txtE40GHDD"
Me.txtE40GHDD.Size = New System.Drawing.Size(33, 20)
Me.txtE40GHDD.TabIndex = 1
'
'txtE40HGDD
'
Me.txtE40HGDD.Location = New System.Drawing.Point(155, 75)
Me.txtE40HGDD.Name = "txtE40HGDD"
Me.txtE40HGDD.Size = New System.Drawing.Size(33, 20)
Me.txtE40HGDD.TabIndex = 1
'
'txtE20HGDD
'
Me.txtE20HGDD.Location = New System.Drawing.Point(110, 75)
Me.txtE20HGDD.Name = "txtE20HGDD"
Me.txtE20HGDD.Size = New System.Drawing.Size(33, 20)
Me.txtE20HGDD.TabIndex = 1
'
'txtE40FRDD
'
Me.txtE40FRDD.Location = New System.Drawing.Point(57, 75)
Me.txtE40FRDD.Name = "txtE40FRDD"
Me.txtE40FRDD.Size = New System.Drawing.Size(33, 20)
Me.txtE40FRDD.TabIndex = 1
'
'txtE20FRDD
'
Me.txtE20FRDD.Location = New System.Drawing.Point(18, 75)
Me.txtE20FRDD.Name = "txtE20FRDD"
Me.txtE20FRDD.Size = New System.Drawing.Size(33, 20)
Me.txtE20FRDD.TabIndex = 1
'
'txtE45RHDD
'
Me.txtE45RHDD.Location = New System.Drawing.Point(422, 29)
Me.txtE45RHDD.Name = "txtE45RHDD"
Me.txtE45RHDD.Size = New System.Drawing.Size(33, 20)
Me.txtE45RHDD.TabIndex = 1
'
'txtE40RHDD
'
Me.txtE40RHDD.Location = New System.Drawing.Point(377, 29)
Me.txtE40RHDD.Name = "txtE40RHDD"
Me.txtE40RHDD.Size = New System.Drawing.Size(33, 20)
Me.txtE40RHDD.TabIndex = 1
'
'txtE20RHDD
'
Me.txtE20RHDD.Location = New System.Drawing.Point(337, 29)
Me.txtE20RHDD.Name = "txtE20RHDD"
Me.txtE20RHDD.Size = New System.Drawing.Size(33, 20)
Me.txtE20RHDD.TabIndex = 1
'
'txtE40RFDD
'
Me.txtE40RFDD.Location = New System.Drawing.Point(293, 29)
Me.txtE40RFDD.Name = "txtE40RFDD"
Me.txtE40RFDD.Size = New System.Drawing.Size(33, 20)
Me.txtE40RFDD.TabIndex = 1
'
'txtE20RFDD
'
Me.txtE20RFDD.Location = New System.Drawing.Point(247, 29)
Me.txtE20RFDD.Name = "txtE20RFDD"
Me.txtE20RFDD.Size = New System.Drawing.Size(33, 20)
Me.txtE20RFDD.TabIndex = 1
'
'txtE45HCDD
'
Me.txtE45HCDD.Location = New System.Drawing.Point(192, 29)
Me.txtE45HCDD.Name = "txtE45HCDD"
Me.txtE45HCDD.Size = New System.Drawing.Size(33, 20)
Me.txtE45HCDD.TabIndex = 1
'
'txtE40HCDD
'
Me.txtE40HCDD.Location = New System.Drawing.Point(153, 29)
Me.txtE40HCDD.Name = "txtE40HCDD"
Me.txtE40HCDD.Size = New System.Drawing.Size(33, 20)
Me.txtE40HCDD.TabIndex = 1
'
'txtE20HCDD
'
Me.txtE20HCDD.Location = New System.Drawing.Point(110, 29)
Me.txtE20HCDD.Name = "txtE20HCDD"
Me.txtE20HCDD.Size = New System.Drawing.Size(33, 20)
Me.txtE20HCDD.TabIndex = 1
'
'txtE40GPDD
'
Me.txtE40GPDD.Location = New System.Drawing.Point(61, 29)
Me.txtE40GPDD.Name = "txtE40GPDD"
Me.txtE40GPDD.Size = New System.Drawing.Size(33, 20)
Me.txtE40GPDD.TabIndex = 1
'
'txtE20GPDD
'
Me.txtE20GPDD.Location = New System.Drawing.Point(6, 29)
Me.txtE20GPDD.Name = "txtE20GPDD"
Me.txtE20GPDD.Size = New System.Drawing.Size(33, 20)
Me.txtE20GPDD.TabIndex = 1
'
'GroupBox16
'
Me.GroupBox16.Controls.Add(Me.txtETONDD)
Me.GroupBox16.Controls.Add(Me.txtETEUDD)
Me.GroupBox16.Controls.Add(Me.txtECNTRDD)
Me.GroupBox16.Controls.Add(Me.Label101)
Me.GroupBox16.Controls.Add(Me.Label102)
Me.GroupBox16.Controls.Add(Me.Label103)
Me.GroupBox16.Location = New System.Drawing.Point(473, 29)
Me.GroupBox16.Name = "GroupBox16"
Me.GroupBox16.Size = New System.Drawing.Size(199, 66)
Me.GroupBox16.TabIndex = 148
Me.GroupBox16.TabStop = false
'
'txtETONDD
'
Me.txtETONDD.Location = New System.Drawing.Point(136, 40)
Me.txtETONDD.Name = "txtETONDD"
Me.txtETONDD.Size = New System.Drawing.Size(45, 20)
Me.txtETONDD.TabIndex = 1
'
'txtETEUDD
'
Me.txtETEUDD.Location = New System.Drawing.Point(85, 40)
Me.txtETEUDD.Name = "txtETEUDD"
Me.txtETEUDD.Size = New System.Drawing.Size(45, 20)
Me.txtETEUDD.TabIndex = 1
'
'txtECNTRDD
'
Me.txtECNTRDD.Location = New System.Drawing.Point(34, 40)
Me.txtECNTRDD.Name = "txtECNTRDD"
Me.txtECNTRDD.Size = New System.Drawing.Size(45, 20)
Me.txtECNTRDD.TabIndex = 1
'
'Label101
'
Me.Label101.AutoSize = true
Me.Label101.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label101.Location = New System.Drawing.Point(132, 19)
Me.Label101.Name = "Label101"
Me.Label101.Size = New System.Drawing.Size(37, 13)
Me.Label101.TabIndex = 147
Me.Label101.Text = "TONS"
'
'Label102
'
Me.Label102.AutoSize = true
Me.Label102.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label102.Location = New System.Drawing.Point(86, 19)
Me.Label102.Name = "Label102"
Me.Label102.Size = New System.Drawing.Size(29, 13)
Me.Label102.TabIndex = 147
Me.Label102.Text = "TEU"
'
'Label103
'
Me.Label103.AutoSize = true
Me.Label103.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label103.Location = New System.Drawing.Point(30, 19)
Me.Label103.Name = "Label103"
Me.Label103.Size = New System.Drawing.Size(37, 13)
Me.Label103.TabIndex = 147
Me.Label103.Text = "CTNR"
'
'Label104
'
Me.Label104.AutoSize = true
Me.Label104.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label104.Location = New System.Drawing.Point(377, 59)
Me.Label104.Name = "Label104"
Me.Label104.Size = New System.Drawing.Size(33, 13)
Me.Label104.TabIndex = 147
Me.Label104.Text = "40TK"
'
'Label105
'
Me.Label105.AutoSize = true
Me.Label105.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label105.Location = New System.Drawing.Point(420, 9)
Me.Label105.Name = "Label105"
Me.Label105.Size = New System.Drawing.Size(35, 13)
Me.Label105.TabIndex = 147
Me.Label105.Text = "45RH"
'
'Label106
'
Me.Label106.AutoSize = true
Me.Label106.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label106.Location = New System.Drawing.Point(377, 9)
Me.Label106.Name = "Label106"
Me.Label106.Size = New System.Drawing.Size(35, 13)
Me.Label106.TabIndex = 147
Me.Label106.Text = "40RH"
'
'Label107
'
Me.Label107.AutoSize = true
Me.Label107.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label107.Location = New System.Drawing.Point(196, 59)
Me.Label107.Name = "Label107"
Me.Label107.Size = New System.Drawing.Size(35, 13)
Me.Label107.TabIndex = 147
Me.Label107.Text = "40GH"
'
'Label108
'
Me.Label108.AutoSize = true
Me.Label108.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label108.Location = New System.Drawing.Point(195, 9)
Me.Label108.Name = "Label108"
Me.Label108.Size = New System.Drawing.Size(34, 13)
Me.Label108.TabIndex = 147
Me.Label108.Text = "45HC"
'
'Label109
'
Me.Label109.AutoSize = true
Me.Label109.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label109.Location = New System.Drawing.Point(290, 59)
Me.Label109.Name = "Label109"
Me.Label109.Size = New System.Drawing.Size(34, 13)
Me.Label109.TabIndex = 147
Me.Label109.Text = "40OT"
'
'Label110
'
Me.Label110.AutoSize = true
Me.Label110.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label110.Location = New System.Drawing.Point(153, 59)
Me.Label110.Name = "Label110"
Me.Label110.Size = New System.Drawing.Size(35, 13)
Me.Label110.TabIndex = 147
Me.Label110.Text = "40HG"
'
'Label111
'
Me.Label111.AutoSize = true
Me.Label111.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label111.Location = New System.Drawing.Point(290, 9)
Me.Label111.Name = "Label111"
Me.Label111.Size = New System.Drawing.Size(33, 13)
Me.Label111.TabIndex = 147
Me.Label111.Text = "40RF"
'
'Label112
'
Me.Label112.AutoSize = true
Me.Label112.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label112.Location = New System.Drawing.Point(334, 59)
Me.Label112.Name = "Label112"
Me.Label112.Size = New System.Drawing.Size(33, 13)
Me.Label112.TabIndex = 147
Me.Label112.Text = "20TK"
'
'Label113
'
Me.Label113.AutoSize = true
Me.Label113.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label113.Location = New System.Drawing.Point(152, 9)
Me.Label113.Name = "Label113"
Me.Label113.Size = New System.Drawing.Size(34, 13)
Me.Label113.TabIndex = 147
Me.Label113.Text = "40HC"
'
'Label114
'
Me.Label114.AutoSize = true
Me.Label114.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label114.Location = New System.Drawing.Point(334, 9)
Me.Label114.Name = "Label114"
Me.Label114.Size = New System.Drawing.Size(35, 13)
Me.Label114.TabIndex = 147
Me.Label114.Text = "20RH"
'
'Label115
'
Me.Label115.AutoSize = true
Me.Label115.ForeColor = System.Drawing.Color.Maroon
Me.Label115.Location = New System.Drawing.Point(61, 59)
Me.Label115.Name = "Label115"
Me.Label115.Size = New System.Drawing.Size(33, 13)
Me.Label115.TabIndex = 147
Me.Label115.Text = "40FR"
'
'Label116
'
Me.Label116.AutoSize = true
Me.Label116.ForeColor = System.Drawing.Color.Gold
Me.Label116.Location = New System.Drawing.Point(61, 9)
Me.Label116.Name = "Label116"
Me.Label116.Size = New System.Drawing.Size(34, 13)
Me.Label116.TabIndex = 147
Me.Label116.Text = "40GP"
'
'Label117
'
Me.Label117.AutoSize = true
Me.Label117.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label117.Location = New System.Drawing.Point(247, 59)
Me.Label117.Name = "Label117"
Me.Label117.Size = New System.Drawing.Size(34, 13)
Me.Label117.TabIndex = 147
Me.Label117.Text = "20OT"
'
'Label118
'
Me.Label118.AutoSize = true
Me.Label118.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label118.Location = New System.Drawing.Point(110, 59)
Me.Label118.Name = "Label118"
Me.Label118.Size = New System.Drawing.Size(35, 13)
Me.Label118.TabIndex = 147
Me.Label118.Text = "20HG"
'
'Label119
'
Me.Label119.AutoSize = true
Me.Label119.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label119.Location = New System.Drawing.Point(247, 9)
Me.Label119.Name = "Label119"
Me.Label119.Size = New System.Drawing.Size(33, 13)
Me.Label119.TabIndex = 147
Me.Label119.Text = "20RF"
'
'Label120
'
Me.Label120.AutoSize = true
Me.Label120.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label120.Location = New System.Drawing.Point(109, 9)
Me.Label120.Name = "Label120"
Me.Label120.Size = New System.Drawing.Size(34, 13)
Me.Label120.TabIndex = 147
Me.Label120.Text = "20HC"
'
'Label121
'
Me.Label121.AutoSize = true
Me.Label121.ForeColor = System.Drawing.Color.Maroon
Me.Label121.Location = New System.Drawing.Point(18, 59)
Me.Label121.Name = "Label121"
Me.Label121.Size = New System.Drawing.Size(33, 13)
Me.Label121.TabIndex = 147
Me.Label121.Text = "20FR"
'
'Label122
'
Me.Label122.AutoSize = true
Me.Label122.ForeColor = System.Drawing.Color.Gold
Me.Label122.Location = New System.Drawing.Point(18, 9)
Me.Label122.Name = "Label122"
Me.Label122.Size = New System.Drawing.Size(34, 13)
Me.Label122.TabIndex = 147
Me.Label122.Text = "20GP"
'
'TabPage10
'
Me.TabPage10.Controls.Add(Me.txtRemarksDD)
Me.TabPage10.Controls.Add(Me.txtOtherConcerningRequirementOfShipDD)
Me.TabPage10.Controls.Add(Me.txtF40TKDD)
Me.TabPage10.Controls.Add(Me.txtF20TKDD)
Me.TabPage10.Controls.Add(Me.txtF40OTDD)
Me.TabPage10.Controls.Add(Me.txtF20OTDD)
Me.TabPage10.Controls.Add(Me.txtF40GHDD)
Me.TabPage10.Controls.Add(Me.txtF40HGDD)
Me.TabPage10.Controls.Add(Me.txtF20HGDD)
Me.TabPage10.Controls.Add(Me.txtF40FRDD)
Me.TabPage10.Controls.Add(Me.txtF20FRDD)
Me.TabPage10.Controls.Add(Me.txtF45RHDD)
Me.TabPage10.Controls.Add(Me.txtF40RHDD)
Me.TabPage10.Controls.Add(Me.txtF20RHDD)
Me.TabPage10.Controls.Add(Me.txtF40RFDD)
Me.TabPage10.Controls.Add(Me.txtF20RFDD)
Me.TabPage10.Controls.Add(Me.txtF45HCDD)
Me.TabPage10.Controls.Add(Me.txtF40HCDD)
Me.TabPage10.Controls.Add(Me.txtF20HCDD)
Me.TabPage10.Controls.Add(Me.txtF40GPDD)
Me.TabPage10.Controls.Add(Me.txtF20GPDD)
Me.TabPage10.Controls.Add(Me.Label123)
Me.TabPage10.Controls.Add(Me.Label124)
Me.TabPage10.Controls.Add(Me.GroupBox17)
Me.TabPage10.Controls.Add(Me.GroupBox18)
Me.TabPage10.Controls.Add(Me.Label131)
Me.TabPage10.Controls.Add(Me.Label132)
Me.TabPage10.Controls.Add(Me.Label133)
Me.TabPage10.Controls.Add(Me.Label134)
Me.TabPage10.Controls.Add(Me.Label135)
Me.TabPage10.Controls.Add(Me.Label136)
Me.TabPage10.Controls.Add(Me.Label137)
Me.TabPage10.Controls.Add(Me.Label138)
Me.TabPage10.Controls.Add(Me.Label139)
Me.TabPage10.Controls.Add(Me.Label140)
Me.TabPage10.Controls.Add(Me.Label141)
Me.TabPage10.Controls.Add(Me.Label142)
Me.TabPage10.Controls.Add(Me.Label143)
Me.TabPage10.Controls.Add(Me.Label145)
Me.TabPage10.Controls.Add(Me.Label146)
Me.TabPage10.Controls.Add(Me.Label147)
Me.TabPage10.Controls.Add(Me.Label148)
Me.TabPage10.Controls.Add(Me.Label149)
Me.TabPage10.Controls.Add(Me.Label150)
Me.TabPage10.Location = New System.Drawing.Point(4, 22)
Me.TabPage10.Name = "TabPage10"
Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage10.Size = New System.Drawing.Size(733, 179)
Me.TabPage10.TabIndex = 1
Me.TabPage10.Text = "Full Outbound Local Container"
Me.TabPage10.UseVisualStyleBackColor = true
'
'txtRemarksDD
'
Me.txtRemarksDD.Location = New System.Drawing.Point(21, 149)
Me.txtRemarksDD.Name = "txtRemarksDD"
Me.txtRemarksDD.Size = New System.Drawing.Size(395, 20)
Me.txtRemarksDD.TabIndex = 191
'
'txtOtherConcerningRequirementOfShipDD
'
Me.txtOtherConcerningRequirementOfShipDD.Location = New System.Drawing.Point(20, 112)
Me.txtOtherConcerningRequirementOfShipDD.Name = "txtOtherConcerningRequirementOfShipDD"
Me.txtOtherConcerningRequirementOfShipDD.Size = New System.Drawing.Size(395, 20)
Me.txtOtherConcerningRequirementOfShipDD.TabIndex = 191
'
'txtF40TKDD
'
Me.txtF40TKDD.Location = New System.Drawing.Point(381, 67)
Me.txtF40TKDD.Name = "txtF40TKDD"
Me.txtF40TKDD.Size = New System.Drawing.Size(34, 20)
Me.txtF40TKDD.TabIndex = 191
'
'txtF20TKDD
'
Me.txtF20TKDD.Location = New System.Drawing.Point(338, 67)
Me.txtF20TKDD.Name = "txtF20TKDD"
Me.txtF20TKDD.Size = New System.Drawing.Size(34, 20)
Me.txtF20TKDD.TabIndex = 191
'
'txtF40OTDD
'
Me.txtF40OTDD.Location = New System.Drawing.Point(294, 67)
Me.txtF40OTDD.Name = "txtF40OTDD"
Me.txtF40OTDD.Size = New System.Drawing.Size(34, 20)
Me.txtF40OTDD.TabIndex = 191
'
'txtF20OTDD
'
Me.txtF20OTDD.Location = New System.Drawing.Point(246, 67)
Me.txtF20OTDD.Name = "txtF20OTDD"
Me.txtF20OTDD.Size = New System.Drawing.Size(34, 20)
Me.txtF20OTDD.TabIndex = 191
'
'txtF40GHDD
'
Me.txtF40GHDD.Location = New System.Drawing.Point(199, 67)
Me.txtF40GHDD.Name = "txtF40GHDD"
Me.txtF40GHDD.Size = New System.Drawing.Size(34, 20)
Me.txtF40GHDD.TabIndex = 191
'
'txtF40HGDD
'
Me.txtF40HGDD.Location = New System.Drawing.Point(155, 67)
Me.txtF40HGDD.Name = "txtF40HGDD"
Me.txtF40HGDD.Size = New System.Drawing.Size(34, 20)
Me.txtF40HGDD.TabIndex = 191
'
'txtF20HGDD
'
Me.txtF20HGDD.Location = New System.Drawing.Point(112, 67)
Me.txtF20HGDD.Name = "txtF20HGDD"
Me.txtF20HGDD.Size = New System.Drawing.Size(34, 20)
Me.txtF20HGDD.TabIndex = 191
'
'txtF40FRDD
'
Me.txtF40FRDD.Location = New System.Drawing.Point(61, 67)
Me.txtF40FRDD.Name = "txtF40FRDD"
Me.txtF40FRDD.Size = New System.Drawing.Size(34, 20)
Me.txtF40FRDD.TabIndex = 191
'
'txtF20FRDD
'
Me.txtF20FRDD.Location = New System.Drawing.Point(6, 67)
Me.txtF20FRDD.Name = "txtF20FRDD"
Me.txtF20FRDD.Size = New System.Drawing.Size(34, 20)
Me.txtF20FRDD.TabIndex = 191
'
'txtF45RHDD
'
Me.txtF45RHDD.Location = New System.Drawing.Point(419, 23)
Me.txtF45RHDD.Name = "txtF45RHDD"
Me.txtF45RHDD.Size = New System.Drawing.Size(34, 20)
Me.txtF45RHDD.TabIndex = 191
'
'txtF40RHDD
'
Me.txtF40RHDD.Location = New System.Drawing.Point(379, 23)
Me.txtF40RHDD.Name = "txtF40RHDD"
Me.txtF40RHDD.Size = New System.Drawing.Size(34, 20)
Me.txtF40RHDD.TabIndex = 191
'
'txtF20RHDD
'
Me.txtF20RHDD.Location = New System.Drawing.Point(334, 23)
Me.txtF20RHDD.Name = "txtF20RHDD"
Me.txtF20RHDD.Size = New System.Drawing.Size(34, 20)
Me.txtF20RHDD.TabIndex = 191
'
'txtF40RFDD
'
Me.txtF40RFDD.Location = New System.Drawing.Point(294, 23)
Me.txtF40RFDD.Name = "txtF40RFDD"
Me.txtF40RFDD.Size = New System.Drawing.Size(34, 20)
Me.txtF40RFDD.TabIndex = 191
'
'txtF20RFDD
'
Me.txtF20RFDD.Location = New System.Drawing.Point(246, 23)
Me.txtF20RFDD.Name = "txtF20RFDD"
Me.txtF20RFDD.Size = New System.Drawing.Size(34, 20)
Me.txtF20RFDD.TabIndex = 191
'
'txtF45HCDD
'
Me.txtF45HCDD.Location = New System.Drawing.Point(196, 23)
Me.txtF45HCDD.Name = "txtF45HCDD"
Me.txtF45HCDD.Size = New System.Drawing.Size(34, 20)
Me.txtF45HCDD.TabIndex = 191
'
'txtF40HCDD
'
Me.txtF40HCDD.Location = New System.Drawing.Point(157, 23)
Me.txtF40HCDD.Name = "txtF40HCDD"
Me.txtF40HCDD.Size = New System.Drawing.Size(34, 20)
Me.txtF40HCDD.TabIndex = 191
'
'txtF20HCDD
'
Me.txtF20HCDD.Location = New System.Drawing.Point(114, 23)
Me.txtF20HCDD.Name = "txtF20HCDD"
Me.txtF20HCDD.Size = New System.Drawing.Size(34, 20)
Me.txtF20HCDD.TabIndex = 191
'
'txtF40GPDD
'
Me.txtF40GPDD.Location = New System.Drawing.Point(61, 23)
Me.txtF40GPDD.Name = "txtF40GPDD"
Me.txtF40GPDD.Size = New System.Drawing.Size(34, 20)
Me.txtF40GPDD.TabIndex = 191
'
'txtF20GPDD
'
Me.txtF20GPDD.Location = New System.Drawing.Point(6, 23)
Me.txtF20GPDD.Name = "txtF20GPDD"
Me.txtF20GPDD.Size = New System.Drawing.Size(34, 20)
Me.txtF20GPDD.TabIndex = 191
'
'Label123
'
Me.Label123.AutoSize = true
Me.Label123.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label123.Location = New System.Drawing.Point(18, 135)
Me.Label123.Name = "Label123"
Me.Label123.Size = New System.Drawing.Size(52, 13)
Me.Label123.TabIndex = 190
Me.Label123.Text = "Remaks :"
'
'Label124
'
Me.Label124.AutoSize = true
Me.Label124.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label124.Location = New System.Drawing.Point(17, 95)
Me.Label124.Name = "Label124"
Me.Label124.Size = New System.Drawing.Size(187, 13)
Me.Label124.TabIndex = 190
Me.Label124.Text = "Other concerning requirement of ship :"
'
'GroupBox17
'
Me.GroupBox17.Controls.Add(Me.txtDangerousInboundCargoCLASSDD)
Me.GroupBox17.Controls.Add(Me.txtDangerousInboundCargoTONSDD)
Me.GroupBox17.Controls.Add(Me.txtDangerousInboundCargoCNTRDD)
Me.GroupBox17.Controls.Add(Me.Label125)
Me.GroupBox17.Controls.Add(Me.Label126)
Me.GroupBox17.Controls.Add(Me.Label127)
Me.GroupBox17.Location = New System.Drawing.Point(474, 86)
Me.GroupBox17.Name = "GroupBox17"
Me.GroupBox17.Size = New System.Drawing.Size(199, 66)
Me.GroupBox17.TabIndex = 188
Me.GroupBox17.TabStop = false
Me.GroupBox17.Text = "Dangerous Inbound Cargo"
'
'txtDangerousInboundCargoCLASSDD
'
Me.txtDangerousInboundCargoCLASSDD.Location = New System.Drawing.Point(137, 40)
Me.txtDangerousInboundCargoCLASSDD.Name = "txtDangerousInboundCargoCLASSDD"
Me.txtDangerousInboundCargoCLASSDD.Size = New System.Drawing.Size(50, 20)
Me.txtDangerousInboundCargoCLASSDD.TabIndex = 191
'
'txtDangerousInboundCargoTONSDD
'
Me.txtDangerousInboundCargoTONSDD.Location = New System.Drawing.Point(79, 40)
Me.txtDangerousInboundCargoTONSDD.Name = "txtDangerousInboundCargoTONSDD"
Me.txtDangerousInboundCargoTONSDD.Size = New System.Drawing.Size(50, 20)
Me.txtDangerousInboundCargoTONSDD.TabIndex = 191
'
'txtDangerousInboundCargoCNTRDD
'
Me.txtDangerousInboundCargoCNTRDD.Location = New System.Drawing.Point(16, 40)
Me.txtDangerousInboundCargoCNTRDD.Name = "txtDangerousInboundCargoCNTRDD"
Me.txtDangerousInboundCargoCNTRDD.Size = New System.Drawing.Size(50, 20)
Me.txtDangerousInboundCargoCNTRDD.TabIndex = 191
'
'Label125
'
Me.Label125.AutoSize = true
Me.Label125.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label125.Location = New System.Drawing.Point(134, 19)
Me.Label125.Name = "Label125"
Me.Label125.Size = New System.Drawing.Size(32, 13)
Me.Label125.TabIndex = 147
Me.Label125.Text = "Class"
'
'Label126
'
Me.Label126.AutoSize = true
Me.Label126.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label126.Location = New System.Drawing.Point(86, 19)
Me.Label126.Name = "Label126"
Me.Label126.Size = New System.Drawing.Size(37, 13)
Me.Label126.TabIndex = 147
Me.Label126.Text = "TONS"
'
'Label127
'
Me.Label127.AutoSize = true
Me.Label127.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label127.Location = New System.Drawing.Point(30, 19)
Me.Label127.Name = "Label127"
Me.Label127.Size = New System.Drawing.Size(37, 13)
Me.Label127.TabIndex = 147
Me.Label127.Text = "CTNR"
'
'GroupBox18
'
Me.GroupBox18.Controls.Add(Me.txtFTONDD)
Me.GroupBox18.Controls.Add(Me.txtFTEUDD)
Me.GroupBox18.Controls.Add(Me.txtFCNTRDD)
Me.GroupBox18.Controls.Add(Me.Label128)
Me.GroupBox18.Controls.Add(Me.Label129)
Me.GroupBox18.Controls.Add(Me.Label130)
Me.GroupBox18.Location = New System.Drawing.Point(474, 7)
Me.GroupBox18.Name = "GroupBox18"
Me.GroupBox18.Size = New System.Drawing.Size(199, 66)
Me.GroupBox18.TabIndex = 187
Me.GroupBox18.TabStop = false
'
'txtFTONDD
'
Me.txtFTONDD.Location = New System.Drawing.Point(129, 37)
Me.txtFTONDD.Name = "txtFTONDD"
Me.txtFTONDD.Size = New System.Drawing.Size(50, 20)
Me.txtFTONDD.TabIndex = 191
'
'txtFTEUDD
'
Me.txtFTEUDD.Location = New System.Drawing.Point(73, 37)
Me.txtFTEUDD.Name = "txtFTEUDD"
Me.txtFTEUDD.Size = New System.Drawing.Size(50, 20)
Me.txtFTEUDD.TabIndex = 191
'
'txtFCNTRDD
'
Me.txtFCNTRDD.Location = New System.Drawing.Point(17, 37)
Me.txtFCNTRDD.Name = "txtFCNTRDD"
Me.txtFCNTRDD.Size = New System.Drawing.Size(50, 20)
Me.txtFCNTRDD.TabIndex = 191
'
'Label128
'
Me.Label128.AutoSize = true
Me.Label128.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label128.Location = New System.Drawing.Point(132, 19)
Me.Label128.Name = "Label128"
Me.Label128.Size = New System.Drawing.Size(37, 13)
Me.Label128.TabIndex = 147
Me.Label128.Text = "TONS"
'
'Label129
'
Me.Label129.AutoSize = true
Me.Label129.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label129.Location = New System.Drawing.Point(86, 19)
Me.Label129.Name = "Label129"
Me.Label129.Size = New System.Drawing.Size(29, 13)
Me.Label129.TabIndex = 147
Me.Label129.Text = "TEU"
'
'Label130
'
Me.Label130.AutoSize = true
Me.Label130.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label130.Location = New System.Drawing.Point(30, 19)
Me.Label130.Name = "Label130"
Me.Label130.Size = New System.Drawing.Size(37, 13)
Me.Label130.TabIndex = 147
Me.Label130.Text = "CTNR"
'
'Label131
'
Me.Label131.AutoSize = true
Me.Label131.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label131.Location = New System.Drawing.Point(378, 51)
Me.Label131.Name = "Label131"
Me.Label131.Size = New System.Drawing.Size(33, 13)
Me.Label131.TabIndex = 174
Me.Label131.Text = "40TK"
'
'Label132
'
Me.Label132.AutoSize = true
Me.Label132.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label132.Location = New System.Drawing.Point(421, 7)
Me.Label132.Name = "Label132"
Me.Label132.Size = New System.Drawing.Size(35, 13)
Me.Label132.TabIndex = 173
Me.Label132.Text = "45RH"
'
'Label133
'
Me.Label133.AutoSize = true
Me.Label133.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label133.Location = New System.Drawing.Point(378, 7)
Me.Label133.Name = "Label133"
Me.Label133.Size = New System.Drawing.Size(35, 13)
Me.Label133.TabIndex = 176
Me.Label133.Text = "40RH"
'
'Label134
'
Me.Label134.AutoSize = true
Me.Label134.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label134.Location = New System.Drawing.Point(197, 51)
Me.Label134.Name = "Label134"
Me.Label134.Size = New System.Drawing.Size(35, 13)
Me.Label134.TabIndex = 175
Me.Label134.Text = "40GH"
'
'Label135
'
Me.Label135.AutoSize = true
Me.Label135.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label135.Location = New System.Drawing.Point(196, 7)
Me.Label135.Name = "Label135"
Me.Label135.Size = New System.Drawing.Size(34, 13)
Me.Label135.TabIndex = 172
Me.Label135.Text = "45HC"
'
'Label136
'
Me.Label136.AutoSize = true
Me.Label136.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label136.Location = New System.Drawing.Point(291, 51)
Me.Label136.Name = "Label136"
Me.Label136.Size = New System.Drawing.Size(34, 13)
Me.Label136.TabIndex = 169
Me.Label136.Text = "40OT"
'
'Label137
'
Me.Label137.AutoSize = true
Me.Label137.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label137.Location = New System.Drawing.Point(154, 51)
Me.Label137.Name = "Label137"
Me.Label137.Size = New System.Drawing.Size(35, 13)
Me.Label137.TabIndex = 168
Me.Label137.Text = "40HG"
'
'Label138
'
Me.Label138.AutoSize = true
Me.Label138.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label138.Location = New System.Drawing.Point(291, 7)
Me.Label138.Name = "Label138"
Me.Label138.Size = New System.Drawing.Size(33, 13)
Me.Label138.TabIndex = 171
Me.Label138.Text = "40RF"
'
'Label139
'
Me.Label139.AutoSize = true
Me.Label139.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label139.Location = New System.Drawing.Point(335, 51)
Me.Label139.Name = "Label139"
Me.Label139.Size = New System.Drawing.Size(33, 13)
Me.Label139.TabIndex = 170
Me.Label139.Text = "20TK"
'
'Label140
'
Me.Label140.AutoSize = true
Me.Label140.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label140.Location = New System.Drawing.Point(153, 7)
Me.Label140.Name = "Label140"
Me.Label140.Size = New System.Drawing.Size(34, 13)
Me.Label140.TabIndex = 177
Me.Label140.Text = "40HC"
'
'Label141
'
Me.Label141.AutoSize = true
Me.Label141.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label141.Location = New System.Drawing.Point(335, 7)
Me.Label141.Name = "Label141"
Me.Label141.Size = New System.Drawing.Size(35, 13)
Me.Label141.TabIndex = 184
Me.Label141.Text = "20RH"
'
'Label142
'
Me.Label142.AutoSize = true
Me.Label142.ForeColor = System.Drawing.Color.Maroon
Me.Label142.Location = New System.Drawing.Point(62, 51)
Me.Label142.Name = "Label142"
Me.Label142.Size = New System.Drawing.Size(33, 13)
Me.Label142.TabIndex = 183
Me.Label142.Text = "40FR"
'
'Label143
'
Me.Label143.AutoSize = true
Me.Label143.ForeColor = System.Drawing.Color.Gold
Me.Label143.Location = New System.Drawing.Point(62, 7)
Me.Label143.Name = "Label143"
Me.Label143.Size = New System.Drawing.Size(34, 13)
Me.Label143.TabIndex = 186
Me.Label143.Text = "40GP"
'
'Label145
'
Me.Label145.AutoSize = true
Me.Label145.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label145.Location = New System.Drawing.Point(248, 51)
Me.Label145.Name = "Label145"
Me.Label145.Size = New System.Drawing.Size(34, 13)
Me.Label145.TabIndex = 185
Me.Label145.Text = "20OT"
'
'Label146
'
Me.Label146.AutoSize = true
Me.Label146.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label146.Location = New System.Drawing.Point(111, 51)
Me.Label146.Name = "Label146"
Me.Label146.Size = New System.Drawing.Size(35, 13)
Me.Label146.TabIndex = 182
Me.Label146.Text = "20HG"
'
'Label147
'
Me.Label147.AutoSize = true
Me.Label147.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label147.Location = New System.Drawing.Point(248, 7)
Me.Label147.Name = "Label147"
Me.Label147.Size = New System.Drawing.Size(33, 13)
Me.Label147.TabIndex = 179
Me.Label147.Text = "20RF"
'
'Label148
'
Me.Label148.AutoSize = true
Me.Label148.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label148.Location = New System.Drawing.Point(110, 7)
Me.Label148.Name = "Label148"
Me.Label148.Size = New System.Drawing.Size(34, 13)
Me.Label148.TabIndex = 178
Me.Label148.Text = "20HC"
'
'Label149
'
Me.Label149.AutoSize = true
Me.Label149.ForeColor = System.Drawing.Color.Maroon
Me.Label149.Location = New System.Drawing.Point(19, 51)
Me.Label149.Name = "Label149"
Me.Label149.Size = New System.Drawing.Size(33, 13)
Me.Label149.TabIndex = 180
Me.Label149.Text = "20FR"
'
'Label150
'
Me.Label150.AutoSize = true
Me.Label150.ForeColor = System.Drawing.Color.Gold
Me.Label150.Location = New System.Drawing.Point(19, 7)
Me.Label150.Name = "Label150"
Me.Label150.Size = New System.Drawing.Size(34, 13)
Me.Label150.TabIndex = 181
Me.Label150.Text = "20GP"
'
'TabPage14
'
Me.TabPage14.Controls.Add(Me.TabControl6)
Me.TabPage14.Location = New System.Drawing.Point(4, 22)
Me.TabPage14.Name = "TabPage14"
Me.TabPage14.Size = New System.Drawing.Size(753, 217)
Me.TabPage14.TabIndex = 3
Me.TabPage14.Text = "Transit Outbound Cargo"
Me.TabPage14.UseVisualStyleBackColor = true
'
'TabControl6
'
Me.TabControl6.Controls.Add(Me.TabPage15)
Me.TabControl6.Controls.Add(Me.TabPage16)
Me.TabControl6.Location = New System.Drawing.Point(6, 6)
Me.TabControl6.Name = "TabControl6"
Me.TabControl6.SelectedIndex = 0
Me.TabControl6.Size = New System.Drawing.Size(741, 205)
Me.TabControl6.TabIndex = 1
'
'TabPage15
'
Me.TabPage15.Controls.Add(Me.txtE40TKDD1)
Me.TabPage15.Controls.Add(Me.txtE20TKDD1)
Me.TabPage15.Controls.Add(Me.txtE40OTDD1)
Me.TabPage15.Controls.Add(Me.txtE20OTDD1)
Me.TabPage15.Controls.Add(Me.txtE40GHDD1)
Me.TabPage15.Controls.Add(Me.txtE40HGDD1)
Me.TabPage15.Controls.Add(Me.txtE20HGDD1)
Me.TabPage15.Controls.Add(Me.txtE20FRDD1)
Me.TabPage15.Controls.Add(Me.txtE40FRDD1)
Me.TabPage15.Controls.Add(Me.txtE45RHDD1)
Me.TabPage15.Controls.Add(Me.txtE40RHDD1)
Me.TabPage15.Controls.Add(Me.txtE20RHDD1)
Me.TabPage15.Controls.Add(Me.txtE40RFDD1)
Me.TabPage15.Controls.Add(Me.txtE20RFDD1)
Me.TabPage15.Controls.Add(Me.txtE45HCDD1)
Me.TabPage15.Controls.Add(Me.txtE40HCDD1)
Me.TabPage15.Controls.Add(Me.txtE20HCDD1)
Me.TabPage15.Controls.Add(Me.txtE40GPDD1)
Me.TabPage15.Controls.Add(Me.txtE20GPDD1)
Me.TabPage15.Controls.Add(Me.GroupBox22)
Me.TabPage15.Controls.Add(Me.Label205)
Me.TabPage15.Controls.Add(Me.Label206)
Me.TabPage15.Controls.Add(Me.Label207)
Me.TabPage15.Controls.Add(Me.Label208)
Me.TabPage15.Controls.Add(Me.Label209)
Me.TabPage15.Controls.Add(Me.Label210)
Me.TabPage15.Controls.Add(Me.Label211)
Me.TabPage15.Controls.Add(Me.Label212)
Me.TabPage15.Controls.Add(Me.Label213)
Me.TabPage15.Controls.Add(Me.Label214)
Me.TabPage15.Controls.Add(Me.Label215)
Me.TabPage15.Controls.Add(Me.Label216)
Me.TabPage15.Controls.Add(Me.Label217)
Me.TabPage15.Controls.Add(Me.Label218)
Me.TabPage15.Controls.Add(Me.Label219)
Me.TabPage15.Controls.Add(Me.Label220)
Me.TabPage15.Controls.Add(Me.Label221)
Me.TabPage15.Controls.Add(Me.Label222)
Me.TabPage15.Controls.Add(Me.Label223)
Me.TabPage15.Location = New System.Drawing.Point(4, 22)
Me.TabPage15.Name = "TabPage15"
Me.TabPage15.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage15.Size = New System.Drawing.Size(733, 179)
Me.TabPage15.TabIndex = 0
Me.TabPage15.Text = "Empty Transit Outbound Container"
Me.TabPage15.UseVisualStyleBackColor = true
'
'txtE40TKDD1
'
Me.txtE40TKDD1.Location = New System.Drawing.Point(380, 75)
Me.txtE40TKDD1.Name = "txtE40TKDD1"
Me.txtE40TKDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40TKDD1.TabIndex = 148
'
'txtE20TKDD1
'
Me.txtE20TKDD1.Location = New System.Drawing.Point(330, 75)
Me.txtE20TKDD1.Name = "txtE20TKDD1"
Me.txtE20TKDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20TKDD1.TabIndex = 148
'
'txtE40OTDD1
'
Me.txtE40OTDD1.Location = New System.Drawing.Point(288, 75)
Me.txtE40OTDD1.Name = "txtE40OTDD1"
Me.txtE40OTDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40OTDD1.TabIndex = 148
'
'txtE20OTDD1
'
Me.txtE20OTDD1.Location = New System.Drawing.Point(250, 75)
Me.txtE20OTDD1.Name = "txtE20OTDD1"
Me.txtE20OTDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20OTDD1.TabIndex = 148
'
'txtE40GHDD1
'
Me.txtE40GHDD1.Location = New System.Drawing.Point(199, 75)
Me.txtE40GHDD1.Name = "txtE40GHDD1"
Me.txtE40GHDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40GHDD1.TabIndex = 148
'
'txtE40HGDD1
'
Me.txtE40HGDD1.Location = New System.Drawing.Point(156, 75)
Me.txtE40HGDD1.Name = "txtE40HGDD1"
Me.txtE40HGDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40HGDD1.TabIndex = 148
'
'txtE20HGDD1
'
Me.txtE20HGDD1.Location = New System.Drawing.Point(113, 75)
Me.txtE20HGDD1.Name = "txtE20HGDD1"
Me.txtE20HGDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20HGDD1.TabIndex = 148
'
'txtE20FRDD1
'
Me.txtE20FRDD1.Location = New System.Drawing.Point(16, 75)
Me.txtE20FRDD1.Name = "txtE20FRDD1"
Me.txtE20FRDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20FRDD1.TabIndex = 148
'
'txtE40FRDD1
'
Me.txtE40FRDD1.Location = New System.Drawing.Point(59, 75)
Me.txtE40FRDD1.Name = "txtE40FRDD1"
Me.txtE40FRDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40FRDD1.TabIndex = 148
'
'txtE45RHDD1
'
Me.txtE45RHDD1.Location = New System.Drawing.Point(420, 25)
Me.txtE45RHDD1.Name = "txtE45RHDD1"
Me.txtE45RHDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE45RHDD1.TabIndex = 148
'
'txtE40RHDD1
'
Me.txtE40RHDD1.Location = New System.Drawing.Point(380, 25)
Me.txtE40RHDD1.Name = "txtE40RHDD1"
Me.txtE40RHDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40RHDD1.TabIndex = 148
'
'txtE20RHDD1
'
Me.txtE20RHDD1.Location = New System.Drawing.Point(336, 25)
Me.txtE20RHDD1.Name = "txtE20RHDD1"
Me.txtE20RHDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20RHDD1.TabIndex = 148
'
'txtE40RFDD1
'
Me.txtE40RFDD1.Location = New System.Drawing.Point(293, 25)
Me.txtE40RFDD1.Name = "txtE40RFDD1"
Me.txtE40RFDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40RFDD1.TabIndex = 148
'
'txtE20RFDD1
'
Me.txtE20RFDD1.Location = New System.Drawing.Point(245, 25)
Me.txtE20RFDD1.Name = "txtE20RFDD1"
Me.txtE20RFDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20RFDD1.TabIndex = 148
'
'txtE45HCDD1
'
Me.txtE45HCDD1.Location = New System.Drawing.Point(196, 25)
Me.txtE45HCDD1.Name = "txtE45HCDD1"
Me.txtE45HCDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE45HCDD1.TabIndex = 148
'
'txtE40HCDD1
'
Me.txtE40HCDD1.Location = New System.Drawing.Point(149, 25)
Me.txtE40HCDD1.Name = "txtE40HCDD1"
Me.txtE40HCDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40HCDD1.TabIndex = 148
'
'txtE20HCDD1
'
Me.txtE20HCDD1.Location = New System.Drawing.Point(108, 25)
Me.txtE20HCDD1.Name = "txtE20HCDD1"
Me.txtE20HCDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20HCDD1.TabIndex = 148
'
'txtE40GPDD1
'
Me.txtE40GPDD1.Location = New System.Drawing.Point(59, 25)
Me.txtE40GPDD1.Name = "txtE40GPDD1"
Me.txtE40GPDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE40GPDD1.TabIndex = 148
'
'txtE20GPDD1
'
Me.txtE20GPDD1.Location = New System.Drawing.Point(6, 25)
Me.txtE20GPDD1.Name = "txtE20GPDD1"
Me.txtE20GPDD1.Size = New System.Drawing.Size(35, 20)
Me.txtE20GPDD1.TabIndex = 148
'
'GroupBox22
'
Me.GroupBox22.Controls.Add(Me.txtETONDD1)
Me.GroupBox22.Controls.Add(Me.txtETEUDD1)
Me.GroupBox22.Controls.Add(Me.txtECNTRDD1)
Me.GroupBox22.Controls.Add(Me.Label202)
Me.GroupBox22.Controls.Add(Me.Label203)
Me.GroupBox22.Controls.Add(Me.Label204)
Me.GroupBox22.Location = New System.Drawing.Point(473, 29)
Me.GroupBox22.Name = "GroupBox22"
Me.GroupBox22.Size = New System.Drawing.Size(199, 66)
Me.GroupBox22.TabIndex = 148
Me.GroupBox22.TabStop = false
'
'txtETONDD1
'
Me.txtETONDD1.Location = New System.Drawing.Point(138, 40)
Me.txtETONDD1.Name = "txtETONDD1"
Me.txtETONDD1.Size = New System.Drawing.Size(56, 20)
Me.txtETONDD1.TabIndex = 148
'
'txtETEUDD1
'
Me.txtETEUDD1.Location = New System.Drawing.Point(76, 40)
Me.txtETEUDD1.Name = "txtETEUDD1"
Me.txtETEUDD1.Size = New System.Drawing.Size(56, 20)
Me.txtETEUDD1.TabIndex = 148
'
'txtECNTRDD1
'
Me.txtECNTRDD1.Location = New System.Drawing.Point(14, 40)
Me.txtECNTRDD1.Name = "txtECNTRDD1"
Me.txtECNTRDD1.Size = New System.Drawing.Size(56, 20)
Me.txtECNTRDD1.TabIndex = 148
'
'Label202
'
Me.Label202.AutoSize = true
Me.Label202.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label202.Location = New System.Drawing.Point(132, 19)
Me.Label202.Name = "Label202"
Me.Label202.Size = New System.Drawing.Size(37, 13)
Me.Label202.TabIndex = 147
Me.Label202.Text = "TONS"
'
'Label203
'
Me.Label203.AutoSize = true
Me.Label203.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label203.Location = New System.Drawing.Point(86, 19)
Me.Label203.Name = "Label203"
Me.Label203.Size = New System.Drawing.Size(29, 13)
Me.Label203.TabIndex = 147
Me.Label203.Text = "TEU"
'
'Label204
'
Me.Label204.AutoSize = true
Me.Label204.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label204.Location = New System.Drawing.Point(30, 19)
Me.Label204.Name = "Label204"
Me.Label204.Size = New System.Drawing.Size(37, 13)
Me.Label204.TabIndex = 147
Me.Label204.Text = "CTNR"
'
'Label205
'
Me.Label205.AutoSize = true
Me.Label205.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label205.Location = New System.Drawing.Point(377, 59)
Me.Label205.Name = "Label205"
Me.Label205.Size = New System.Drawing.Size(33, 13)
Me.Label205.TabIndex = 147
Me.Label205.Text = "40TK"
'
'Label206
'
Me.Label206.AutoSize = true
Me.Label206.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label206.Location = New System.Drawing.Point(420, 9)
Me.Label206.Name = "Label206"
Me.Label206.Size = New System.Drawing.Size(35, 13)
Me.Label206.TabIndex = 147
Me.Label206.Text = "45RH"
'
'Label207
'
Me.Label207.AutoSize = true
Me.Label207.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label207.Location = New System.Drawing.Point(377, 9)
Me.Label207.Name = "Label207"
Me.Label207.Size = New System.Drawing.Size(35, 13)
Me.Label207.TabIndex = 147
Me.Label207.Text = "40RH"
'
'Label208
'
Me.Label208.AutoSize = true
Me.Label208.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label208.Location = New System.Drawing.Point(196, 59)
Me.Label208.Name = "Label208"
Me.Label208.Size = New System.Drawing.Size(35, 13)
Me.Label208.TabIndex = 147
Me.Label208.Text = "40GH"
'
'Label209
'
Me.Label209.AutoSize = true
Me.Label209.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label209.Location = New System.Drawing.Point(195, 9)
Me.Label209.Name = "Label209"
Me.Label209.Size = New System.Drawing.Size(34, 13)
Me.Label209.TabIndex = 147
Me.Label209.Text = "45HC"
'
'Label210
'
Me.Label210.AutoSize = true
Me.Label210.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label210.Location = New System.Drawing.Point(290, 59)
Me.Label210.Name = "Label210"
Me.Label210.Size = New System.Drawing.Size(34, 13)
Me.Label210.TabIndex = 147
Me.Label210.Text = "40OT"
'
'Label211
'
Me.Label211.AutoSize = true
Me.Label211.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label211.Location = New System.Drawing.Point(153, 59)
Me.Label211.Name = "Label211"
Me.Label211.Size = New System.Drawing.Size(35, 13)
Me.Label211.TabIndex = 147
Me.Label211.Text = "40HG"
'
'Label212
'
Me.Label212.AutoSize = true
Me.Label212.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label212.Location = New System.Drawing.Point(290, 9)
Me.Label212.Name = "Label212"
Me.Label212.Size = New System.Drawing.Size(33, 13)
Me.Label212.TabIndex = 147
Me.Label212.Text = "40RF"
'
'Label213
'
Me.Label213.AutoSize = true
Me.Label213.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label213.Location = New System.Drawing.Point(334, 59)
Me.Label213.Name = "Label213"
Me.Label213.Size = New System.Drawing.Size(33, 13)
Me.Label213.TabIndex = 147
Me.Label213.Text = "20TK"
'
'Label214
'
Me.Label214.AutoSize = true
Me.Label214.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label214.Location = New System.Drawing.Point(152, 9)
Me.Label214.Name = "Label214"
Me.Label214.Size = New System.Drawing.Size(34, 13)
Me.Label214.TabIndex = 147
Me.Label214.Text = "40HC"
'
'Label215
'
Me.Label215.AutoSize = true
Me.Label215.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label215.Location = New System.Drawing.Point(334, 9)
Me.Label215.Name = "Label215"
Me.Label215.Size = New System.Drawing.Size(35, 13)
Me.Label215.TabIndex = 147
Me.Label215.Text = "20RH"
'
'Label216
'
Me.Label216.AutoSize = true
Me.Label216.ForeColor = System.Drawing.Color.Maroon
Me.Label216.Location = New System.Drawing.Point(61, 59)
Me.Label216.Name = "Label216"
Me.Label216.Size = New System.Drawing.Size(33, 13)
Me.Label216.TabIndex = 147
Me.Label216.Text = "40FR"
'
'Label217
'
Me.Label217.AutoSize = true
Me.Label217.ForeColor = System.Drawing.Color.Gold
Me.Label217.Location = New System.Drawing.Point(61, 9)
Me.Label217.Name = "Label217"
Me.Label217.Size = New System.Drawing.Size(34, 13)
Me.Label217.TabIndex = 147
Me.Label217.Text = "40GP"
'
'Label218
'
Me.Label218.AutoSize = true
Me.Label218.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label218.Location = New System.Drawing.Point(247, 59)
Me.Label218.Name = "Label218"
Me.Label218.Size = New System.Drawing.Size(34, 13)
Me.Label218.TabIndex = 147
Me.Label218.Text = "20OT"
'
'Label219
'
Me.Label219.AutoSize = true
Me.Label219.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label219.Location = New System.Drawing.Point(110, 59)
Me.Label219.Name = "Label219"
Me.Label219.Size = New System.Drawing.Size(35, 13)
Me.Label219.TabIndex = 147
Me.Label219.Text = "20HG"
'
'Label220
'
Me.Label220.AutoSize = true
Me.Label220.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label220.Location = New System.Drawing.Point(247, 9)
Me.Label220.Name = "Label220"
Me.Label220.Size = New System.Drawing.Size(33, 13)
Me.Label220.TabIndex = 147
Me.Label220.Text = "20RF"
'
'Label221
'
Me.Label221.AutoSize = true
Me.Label221.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label221.Location = New System.Drawing.Point(109, 9)
Me.Label221.Name = "Label221"
Me.Label221.Size = New System.Drawing.Size(34, 13)
Me.Label221.TabIndex = 147
Me.Label221.Text = "20HC"
'
'Label222
'
Me.Label222.AutoSize = true
Me.Label222.ForeColor = System.Drawing.Color.Maroon
Me.Label222.Location = New System.Drawing.Point(18, 59)
Me.Label222.Name = "Label222"
Me.Label222.Size = New System.Drawing.Size(33, 13)
Me.Label222.TabIndex = 147
Me.Label222.Text = "20FR"
'
'Label223
'
Me.Label223.AutoSize = true
Me.Label223.ForeColor = System.Drawing.Color.Gold
Me.Label223.Location = New System.Drawing.Point(18, 9)
Me.Label223.Name = "Label223"
Me.Label223.Size = New System.Drawing.Size(34, 13)
Me.Label223.TabIndex = 147
Me.Label223.Text = "20GP"
'
'TabPage16
'
Me.TabPage16.Controls.Add(Me.txtRemarksDD1)
Me.TabPage16.Controls.Add(Me.txtOtherConcerningRequirementOfShipDD1)
Me.TabPage16.Controls.Add(Me.txtF40TKDD1)
Me.TabPage16.Controls.Add(Me.txtF20TKDD1)
Me.TabPage16.Controls.Add(Me.txtF40OTDD1)
Me.TabPage16.Controls.Add(Me.txtF20OTDD1)
Me.TabPage16.Controls.Add(Me.txtF40GHDD1)
Me.TabPage16.Controls.Add(Me.txtF40HGDD1)
Me.TabPage16.Controls.Add(Me.txtF20HGDD1)
Me.TabPage16.Controls.Add(Me.txtF40FRDD1)
Me.TabPage16.Controls.Add(Me.txtF20FRDD1)
Me.TabPage16.Controls.Add(Me.txtF45RHDD1)
Me.TabPage16.Controls.Add(Me.txtF40RHDD1)
Me.TabPage16.Controls.Add(Me.txtF20RHDD1)
Me.TabPage16.Controls.Add(Me.txtF40RFDD1)
Me.TabPage16.Controls.Add(Me.txtF20RFDD1)
Me.TabPage16.Controls.Add(Me.txtF45HCDD1)
Me.TabPage16.Controls.Add(Me.txtF40HCDD1)
Me.TabPage16.Controls.Add(Me.txtF20HCDD1)
Me.TabPage16.Controls.Add(Me.txtF40GPDD1)
Me.TabPage16.Controls.Add(Me.txtF20GPDD1)
Me.TabPage16.Controls.Add(Me.Label224)
Me.TabPage16.Controls.Add(Me.Label225)
Me.TabPage16.Controls.Add(Me.GroupBox23)
Me.TabPage16.Controls.Add(Me.GroupBox24)
Me.TabPage16.Controls.Add(Me.Label232)
Me.TabPage16.Controls.Add(Me.Label233)
Me.TabPage16.Controls.Add(Me.Label234)
Me.TabPage16.Controls.Add(Me.Label235)
Me.TabPage16.Controls.Add(Me.Label236)
Me.TabPage16.Controls.Add(Me.Label237)
Me.TabPage16.Controls.Add(Me.Label238)
Me.TabPage16.Controls.Add(Me.Label239)
Me.TabPage16.Controls.Add(Me.Label240)
Me.TabPage16.Controls.Add(Me.Label241)
Me.TabPage16.Controls.Add(Me.Label242)
Me.TabPage16.Controls.Add(Me.Label243)
Me.TabPage16.Controls.Add(Me.Label244)
Me.TabPage16.Controls.Add(Me.Label245)
Me.TabPage16.Controls.Add(Me.Label246)
Me.TabPage16.Controls.Add(Me.Label247)
Me.TabPage16.Controls.Add(Me.Label248)
Me.TabPage16.Controls.Add(Me.Label249)
Me.TabPage16.Controls.Add(Me.Label250)
Me.TabPage16.Location = New System.Drawing.Point(4, 22)
Me.TabPage16.Name = "TabPage16"
Me.TabPage16.Padding = New System.Windows.Forms.Padding(3)
Me.TabPage16.Size = New System.Drawing.Size(733, 179)
Me.TabPage16.TabIndex = 1
Me.TabPage16.Text = "Full Transit Outbound Container"
Me.TabPage16.UseVisualStyleBackColor = true
'
'txtRemarksDD1
'
Me.txtRemarksDD1.Location = New System.Drawing.Point(48, 150)
Me.txtRemarksDD1.Name = "txtRemarksDD1"
Me.txtRemarksDD1.Size = New System.Drawing.Size(395, 20)
Me.txtRemarksDD1.TabIndex = 265
'
'txtOtherConcerningRequirementOfShipDD1
'
Me.txtOtherConcerningRequirementOfShipDD1.Location = New System.Drawing.Point(47, 113)
Me.txtOtherConcerningRequirementOfShipDD1.Name = "txtOtherConcerningRequirementOfShipDD1"
Me.txtOtherConcerningRequirementOfShipDD1.Size = New System.Drawing.Size(395, 20)
Me.txtOtherConcerningRequirementOfShipDD1.TabIndex = 264
'
'txtF40TKDD1
'
Me.txtF40TKDD1.Location = New System.Drawing.Point(408, 68)
Me.txtF40TKDD1.Name = "txtF40TKDD1"
Me.txtF40TKDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF40TKDD1.TabIndex = 266
'
'txtF20TKDD1
'
Me.txtF20TKDD1.Location = New System.Drawing.Point(365, 68)
Me.txtF20TKDD1.Name = "txtF20TKDD1"
Me.txtF20TKDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF20TKDD1.TabIndex = 268
'
'txtF40OTDD1
'
Me.txtF40OTDD1.Location = New System.Drawing.Point(321, 68)
Me.txtF40OTDD1.Name = "txtF40OTDD1"
Me.txtF40OTDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF40OTDD1.TabIndex = 267
'
'txtF20OTDD1
'
Me.txtF20OTDD1.Location = New System.Drawing.Point(273, 68)
Me.txtF20OTDD1.Name = "txtF20OTDD1"
Me.txtF20OTDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF20OTDD1.TabIndex = 260
'
'txtF40GHDD1
'
Me.txtF40GHDD1.Location = New System.Drawing.Point(226, 68)
Me.txtF40GHDD1.Name = "txtF40GHDD1"
Me.txtF40GHDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF40GHDD1.TabIndex = 259
'
'txtF40HGDD1
'
Me.txtF40HGDD1.Location = New System.Drawing.Point(182, 68)
Me.txtF40HGDD1.Name = "txtF40HGDD1"
Me.txtF40HGDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF40HGDD1.TabIndex = 261
'
'txtF20HGDD1
'
Me.txtF20HGDD1.Location = New System.Drawing.Point(139, 68)
Me.txtF20HGDD1.Name = "txtF20HGDD1"
Me.txtF20HGDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF20HGDD1.TabIndex = 263
'
'txtF40FRDD1
'
Me.txtF40FRDD1.Location = New System.Drawing.Point(88, 68)
Me.txtF40FRDD1.Name = "txtF40FRDD1"
Me.txtF40FRDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF40FRDD1.TabIndex = 262
'
'txtF20FRDD1
'
Me.txtF20FRDD1.Location = New System.Drawing.Point(33, 68)
Me.txtF20FRDD1.Name = "txtF20FRDD1"
Me.txtF20FRDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF20FRDD1.TabIndex = 269
'
'txtF45RHDD1
'
Me.txtF45RHDD1.Location = New System.Drawing.Point(446, 24)
Me.txtF45RHDD1.Name = "txtF45RHDD1"
Me.txtF45RHDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF45RHDD1.TabIndex = 276
'
'txtF40RHDD1
'
Me.txtF40RHDD1.Location = New System.Drawing.Point(406, 24)
Me.txtF40RHDD1.Name = "txtF40RHDD1"
Me.txtF40RHDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF40RHDD1.TabIndex = 275
'
'txtF20RHDD1
'
Me.txtF20RHDD1.Location = New System.Drawing.Point(361, 24)
Me.txtF20RHDD1.Name = "txtF20RHDD1"
Me.txtF20RHDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF20RHDD1.TabIndex = 277
'
'txtF40RFDD1
'
Me.txtF40RFDD1.Location = New System.Drawing.Point(321, 24)
Me.txtF40RFDD1.Name = "txtF40RFDD1"
Me.txtF40RFDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF40RFDD1.TabIndex = 279
'
'txtF20RFDD1
'
Me.txtF20RFDD1.Location = New System.Drawing.Point(273, 24)
Me.txtF20RFDD1.Name = "txtF20RFDD1"
Me.txtF20RFDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF20RFDD1.TabIndex = 278
'
'txtF45HCDD1
'
Me.txtF45HCDD1.Location = New System.Drawing.Point(223, 24)
Me.txtF45HCDD1.Name = "txtF45HCDD1"
Me.txtF45HCDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF45HCDD1.TabIndex = 271
'
'txtF40HCDD1
'
Me.txtF40HCDD1.Location = New System.Drawing.Point(184, 24)
Me.txtF40HCDD1.Name = "txtF40HCDD1"
Me.txtF40HCDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF40HCDD1.TabIndex = 270
'
'txtF20HCDD1
'
Me.txtF20HCDD1.Location = New System.Drawing.Point(141, 24)
Me.txtF20HCDD1.Name = "txtF20HCDD1"
Me.txtF20HCDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF20HCDD1.TabIndex = 272
'
'txtF40GPDD1
'
Me.txtF40GPDD1.Location = New System.Drawing.Point(88, 24)
Me.txtF40GPDD1.Name = "txtF40GPDD1"
Me.txtF40GPDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF40GPDD1.TabIndex = 274
'
'txtF20GPDD1
'
Me.txtF20GPDD1.Location = New System.Drawing.Point(33, 24)
Me.txtF20GPDD1.Name = "txtF20GPDD1"
Me.txtF20GPDD1.Size = New System.Drawing.Size(34, 20)
Me.txtF20GPDD1.TabIndex = 273
'
'Label224
'
Me.Label224.AutoSize = true
Me.Label224.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label224.Location = New System.Drawing.Point(45, 136)
Me.Label224.Name = "Label224"
Me.Label224.Size = New System.Drawing.Size(55, 13)
Me.Label224.TabIndex = 258
Me.Label224.Text = "Remarks :"
'
'Label225
'
Me.Label225.AutoSize = true
Me.Label225.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
Me.Label225.Location = New System.Drawing.Point(44, 96)
Me.Label225.Name = "Label225"
Me.Label225.Size = New System.Drawing.Size(187, 13)
Me.Label225.TabIndex = 257
Me.Label225.Text = "Other concerning requirement of ship :"
'
'GroupBox23
'
Me.GroupBox23.Controls.Add(Me.txtDangerousInboundCargoCLASSDD1)
Me.GroupBox23.Controls.Add(Me.txtDangerousInboundCargoTONSDD1)
Me.GroupBox23.Controls.Add(Me.txtDangerousInboundCargoCNTRDD1)
Me.GroupBox23.Controls.Add(Me.Label226)
Me.GroupBox23.Controls.Add(Me.Label227)
Me.GroupBox23.Controls.Add(Me.Label228)
Me.GroupBox23.Location = New System.Drawing.Point(501, 87)
Me.GroupBox23.Name = "GroupBox23"
Me.GroupBox23.Size = New System.Drawing.Size(199, 66)
Me.GroupBox23.TabIndex = 256
Me.GroupBox23.TabStop = false
Me.GroupBox23.Text = "Dangerous Inbound Cargo"
'
'txtDangerousInboundCargoCLASSDD1
'
Me.txtDangerousInboundCargoCLASSDD1.Location = New System.Drawing.Point(137, 40)
Me.txtDangerousInboundCargoCLASSDD1.Name = "txtDangerousInboundCargoCLASSDD1"
Me.txtDangerousInboundCargoCLASSDD1.Size = New System.Drawing.Size(50, 20)
Me.txtDangerousInboundCargoCLASSDD1.TabIndex = 191
'
'txtDangerousInboundCargoTONSDD1
'
Me.txtDangerousInboundCargoTONSDD1.Location = New System.Drawing.Point(79, 40)
Me.txtDangerousInboundCargoTONSDD1.Name = "txtDangerousInboundCargoTONSDD1"
Me.txtDangerousInboundCargoTONSDD1.Size = New System.Drawing.Size(50, 20)
Me.txtDangerousInboundCargoTONSDD1.TabIndex = 191
'
'txtDangerousInboundCargoCNTRDD1
'
Me.txtDangerousInboundCargoCNTRDD1.Location = New System.Drawing.Point(16, 40)
Me.txtDangerousInboundCargoCNTRDD1.Name = "txtDangerousInboundCargoCNTRDD1"
Me.txtDangerousInboundCargoCNTRDD1.Size = New System.Drawing.Size(50, 20)
Me.txtDangerousInboundCargoCNTRDD1.TabIndex = 191
'
'Label226
'
Me.Label226.AutoSize = true
Me.Label226.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label226.Location = New System.Drawing.Point(134, 19)
Me.Label226.Name = "Label226"
Me.Label226.Size = New System.Drawing.Size(32, 13)
Me.Label226.TabIndex = 147
Me.Label226.Text = "Class"
'
'Label227
'
Me.Label227.AutoSize = true
Me.Label227.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label227.Location = New System.Drawing.Point(86, 19)
Me.Label227.Name = "Label227"
Me.Label227.Size = New System.Drawing.Size(37, 13)
Me.Label227.TabIndex = 147
Me.Label227.Text = "TONS"
'
'Label228
'
Me.Label228.AutoSize = true
Me.Label228.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label228.Location = New System.Drawing.Point(30, 19)
Me.Label228.Name = "Label228"
Me.Label228.Size = New System.Drawing.Size(37, 13)
Me.Label228.TabIndex = 147
Me.Label228.Text = "CTNR"
'
'GroupBox24
'
Me.GroupBox24.Controls.Add(Me.txtFTONDD1)
Me.GroupBox24.Controls.Add(Me.txtFTEUDD1)
Me.GroupBox24.Controls.Add(Me.txtFCNTRDD1)
Me.GroupBox24.Controls.Add(Me.Label229)
Me.GroupBox24.Controls.Add(Me.Label230)
Me.GroupBox24.Controls.Add(Me.Label231)
Me.GroupBox24.Location = New System.Drawing.Point(501, 8)
Me.GroupBox24.Name = "GroupBox24"
Me.GroupBox24.Size = New System.Drawing.Size(199, 66)
Me.GroupBox24.TabIndex = 255
Me.GroupBox24.TabStop = false
'
'txtFTONDD1
'
Me.txtFTONDD1.Location = New System.Drawing.Point(129, 37)
Me.txtFTONDD1.Name = "txtFTONDD1"
Me.txtFTONDD1.Size = New System.Drawing.Size(50, 20)
Me.txtFTONDD1.TabIndex = 191
'
'txtFTEUDD1
'
Me.txtFTEUDD1.Location = New System.Drawing.Point(73, 37)
Me.txtFTEUDD1.Name = "txtFTEUDD1"
Me.txtFTEUDD1.Size = New System.Drawing.Size(50, 20)
Me.txtFTEUDD1.TabIndex = 191
'
'txtFCNTRDD1
'
Me.txtFCNTRDD1.Location = New System.Drawing.Point(17, 37)
Me.txtFCNTRDD1.Name = "txtFCNTRDD1"
Me.txtFCNTRDD1.Size = New System.Drawing.Size(50, 20)
Me.txtFCNTRDD1.TabIndex = 191
'
'Label229
'
Me.Label229.AutoSize = true
Me.Label229.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label229.Location = New System.Drawing.Point(132, 19)
Me.Label229.Name = "Label229"
Me.Label229.Size = New System.Drawing.Size(37, 13)
Me.Label229.TabIndex = 147
Me.Label229.Text = "TONS"
'
'Label230
'
Me.Label230.AutoSize = true
Me.Label230.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label230.Location = New System.Drawing.Point(86, 19)
Me.Label230.Name = "Label230"
Me.Label230.Size = New System.Drawing.Size(29, 13)
Me.Label230.TabIndex = 147
Me.Label230.Text = "TEU"
'
'Label231
'
Me.Label231.AutoSize = true
Me.Label231.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label231.Location = New System.Drawing.Point(30, 19)
Me.Label231.Name = "Label231"
Me.Label231.Size = New System.Drawing.Size(37, 13)
Me.Label231.TabIndex = 147
Me.Label231.Text = "CTNR"
'
'Label232
'
Me.Label232.AutoSize = true
Me.Label232.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label232.Location = New System.Drawing.Point(405, 52)
Me.Label232.Name = "Label232"
Me.Label232.Size = New System.Drawing.Size(33, 13)
Me.Label232.TabIndex = 242
Me.Label232.Text = "40TK"
'
'Label233
'
Me.Label233.AutoSize = true
Me.Label233.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label233.Location = New System.Drawing.Point(448, 8)
Me.Label233.Name = "Label233"
Me.Label233.Size = New System.Drawing.Size(35, 13)
Me.Label233.TabIndex = 241
Me.Label233.Text = "45RH"
'
'Label234
'
Me.Label234.AutoSize = true
Me.Label234.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label234.Location = New System.Drawing.Point(405, 8)
Me.Label234.Name = "Label234"
Me.Label234.Size = New System.Drawing.Size(35, 13)
Me.Label234.TabIndex = 244
Me.Label234.Text = "40RH"
'
'Label235
'
Me.Label235.AutoSize = true
Me.Label235.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label235.Location = New System.Drawing.Point(224, 52)
Me.Label235.Name = "Label235"
Me.Label235.Size = New System.Drawing.Size(35, 13)
Me.Label235.TabIndex = 243
Me.Label235.Text = "40GH"
'
'Label236
'
Me.Label236.AutoSize = true
Me.Label236.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label236.Location = New System.Drawing.Point(223, 8)
Me.Label236.Name = "Label236"
Me.Label236.Size = New System.Drawing.Size(34, 13)
Me.Label236.TabIndex = 240
Me.Label236.Text = "45HC"
'
'Label237
'
Me.Label237.AutoSize = true
Me.Label237.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label237.Location = New System.Drawing.Point(318, 52)
Me.Label237.Name = "Label237"
Me.Label237.Size = New System.Drawing.Size(34, 13)
Me.Label237.TabIndex = 237
Me.Label237.Text = "40OT"
'
'Label238
'
Me.Label238.AutoSize = true
Me.Label238.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label238.Location = New System.Drawing.Point(181, 52)
Me.Label238.Name = "Label238"
Me.Label238.Size = New System.Drawing.Size(35, 13)
Me.Label238.TabIndex = 236
Me.Label238.Text = "40HG"
'
'Label239
'
Me.Label239.AutoSize = true
Me.Label239.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label239.Location = New System.Drawing.Point(318, 8)
Me.Label239.Name = "Label239"
Me.Label239.Size = New System.Drawing.Size(33, 13)
Me.Label239.TabIndex = 239
Me.Label239.Text = "40RF"
'
'Label240
'
Me.Label240.AutoSize = true
Me.Label240.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label240.Location = New System.Drawing.Point(362, 52)
Me.Label240.Name = "Label240"
Me.Label240.Size = New System.Drawing.Size(33, 13)
Me.Label240.TabIndex = 238
Me.Label240.Text = "20TK"
'
'Label241
'
Me.Label241.AutoSize = true
Me.Label241.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label241.Location = New System.Drawing.Point(180, 8)
Me.Label241.Name = "Label241"
Me.Label241.Size = New System.Drawing.Size(34, 13)
Me.Label241.TabIndex = 245
Me.Label241.Text = "40HC"
'
'Label242
'
Me.Label242.AutoSize = true
Me.Label242.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label242.Location = New System.Drawing.Point(362, 8)
Me.Label242.Name = "Label242"
Me.Label242.Size = New System.Drawing.Size(35, 13)
Me.Label242.TabIndex = 252
Me.Label242.Text = "20RH"
'
'Label243
'
Me.Label243.AutoSize = true
Me.Label243.ForeColor = System.Drawing.Color.Maroon
Me.Label243.Location = New System.Drawing.Point(89, 52)
Me.Label243.Name = "Label243"
Me.Label243.Size = New System.Drawing.Size(33, 13)
Me.Label243.TabIndex = 251
Me.Label243.Text = "40FR"
'
'Label244
'
Me.Label244.AutoSize = true
Me.Label244.ForeColor = System.Drawing.Color.Gold
Me.Label244.Location = New System.Drawing.Point(89, 8)
Me.Label244.Name = "Label244"
Me.Label244.Size = New System.Drawing.Size(34, 13)
Me.Label244.TabIndex = 254
Me.Label244.Text = "40GP"
'
'Label245
'
Me.Label245.AutoSize = true
Me.Label245.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label245.Location = New System.Drawing.Point(275, 52)
Me.Label245.Name = "Label245"
Me.Label245.Size = New System.Drawing.Size(34, 13)
Me.Label245.TabIndex = 253
Me.Label245.Text = "20OT"
'
'Label246
'
Me.Label246.AutoSize = true
Me.Label246.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label246.Location = New System.Drawing.Point(138, 52)
Me.Label246.Name = "Label246"
Me.Label246.Size = New System.Drawing.Size(35, 13)
Me.Label246.TabIndex = 250
Me.Label246.Text = "20HG"
'
'Label247
'
Me.Label247.AutoSize = true
Me.Label247.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label247.Location = New System.Drawing.Point(275, 8)
Me.Label247.Name = "Label247"
Me.Label247.Size = New System.Drawing.Size(33, 13)
Me.Label247.TabIndex = 247
Me.Label247.Text = "20RF"
'
'Label248
'
Me.Label248.AutoSize = true
Me.Label248.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
Me.Label248.Location = New System.Drawing.Point(137, 8)
Me.Label248.Name = "Label248"
Me.Label248.Size = New System.Drawing.Size(34, 13)
Me.Label248.TabIndex = 246
Me.Label248.Text = "20HC"
'
'Label249
'
Me.Label249.AutoSize = true
Me.Label249.ForeColor = System.Drawing.Color.Maroon
Me.Label249.Location = New System.Drawing.Point(46, 52)
Me.Label249.Name = "Label249"
Me.Label249.Size = New System.Drawing.Size(33, 13)
Me.Label249.TabIndex = 248
Me.Label249.Text = "20FR"
'
'Label250
'
Me.Label250.AutoSize = true
Me.Label250.ForeColor = System.Drawing.Color.Gold
Me.Label250.Location = New System.Drawing.Point(46, 8)
Me.Label250.Name = "Label250"
Me.Label250.Size = New System.Drawing.Size(34, 13)
Me.Label250.TabIndex = 249
Me.Label250.Text = "20GP"
'
'cxtPort
'
Me.cxtPort.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxtsmnuPort})
Me.cxtPort.Name = "ctmnuPrice"
Me.cxtPort.Size = New System.Drawing.Size(119, 26)
'
'cxtsmnuPort
'
Me.cxtsmnuPort.Name = "cxtsmnuPort"
Me.cxtsmnuPort.Size = New System.Drawing.Size(118, 22)
Me.cxtsmnuPort.Text = "Search"
'
'ctmnuPrice
'
Me.ctmnuPrice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctmnuAdd, Me.ctmnuEdit, Me.ctmnuDel})
Me.ctmnuPrice.Name = "ctmnuPrice"
Me.ctmnuPrice.Size = New System.Drawing.Size(117, 70)
'
'ctmnuAdd
'
Me.ctmnuAdd.Image = CType(resources.GetObject("ctmnuAdd.Image"),System.Drawing.Image)
Me.ctmnuAdd.Name = "ctmnuAdd"
Me.ctmnuAdd.Size = New System.Drawing.Size(116, 22)
Me.ctmnuAdd.Text = "Add"
'
'ctmnuEdit
'
Me.ctmnuEdit.Image = CType(resources.GetObject("ctmnuEdit.Image"),System.Drawing.Image)
Me.ctmnuEdit.Name = "ctmnuEdit"
Me.ctmnuEdit.Size = New System.Drawing.Size(116, 22)
Me.ctmnuEdit.Text = "Edit"
'
'ctmnuDel
'
Me.ctmnuDel.Image = CType(resources.GetObject("ctmnuDel.Image"),System.Drawing.Image)
Me.ctmnuDel.Name = "ctmnuDel"
Me.ctmnuDel.Size = New System.Drawing.Size(116, 22)
Me.ctmnuDel.Text = "Delete"
'
'cxtPortTranship
'
Me.cxtPortTranship.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxtsmnuPortTranship})
Me.cxtPortTranship.Name = "ctmnuPrice"
Me.cxtPortTranship.Size = New System.Drawing.Size(119, 26)
'
'cxtsmnuPortTranship
'
Me.cxtsmnuPortTranship.Name = "cxtsmnuPortTranship"
Me.cxtsmnuPortTranship.Size = New System.Drawing.Size(118, 22)
Me.cxtsmnuPortTranship.Text = "Search"
'
'cmdCancel
'
Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ActiveCaption
Me.cmdCancel.Location = New System.Drawing.Point(597, 476)
Me.cmdCancel.Name = "cmdCancel"
Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
Me.cmdCancel.TabIndex = 19
Me.cmdCancel.Text = "&Cancel"
Me.cmdCancel.UseVisualStyleBackColor = true
'
'cmdOk
'
Me.cmdOk.ForeColor = System.Drawing.SystemColors.ActiveCaption
Me.cmdOk.Location = New System.Drawing.Point(691, 476)
Me.cmdOk.Name = "cmdOk"
Me.cmdOk.Size = New System.Drawing.Size(75, 23)
Me.cmdOk.TabIndex = 20
Me.cmdOk.Text = "&Ok"
Me.cmdOk.UseVisualStyleBackColor = true
'
'frmBoardingAgent
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(804, 502)
Me.Controls.Add(Me.cmdFind)
Me.Controls.Add(Me.cmdOk)
Me.Controls.Add(Me.FindBoardingAgent)
Me.Controls.Add(Me.dgdBoardingAgent)
Me.Controls.Add(Me.cboFind)
Me.Controls.Add(Me.cmdCancel)
Me.Controls.Add(Me.fraUpdate)
Me.Controls.Add(Me.MenuStrip)
Me.Name = "frmBoardingAgent"
Me.Text = "Boarding Agent"
Me.MenuStrip.ResumeLayout(false)
Me.MenuStrip.PerformLayout
CType(Me.dgdBoardingAgent,System.ComponentModel.ISupportInitialize).EndInit
Me.fraUpdate.ResumeLayout(false)
Me.TabPage5.ResumeLayout(false)
Me.TabPage5.PerformLayout
Me.tbcSailingSchedule.ResumeLayout(false)
Me.TabControl1.ResumeLayout(false)
Me.lbl.ResumeLayout(false)
Me.lbl.PerformLayout
Me.GroupBox25.ResumeLayout(false)
Me.GroupBox25.PerformLayout
Me.GroupBox4.ResumeLayout(false)
Me.GroupBox4.PerformLayout
Me.GroupBox3.ResumeLayout(false)
Me.GroupBox3.PerformLayout
Me.GroupBox2.ResumeLayout(false)
Me.GroupBox2.PerformLayout
Me.GroupBox1.ResumeLayout(false)
Me.GroupBox1.PerformLayout
Me.TabPage1.ResumeLayout(false)
Me.TabPage1.PerformLayout
Me.GroupBox6.ResumeLayout(false)
Me.GroupBox6.PerformLayout
Me.GroupBox5.ResumeLayout(false)
Me.GroupBox5.PerformLayout
Me.TabPage2.ResumeLayout(false)
Me.TabControl3.ResumeLayout(false)
Me.TabPage6.ResumeLayout(false)
Me.TabPage6.PerformLayout
Me.GroupBox7.ResumeLayout(false)
Me.GroupBox7.PerformLayout
Me.TabPage7.ResumeLayout(false)
Me.TabPage7.PerformLayout
Me.GroupBox9.ResumeLayout(false)
Me.GroupBox9.PerformLayout
Me.GroupBox8.ResumeLayout(false)
Me.GroupBox8.PerformLayout
Me.TabPage11.ResumeLayout(false)
Me.TabControl5.ResumeLayout(false)
Me.TabPage12.ResumeLayout(false)
Me.TabPage12.PerformLayout
Me.GroupBox19.ResumeLayout(false)
Me.GroupBox19.PerformLayout
Me.TabPage13.ResumeLayout(false)
Me.TabPage13.PerformLayout
Me.GroupBox20.ResumeLayout(false)
Me.GroupBox20.PerformLayout
Me.GroupBox21.ResumeLayout(false)
Me.GroupBox21.PerformLayout
Me.ETASailingSchedule.ResumeLayout(false)
Me.TabControl2.ResumeLayout(false)
Me.TabPage3.ResumeLayout(false)
Me.TabPage3.PerformLayout
Me.GroupBox10.ResumeLayout(false)
Me.GroupBox10.PerformLayout
Me.GroupBox11.ResumeLayout(false)
Me.GroupBox11.PerformLayout
Me.GroupBox12.ResumeLayout(false)
Me.GroupBox12.PerformLayout
Me.GroupBox13.ResumeLayout(false)
Me.GroupBox13.PerformLayout
Me.TabPage4.ResumeLayout(false)
Me.TabPage4.PerformLayout
Me.GroupBox14.ResumeLayout(false)
Me.GroupBox14.PerformLayout
Me.GroupBox15.ResumeLayout(false)
Me.GroupBox15.PerformLayout
Me.TabPage8.ResumeLayout(false)
Me.TabControl4.ResumeLayout(false)
Me.TabPage9.ResumeLayout(false)
Me.TabPage9.PerformLayout
Me.GroupBox16.ResumeLayout(false)
Me.GroupBox16.PerformLayout
Me.TabPage10.ResumeLayout(false)
Me.TabPage10.PerformLayout
Me.GroupBox17.ResumeLayout(false)
Me.GroupBox17.PerformLayout
Me.GroupBox18.ResumeLayout(false)
Me.GroupBox18.PerformLayout
Me.TabPage14.ResumeLayout(false)
Me.TabControl6.ResumeLayout(false)
Me.TabPage15.ResumeLayout(false)
Me.TabPage15.PerformLayout
Me.GroupBox22.ResumeLayout(false)
Me.GroupBox22.PerformLayout
Me.TabPage16.ResumeLayout(false)
Me.TabPage16.PerformLayout
Me.GroupBox23.ResumeLayout(false)
Me.GroupBox23.PerformLayout
Me.GroupBox24.ResumeLayout(false)
Me.GroupBox24.PerformLayout
Me.cxtPort.ResumeLayout(false)
Me.ctmnuPrice.ResumeLayout(false)
Me.cxtPortTranship.ResumeLayout(false)
Me.ResumeLayout(false)
Me.PerformLayout

End Sub
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents FindBoardingAgent As System.Windows.Forms.TextBox
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgdBoardingAgent As System.Windows.Forms.DataGridView
    Friend WithEvents fraUpdate As System.Windows.Forms.TabControl
    Friend WithEvents tbcSailingSchedule As System.Windows.Forms.TabPage
    Friend WithEvents ETASailingSchedule As System.Windows.Forms.TabPage
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents ctmnuPrice As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctmnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctmnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctmnuDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxtPortTranship As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cxtsmnuPortTranship As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxtPort As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cxtsmnuPort As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents lbl As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label144 As System.Windows.Forms.Label
    Friend WithEvents lbldescriptionShipper As System.Windows.Forms.Label
    Friend WithEvents txtServiceTerm As System.Windows.Forms.TextBox
    Friend WithEvents txtOperatorName As System.Windows.Forms.TextBox
    Friend WithEvents txtVoyageArrival As System.Windows.Forms.TextBox
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents lblShipper As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOwnerName As System.Windows.Forms.TextBox
    Friend WithEvents txtAgentName As System.Windows.Forms.TextBox
    Friend WithEvents txtVoyageDeparture As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtdateofarrivalPilotStationAD As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeOfArrivalPilotStationAD As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNumOfCrewAD As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPurposetoportAD As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFOAD As System.Windows.Forms.TextBox
    Friend WithEvents txtFWAD As System.Windows.Forms.TextBox
    Friend WithEvents lblFWAD As System.Windows.Forms.Label
    Friend WithEvents txtDOAD As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtKindofCargoAD As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDateOfArrivalPilotOnboardAD As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtDateOfBerthAD As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeOfBerthAD As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtLastDateOfArrivalAD As System.Windows.Forms.TextBox
    Friend WithEvents txtActualDisplacementAD As System.Windows.Forms.TextBox
    Friend WithEvents txtAfterDraftAD As System.Windows.Forms.TextBox
    Friend WithEvents txtForeDraftAD As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TabControl3 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtE20FRAD As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents txtOtherConcerningRequirementOfShipAD As System.Windows.Forms.TextBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label152 As System.Windows.Forms.Label
    Friend WithEvents Label151 As System.Windows.Forms.Label
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl4 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents Label124 As System.Windows.Forms.Label
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents Label125 As System.Windows.Forms.Label
    Friend WithEvents Label126 As System.Windows.Forms.Label
    Friend WithEvents Label127 As System.Windows.Forms.Label
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents Label134 As System.Windows.Forms.Label
    Friend WithEvents Label135 As System.Windows.Forms.Label
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents Label140 As System.Windows.Forms.Label
    Friend WithEvents Label141 As System.Windows.Forms.Label
    Friend WithEvents Label142 As System.Windows.Forms.Label
    Friend WithEvents Label143 As System.Windows.Forms.Label
    Friend WithEvents Label145 As System.Windows.Forms.Label
    Friend WithEvents Label146 As System.Windows.Forms.Label
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents Label148 As System.Windows.Forms.Label
    Friend WithEvents Label149 As System.Windows.Forms.Label
    Friend WithEvents Label150 As System.Windows.Forms.Label
    Friend WithEvents TabPage11 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl5 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage12 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents Label153 As System.Windows.Forms.Label
    Friend WithEvents Label154 As System.Windows.Forms.Label
    Friend WithEvents Label155 As System.Windows.Forms.Label
    Friend WithEvents Label156 As System.Windows.Forms.Label
    Friend WithEvents Label157 As System.Windows.Forms.Label
    Friend WithEvents Label158 As System.Windows.Forms.Label
    Friend WithEvents Label159 As System.Windows.Forms.Label
    Friend WithEvents Label160 As System.Windows.Forms.Label
    Friend WithEvents Label161 As System.Windows.Forms.Label
    Friend WithEvents Label162 As System.Windows.Forms.Label
    Friend WithEvents Label163 As System.Windows.Forms.Label
    Friend WithEvents Label164 As System.Windows.Forms.Label
    Friend WithEvents Label165 As System.Windows.Forms.Label
    Friend WithEvents Label166 As System.Windows.Forms.Label
    Friend WithEvents Label167 As System.Windows.Forms.Label
    Friend WithEvents Label168 As System.Windows.Forms.Label
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents Label170 As System.Windows.Forms.Label
    Friend WithEvents Label171 As System.Windows.Forms.Label
    Friend WithEvents Label172 As System.Windows.Forms.Label
    Friend WithEvents Label173 As System.Windows.Forms.Label
    Friend WithEvents Label174 As System.Windows.Forms.Label
    Friend WithEvents TabPage13 As System.Windows.Forms.TabPage
    Friend WithEvents Label175 As System.Windows.Forms.Label
    Friend WithEvents Label176 As System.Windows.Forms.Label
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents Label177 As System.Windows.Forms.Label
    Friend WithEvents Label178 As System.Windows.Forms.Label
    Friend WithEvents Label179 As System.Windows.Forms.Label
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents Label180 As System.Windows.Forms.Label
    Friend WithEvents Label181 As System.Windows.Forms.Label
    Friend WithEvents Label182 As System.Windows.Forms.Label
    Friend WithEvents Label183 As System.Windows.Forms.Label
    Friend WithEvents Label184 As System.Windows.Forms.Label
    Friend WithEvents Label185 As System.Windows.Forms.Label
    Friend WithEvents Label186 As System.Windows.Forms.Label
    Friend WithEvents Label187 As System.Windows.Forms.Label
    Friend WithEvents Label188 As System.Windows.Forms.Label
    Friend WithEvents Label189 As System.Windows.Forms.Label
    Friend WithEvents Label190 As System.Windows.Forms.Label
    Friend WithEvents Label191 As System.Windows.Forms.Label
    Friend WithEvents Label192 As System.Windows.Forms.Label
    Friend WithEvents Label193 As System.Windows.Forms.Label
    Friend WithEvents Label194 As System.Windows.Forms.Label
    Friend WithEvents Label195 As System.Windows.Forms.Label
    Friend WithEvents Label196 As System.Windows.Forms.Label
    Friend WithEvents Label197 As System.Windows.Forms.Label
    Friend WithEvents Label198 As System.Windows.Forms.Label
    Friend WithEvents Label199 As System.Windows.Forms.Label
    Friend WithEvents Label200 As System.Windows.Forms.Label
    Friend WithEvents Label201 As System.Windows.Forms.Label
    Friend WithEvents TabPage14 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl6 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage15 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox22 As System.Windows.Forms.GroupBox
    Friend WithEvents Label202 As System.Windows.Forms.Label
    Friend WithEvents Label203 As System.Windows.Forms.Label
    Friend WithEvents Label204 As System.Windows.Forms.Label
    Friend WithEvents Label205 As System.Windows.Forms.Label
    Friend WithEvents Label206 As System.Windows.Forms.Label
    Friend WithEvents Label207 As System.Windows.Forms.Label
    Friend WithEvents Label208 As System.Windows.Forms.Label
    Friend WithEvents Label209 As System.Windows.Forms.Label
    Friend WithEvents Label210 As System.Windows.Forms.Label
    Friend WithEvents Label211 As System.Windows.Forms.Label
    Friend WithEvents Label212 As System.Windows.Forms.Label
    Friend WithEvents Label213 As System.Windows.Forms.Label
    Friend WithEvents Label214 As System.Windows.Forms.Label
    Friend WithEvents Label215 As System.Windows.Forms.Label
    Friend WithEvents Label216 As System.Windows.Forms.Label
    Friend WithEvents Label217 As System.Windows.Forms.Label
    Friend WithEvents Label218 As System.Windows.Forms.Label
    Friend WithEvents Label219 As System.Windows.Forms.Label
    Friend WithEvents Label220 As System.Windows.Forms.Label
    Friend WithEvents Label221 As System.Windows.Forms.Label
    Friend WithEvents Label222 As System.Windows.Forms.Label
    Friend WithEvents Label223 As System.Windows.Forms.Label
    Friend WithEvents TabPage16 As System.Windows.Forms.TabPage
    Friend WithEvents txtE40GPAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20GPAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE45RHAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40RHAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20RHAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40RFAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20RFAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE45HCAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20HCAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20HGAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40FRAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40TKAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20TKAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40OTAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20OTAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40HGAD As System.Windows.Forms.TextBox
    Friend WithEvents TXTETONSAD As System.Windows.Forms.TextBox
    Friend WithEvents TXTETEUAD As System.Windows.Forms.TextBox
    Friend WithEvents TXTECNTRAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20GPAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40HGAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20HGAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40FRAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20FRAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF45RHAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40RHAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20RHAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40RFAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20RFAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF45HCAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40HCAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20HCAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40GPAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40GHAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40TKAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20TKAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40OTAD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20OTAD As System.Windows.Forms.TextBox
    Friend WithEvents txtDangerousInboundCargoCLASSAD As System.Windows.Forms.TextBox
    Friend WithEvents txtDangerousInboundCargoCNTRAD As System.Windows.Forms.TextBox
    Friend WithEvents txtFTONAD As System.Windows.Forms.TextBox
    Friend WithEvents txtFTEUAD As System.Windows.Forms.TextBox
    Friend WithEvents txtFCNTRAD As System.Windows.Forms.TextBox
    Friend WithEvents txtRemaksAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40TKAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20TKAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40OTAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20OTAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40GHAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40HGAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20HGAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40FRAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20FRAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE45RHAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40RHAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20RHAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40RFAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20RFAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE45HCAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40HCAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20HCAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40GPAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20GPAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtETEUAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtECNTRAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtETONAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40OTAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20OTAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40GHAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40HGAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20HGAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40FRAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20FRAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF45RHAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40RHAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20RHAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40RFAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20RFAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF45HCAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40HCAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20HCAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40GPAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20GPAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRemaksAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtOtherConcerningRequirementOfShipAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40TKAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20TKAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDangerousInboundCargoCLASSAD1 As System.Windows.Forms.TextBox
    Friend WithEvents DangerousInboundCargoTEUAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDangerousInboundCargoCNTRAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFTONAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFTEUAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFCNTRAD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtKindOfCargoDD As System.Windows.Forms.TextBox
    Friend WithEvents txtPurposeToPortDD As System.Windows.Forms.TextBox
    Friend WithEvents txtPositionOfShipInPortDD As System.Windows.Forms.TextBox
    Friend WithEvents txtNumOfPassengersDD As System.Windows.Forms.TextBox
    Friend WithEvents txtNumOfCrewDD As System.Windows.Forms.TextBox
    Friend WithEvents txtCaptionNameDD As System.Windows.Forms.TextBox
    Friend WithEvents txtFWDD As System.Windows.Forms.TextBox
    Friend WithEvents txtDODD As System.Windows.Forms.TextBox
    Friend WithEvents txtFODD As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeOfBerthDD As System.Windows.Forms.TextBox
    Friend WithEvents txtDateOfBerthDD As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeOfArrivalPilotOnboardDD As System.Windows.Forms.TextBox
    Friend WithEvents txtDateOfArrivalPilotOnboardDD As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeOfArrivalPilotStationDD As System.Windows.Forms.TextBox
    Friend WithEvents txtDateOfArrivalPilotStationDD As System.Windows.Forms.TextBox
    Friend WithEvents txtActualDisplacementDD As System.Windows.Forms.TextBox
    Friend WithEvents txtAfterDraftDD As System.Windows.Forms.TextBox
    Friend WithEvents txtforeDraftDD As System.Windows.Forms.TextBox
    Friend WithEvents txtLastDateOfArrivalDD As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeCommencingOperationDD As System.Windows.Forms.TextBox
    Friend WithEvents txtDateCommencingOperationDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40TKDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40OTDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20OTDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40GHDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40HGDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20HGDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40FRDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20FRDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE45RHDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40RHDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20RHDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40RFDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20RFDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE45HCDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40HCDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20HCDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40GPDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20GPDD As System.Windows.Forms.TextBox
    Friend WithEvents txtETONDD As System.Windows.Forms.TextBox
    Friend WithEvents txtETEUDD As System.Windows.Forms.TextBox
    Friend WithEvents txtECNTRDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40TKDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20TKDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40OTDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20OTDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40GHDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40HGDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20HGDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40FRDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20FRDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF45RHDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40RHDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20RHDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40RFDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20RFDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF45HCDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40HCDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20HCDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF40GPDD As System.Windows.Forms.TextBox
    Friend WithEvents txtF20GPDD As System.Windows.Forms.TextBox
    Friend WithEvents txtDangerousInboundCargoCLASSDD As System.Windows.Forms.TextBox
    Friend WithEvents txtDangerousInboundCargoTONSDD As System.Windows.Forms.TextBox
    Friend WithEvents txtDangerousInboundCargoCNTRDD As System.Windows.Forms.TextBox
    Friend WithEvents txtFTONDD As System.Windows.Forms.TextBox
    Friend WithEvents txtFTEUDD As System.Windows.Forms.TextBox
    Friend WithEvents txtFCNTRDD As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarksDD As System.Windows.Forms.TextBox
    Friend WithEvents txtOtherConcerningRequirementOfShipDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40FRDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE45RHDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40RHDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20RHDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40RFDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20RFDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE45HCDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40HCDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20HCDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40GPDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20GPDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40TKDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20TKDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40OTDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20OTDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40GHDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE40HGDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtE20HGDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtETONDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtETEUDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtECNTRDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarksDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtOtherConcerningRequirementOfShipDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40TKDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20TKDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40OTDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20OTDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40GHDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40HGDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20HGDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40FRDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20FRDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF45RHDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40RHDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20RHDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40RFDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20RFDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF45HCDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40HCDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20HCDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF40GPDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtF20GPDD1 As System.Windows.Forms.TextBox
    Friend WithEvents Label224 As System.Windows.Forms.Label
    Friend WithEvents Label225 As System.Windows.Forms.Label
    Friend WithEvents GroupBox23 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDangerousInboundCargoCLASSDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDangerousInboundCargoTONSDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDangerousInboundCargoCNTRDD1 As System.Windows.Forms.TextBox
    Friend WithEvents Label226 As System.Windows.Forms.Label
    Friend WithEvents Label227 As System.Windows.Forms.Label
    Friend WithEvents Label228 As System.Windows.Forms.Label
    Friend WithEvents GroupBox24 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFTONDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFTEUDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFCNTRDD1 As System.Windows.Forms.TextBox
    Friend WithEvents Label229 As System.Windows.Forms.Label
    Friend WithEvents Label230 As System.Windows.Forms.Label
    Friend WithEvents Label231 As System.Windows.Forms.Label
    Friend WithEvents Label232 As System.Windows.Forms.Label
    Friend WithEvents Label233 As System.Windows.Forms.Label
    Friend WithEvents Label234 As System.Windows.Forms.Label
    Friend WithEvents Label235 As System.Windows.Forms.Label
    Friend WithEvents Label236 As System.Windows.Forms.Label
    Friend WithEvents Label237 As System.Windows.Forms.Label
    Friend WithEvents Label238 As System.Windows.Forms.Label
    Friend WithEvents Label239 As System.Windows.Forms.Label
    Friend WithEvents Label240 As System.Windows.Forms.Label
    Friend WithEvents Label241 As System.Windows.Forms.Label
    Friend WithEvents Label242 As System.Windows.Forms.Label
    Friend WithEvents Label243 As System.Windows.Forms.Label
    Friend WithEvents Label244 As System.Windows.Forms.Label
    Friend WithEvents Label245 As System.Windows.Forms.Label
    Friend WithEvents Label246 As System.Windows.Forms.Label
    Friend WithEvents Label247 As System.Windows.Forms.Label
    Friend WithEvents Label248 As System.Windows.Forms.Label
    Friend WithEvents Label249 As System.Windows.Forms.Label
    Friend WithEvents Label250 As System.Windows.Forms.Label
    Friend WithEvents txtNumOfPassengersAD As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeOfArrivalPilotOnboardAD As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeCommencingOperationAD As System.Windows.Forms.TextBox
    Friend WithEvents txtDateCommencingOperationAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40HCAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE40GHAD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20TKDD As System.Windows.Forms.TextBox
    Friend WithEvents txtE20FRDD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTheApprovalPort As System.Windows.Forms.TextBox
    Friend WithEvents txtApplicationForArrivalDate As System.Windows.Forms.TextBox
    Friend WithEvents txtDangerousInboundCargoTONSAD As System.Windows.Forms.TextBox
    Friend WithEvents txtPositionOfShipInPortAD As System.Windows.Forms.TextBox
    Friend WithEvents Label251 As System.Windows.Forms.Label
    Friend WithEvents txtshipCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCaptionNameAD As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox25 As System.Windows.Forms.GroupBox
    Friend WithEvents Label252 As System.Windows.Forms.Label
    Friend WithEvents Label253 As System.Windows.Forms.Label
    Friend WithEvents txtTimeOfArrivalAD As System.Windows.Forms.TextBox
    Friend WithEvents txtDateOfArrivalAD As System.Windows.Forms.TextBox
    Friend WithEvents cboNextPortAD As System.Windows.Forms.TextBox
    Friend WithEvents cboDis_LoadPortAD As System.Windows.Forms.TextBox
    Friend WithEvents cboPreviousPortAD As System.Windows.Forms.TextBox
    Friend WithEvents cboNextPortDD As System.Windows.Forms.TextBox
    Friend WithEvents cboDis_LoadPortDD As System.Windows.Forms.TextBox
    Friend WithEvents cboPreviousPortDD As System.Windows.Forms.TextBox
    Friend WithEvents ExportExcelFromToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkApproveETA As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDateOfArrivalAD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpdateofarrivalPilotStationAD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateOfBerthAD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateOfArrivalPilotOnboardAD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateCommencingOperationAD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateOfBerthDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateOfArrivalPilotOnboardDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateOfArrivalPilotStationDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateCommencingOperationDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents mnuReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeclarationOfDepartureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForeignVesselApplicaitonForArrivalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PermissionForForeignVesselToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BoardingagentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shipCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyageNoOnArrival As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyageNoOnDeparture As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceTerm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperatorName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgentName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OwnerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateOfArrivalAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeOfArrivalAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaptionNameAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumOfCrewAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumOfPassengersAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PositionOfShipInPortAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurposeToPortAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KindOfCargoAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FWAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateOfArrivalPilotStationAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeOfArrivalPilotStationAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateOfArrivalPilotOnboardAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeOfArrivalPilotOnboardAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateOfBerthAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeOfBerthAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents foreDraftAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AfterDraftAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActualDisplacementAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastDateOfArrivalAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreviousPortAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dis_LoadPortAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NextPortAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCommencingOperationAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeCommencingOperationAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20GPAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40GPAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20HCAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40HCAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E45HCAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20RFAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40RFAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20RHAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40RHAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E45RHAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20FRAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40FRAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20HGAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40HGAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40GHAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20OTAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40OTAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20TKAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40TKAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ECNTRAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETEUAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETONSAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20GPAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40GPAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20HCAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40HCAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F45HCAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20RFAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40RFAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20RHAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40RHAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F45RHAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20FRAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40FRAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20HGAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40HGAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40GHAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20OTAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40OTAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20TKAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40TKAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCNTRAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTEUAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTONSAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoCNTRAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoTONSAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoCLASSAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtherConcerningRequirementOfShipAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemaksAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaptionNameDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumOfCrewDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumOfPassengersDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PositionOfShipInPortDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurposeToPortDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KindOfCargoDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FODD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DODD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FWDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateOfArrivalPilotStationDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeOfArrivalPilotStationDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateOfArrivalPilotOnboardDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeOfArrivalPilotOnboardDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateOfBerthDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeOfBerthDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents foreDraftDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AfterDraftDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActualDisplacementDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastDateOfArrivalDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreviousPortDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dis_LoadPortDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NextPortDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCommencingOperationDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeCommencingOperationDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20GPDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40GPDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20HCDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40HCDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E45HCDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20RFDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40RFDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20RHDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40RHDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E45RHDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20FRDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40FRDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20HGDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40HGDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40GHDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20OTDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40OTDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20TKDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40TKDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ECNTRDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETEUDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETONSDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20GPDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40GPDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20HCDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40HCDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F45HCDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20RFDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40RFDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20RHDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40RHDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F45RHDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20FRDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40FRDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20HGDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40HGDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40GHDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20OTDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40OTDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20TKDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40TKDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCNTRDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTEUDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTONSDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoCNTRDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoTONSDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoCLASSDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtherConcerningRequirementOfShipDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemarksDD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20GPAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40GPAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20HCAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40HCAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E45HCAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20RFAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40RFAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20RHAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40RHAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E45RHAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20FRAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40FRAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20HGAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40HGAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40GHAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20OTAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40OTAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20TKAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40TKAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ECNTRAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETEUAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETONSAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20GPAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40GPAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20HCAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40HCAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F45HCAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20RFAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40RFAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20RHAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40RHAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F45RHAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20FRAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40FRAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20HGAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40HGAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40GHAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20OTAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40OTAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20TKAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40TKAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCNTRAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTEUAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTONSAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoCNTRAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoTONSAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoCLASSAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtherConcerningRequirementOfShipAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemaksAD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20GPDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40GPDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20HCDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40HCDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E45HCDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20RFDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40RFDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20RHDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40RHDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E45RHDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20FRDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40FRDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20HGDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40HGDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40GHDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20OTDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40OTDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E20TKDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E40TKDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ECNTRDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETEUDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETONSDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20GPDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40GPDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20HCDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40HCDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F45HCDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20RFDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40RFDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20RHDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40RHDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F45RHDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20FRDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40FRDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20HGDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40HGDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40GHDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20OTDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40OTDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F20TKDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F40TKDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCNTRDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTEUDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTONSDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoCNTRDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoTONSDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangerousInboundCargoCLASSDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtherConcerningRequirementOfShipDD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApplicationForArrivalDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TheApprovalPort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApproveArrival As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
