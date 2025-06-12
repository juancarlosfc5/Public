using Application.Interfaces; 
using Domain.Entities; 
using Infrastructure.Data; 
namespace Infrastructure.Repositories; 
public class RolRepository : GenericRepository<Rol>, IRolRepository { 
    private readonly PublicDBContext _context;
    public RolRepository(PublicDBContext context) : base(context)
    {
        _context = context;
    } 
} 