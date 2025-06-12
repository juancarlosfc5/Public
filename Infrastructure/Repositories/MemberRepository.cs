using Application.Interfaces; 
using Domain.Entities; 
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories; 
public class MemberRepository : GenericRepository<Member>, IMemberRepository { 
    protected readonly PublicDBContext _context;
    public MemberRepository(PublicDBContext context) : base(context)
    {
        _context = context;
    }
    public async Task<Member> GetByUsernameAsync(string username)
    {
        return await _context.Members
                        .Include(u=>u.Rols)
                        .FirstOrDefaultAsync(u=>u.Username.ToLower()==username.ToLower());
    }
}