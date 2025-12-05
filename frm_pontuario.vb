Imports System
Imports System.Windows.Forms
Imports System.Text

Public Class frm_pontuario
    Inherits Form

    Private cmbPaciente As ComboBox
    Private dtpDataConsulta As DateTimePicker
    Private txtDescricao As TextBox
    Private cmbProfissional As ComboBox
    Private dtpDataFim As DateTimePicker
    Private dtpHoraFim As DateTimePicker
    Private btnSalvar As Button
    Private btnCancelar As Button
    Private lblPaciente As Label
    Private lblDataConsulta As Label
    Private lblDescricao As Label
    Private lblProfissional As Label
    Private lblDataFim As Label
    Private lblHoraFim As Label

    Public Sub New()
        Me.Text = "Registrar no Prontuário"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ClientSize = New Drawing.Size(520, 360)

        InitializeControls()
        AddHandler Me.Load, AddressOf FrmPontuario_Load
    End Sub

    Private Sub InitializeControls()
        lblPaciente = New Label() With {.Text = "Paciente:", .Location = New Drawing.Point(12, 15), .AutoSize = True}
        cmbPaciente = New ComboBox() With {.Location = New Drawing.Point(90, 12), .Size = New Drawing.Size(410, 24), .DropDownStyle = ComboBoxStyle.DropDownList}

        lblDataConsulta = New Label() With {.Text = "Data consulta (agendada):", .Location = New Drawing.Point(12, 50), .AutoSize = True}
        dtpDataConsulta = New DateTimePicker() With {.Location = New Drawing.Point(190, 46), .Format = DateTimePickerFormat.Short, .Width = 120}

        lblDescricao = New Label() With {.Text = "Descrição (registro):", .Location = New Drawing.Point(12, 90), .AutoSize = True}
        txtDescricao = New TextBox() With {.Location = New Drawing.Point(15, 110), .Size = New Drawing.Size(485, 140), .Multiline = True, .ScrollBars = ScrollBars.Vertical}

        lblProfissional = New Label() With {.Text = "Profissional responsável:", .Location = New Drawing.Point(12, 260), .AutoSize = True}
        cmbProfissional = New ComboBox() With {.Location = New Drawing.Point(170, 256), .Size = New Drawing.Size(325, 24), .DropDownStyle = ComboBoxStyle.DropDownList}

        lblDataFim = New Label() With {.Text = "Data fim:", .Location = New Drawing.Point(12, 295), .AutoSize = True}
        dtpDataFim = New DateTimePicker() With {.Location = New Drawing.Point(70, 291), .Format = DateTimePickerFormat.Short, .Width = 110}

        lblHoraFim = New Label() With {.Text = "Hora fim:", .Location = New Drawing.Point(200, 295), .AutoSize = True}
        dtpHoraFim = New DateTimePicker() With {.Location = New Drawing.Point(260, 291), .Format = DateTimePickerFormat.Time, .ShowUpDown = True, .Width = 90}

        btnSalvar = New Button() With {.Text = "Salvar registro", .Location = New Drawing.Point(242, 330), .Size = New Drawing.Size(120, 30)}
        btnCancelar = New Button() With {.Text = "Cancelar", .Location = New Drawing.Point(370, 330), .Size = New Drawing.Size(120, 30)}

        Me.Controls.AddRange(New Control() {
            lblPaciente, cmbPaciente,
            lblDataConsulta, dtpDataConsulta,
            lblDescricao, txtDescricao,
            lblProfissional, cmbProfissional,
            lblDataFim, dtpDataFim,
            lblHoraFim, dtpHoraFim,
            btnSalvar, btnCancelar
        })

        AddHandler btnSalvar.Click, AddressOf BtnSalvar_Click
        AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
    End Sub

    Private Sub FrmPontuario_Load(sender As Object, e As EventArgs)
        PreencherPacientes()
        PreencherProfissionais()
    End Sub

    Private Sub PreencherPacientes()
        Try
            cmbPaciente.Items.Clear()
            SQL = "SELECT cpf, nome FROM tb_clientes_adsva2 WHERE cargo='Paciente' ORDER BY nome ASC"
            rs = db.Execute(SQL)
            Do While Not rs.EOF
                Dim cpf = If(IsDBNull(rs.Fields("cpf").Value), "", Convert.ToString(rs.Fields("cpf").Value))
                Dim nome = If(IsDBNull(rs.Fields("nome").Value), "", Convert.ToString(rs.Fields("nome").Value))
                cmbPaciente.Items.Add($"{cpf} - {nome}")
                rs.MoveNext()
            Loop
            If cmbPaciente.Items.Count > 0 Then cmbPaciente.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Erro ao carregar pacientes: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub PreencherProfissionais()
        Try
            cmbProfissional.Items.Clear()
            SQL = "SELECT cpf, nome, cargo FROM tb_clientes_adsva2 WHERE cargo LIKE 'Médico%' ORDER BY nome ASC"
            rs = db.Execute(SQL)
            Do While Not rs.EOF
                Dim cpf = If(IsDBNull(rs.Fields("cpf").Value), "", Convert.ToString(rs.Fields("cpf").Value))
                Dim nome = If(IsDBNull(rs.Fields("nome").Value), "", Convert.ToString(rs.Fields("nome").Value))
                Dim cargo = If(IsDBNull(rs.Fields("cargo").Value), "", Convert.ToString(rs.Fields("cargo").Value))
                cmbProfissional.Items.Add($"{cpf} - {nome} ({cargo})")
                rs.MoveNext()
            Loop
            If cmbProfissional.Items.Count > 0 Then cmbProfissional.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Erro ao carregar profissionais: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs)
        Try
            ' Validações básicas
            If cmbPaciente.SelectedIndex < 0 Then
                MsgBox("Selecione um paciente.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
                Return
            End If
            If cmbProfissional.SelectedIndex < 0 Then
                MsgBox("Selecione o profissional responsável.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
                Return
            End If
            Dim descricao = txtDescricao.Text.Trim()
            If descricao = "" Then
                If MsgBox("Descrição vazia. Deseja continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMAR") = MsgBoxResult.No Then
                    Return
                End If
            End If

            ' --- busca id_cliente do paciente ---
            Dim pacienteItem = cmbPaciente.SelectedItem.ToString()
            Dim pacienteCpf = pacienteItem.Split("-"c)(0).Trim()
            Dim pacienteCpfSan = pacienteCpf.Replace("'", "''")

            SQL = $"SELECT id_cliente FROM tb_clientes_adsva2 WHERE cpf='{pacienteCpfSan}' LIMIT 1"
            Dim rsClient = db.Execute(SQL)
            If rsClient.EOF Then
                MsgBox("Paciente não encontrado no cadastro. Não é possível salvar o prontuário.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
                Return
            End If

            Dim idCliente = rsClient.Fields("id_cliente").Value

            ' --- prepara demais campos ---
            Dim profSan = cmbProfissional.SelectedItem.ToString().Replace("'", "''")
            Dim dataConsulta = dtpDataConsulta.Value.ToString("yyyy-MM-dd")
            Dim dataFim = dtpDataFim.Value.ToString("yyyy-MM-dd")
            Dim horaFim = dtpHoraFim.Value.ToString("HH:mm:ss")
            Dim pacienteNome = pacienteItem.Substring(pacienteItem.IndexOf("-"c) + 1).Trim().Replace("'", "''")

            ' --- insere incluindo o id (FK) ---
            SQL = $"INSERT INTO tb_pontuarios (id, paciente_cpf, paciente_nome, data_consulta, descricao, profissional_responsavel, data_fim, hora_fim) " &
                  $"VALUES ({idCliente},'{pacienteCpfSan}','{pacienteNome}','{dataConsulta}','{descricao}','{profSan}','{dataFim}','{horaFim}')"
            rs = db.Execute(SQL)

            MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
            limparCampos()
            Me.Close()
        Catch ex As Exception
            MsgBox("Erro ao salvar registro: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        If MsgBox("Cancelar registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMAR") = MsgBoxResult.Yes Then
            limparCampos()
            Me.Hide()
            frm_menu_medico.Show()
        End If
    End Sub

    Private Sub limparCampos()
        txtDescricao.Text = ""
        If cmbPaciente.Items.Count > 0 Then cmbPaciente.SelectedIndex = 0
        If cmbProfissional.Items.Count > 0 Then cmbProfissional.SelectedIndex = 0
        dtpDataConsulta.Value = DateTime.Now
        dtpDataFim.Value = DateTime.Now
        dtpHoraFim.Value = DateTime.Now
    End Sub
End Class