using System;
using SocketSQL.Entities;
using SocketSQL.Repositories;

namespace SocketSQL.Services
{
    public class DadosService
    {
        public int GravarDados(string receivedText)
        {
            try
            {
                var dados = new DadosRepository();
                var usuario = new Usuario();
                var funcionario = new Funcionario();

                var texto = receivedText.Split(";");

                if (!string.IsNullOrEmpty(texto[0]) || !string.IsNullOrEmpty(texto[1]))
                {
                    usuario.Username = texto[0];
                    usuario.Password = texto[1];
                }
                else
                {
                    throw new Exception("Por favor, informar os dados do usuário.");
                }

                if (!string.IsNullOrEmpty(texto[2]))
                {
                    funcionario.Nome = texto[2];
                }
                else
                {
                    throw new Exception("Por favor, informar o nome do funcionário.");
                }

                usuario.ID = dados.InserirUsuario(usuario);

                funcionario.Usuario = usuario;

                return dados.InserirFuncionario(funcionario);
            }
            catch (Exception) { throw; }
        }
    }
}