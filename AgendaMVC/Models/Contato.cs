namespace AgendaMVC.Models
{
	public class Contato
	{
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Contato() { }

        public Contato(int id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
        public Contato(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
        public Contato(int id)
        {
            Id = id;
        }
    }
}
