Public Class frm_autocadastro
    Private Sub frm_autocadastro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_criar.Click
        Try
            SQL = $"select * from tb_clientes_adsva2 where cpf='{txt_cpf.Text}'"
            rs = db.Execute(SQL)
            If rs.EOF = True Then
                SQL = $"insert into tb_clientes_adsva2 (cpf,nome,data_nasc,fone,email,foto,senha,cargo,status) values (
                       '{txt_cpf.Text}','{txt_nome.Text}','{cmb_data_nasc.Value.ToShortDateString}',
                       '{txt_fone.Text}','{txt_email.Text}','{diretorio}','{txt_senha.Text}','Paciente','Ativo')"
                rs = db.Execute(UCase(SQL))
                MsgBox("Dados gravados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")



            End If
            carregar_dados()
            limpar_cadastro()
        Catch ex As Exception
            MsgBox("Erro ao criar a conta!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub
End Class