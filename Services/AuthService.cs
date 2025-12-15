using _213FinalProject.Data;
using _213FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

public class AuthService
{
    private readonly _213FinalProjectContext _context;
    private readonly ProtectedSessionStorage _session;

    private const string USER_KEY = "loggedInUserId";

    public AuthService(_213FinalProjectContext context, ProtectedSessionStorage session)
    {
        _context = context;
        _session = session;
    }

    /// <summary>
    /// Attempts to log in a user by email and password (plain-text).
    /// </summary>
    public async Task<bool> LoginAsync(string email, string password)
    {
        // Trim input to avoid whitespace issues
        email = email.Trim();
        password = password.Trim();

        Console.WriteLine($"[Login] Attempting login for email: '{email}' with password: '{password}'");

        // Fetch user by email only
        var user = await _context.User.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

        if (user == null)
        {
            Console.WriteLine("[Login] No user found with this email.");
            return false;
        }

        // Compare password manually
        if (user.PasswordHash != password)
        {
            Console.WriteLine("[Login] Password mismatch.");
            return false;
        }

        // Store user ID in session
        await _session.SetAsync(USER_KEY, user.UserID);
        Console.WriteLine("[Login] Login successful!");
        return true;
    }

    /// <summary>
    /// Logs out the current user.
    /// </summary>
    public async Task LogoutAsync()
    {
        await _session.DeleteAsync(USER_KEY);
        Console.WriteLine("[Logout] User logged out.");
    }

    /// <summary>
    /// Returns true if a user is currently logged in.
    /// </summary>
    public async Task<bool> IsLoggedInAsync()
    {
        var result = await _session.GetAsync<int>(USER_KEY);
        return result.Success;
    }

    /// <summary>
    /// Returns the currently logged-in user, or null if none.
    /// </summary>
    public async Task<User?> GetCurrentUserAsync()
    {
        var result = await _session.GetAsync<int>(USER_KEY);
        if (!result.Success)
            return null;

        return await _context.User.FindAsync(result.Value);
    }

    /// <summary>
    /// Validate user registration details and create a new user if valid.
    /// </summary>
    public async Task<bool> IsUser(string email, string password, string firstName, string lastName)
    {
        var result = await _context.User.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

        //If result is not null, user with email already exists
        if (result != null)
        {
            return false;
        }
        //Validate input lengths
        if (password.Length < 5 || password.Length > 128
            || firstName.Length == 0 || firstName.Length > 50
            || lastName.Length == 0 || lastName.Length > 50
            || email.Length == 0 || email.Length > 254)
        {
            return false;
        }

        User newUser = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PasswordHash = password
        };
        _context.User.Add(newUser);
        _context.SaveChanges();
        return true;
    }

    ///<summary>
    /// Validate if email is in use and password is valid, set new password
    /// </summary>
    public async Task<bool> IsUser(string email, string password)
    {
            var result = await _context.User.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            if (result != null)
            {
                result.PasswordHash = password;
                _context.User.Update(result);
                _context.SaveChanges();
            return true;
            }
        
        return false;
    }
}