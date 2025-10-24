using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

public interface IUsersRepository
{
    /// <summary>
    /// Method to add user to data store
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);
    
    /// <summary>
    /// Method to retrieve existing user by email and password
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);

    /// <summary>
    /// Returns the users data based on the given user id
    /// </summary>
    /// <param name="userId">User id to search</param>
    /// <returns>ApplicationUser object that matches given User id</returns>
    Task<ApplicationUser?> GetUserByUserId(Guid? userId);
}