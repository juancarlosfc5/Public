using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class SubQuestionRepository : GenericRepository<SubQuestion>, ISubQuestionRepository
{
    protected readonly PublicDBContext _context;

    public SubQuestionRepository(PublicDBContext context) : base(context)
    {
        _context = context;
    }
}