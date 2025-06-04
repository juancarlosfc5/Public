using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class OptionQuestionRepository : GenericRepository<OptionQuestion>, IOptionQuestionRepository
{
    protected readonly PublicDBContext _context;

    public OptionQuestionRepository(PublicDBContext context) : base(context)
    {
        _context = context;
    }
}