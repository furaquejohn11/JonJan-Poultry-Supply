<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmViewInformation
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.curDate = New System.Windows.Forms.TextBox()
        Me.curUser = New System.Windows.Forms.TextBox()
        Me.dgvViewInfo = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProdName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHQS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLQS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHPS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLPS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbHighestQuantitySold = New System.Windows.Forms.CheckBox()
        Me.cbLowestQuantitySold = New System.Windows.Forms.CheckBox()
        Me.cbLowestPercentageSold = New System.Windows.Forms.CheckBox()
        Me.cbHighestPercentageSold = New System.Windows.Forms.CheckBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.cbHighestAmount = New System.Windows.Forms.CheckBox()
        Me.cbLowestAmount = New System.Windows.Forms.CheckBox()
        Me.cbHighestPercentageAmount = New System.Windows.Forms.CheckBox()
        Me.cbLowestPercentageEarnings = New System.Windows.Forms.CheckBox()
        Me.txtDebug = New System.Windows.Forms.Label()
        CType(Me.dgvViewInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'curDate
        '
        Me.curDate.Enabled = False
        Me.curDate.Location = New System.Drawing.Point(51, 26)
        Me.curDate.Name = "curDate"
        Me.curDate.ReadOnly = True
        Me.curDate.Size = New System.Drawing.Size(197, 20)
        Me.curDate.TabIndex = 0
        '
        'curUser
        '
        Me.curUser.Enabled = False
        Me.curUser.Location = New System.Drawing.Point(51, 77)
        Me.curUser.Name = "curUser"
        Me.curUser.ReadOnly = True
        Me.curUser.Size = New System.Drawing.Size(197, 20)
        Me.curUser.TabIndex = 1
        '
        'dgvViewInfo
        '
        Me.dgvViewInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvViewInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.colProdName, Me.colHQS, Me.colLQS, Me.colHPS, Me.colLPS, Me.colHAE, Me.colLAE, Me.colHPE, Me.colLPE})
        Me.dgvViewInfo.Enabled = False
        Me.dgvViewInfo.Location = New System.Drawing.Point(37, 289)
        Me.dgvViewInfo.Name = "dgvViewInfo"
        Me.dgvViewInfo.Size = New System.Drawing.Size(681, 486)
        Me.dgvViewInfo.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.HeaderText = "#"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'colProdName
        '
        Me.colProdName.HeaderText = "Products Name"
        Me.colProdName.Name = "colProdName"
        Me.colProdName.ReadOnly = True
        '
        'colHQS
        '
        Me.colHQS.HeaderText = "Based on Highest Quantity Sold"
        Me.colHQS.Name = "colHQS"
        Me.colHQS.ReadOnly = True
        '
        'colLQS
        '
        Me.colLQS.HeaderText = "Based on Lowest Quantity Sold"
        Me.colLQS.Name = "colLQS"
        Me.colLQS.ReadOnly = True
        '
        'colHPS
        '
        Me.colHPS.HeaderText = "Based on Highest Percentage of Quantity Sold"
        Me.colHPS.Name = "colHPS"
        Me.colHPS.ReadOnly = True
        '
        'colLPS
        '
        Me.colLPS.HeaderText = "Based on Lowest Percentage of Quantity Sold"
        Me.colLPS.Name = "colLPS"
        Me.colLPS.ReadOnly = True
        '
        'colHAE
        '
        Me.colHAE.HeaderText = "Based on Highest Amount of Earnings"
        Me.colHAE.Name = "colHAE"
        Me.colHAE.ReadOnly = True
        '
        'colLAE
        '
        Me.colLAE.HeaderText = "Based on Lowest Amount of Earnings"
        Me.colLAE.Name = "colLAE"
        Me.colLAE.ReadOnly = True
        '
        'colHPE
        '
        Me.colHPE.HeaderText = "Based on Highest Percentage Amount of Earnings"
        Me.colHPE.Name = "colHPE"
        Me.colHPE.ReadOnly = True
        '
        'colLPE
        '
        Me.colLPE.HeaderText = "Based on Lowest Percentage of Earnings"
        Me.colLPE.Name = "colLPE"
        Me.colLPE.ReadOnly = True
        '
        'cbHighestQuantitySold
        '
        Me.cbHighestQuantitySold.AutoSize = True
        Me.cbHighestQuantitySold.Location = New System.Drawing.Point(124, 126)
        Me.cbHighestQuantitySold.Name = "cbHighestQuantitySold"
        Me.cbHighestQuantitySold.Size = New System.Drawing.Size(214, 17)
        Me.cbHighestQuantitySold.TabIndex = 3
        Me.cbHighestQuantitySold.Text = "Sort to Number of Highest Quantity Sold"
        Me.cbHighestQuantitySold.UseVisualStyleBackColor = True
        '
        'cbLowestQuantitySold
        '
        Me.cbLowestQuantitySold.AutoSize = True
        Me.cbLowestQuantitySold.Location = New System.Drawing.Point(124, 149)
        Me.cbLowestQuantitySold.Name = "cbLowestQuantitySold"
        Me.cbLowestQuantitySold.Size = New System.Drawing.Size(212, 17)
        Me.cbLowestQuantitySold.TabIndex = 4
        Me.cbLowestQuantitySold.Text = "Sort to Number of Lowest Quantity Sold"
        Me.cbLowestQuantitySold.UseVisualStyleBackColor = True
        '
        'cbLowestPercentageSold
        '
        Me.cbLowestPercentageSold.AutoSize = True
        Me.cbLowestPercentageSold.Location = New System.Drawing.Point(340, 149)
        Me.cbLowestPercentageSold.Name = "cbLowestPercentageSold"
        Me.cbLowestPercentageSold.Size = New System.Drawing.Size(230, 17)
        Me.cbLowestPercentageSold.TabIndex = 5
        Me.cbLowestPercentageSold.Text = "Sort to Lowest Percentage of Quantity Sold"
        Me.cbLowestPercentageSold.UseVisualStyleBackColor = True
        '
        'cbHighestPercentageSold
        '
        Me.cbHighestPercentageSold.AutoSize = True
        Me.cbHighestPercentageSold.Location = New System.Drawing.Point(340, 126)
        Me.cbHighestPercentageSold.Name = "cbHighestPercentageSold"
        Me.cbHighestPercentageSold.Size = New System.Drawing.Size(232, 17)
        Me.cbHighestPercentageSold.TabIndex = 6
        Me.cbHighestPercentageSold.Text = "Sort to Highest Percentage of Quantity Sold"
        Me.cbHighestPercentageSold.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(768, 289)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(560, 486)
        Me.Chart1.TabIndex = 7
        Me.Chart1.Text = "Chart1"
        '
        'cbHighestAmount
        '
        Me.cbHighestAmount.AutoSize = True
        Me.cbHighestAmount.Location = New System.Drawing.Point(609, 126)
        Me.cbHighestAmount.Name = "cbHighestAmount"
        Me.cbHighestAmount.Size = New System.Drawing.Size(191, 17)
        Me.cbHighestAmount.TabIndex = 8
        Me.cbHighestAmount.Text = "Sort to Highest Amount of Earnings"
        Me.cbHighestAmount.UseVisualStyleBackColor = True
        '
        'cbLowestAmount
        '
        Me.cbLowestAmount.AutoSize = True
        Me.cbLowestAmount.Location = New System.Drawing.Point(609, 150)
        Me.cbLowestAmount.Name = "cbLowestAmount"
        Me.cbLowestAmount.Size = New System.Drawing.Size(189, 17)
        Me.cbLowestAmount.TabIndex = 9
        Me.cbLowestAmount.Text = "Sort to Lowest Amount of Earnings"
        Me.cbLowestAmount.UseVisualStyleBackColor = True
        '
        'cbHighestPercentageAmount
        '
        Me.cbHighestPercentageAmount.AutoSize = True
        Me.cbHighestPercentageAmount.Location = New System.Drawing.Point(900, 126)
        Me.cbHighestPercentageAmount.Name = "cbHighestPercentageAmount"
        Me.cbHighestPercentageAmount.Size = New System.Drawing.Size(249, 17)
        Me.cbHighestPercentageAmount.TabIndex = 10
        Me.cbHighestPercentageAmount.Text = "Sort to Highest Percentage Amount of Earnings"
        Me.cbHighestPercentageAmount.UseVisualStyleBackColor = True
        '
        'cbLowestPercentageEarnings
        '
        Me.cbLowestPercentageEarnings.AutoSize = True
        Me.cbLowestPercentageEarnings.Location = New System.Drawing.Point(900, 149)
        Me.cbLowestPercentageEarnings.Name = "cbLowestPercentageEarnings"
        Me.cbLowestPercentageEarnings.Size = New System.Drawing.Size(208, 17)
        Me.cbLowestPercentageEarnings.TabIndex = 11
        Me.cbLowestPercentageEarnings.Text = "Sort to Lowest Percentage of Earnings"
        Me.cbLowestPercentageEarnings.UseVisualStyleBackColor = True
        '
        'txtDebug
        '
        Me.txtDebug.AutoSize = True
        Me.txtDebug.Location = New System.Drawing.Point(679, 32)
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.Size = New System.Drawing.Size(39, 13)
        Me.txtDebug.TabIndex = 12
        Me.txtDebug.Text = "Label1"
        '
        'frmViewInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1340, 811)
        Me.Controls.Add(Me.txtDebug)
        Me.Controls.Add(Me.cbLowestPercentageEarnings)
        Me.Controls.Add(Me.cbHighestPercentageAmount)
        Me.Controls.Add(Me.cbLowestAmount)
        Me.Controls.Add(Me.cbHighestAmount)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.cbHighestPercentageSold)
        Me.Controls.Add(Me.cbLowestPercentageSold)
        Me.Controls.Add(Me.cbLowestQuantitySold)
        Me.Controls.Add(Me.cbHighestQuantitySold)
        Me.Controls.Add(Me.dgvViewInfo)
        Me.Controls.Add(Me.curUser)
        Me.Controls.Add(Me.curDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmViewInformation"
        Me.Text = "frmViewInformation"
        CType(Me.dgvViewInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents curDate As TextBox
    Friend WithEvents curUser As TextBox
    Friend WithEvents dgvViewInfo As DataGridView
    Friend WithEvents cbHighestQuantitySold As CheckBox
    Friend WithEvents cbLowestQuantitySold As CheckBox
    Friend WithEvents cbLowestPercentageSold As CheckBox
    Friend WithEvents cbHighestPercentageSold As CheckBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents cbHighestAmount As CheckBox
    Friend WithEvents cbLowestAmount As CheckBox
    Friend WithEvents cbHighestPercentageAmount As CheckBox
    Friend WithEvents cbLowestPercentageEarnings As CheckBox
    Friend WithEvents txtDebug As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents colProdName As DataGridViewTextBoxColumn
    Friend WithEvents colHQS As DataGridViewTextBoxColumn
    Friend WithEvents colLQS As DataGridViewTextBoxColumn
    Friend WithEvents colHPS As DataGridViewTextBoxColumn
    Friend WithEvents colLPS As DataGridViewTextBoxColumn
    Friend WithEvents colHAE As DataGridViewTextBoxColumn
    Friend WithEvents colLAE As DataGridViewTextBoxColumn
    Friend WithEvents colHPE As DataGridViewTextBoxColumn
    Friend WithEvents colLPE As DataGridViewTextBoxColumn
End Class
