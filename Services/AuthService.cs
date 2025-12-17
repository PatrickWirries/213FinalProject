using _213FinalProject.Data;
using _213FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

public class AuthService
{
    private readonly _213FinalProjectContext _context;
    private readonly ProtectedSessionStorage _session;

    private const string USER_KEY = "loggedInUserId";
    private const string USER_ROLE = "USER_ROLE";
 
    public AuthService(_213FinalProjectContext context, ProtectedSessionStorage session)
    {
        _context = context;
        _session = session;
    }

    private bool _loggedIn;
    public bool LoggedIn => _loggedIn;
    public event Action? OnChange;
    private bool _initialized;


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

        // Determine and store user role
        if (_context.User.OfType<Manager>().Any(u => u.UserID == user.UserID))
        {
            await _session.SetAsync(USER_ROLE, "Manager");
        }
        else if (_context.User.OfType<Receptionist>().Any(u => u.UserID == user.UserID))
        {
            await _session.SetAsync(USER_ROLE, "Receptionist");
        }
        else if (_context.User.OfType<ServicePerforming>().Any(u => u.UserID == user.UserID))
        {
            await _session.SetAsync(USER_ROLE, "ServicePerforming");
        }
        else
        {
            await _session.SetAsync(USER_ROLE, "Customer");
        }
        _loggedIn = true;
        _initialized = true;
        OnChange?.Invoke();

        Console.WriteLine("[Login] Login successful!");
        return true;
    
        }

    /// <summary>
    /// Logs out the current user.
    /// </summary>
    public async Task LogoutAsync()
    {

        await _session.DeleteAsync(USER_KEY);
        _loggedIn = false;
        OnChange?.Invoke();
    }

    /// <summary>
    /// Returns true if a user is currently logged in.
    /// </summary>
    public async Task<bool> IsLoggedInAsync()
    {
        if (!_initialized)
            return false;

        return LoggedIn;

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

    //Gets the role of the currently logged-in user
    public async Task<String?> GetUserRoleAsync()
    {
        var result = await _session.GetAsync<string>(USER_ROLE);
        if (!result.Success)
            return null;
        return result.Value;
    }

    //Is Manager? True ; False
    public async Task<bool> IsManager()
    {
        var result = await _session.GetAsync<string>(USER_ROLE);
        if (!result.Success)
            return false;
        return result.Value == "Manager";
    }

    //Is Receptionist? True ; False
    public async Task<bool> IsReceptionist()
    {
        var result = await _session.GetAsync<string>(USER_ROLE);
        if (!result.Success)
            return false;
        return result.Value == "Receptionist";
    }

    //Is ServicePerforming? True ; False
    public async Task<bool> IsServicePerforming()
    {
        var result = await _session.GetAsync<string>(USER_ROLE);
        if (!result.Success)
            return false;
        return result.Value == "ServicePerforming";
    }

    //Is Customer? True ; False
    public async Task<bool> IsCustomer()
    {
        var result = await _session.GetAsync<string>(USER_ROLE);
        if (!result.Success)
            return false;
        return result.Value == "Customer";
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

    public void SetLoggedIn(bool value)
    {
        if (_loggedIn == value)
            return;

        _loggedIn = value;
        OnChange?.Invoke();
    }

    public async Task InitializeAsync()
    {
        var result = await _session.GetAsync<int>(USER_KEY);
        _loggedIn = result.Success && result.Value > 0;
        _initialized = true;
    }

}