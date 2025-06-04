namespace Domain.Entities;

public class CategoryCatalog : BaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<CategoryOption>? CategoryOptions { get; set; }
    public ICollection<OptionQuestion>? OptionQuestions { get; set; }
}