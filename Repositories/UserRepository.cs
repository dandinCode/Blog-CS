using Blog.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using BCrypt.Net;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public void Create(User model)
        {
            model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
            _connection.Insert(model);
        }

        public void Update(User model)
        {
            User oldModel = _connection.Get<User>(model.Id);

            if (oldModel != null)
            {
                if (BCrypt.Net.BCrypt.Verify(model.PasswordHash, oldModel.PasswordHash))
                {
                    model.PasswordHash = oldModel.PasswordHash;
                    _connection.Update(model);
                    }
                else
                    Console.WriteLine("Senha incorreta.");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }


        public List<User> GetWithRoles()
        {
            var query = @"
            SELECT 
                [User].*,
                [Role].*
            FROM
                [User]
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();
            
            var items = _connection.Query<User, Role, User> (
                query,
                (user, role) => 
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);
                            
                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);
                    return user;
                }, splitOn: "Id");

            return users;
        }
    }
}