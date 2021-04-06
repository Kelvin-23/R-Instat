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

Imports instat
Imports instat.Translations
Public Class sdgClimaticDataEntryOptions
    Private bFirstLoad As Boolean = True
    Private Sub sdgClimaticDataEntryOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitialiseControls()
            SetDefaults()
            bFirstLoad = False
        End If
        autoTranslate(Me)
    End Sub
    Private Sub InitialiseControls()
        ucrChkTransform.SetText("Transform:")

        'ucrInputTransform.SetItems({"10", "Inch to mm"})
        ucrInputTransform.SetItems({"10"}) 'todo. temporary
        ucrInputTransform.SetValidationTypeAsNumeric(dcmMin:=1) 'temporary`
        ucrInputTransform.Visible = False

        ucrChkDefaultValue.SetText("Default Value")
        ucrInputDefaultValue.SetText("0")
        ucrInputDefaultValue.Visible = False

        ucrChkNoDecimal.SetText("No Decimal")

        ucrChkExtraRows.SetText("Extra Rows")

        ucrChkAllowTrace.SetText("Allow t for Trace")
        ttucrChkDefaultValue.SetToolTip(ucrChkDefaultValue, "The data must be defined as climatic to recognise which variable is precipitation.")
    End Sub

    Private Sub SetDefaults()
        ucrChkDefaultValue.Checked = False
        ucrChkAllowTrace.Checked = False
        ucrChkTransform.Checked = False
        ucrNudBefore.Visible = False
        ucrNudAfter.Visible = False
        lblBefore.Visible = False
        lblAfter.Visible = False
        ucrInputTransform.SetName(10)
    End Sub

    Private Sub ucrChkDefaultValue_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkDefaultValue.ControlValueChanged
        'todo. can this "toggling" be done in another way?
        ucrInputDefaultValue.Visible = ucrChkDefaultValue.Checked
    End Sub

    Private Sub ucrChkTransform_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkTransform.ControlValueChanged
        'todo. can this "toggling" be done in another way?
        ucrInputTransform.Visible = ucrChkTransform.Checked
    End Sub

    Private Sub ucrChkExtraRows_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkExtraRows.ControlValueChanged
        ucrNudBefore.Visible = ucrChkExtraRows.Checked
        ucrNudAfter.Visible = ucrChkExtraRows.Checked
        lblBefore.Visible = ucrChkExtraRows.Checked
        lblAfter.Visible = ucrChkExtraRows.Checked
    End Sub
End Class