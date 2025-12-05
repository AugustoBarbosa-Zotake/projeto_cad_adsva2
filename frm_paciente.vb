Public Class frm_paciente
    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        Try
            resp = MsgBox("Deseja sair?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
            If resp = MsgBoxResult.Yes Then
                Application.Exit()
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Try
            resp = MsgBox("Deseja se desconectar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
            If resp = MsgBoxResult.Yes Then
                Me.Close()
                frm_login.Show()
                limpar_login()
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Me.Hide()
            Dim ag As New frm_agendamento(aux_cpf)
            AddHandler ag.FormClosed, AddressOf Ag_FormClosed
            ag.Show()
        Catch ex As Exception
            MsgBox("Erro ao abrir agendamento: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            Me.Show()
        End Try
    End Sub

    Private Sub Ag_FormClosed(sender As Object, e As FormClosedEventArgs)
        Try
            Me.Show()
        Catch ex As Exception

        End Try
    End Sub
End Class