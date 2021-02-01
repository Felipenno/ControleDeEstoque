using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.ViewModels;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace CDE.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataProviders _dataProviders;

        public UserRepository(DataProviders dataProviders)
        {
            _dataProviders = dataProviders;
        }

        public async Task<int> AddAsync(User user)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                return await connection.ExecuteAsync
                (
                    $@"
                       insert into 
	                        tb_user([user_name], user_email, user_password) 
                        Values
	                        (@UserName, @UserEmail, @UserPassword);
                            
                    ",
                    user
                );
            }
        }

        public async Task<string> EmailAlreadyExists(string email)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                return await connection. QueryFirstOrDefaultAsync<string>
                (
                    $@"
                        select user_email as UserEmail from tb_user where user_email = '{email}';   
                    "
                );
            }
        }

        public async Task<User> Login(UserLoginViewModel userLoginViewModel)
        {
            using (IDbConnection connection = _dataProviders.CDE_DbConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<User>
                (
                    $@"
                        select
                            [user_name] as UserName,
                            user_email as UserEmail,
                            user_password as UserPassword
                        from tb_user where user_email = @UserEmail and user_password = @UserPassword;
                    ",
                    userLoginViewModel
                );
            }
        }
    }
}
