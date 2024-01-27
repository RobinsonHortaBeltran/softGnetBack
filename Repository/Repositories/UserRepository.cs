using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoftGnet.Models;
using SoftGnet.Repository.Interfaces;

namespace SoftGnet.Repository.Repositories;
public class UserRepository : IUsersInterface
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    // Implementa los métodos de la interfaz aquí
    public void CreateUser(Users user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void DeleteUser(int userId)
    {
        var user = _context.Users.Find(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    public List<Users> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public Users GetUserById(int userId)
    {
        var user = _context.Users.Find(userId);
        return user != null ? user : throw new ArgumentNullException(nameof(user));
    }

    public Users GetUserByUsername(string Email)
    {
        if (Email == null)
        {
            throw new ArgumentNullException(nameof(Email), "El correo electrónico no puede ser nulo.");
        }
        var user = _context.Users.FirstOrDefault(u => u.Email == Email);
        return user;
    }

    public void UpdateUser(Users user)
    {
        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public bool ValidateUser(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        return user != null && VerifyPasswordHash(password, user.Password);
    }

    private bool VerifyPasswordHash(string password, string storedHash)
    {
        if (storedHash == null)
        {
            throw new ArgumentNullException(nameof(storedHash));
        }
        return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }
}
