using Domain.Entities;

namespace Application.Interfaces;

public interface IMemberRepository : IGenericRepository<Member>
{
    Task<Member> GetByUsernameAsync(string username);
    Task<Member> GetByRefreshTokenAsync (string refreshtoken);
}