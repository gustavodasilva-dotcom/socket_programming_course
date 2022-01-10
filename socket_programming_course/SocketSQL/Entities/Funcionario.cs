namespace SocketSQL.Entities
{
    public class Funcionario : EntityBase
    {
        public string Nome { get; set; }

        public Usuario Usuario { get; set; }
    }
}