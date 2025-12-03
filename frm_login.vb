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
                MsgBox("Login Válido!")
                frm_menu.Show()
            Else
                MsgBox("Login Inválido!")
            End If
        Catch ex As Exception
            MsgBox("Erro ao gravar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub
End Class
