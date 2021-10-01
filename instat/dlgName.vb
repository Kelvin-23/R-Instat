﻿' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports instat.Translations
Imports RDotNet

Public Class dlgName
    Dim bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Dim bUseSelectedColumn As Boolean = False
    Dim strSelectedColumn As String = ""
    Dim strSelectedDataFrame As String = ""
    Private clsDefaultRFunction As New RFunction
    Private clsRenameWithFunction As RFunction

    Private Sub dlgName_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        If bUseSelectedColumn Then
            SetSelectedColumn()
        End If
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.iHelpTopicID = 33

        'Selector
        ucrSelectVariables.SetParameter(New RParameter("data_name", 0))
        ucrSelectVariables.SetParameterIsString()

        'Receiver
        ucrReceiverName.SetParameter(New RParameter("column_name", 1))
        ucrReceiverName.SetParameterIsString()
        ucrReceiverName.Selector = ucrSelectVariables

        'New Name Input
        ucrInputNewName.SetParameter(New RParameter("new_val", 2))
        'set validation of ucrInputNewName as an RVariable.(input should not have any R reserved words like 'if','while')
        ucrInputNewName.SetValidationTypeAsRVariable()

        'Label Input
        ucrInputVariableLabel.SetParameter(New RParameter("label", 3))

        ucrPnlOptions.AddRadioButton(rdoSingle)
        ucrPnlOptions.AddRadioButton(rdoMultiple)
        ucrPnlOptions.AddFunctionNamesCondition(rdoSingle, frmMain.clsRLink.strInstatDataObject & "$rename_column_in_data")
        ucrPnlOptions.AddFunctionNamesCondition(rdoMultiple, "rename_with")

        ucrPnlOptions.AddToLinkedControls({ucrReceiverName, ucrInputNewName, ucrInputVariableLabel}, {rdoSingle}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlOptions.AddToLinkedControls({ucrReceiverColumns, ucrSaveDataFrame}, {rdoMultiple}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlOptions.AddToLinkedControls(ucrPnlCase, {rdoMultiple}, bNewLinkedHideIfParameterMissing:=True)
        ucrReceiverName.SetLinkedDisplayControl(lblCurrentName)
        ucrInputNewName.SetLinkedDisplayControl(lblName)
        ucrInputVariableLabel.SetLinkedDisplayControl(lblVariableLabel)
        ucrReceiverColumns.SetLinkedDisplayControl(lblColumns)

        ucrReceiverColumns.SetParameter(New RParameter(".cols", 2))
        ucrReceiverColumns.Selector = ucrSelectVariables
        ucrReceiverColumns.SetParameterIsString()
        ucrReceiverColumns.bWithQuotes = False

        ucrPnlCase.SetParameter(New RParameter(".fn", 1))
        ucrPnlCase.AddRadioButton(rdoToUpper, "toupper")
        ucrPnlCase.AddRadioButton(rdoToLower, "tolower")
        ucrPnlCase.AddRadioButton(rdoToTitle, "stringr::str_to_title")
        ucrPnlCase.AddRadioButton(rdoToSentence, "stringr::str_to_sentence")
        ucrPnlCase.AddParameterValuesCondition(rdoToUpper, ".fn", "toupper")
        ucrPnlCase.AddParameterValuesCondition(rdoToLower, ".fn", "tolower")
        ucrPnlCase.AddParameterValuesCondition(rdoToTitle, ".fn", "stringr::str_to_title")
        ucrPnlCase.AddParameterValuesCondition(rdoToSentence, ".fn", "stringr::str_to_sentence")

        ucrSaveDataFrame.SetLabelText("New Data Frame Name:")
        ucrSaveDataFrame.SetSaveTypeAsDataFrame()
        ucrSaveDataFrame.SetPrefix("new_data_frame")
        ucrSaveDataFrame.SetDataFrameSelector(ucrSelectVariables.ucrAvailableDataFrames)
    End Sub

    Public Sub SetDefaults()
        clsDefaultRFunction = New RFunction
        clsRenameWithFunction = New RFunction

        ucrSelectVariables.Reset()
        ucrSaveDataFrame.Reset()

        clsDefaultRFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$rename_column_in_data")

        clsRenameWithFunction.SetPackageName("dplyr")
        clsRenameWithFunction.SetRCommand("rename_with")
        clsRenameWithFunction.AddParameter(".fn", "toupper", iPosition:=1)
        ucrBase.clsRsyntax.SetBaseRFunction(clsDefaultRFunction)
    End Sub

    Private Sub TestOKEnabled()
        If rdoSingle.Checked Then
            If Not ucrReceiverName.IsEmpty() AndAlso Not ucrInputNewName.IsEmpty() Then
                ucrBase.OKEnabled(True)
            Else
                ucrBase.OKEnabled(False)
            End If
        Else
            If ucrSaveDataFrame.IsComplete Then
                ucrBase.OKEnabled(True)
            Else
                ucrBase.OKEnabled(False)
            End If
        End If
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        ucrSelectVariables.SetRCode(clsDefaultRFunction, bReset)
        ucrReceiverName.SetRCode(clsDefaultRFunction, bReset)
        ucrInputNewName.SetRCode(clsDefaultRFunction, bReset)
        ucrInputVariableLabel.SetRCode(clsDefaultRFunction, bReset)
        ucrPnlOptions.SetRCode(ucrBase.clsRsyntax.clsBaseFunction, bReset)
        ucrReceiverColumns.SetRCode(clsRenameWithFunction, bReset)
        ucrPnlCase.SetRCode(clsRenameWithFunction, bReset)
        ucrSaveDataFrame.SetRCode(clsRenameWithFunction, bReset)
    End Sub

    Public Sub SetCurrentColumn(strColumn As String, strDataFrame As String)
        strSelectedColumn = strColumn
        strSelectedDataFrame = strDataFrame
        bUseSelectedColumn = True
    End Sub

    Private Sub SetSelectedColumn()
        ucrSelectVariables.SetDataframe(strSelectedDataFrame)
        ucrReceiverName.Add(strSelectedColumn, strSelectedDataFrame)
        bUseSelectedColumn = False
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub ucrReceiverName_ControlValueChanged() Handles ucrReceiverName.ControlValueChanged
        'if the receiver is not empty
        If Not ucrReceiverName.IsEmpty Then
            'if the user has not typed anything then change the ucrInputNewName contents
            ucrInputNewName.SetName(ucrReceiverName.GetVariableNames(bWithQuotes:=False))
            'get the label of the column selected(from ucrReceiverName) and set it as ucrInputVariableLabel value
            ucrInputVariableLabel.SetName(GetColLabel())

        Else
            'if the receiver is empty. These 2 controls should be empty
            ucrInputNewName.SetName("")
            ucrInputVariableLabel.SetName("")
        End If

    End Sub

    'Gets the label of the column selected(from ucrReceiverName) 
    Private Function GetColLabel()
        Dim strColLabel As String = ""
        Dim clsColmnLabelsRFunction = New RFunction
        Dim expItems As SymbolicExpression

        clsColmnLabelsRFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_column_labels")
        clsColmnLabelsRFunction.AddParameter("data_name", Chr(34) & ucrSelectVariables.strCurrentDataFrame & Chr(34), iPosition:=0)
        clsColmnLabelsRFunction.AddParameter("columns", ucrReceiverName.GetVariableNames(bWithQuotes:=True), iPosition:=1)

        expItems = frmMain.clsRLink.RunInternalScriptGetValue(clsColmnLabelsRFunction.ToScript(), bSilent:=True)

        If expItems IsNot Nothing AndAlso Not (expItems.Type = Internals.SymbolicExpressionType.Null) Then
            Dim strArr As String() = expItems.AsCharacter.ToArray
            If strArr IsNot Nothing Then
                'the number of labels for a column expected is 1
                If strArr.Length = 1 Then
                    strColLabel = strArr(0)
                ElseIf strArr.Length > 1 Then
                    MessageBox.Show(Me, "Developer error: retrieved column label should be one.", "Developer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    strColLabel = strArr(strArr.Length - 1)
                End If
            End If
        End If
        Return strColLabel
    End Function

    Private Sub ucrPnlOptions_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrPnlOptions.ControlValueChanged
        If rdoSingle.Checked Then
            ucrBase.clsRsyntax.SetBaseRFunction(clsDefaultRFunction)
            ucrReceiverName.SetMeAsReceiver()
        Else
            ucrBase.clsRsyntax.SetBaseRFunction(clsRenameWithFunction)
            ucrReceiverColumns.SetMeAsReceiver()
        End If
    End Sub

    Private Sub ucrSelectVariables_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrSelectVariables.ControlValueChanged, ucrPnlOptions.ControlValueChanged
        If rdoMultiple.Checked AndAlso Not ucrSelectVariables.IsEmpty Then
            clsRenameWithFunction.AddParameter(".data", clsRFunctionParameter:=ucrSelectVariables.ucrAvailableDataFrames.clsCurrDataFrame, iPosition:=0)
        Else
            clsRenameWithFunction.RemoveParameterByName(".data")
        End If
    End Sub

    Private Sub ucrCoreControls_ControlContentsChanged() Handles ucrInputNewName.ControlContentsChanged, ucrReceiverName.ControlContentsChanged, ucrSelectVariables.ControlContentsChanged, ucrSaveDataFrame.ControlContentsChanged, ucrPnlOptions.ControlContentsChanged
        TestOKEnabled()
    End Sub
End Class
