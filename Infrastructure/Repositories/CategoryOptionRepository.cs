using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class CategoryOptionRepository : GenericRepository<CategoryOption>, ICategoryOptionRepository
{
    protected readonly PublicDBContext _context;

    public CategoryOptionRepository(PublicDBContext context) : base(context)
    {
        _context = context;
    }
}