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

    Task<int> SaveAsync();
}