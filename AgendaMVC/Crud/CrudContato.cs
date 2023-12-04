using System;
using System.Collections.Generic;
using System.Data;
using AgendaMVC.Interface;
using AgendaMVC.Models;
using MySql.Data.MySqlClient;

namespace AgendaMVC.Crud
{
    public class CrudContato : Icrud<Contato>
    {
        private readonly string _connectionString = "Server=localhost;Database=agenda;Uid=root;Pwd=123456;";

        public Contato Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contato> Consultar()
        {
            List<Contato> contatos = new List<Contato>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("SELECT * FROM contato", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contato contato = new Contato
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Email = reader["email"].ToString(),
                                Telefone = reader["telefone"].ToString()
                            };

                            contatos.Add(contato);
                        }
                    }
                }
            }

            return contatos;
        }

        public void Deletar(int id)
        {
            MySqlConnection con = new MySqlConnection(_connectionString);
            MySqlCommand command = con.CreateCommand();

            try
            {
                con.Open();
                command.CommandText = "DELETE FROM contato WHERE id = @id";

                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                
                command.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            };
           
        }

        public bool Editar(Contato t)
        {
            throw new NotImplementedException();
        }

        public bool salvar(Contato contato)
        {
            MySqlConnection con = new MySqlConnection(_connectionString);
            MySqlCommand command = con.CreateCommand();

            try
            {
                con.Open();
                command.CommandText = "insert into contato(nome, email, telefone) values (@nome, @email, @telefone)";

                command.Parameters.Add("@nome", MySqlDbType.VarChar).Value = contato.Nome;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = contato.Email;
                command.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = contato.Telefone;
                command.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }
    }
}
