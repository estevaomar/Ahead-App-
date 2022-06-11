using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahead___Estevao.DAL
{
    class LoginDalComandos
    {
        public bool tem = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;
        public bool verificarLogin(String login, String senha)
        {
            // Para verificar tem no SQL 
            cmd.CommandText = "select * from logins where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    {
                        tem = true;
                    }
                con.desconectar();
                dr.Close();
            }
            catch (SqlException)
            {
                this.mensagem = "Database error!";
            }
            return tem; 
        }

        public String cadastrar(String email, String senha, String confSenha)
        {
            tem = false;
            // Comandos para Inserir 
            if (senha.Equals(confSenha))
            {
                cmd.CommandText = "insert into logins values (@e,@s);";
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@s", senha);

                try
                {
                    cmd.Connection = con.conectar();
                    cmd.ExecuteNonQuery();
                    con.desconectar();
                    this.mensagem = "Successfully registered!";
                    tem = true;
                }
                catch (SqlException)
                {
                    this.mensagem = "Database error!";
                }
            }
            else
            {
                this.mensagem = "Password not matching!";
            }
            return mensagem;
        }
    }
}
