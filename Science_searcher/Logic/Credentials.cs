using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Science_searcher.Models;

namespace Science_searcher.Logic
{
    public class Credentials
    {
        public static string _Login;
        public static string _Password;

        private readonly ILogger<Credentials> _logger;

        public Credentials(string Login, string Password)
        {
            _Login = Login;
            _Password = Password;
        }

        public void Hash_Password(string Login, string Password)
        {
            _logger.LogInformation("Hashing password for user: "+Login+"");
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(projectPath).AddJsonFile("appsettings.json").Build();
            string userConnectionString = configuration.GetConnectionString("users");

            _logger.LogInformation("Verifing are the user: " + Login + " exist.");
            //verifing are the user with provided login exists
            try
            {
                using (SqlConnection conn = new SqlConnection(userConnectionString))
                {
                    string commandText = "SELECT * FROM [users].[dbo].[t_Users] WHERE [Login] = '@ProvidedLogin'";
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProvidedLogin", Login);
                        conn.Open();
                        var RowCounter = cmd.ExecuteReader();

                        if (RowCounter.HasRows)
                        {
                            _logger.LogInformation("User: "+Login+ " exists in [users].[dbo].[t_Users]. Return  from Hash_Password");
                            //Show the information on the page that user exists in database.
                            return;
                        }
                        else
                            _logger.LogInformation("User: " + Login + " doesn't exists in [users].[dbo].[t_Users]. ");

                        conn.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Exception occured verifing are the provieded username exists in the [users].[dbo].[t_Users]");
                return;
            }

            //Generate salt
            string salt = BCrypt.Net.BCrypt.GenerateSalt(15, SaltRevision.Revision2B);
            //Hash the password
            _Password = BCrypt.Net.BCrypt.HashPassword(Password, salt);

            //save Login and Password to database
            try
            {
                TUsers user = new TUsers();
                user.Login = _Login;
                user.Password = _Password;

                using (var userDbContext = new usersContext())
                {
                    userDbContext.Add(user);
                    userDbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Exception occured during INSERT the user data to [users].[dbo].[t_Users]");
            }

            //select Id from database of the records
            int _UserId = 0;
            using (var userDbContext = new usersContext())
                _UserId = userDbContext.TUsers.Where(u => u.Login == _Login).Select(s=>s.Id).FirstOrDefault();

            try
            {
                TUserPwdGen credentialAdditionalInfo = new TUserPwdGen();
                credentialAdditionalInfo.Salt = salt;
                credentialAdditionalInfo.UserId = _UserId;
                using (var credentialDbContext = new credential_dbContext())
                {
                    credentialDbContext.Add(credentialAdditionalInfo);
                    credentialDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured during saving the salt to [credential_db].[dbo].[t_UserPwdGen]");
                return;
            }

        }



    }
}
