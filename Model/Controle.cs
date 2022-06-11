using Ahead___Estevao.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahead___Estevao.Modelo
{
    public class Controle
    {
        public bool tem;
        public String mensagem = "";
    
        public bool acessar(String login, String senha)
        {
            LoginDalComandos loginDal = new LoginDalComandos();
            tem = loginDal.verificarLogin(login, senha);
            if (!loginDal.mensagem.Equals(""))
                {
                    this.mensagem = loginDal.mensagem;
                }
            return tem;
        }

        public String cadastrar(String email, String senha, String confSenha)
        {
            LoginDalComandos loginDal = new LoginDalComandos();
            this.mensagem = loginDal.cadastrar(email, senha, confSenha);
            if (loginDal.tem)
            {
                this.tem = true;
            }
            return mensagem;
        }
    }
}

