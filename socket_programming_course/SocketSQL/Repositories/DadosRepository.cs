using Dapper;
using System;
using System.Data.SqlClient;
using SocketSQL.Entities;

namespace SocketSQL.Repositories
{
    public class DadosRepository
    {
        private string _connectionString { get; set; }

        public DadosRepository()
        {
            _connectionString = @"Data Source=DESKTOP-8J62RD3\SQLEXPRESS;Initial Catalog=ATIVIDADE_HOTEL;Integrated Security=True;Connect Timeout=30";
        }

        public int InserirUsuario(Usuario usuario)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    #region SQL

                    var query =
                    @"  BEGIN TRANSACTION;
                    
                            BEGIN TRY
                            
                                INSERT INTO USUARIO
                                VALUES
                                (
	                                 @usuario
	                                ,@senha
	                                ,1
	                                ,GETDATE()
                                );

                            END TRY

                            BEGIN CATCH

                                IF @@TRANCOUNT > 0
                                    ROLLBACK TRANSACTION;

                            END CATCH;

                        IF @@TRANCOUNT > 0
                            COMMIT TRANSACTION;

                        DECLARE @UsuarioId INT = @@IDENTITY;

                        SELECT @UsuarioId;";

                    #endregion

                    return db.ExecuteScalar<int>(query, new
                    {
                        @usuario = usuario.Username,
                        @senha = usuario.Password
                    },
                    commandTimeout: 30);
                }
            }
            catch (Exception) { throw; }
        }

        public int InserirFuncionario(Funcionario funcionario)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    #region SQL

                    var query =
                    @"BEGIN TRANSACTION;

                        BEGIN TRY

                            INSERT INTO FUNCIONARIO
		                    VALUES
		                    (
			                     @nome
			                    ,1
			                    ,@usuarioId
			                    ,GETDATE()
		                    );

                        END TRY

                        BEGIN CATCH

                            IF @@TRANCOUNT > 0
                                ROLLBACK TRANSACTION;

                        END CATCH;

                    IF @@TRANCOUNT > 0
                        COMMIT TRANSACTION;

                    DECLARE @FuncionarioId INT = @@IDENTITY;

                    SELECT @FuncionarioId;";
                    
                    #endregion

                    return db.ExecuteScalar<int>(query, new
                    {
                        @nome = funcionario.Nome,
                        @usuarioId = funcionario.Usuario.ID
                    },
                    commandTimeout: 30);
                }
            }
            catch (Exception) { throw; }
        }
    }
}