namespace Application.Interfaces;

public interface IUnitOfWork
{
    ICategoryCatalogRepository CategoryCatalogs { get; }
    ICategoryOptionRepository CategoryOptions { get; }
    IChapterRepository Chapters { get; }
    IOptionQuestionRepository OptionQuestions { get; }
    IOptionResponseRepository OptionResponses { get; }
    IQuestionRepository Questions { get; }
    ISubQuestionRepository SubQuestions { get; }
    ISumaryOptionRepository SumaryOptions { get; }
    ISurveyRepository Surveys { get; }
    IMemberRepository Members { get; }
    IRolRepository Rols { get; }

    Task<int> SaveAsync();
}