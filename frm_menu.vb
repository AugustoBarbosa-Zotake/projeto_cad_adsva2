Public Class frm_menu

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Try
            Form1.ShowDialog() 'Chamada de formularios
        Catch ex As Exception
            MsgBox("Erro ao carregar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub BlocoDeNotasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlocoDeNotasToolStripMenuItem.Click
        Try
            Process.Start("Notepad.exe")
        Catch ex As Exception
            MsgBox("Erro ao carregar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub CalculadoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculadoraToolStripMenuItem.Click
        Try
            Process.Start("Calc.exe")
        Catch ex As Exception
            MsgBox("Erro ao carregar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub SairDoSistemaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SairDoSistemaToolStripMenuItem1.Click
        Try
            resp = MsgBox("Deseja sair?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
            If resp = MsgBoxResult.Yes Then
                Application.Exit()
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub
End Class