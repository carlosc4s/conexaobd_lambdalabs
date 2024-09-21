using Oracle.ManagedDataAccess.Client;
using System;

namespace MeuProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            // Diretório onde o Wallet foi descompactado
            string tnsAdminPath = @"C:\Users\Carlos\Downloads\Wallet_lambdalabs";

            // Nome do tipo de serviço (pode ser `lambdalabs_high`, `lambdalabs_medium`, ou `lambdalabs_low`)
            string serviceName = "lambdalabs_low";

            // chave de conexão ao bd
            string connectionString = $"User Id=ADMIN;Password=200319@Lambdalabs;Data Source={serviceName};" +
                                      $"TNS_ADMIN={tnsAdminPath}";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexão bem-sucedida!");

                    // Comando SQL de inserção de dados na tabela no database autonomous oracle
                    string sql = "INSERT INTO CHALLENGE_SANOFI (ID_ARQ, NOME_ARQ, TIPO_ARQ, HASH_ARQ) VALUES (:ID_ARQ, :NOME_ARQ, :TIPO_ARQ, :HASH_ARQ)";

                    // Criando o comando
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        // Adicionando parâmetros
                        command.Parameters.Add(new OracleParameter("ID_ARQ", 2));
                        command.Parameters.Add(new OracleParameter("NOME_ARQ", "excel"));
                        command.Parameters.Add(new OracleParameter("TIPO_ARQ", "csv"));
                        command.Parameters.Add(new OracleParameter("HASH_ARQ", "fdgfjkdhgsadash"));

                        // Executando o comando
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} linha(s) inserida(s) com sucesso.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }
    }
}

