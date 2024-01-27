using System.Collections.Generic;
using SoftGnet.Models;

namespace SoftGnet.Repository.Interfaces;

public interface IUsersInterface
{
    // Define los métodos y propiedades del interface aquí
    void CreateUser(Users user);
    void UpdateUser(Users user);
    void DeleteUser(int userId);
    Users GetUserById(int userId);
    List<Users> GetAllUsers();

    bool ValidateUser(string username, string password);

    Users GetUserByUsername(string email);

}
