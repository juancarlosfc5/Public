using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
{
    protected readonly PublicDBContext _context;

    public QuestionRepository(PublicDBContext context) : base(context)
    {
        _context = context;
    }
}