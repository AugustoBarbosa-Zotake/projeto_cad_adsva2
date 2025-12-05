<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_menu))
        Me.GerenciamentoDeClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btn_gerenciamento_adm = New System.Windows.Forms.Button()
        Me.CadastroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GerarRelatórioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesconectarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GerenciamentoDeClientesToolStripMenuItem
        '
        Me.GerenciamentoDeClientesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastroToolStripMenuItem, Me.GerarRelatórioToolStripMenuItem, Me.DesconectarToolStripMenuItem, Me.SairToolStripMenuItem})
        Me.GerenciamentoDeClientesToolStripMenuItem.Name = "GerenciamentoDeClientesToolStripMenuItem"
        Me.GerenciamentoDeClientesToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.GerenciamentoDeClientesToolStripMenuItem.Text = "Medlink"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GerenciamentoDeClientesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btn_gerenciamento_adm
        '
        Me.btn_gerenciamento_adm.Location = New System.Drawing.Point(12, 64)
        Me.btn_gerenciamento_adm.Name = "btn_gerenciamento_adm"
        Me.btn_gerenciamento_adm.Size = New System.Drawing.Size(68, 52)
        Me.btn_gerenciamento_adm.TabIndex = 1
        Me.btn_gerenciamento_adm.Text = "Gerenciar Usuários"
        Me.btn_gerenciamento_adm.UseVisualStyleBackColor = True
        '
        'CadastroToolStripMenuItem
        '
        Me.CadastroToolStripMenuItem.Name = "CadastroToolStripMenuItem"
        Me.CadastroToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CadastroToolStripMenuItem.Text = "Gerenciar Usuários"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(156, 72)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 37)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Gerar Relatório"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GerarRelatórioToolStripMenuItem
        '
        Me.GerarRelatórioToolStripMenuItem.Name = "GerarRelatórioToolStripMenuItem"
        Me.GerarRelatórioToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GerarRelatórioToolStripMenuItem.Text = "Gerar Relatório"
        '
        'DesconectarToolStripMenuItem
        '
        Me.DesconectarToolStripMenuItem.Name = "DesconectarToolStripMenuItem"
        Me.DesconectarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DesconectarToolStripMenuItem.Text = "Desconectar"
        '
        'frm_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_gerenciamento_adm)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frm_menu"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "MENU PRINCIPAL ADM"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GerenciamentoDeClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btn_gerenciamento_adm As Button
    Friend WithEvents SairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CadastroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GerarRelatórioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents DesconectarToolStripMenuItem As ToolStripMenuItem
End Class
