using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class SumaryOptionRepository : GenericRepository<SumaryOption>, ISumaryOptionRepository
{
    protected readonly PublicDBContext _context;

    public SumaryOptionRepository(PublicDBContext context) : base(context)
    {
        _context = context;
    }
}