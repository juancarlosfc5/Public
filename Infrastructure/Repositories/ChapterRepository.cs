using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class ChapterRepository : GenericRepository<Chapter>, IChapterRepository
{
    protected readonly PublicDBContext _context;

    public ChapterRepository(PublicDBContext context) : base(context)
    {
        _context = context;
    }
}