using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        // Generate a new unique user ID for the user
        user.UserID = Guid.NewGuid();

        string query = "INSERT INTO public.\"users\"(\"userid\", \"email\", \"personname\", \"gender\", \"password\") VALUES(@userid, @email, @personname, @gender, @password)";

        int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

        if (rowCountAffected > 0)
        {
            return user;
        }
        
        return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        // SQL query to select a user by Email and Password
        string query = "SELECT * FROM public.\"users\" WHERE \"email\"=@email AND \"password\"=@password";

        var parameters = new { email, password };

        ApplicationUser?  user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
 
        return user;
    }
}