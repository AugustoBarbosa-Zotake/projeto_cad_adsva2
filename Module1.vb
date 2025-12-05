Imports System.Resources

Module Module1
    Public diretorio, SQL, resp, aux_cpf As String
    Public db As ADODB.Connection 'variavel do bando
    Public rs As New ADODB.Recordset 'variavel das tabelas
    Public cont As Integer

    Sub conecta_banco_mysql()
        Try
            db = CreateObject("ADODB.Connection")
            db.Open("DRIVER={MySQL ODBC 3.51 Driver};SERVER=localhost;DATABASE=cad_clientes;UID=root;PWD=usbw;port=3307;option3;")
            MsgBox("Conexão OK", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")

        Catch ex As Exception
            MsgBox("Erro ao Conectar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub
    Sub limpar_cadastro()
        Try
            With Form1
                .txt_cpf.BackColor = Color.White
                .txt_cpf.Clear()
                .txt_nome.Clear()
                .cmb_data_nasc.Value = Now
                .txt_fone.Clear()
                .txt_email.Clear()
                .img_foto.Load(Application.StartupPath & "\fotos\nova foto.png")
                .txt_cpf.Focus()

            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub carregar_dados()
        Try
            SQL = $"select * from tb_clientes_adsva2 order by nome asc"
            rs = db.Execute(SQL)
            With Form1.dgv_dados
                .Rows.Clear()
                cont = 1
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(5).Value, rs.Fields(7).Value, rs.Fields(8).Value, rs.Fields(9).Value, Nothing, Nothing)
                    cont = cont + 1
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Sub carregar_campos()
        Try
            With Form1.cmb_campo.Items
                .Add("CPF")
                .Add("Nome")
                .Add("Email")
            End With
            Form1.cmb_campo.SelectedIndex = 1
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Sub limpar_login()
        Try
            With frm_login
                .txt_usuario.Clear()
                .txt_senha.Clear()
                .txt_usuario.Focus()
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
End Module
