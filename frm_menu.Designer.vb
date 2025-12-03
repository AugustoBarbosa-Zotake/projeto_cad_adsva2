<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_menu))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GerenciamentoDeClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.APLICATIVOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculadoraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlocoDeNotasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SAIRDOSISTEMAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairDoSistemaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GerenciamentoDeClientesToolStripMenuItem, Me.APLICATIVOSToolStripMenuItem, Me.SAIRDOSISTEMAToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GerenciamentoDeClientesToolStripMenuItem
        '
        Me.GerenciamentoDeClientesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastroToolStripMenuItem})
        Me.GerenciamentoDeClientesToolStripMenuItem.Name = "GerenciamentoDeClientesToolStripMenuItem"
        Me.GerenciamentoDeClientesToolStripMenuItem.Size = New System.Drawing.Size(189, 20)
        Me.GerenciamentoDeClientesToolStripMenuItem.Text = "&GERENCIAMENTO DE USUARIOS"
        '
        'CadastroToolStripMenuItem
        '
        Me.CadastroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientesToolStripMenuItem})
        Me.CadastroToolStripMenuItem.Name = "CadastroToolStripMenuItem"
        Me.CadastroToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CadastroToolStripMenuItem.Text = "Cadastro"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Image = CType(resources.GetObject("ClientesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'APLICATIVOSToolStripMenuItem
        '
        Me.APLICATIVOSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalculadoraToolStripMenuItem, Me.BlocoDeNotasToolStripMenuItem})
        Me.APLICATIVOSToolStripMenuItem.Name = "APLICATIVOSToolStripMenuItem"
        Me.APLICATIVOSToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.APLICATIVOSToolStripMenuItem.Text = "&APLICATIVOS"
        '
        'CalculadoraToolStripMenuItem
        '
        Me.CalculadoraToolStripMenuItem.Name = "CalculadoraToolStripMenuItem"
        Me.CalculadoraToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.CalculadoraToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.CalculadoraToolStripMenuItem.Text = "Calculadora"
        '
        'BlocoDeNotasToolStripMenuItem
        '
        Me.BlocoDeNotasToolStripMenuItem.Name = "BlocoDeNotasToolStripMenuItem"
        Me.BlocoDeNotasToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F2), System.Windows.Forms.Keys)
        Me.BlocoDeNotasToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.BlocoDeNotasToolStripMenuItem.Text = "Bloco de notas"
        '
        'SAIRDOSISTEMAToolStripMenuItem
        '
        Me.SAIRDOSISTEMAToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SairDoSistemaToolStripMenuItem1})
        Me.SAIRDOSISTEMAToolStripMenuItem.Name = "SAIRDOSISTEMAToolStripMenuItem"
        Me.SAIRDOSISTEMAToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SAIRDOSISTEMAToolStripMenuItem.Text = "&SAIR"
        '
        'SairDoSistemaToolStripMenuItem1
        '
        Me.SairDoSistemaToolStripMenuItem1.Name = "SairDoSistemaToolStripMenuItem1"
        Me.SairDoSistemaToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.SairDoSistemaToolStripMenuItem1.Size = New System.Drawing.Size(193, 22)
        Me.SairDoSistemaToolStripMenuItem1.Text = "Sair do sistema"
        '
        'frm_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frm_menu"
        Me.Text = "MENU PRINCIPAL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents GerenciamentoDeClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CadastroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents APLICATIVOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalculadoraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BlocoDeNotasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SAIRDOSISTEMAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SairDoSistemaToolStripMenuItem1 As ToolStripMenuItem
End Class
