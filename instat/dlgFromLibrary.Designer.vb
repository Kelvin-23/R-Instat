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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgFromLibrary
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cmdLibraryCollection = New System.Windows.Forms.Button()
        Me.lstCollection = New System.Windows.Forms.ListView()
        Me.clmDatasets = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmDesc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblFromPackage = New System.Windows.Forms.Label()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.rdoDefaultDatasets = New System.Windows.Forms.RadioButton()
        Me.rdoInstatCollection = New System.Windows.Forms.RadioButton()
        Me.ucrNewDataFrameName = New instat.ucrSave()
        Me.ucrInputPackages = New instat.ucrInputComboBox()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrPnlOptions = New instat.UcrPanel()
        Me.SuspendLayout()
        '
        'cmdLibraryCollection
        '
        Me.cmdLibraryCollection.Location = New System.Drawing.Point(157, 51)
        Me.cmdLibraryCollection.Name = "cmdLibraryCollection"
        Me.cmdLibraryCollection.Size = New System.Drawing.Size(117, 23)
        Me.cmdLibraryCollection.TabIndex = 5
        Me.cmdLibraryCollection.Text = "Browse"
        Me.cmdLibraryCollection.UseVisualStyleBackColor = True
        '
        'lstCollection
        '
        Me.lstCollection.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmDatasets, Me.clmDesc})
        Me.lstCollection.FullRowSelect = True
        Me.lstCollection.HideSelection = False
        Me.lstCollection.Location = New System.Drawing.Point(10, 79)
        Me.lstCollection.MultiSelect = False
        Me.lstCollection.Name = "lstCollection"
        Me.lstCollection.ShowGroups = False
        Me.lstCollection.ShowItemToolTips = True
        Me.lstCollection.Size = New System.Drawing.Size(397, 173)
        Me.lstCollection.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstCollection.TabIndex = 6
        Me.lstCollection.UseCompatibleStateImageBehavior = False
        Me.lstCollection.View = System.Windows.Forms.View.Details
        '
        'clmDatasets
        '
        Me.clmDatasets.Text = "Data"
        Me.clmDatasets.Width = 142
        '
        'clmDesc
        '
        Me.clmDesc.Text = "Description"
        Me.clmDesc.Width = 266
        '
        'lblFromPackage
        '
        Me.lblFromPackage.AutoSize = True
        Me.lblFromPackage.Location = New System.Drawing.Point(10, 56)
        Me.lblFromPackage.Name = "lblFromPackage"
        Me.lblFromPackage.Size = New System.Drawing.Size(79, 13)
        Me.lblFromPackage.TabIndex = 3
        Me.lblFromPackage.Text = "From Package:"
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(332, 258)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(75, 23)
        Me.cmdHelp.TabIndex = 8
        Me.cmdHelp.Text = "R Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'rdoDefaultDatasets
        '
        Me.rdoDefaultDatasets.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoDefaultDatasets.BackColor = System.Drawing.SystemColors.Control
        Me.rdoDefaultDatasets.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoDefaultDatasets.FlatAppearance.BorderSize = 2
        Me.rdoDefaultDatasets.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoDefaultDatasets.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoDefaultDatasets.Location = New System.Drawing.Point(71, 2)
        Me.rdoDefaultDatasets.Name = "rdoDefaultDatasets"
        Me.rdoDefaultDatasets.Size = New System.Drawing.Size(145, 44)
        Me.rdoDefaultDatasets.TabIndex = 1
        Me.rdoDefaultDatasets.TabStop = True
        Me.rdoDefaultDatasets.Tag = ""
        Me.rdoDefaultDatasets.Text = "Load from R"
        Me.rdoDefaultDatasets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoDefaultDatasets.UseVisualStyleBackColor = False
        '
        'rdoInstatCollection
        '
        Me.rdoInstatCollection.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoInstatCollection.BackColor = System.Drawing.SystemColors.Control
        Me.rdoInstatCollection.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoInstatCollection.FlatAppearance.BorderSize = 2
        Me.rdoInstatCollection.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoInstatCollection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoInstatCollection.Location = New System.Drawing.Point(214, 2)
        Me.rdoInstatCollection.Name = "rdoInstatCollection"
        Me.rdoInstatCollection.Size = New System.Drawing.Size(145, 44)
        Me.rdoInstatCollection.TabIndex = 2
        Me.rdoInstatCollection.TabStop = True
        Me.rdoInstatCollection.Tag = ""
        Me.rdoInstatCollection.Text = "Load from Instat collection"
        Me.rdoInstatCollection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoInstatCollection.UseVisualStyleBackColor = False
        '
        'ucrNewDataFrameName
        '
        Me.ucrNewDataFrameName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrNewDataFrameName.Location = New System.Drawing.Point(10, 259)
        Me.ucrNewDataFrameName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNewDataFrameName.Name = "ucrNewDataFrameName"
        Me.ucrNewDataFrameName.Size = New System.Drawing.Size(315, 22)
        Me.ucrNewDataFrameName.TabIndex = 7
        '
        'ucrInputPackages
        '
        Me.ucrInputPackages.AddQuotesIfUnrecognised = True
        Me.ucrInputPackages.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrInputPackages.GetSetSelectedIndex = -1
        Me.ucrInputPackages.IsReadOnly = False
        Me.ucrInputPackages.Location = New System.Drawing.Point(108, 51)
        Me.ucrInputPackages.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrInputPackages.Name = "ucrInputPackages"
        Me.ucrInputPackages.Size = New System.Drawing.Size(144, 23)
        Me.ucrInputPackages.TabIndex = 4
        '
        'ucrBase
        '
        Me.ucrBase.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ucrBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrBase.Location = New System.Drawing.Point(10, 287)
        Me.ucrBase.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(400, 59)
        Me.ucrBase.TabIndex = 9
        '
        'ucrPnlOptions
        '
        Me.ucrPnlOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrPnlOptions.Location = New System.Drawing.Point(59, 2)
        Me.ucrPnlOptions.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrPnlOptions.Name = "ucrPnlOptions"
        Me.ucrPnlOptions.Size = New System.Drawing.Size(316, 44)
        Me.ucrPnlOptions.TabIndex = 0
        '
        'dlgFromLibrary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(418, 348)
        Me.Controls.Add(Me.ucrNewDataFrameName)
        Me.Controls.Add(Me.rdoDefaultDatasets)
        Me.Controls.Add(Me.rdoInstatCollection)
        Me.Controls.Add(Me.cmdLibraryCollection)
        Me.Controls.Add(Me.ucrInputPackages)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.lblFromPackage)
        Me.Controls.Add(Me.lstCollection)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.ucrPnlOptions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgFromLibrary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import From Library"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents cmdLibraryCollection As Button
    Friend WithEvents lstCollection As ListView
    Friend WithEvents clmDatasets As ColumnHeader
    Friend WithEvents clmDesc As ColumnHeader
    Friend WithEvents lblFromPackage As Label
    Friend WithEvents cmdHelp As Button
    Friend WithEvents ucrInputPackages As ucrInputComboBox
    Friend WithEvents ucrPnlOptions As UcrPanel
    Friend WithEvents rdoDefaultDatasets As RadioButton
    Friend WithEvents rdoInstatCollection As RadioButton
    Friend WithEvents ucrNewDataFrameName As ucrSave
End Class