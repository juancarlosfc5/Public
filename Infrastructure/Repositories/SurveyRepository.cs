using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class SurveyRepository : GenericRepository<Survey>, ISurveyRepository
{
    protected readonly PublicDBContext _context;

    public SurveyRepository(PublicDBContext context) : base(context)
    {
        _context = context;
    }
}