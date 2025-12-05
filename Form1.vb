Imports System.Runtime.Remoting.Messaging

Public Class Form1
    Private Sub img_foto_Click(sender As Object, e As EventArgs) Handles img_foto.Click
        Try
            With OpenFileDialog1
                .Title = "Selecione uma Foto" 'titulo da janela das imagens
                .InitialDirectory = Application.StartupPath & "\fotos\"
                .ShowDialog()
                diretorio = .FileName
                diretorio = diretorio.Replace("\", "/")
                img_foto.Load(diretorio)

            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar a imagem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conecta_banco_mysql()
        carregar_dados()
        carregar_campos()

    End Sub

    Private Sub btn_gravar_Click(sender As Object, e As EventArgs) Handles btn_gravar.Click
        Try
            SQL = $"select * from tb_clientes_adsva2 where cpf='{txt_cpf.Text}'"
            rs = db.Execute(SQL)
            If rs.EOF = True Then
                SQL = $"insert into tb_clientes_adsva2 (cpf,nome,data_nasc,fone,email,foto,senha,cargo,status) values (
                       '{txt_cpf.Text}','{txt_nome.Text}','{cmb_data_nasc.Value.ToShortDateString}',
                       '{txt_fone.Text}','{txt_email.Text}','{diretorio}','{txt_senha.Text}','{cmb_cargo.Text}','{cmb_status.Text}')"
                rs = db.Execute(UCase(SQL))
                MsgBox("Dados gravados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")


            Else
                SQL = $"update tb_clientes_adsva2 set nome='{txt_nome.Text}',
                    data_nasc='{cmb_data_nasc.Value.ToShortDateString}',
                    fone='{txt_fone.Text}', email='{txt_email.Text}',
                    foto='{diretorio}', senha='{txt_senha.Text}', cargo='{cmb_cargo.Text}', status='{cmb_status.Text}' where cpf='{txt_cpf.Text}'"
                rs = db.Execute(UCase(SQL))
                MsgBox("Dados alterados com sucesso!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
            End If
            carregar_dados()
            limpar_cadastro()
        Catch ex As Exception
            MsgBox("Erro ao gravar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        Try
            SQL = $"select * from tb_clientes_adsva2 where {cmb_campo.Text} like '{txt_buscar.Text}%' order by nome asc"
            rs = db.Execute(SQL)
            With dgv_dados
                .Rows.Clear()
                cont = 1
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(5).Value, rs.Fields(7).Value,
                              rs.Fields(8).Value, rs.Fields(9).Value, Nothing, Nothing)
                    cont = cont + 1
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub dgv_dados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_dados.CellContentClick
        With dgv_dados
            If .CurrentRow.Cells(7).Selected = True Then
                aux_cpf = .CurrentRow.Cells(1).Value
                SQL = $"select * from tb_clientes_adsva2 where cpf='{aux_cpf}'"
                rs = db.Execute(SQL)
                diretorio = rs.Fields(6).Value
                If rs.EOF = False Then
                    txt_cpf.Text = rs.Fields(1).Value
                    txt_nome.Text = rs.Fields(2).Value
                    cmb_data_nasc.Text = rs.Fields(3).Value
                    txt_fone.Text = rs.Fields(4).Value
                    txt_email.Text = rs.Fields(5).Value
                    img_foto.Load(rs.Fields(6).Value)
                    txt_senha.Text = rs.Fields(7).Value
                    cmb_cargo.Text = rs.Fields(8).Value
                    cmb_status.Text = rs.Fields(9).Value
                End If
            ElseIf .CurrentRow.Cells(8).Selected = True Then
                aux_cpf = .CurrentRow.Cells(1).Value
                SQL = $"select * from tb_clientes_adsva2 where cpf='{aux_cpf}'"
                rs = db.Execute(SQL)
                If rs.EOF = False Then
                    resp = MsgBox("Deseja excluir o cpf: " & aux_cpf & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        SQL = $"delete from tb_clientes_adsva2 where cpf='{aux_cpf}'"
                        rs = db.Execute(SQL)
                        limpar_cadastro()
                        carregar_dados()

                    End If
                End If
            End If
        End With
    End Sub

    Private Sub txt_cpf_DoubleClick(sender As Object, e As EventArgs) Handles txt_cpf.DoubleClick
        limpar_cadastro()
    End Sub

    Private Sub txt_cpf_LostFocus(sender As Object, e As EventArgs) Handles txt_cpf.LostFocus
        Try
            SQL = $"select * from tb_clientes_adsva2 where cpf='{txt_cpf.Text}'"
            rs = db.Execute(SQL)
            If rs.EOF = True Then
                txt_nome.Focus()
            Else
                txt_cpf.BackColor = Color.Yellow
                MsgBox("CPF já cadastrado!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
                txt_cpf.Focus()
            End If
        Catch ex As Exception
            MsgBox("Erro de processamento!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_menu_Click(sender As Object, e As EventArgs) 
        Try
            frm_menu.Show()
            Me.Hide()
        Catch ex As Exception
            MsgBox("Erro ao abrir o Menu", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

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

    Private Sub DesconectarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesconectarToolStripMenuItem.Click
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

    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click
        Try
            frm_menu.Show()
            Me.Hide()
        Catch ex As Exception
            MsgBox("Erro ao abrir o Menu", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub
End Class
