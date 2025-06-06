using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class OptionResponseRepository : GenericRepository<OptionResponse>, IOptionResponseRepository
{
    protected readonly PublicDBContext _context;

    public OptionResponseRepository(PublicDBContext context) : base(context)
    {
        _context = context;
    }
}