Imports System
Imports System.Windows.Forms

Public Class frm_agendamento
    Inherits Form

    Private ReadOnly pacienteCpf As String
    Private pacienteId As Integer
    Private pacienteNome As String

    Private lblPaciente As Label
    Private lblInfoPaciente As Label
    Private lblData As Label
    Private dtpData As DateTimePicker
    Private lblHora As Label
    Private dtpHora As DateTimePicker
    Private lblObs As Label
    Private txtObservacao As TextBox
    Private btnSalvar As Button
    Private btnCancelar As Button

    ' Construtor: informe o CPF do paciente que fez login
    Public Sub New(cpfLogado As String)
        Me.pacienteCpf = If(cpfLogado, String.Empty).Trim()
        Me.Text = "Agendar Consulta"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ClientSize = New Drawing.Size(460, 300)

        InitializeControls()
        AddHandler Me.Load, AddressOf FrmAgendamento_Load
    End Sub

    Private Sub InitializeControls()
        lblPaciente = New Label() With {.Text = "Paciente:", .Location = New Drawing.Point(12, 12), .AutoSize = True}
        lblInfoPaciente = New Label() With {.Text = "(carregando...)", .Location = New Drawing.Point(80, 12), .AutoSize = True}

        lblData = New Label() With {.Text = "Dia da consulta:", .Location = New Drawing.Point(12, 48), .AutoSize = True}
        dtpData = New DateTimePicker() With {.Location = New Drawing.Point(120, 44), .Format = DateTimePickerFormat.Short, .Width = 120}

        lblHora = New Label() With {.Text = "Hora:", .Location = New Drawing.Point(260, 48), .AutoSize = True}
        dtpHora = New DateTimePicker() With {.Location = New Drawing.Point(300, 44), .Format = DateTimePickerFormat.Time, .ShowUpDown = True, .Width = 120}

        lblObs = New Label() With {.Text = "Descrição (opcional):", .Location = New Drawing.Point(12, 84), .AutoSize = True}
        txtObservacao = New TextBox() With {.Location = New Drawing.Point(12, 104), .Size = New Drawing.Size(408, 120), .Multiline = True, .ScrollBars = ScrollBars.Vertical}

        btnSalvar = New Button() With {.Text = "Salvar", .Location = New Drawing.Point(240, 236), .Size = New Drawing.Size(90, 30)}
        btnCancelar = New Button() With {.Text = "Cancelar", .Location = New Drawing.Point(342, 236), .Size = New Drawing.Size(90, 30)}

        Me.Controls.AddRange(New Control() {
            lblPaciente, lblInfoPaciente,
            lblData, dtpData,
            lblHora, dtpHora,
            lblObs, txtObservacao,
            btnSalvar, btnCancelar
        })

        AddHandler btnSalvar.Click, AddressOf BtnSalvar_Click
        AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
    End Sub

    Private Sub FrmAgendamento_Load(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(pacienteCpf) Then
            MsgBox("CPF do paciente não informado. Impossível agendar.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            Me.Close()
            Return
        End If

        Try
            ' Buscar id_cliente e nome do paciente pelo CPF
            Dim cpfSan = pacienteCpf.Replace("'", "''")
            SQL = $"SELECT id_cliente, nome FROM tb_clientes_adsva2 WHERE cpf='{cpfSan}' LIMIT 1"
            rs = db.Execute(SQL)
            If rs.EOF Then
                MsgBox("Paciente não encontrado no cadastro. Verifique login.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
                Me.Close()
                Return
            End If

            pacienteId = If(IsDBNull(rs.Fields("id_cliente").Value), 0, Convert.ToInt32(rs.Fields("id_cliente").Value))
            pacienteNome = If(IsDBNull(rs.Fields("nome").Value), "", Convert.ToString(rs.Fields("nome").Value))
            lblInfoPaciente.Text = $"{pacienteNome} ({pacienteCpf})"

            ' Inicializar data/hora padrão: hoje e próxima hora
            dtpData.Value = DateTime.Now.Date
            dtpHora.Value = DateTime.Now.AddHours(1)
        Catch ex As Exception
            MsgBox("Erro ao carregar dados do paciente: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            Me.Close()
        End Try
    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs)
        Try
            ' Validações
            Dim dataSelecionada = dtpData.Value.Date
            Dim horaSelecionada = dtpHora.Value.TimeOfDay
            Dim dataHoraAgendada = dataSelecionada.Add(horaSelecionada)

            If dataHoraAgendada <= DateTime.Now.AddMinutes(-1) Then
                If MsgBox("Data/hora selecionada é anterior ao momento atual. Deseja continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMAR") = MsgBoxResult.No Then
                    Return
                End If
            End If

            If pacienteId <= 0 Then
                MsgBox("Paciente inválido. Agendamento não realizado.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
                Return
            End If

            ' Preparar campos para inserção (ajuste nomes da tabela/colunas conforme esquema)
            Dim observacaoSan = txtObservacao.Text.Trim().Replace("'", "''")
            Dim dataStr = dataSelecionada.ToString("yyyy-MM-dd")
            Dim horaStr = New DateTime(1, 1, 1).Add(horaSelecionada).ToString("HH:mm:ss")
            Dim criadoPor = pacienteCpf.Replace("'", "''") ' salva quem agendou (cpf do paciente logado)
            Dim status = "Agendado"

            ' Inserir no banco
            ' OBS: ajuste os nomes da tabela/colunas conforme seu schema (ex.: tb_agendamentos)
            SQL = $"INSERT INTO tb_agendamentos (id_cliente, paciente_cpf, paciente_nome, data_agendada, hora_agendada, observacao, status, criado_por) " &
                  $"VALUES ({pacienteId},'{pacienteCpf.Replace("'", "''")}','{pacienteNome.Replace("'", "''")}','{dataStr}','{horaStr}','{observacaoSan}','{status}','{criadoPor}')"
            rs = db.Execute(SQL)

            MsgBox("Consulta agendada com sucesso.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
            Me.Close()
        Catch ex As Exception
            MsgBox("Erro ao salvar agendamento: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        If MsgBox("Cancelar agendamento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMAR") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class