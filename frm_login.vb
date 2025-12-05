Public Class frm_login
    Private Sub frm_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conecta_banco_mysql()
        carregar_dados()
        carregar_campos()
    End Sub

    Private Sub btn_entrar_Click(sender As Object, e As EventArgs) Handles btn_entrar.Click
        Try
            SQL = $"select * from tb_clientes_adsva2 where cpf='{txt_usuario.Text}' and senha='{txt_senha.Text}'"
            rs = db.Execute(SQL)
            If rs.EOF = False Then
                Dim istatus As String = String.Empty
                Try
                    istatus = If(rs.Fields(9).Value IsNot Nothing, rs.Fields(9).Value.ToString(), String.Empty)
                Catch ex As Exception
                    istatus = String.Empty
                End Try
                If String.Compare(istatus, "Bloqueado", True) = 0 Then
                    MsgBox("Usuário Bloqueado! Contate o Administrador.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")

                Else

                    Try
                        aux_cpf = If(rs.Fields("cpf").Value IsNot Nothing, rs.Fields("cpf").Value.ToString().Trim(), txt_usuario.Text.Trim())
                    Catch ex As Exception
                        aux_cpf = txt_usuario.Text.Trim()
                    End Try

                    Dim icargo As String = String.Empty
                    Try
                        icargo = If(rs.Fields(8).Value IsNot Nothing, rs.Fields(8).Value.ToString(), String.Empty)
                    Catch ex As Exception
                        icargo = String.Empty
                    End Try

                    If String.Compare(icargo, "Paciente", True) = 0 Then
                        Me.Hide()
                        frm_paciente.Show()
                    ElseIf String.Compare(icargo, "Administrador", True) = 0 Then
                        Me.Hide()
                        frm_menu.Show()
                    ElseIf String.Compare(icargo, "Recepcionista", True) = 0 Then
                        Me.Hide()
                        frm_menu_recepcionista.Show()
                    ElseIf String.Compare(icargo, "Médico(a)", True) = 0 Then
                        Me.Hide()
                        frm_menu_medico.Show()
                    Else
                        MsgBox("Cargo não reconhecido!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
                    End If
                End If
            Else
                MsgBox("Login Inválido!")
            End If
        Catch ex As Exception
            MsgBox("Erro ao gravar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub
End Class
