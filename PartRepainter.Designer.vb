<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartRepainter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PartRepainter))
        Me.StylesGrid = New System.Windows.Forms.DataGridView()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBodies = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFeatures = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFaces = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStyles = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.StylesGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StylesGrid
        '
        Me.StylesGrid.AllowUserToAddRows = False
        Me.StylesGrid.AllowUserToDeleteRows = False
        Me.StylesGrid.AllowUserToResizeColumns = False
        Me.StylesGrid.AllowUserToResizeRows = False
        Me.StylesGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StylesGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.StylesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.StylesGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colName, Me.colBodies, Me.colFeatures, Me.colFaces})
        Me.StylesGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StylesGrid.Location = New System.Drawing.Point(0, 0)
        Me.StylesGrid.MultiSelect = False
        Me.StylesGrid.Name = "StylesGrid"
        Me.StylesGrid.ReadOnly = True
        Me.StylesGrid.RowHeadersWidth = 25
        Me.StylesGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.StylesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.StylesGrid.Size = New System.Drawing.Size(384, 339)
        Me.StylesGrid.TabIndex = 0
        '
        'colName
        '
        Me.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colName.DataPropertyName = "Name"
        Me.colName.HeaderText = "Name"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        Me.colName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'colBodies
        '
        Me.colBodies.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colBodies.DataPropertyName = "BodiesCount"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colBodies.DefaultCellStyle = DataGridViewCellStyle4
        Me.colBodies.HeaderText = "Bodies"
        Me.colBodies.Name = "colBodies"
        Me.colBodies.ReadOnly = True
        Me.colBodies.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colBodies.Width = 55
        '
        'colFeatures
        '
        Me.colFeatures.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colFeatures.DataPropertyName = "FeaturesCount"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colFeatures.DefaultCellStyle = DataGridViewCellStyle5
        Me.colFeatures.HeaderText = "Features"
        Me.colFeatures.Name = "colFeatures"
        Me.colFeatures.ReadOnly = True
        Me.colFeatures.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colFeatures.Width = 55
        '
        'colFaces
        '
        Me.colFaces.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colFaces.DataPropertyName = "FacesCount"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colFaces.DefaultCellStyle = DataGridViewCellStyle6
        Me.colFaces.HeaderText = "Faces"
        Me.colFaces.Name = "colFaces"
        Me.colFaces.ReadOnly = True
        Me.colFaces.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colFaces.Width = 55
        '
        'MenuStyles
        '
        Me.MenuStyles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStyles.MaximumSize = New System.Drawing.Size(0, 800)
        Me.MenuStyles.Name = "MenuStyles"
        Me.MenuStyles.Size = New System.Drawing.Size(61, 4)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton2, Me.Status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 339)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = True
        Me.StatusStrip1.Size = New System.Drawing.Size(384, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.ShowDropDownArrow = False
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(20, 20)
        Me.ToolStripDropDownButton1.Text = "Refresh"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.ShowDropDownArrow = False
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(20, 20)
        Me.ToolStripDropDownButton2.Text = "Restore"
        '
        'Status
        '
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(39, 17)
        Me.Status.Text = "Ready"
        '
        'PartRepainter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 361)
        Me.Controls.Add(Me.StylesGrid)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PartRepainter"
        Me.Text = "Solid Edge Part Repainter v0.2"
        Me.TopMost = True
        CType(Me.StylesGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StylesGrid As DataGridView
    Friend WithEvents MenuStyles As ContextMenuStrip
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Status As ToolStripStatusLabel
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colBodies As DataGridViewTextBoxColumn
    Friend WithEvents colFeatures As DataGridViewTextBoxColumn
    Friend WithEvents colFaces As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
End Class
