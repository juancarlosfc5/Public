using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class CategoryCatalogRepository : GenericRepository<CategoryCatalog>, ICategoryCatalogRepository
{
    protected readonly PublicDBContext _context;

    public CategoryCatalogRepository(PublicDBContext context) : base(context)
    {
        _context = context;
    }
}