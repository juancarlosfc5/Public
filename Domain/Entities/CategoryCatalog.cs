namespace Domain.Entities;

public class CategoryCatalog
{
    public int Id { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string? Name { get; set; }
    public ICollection<CategoryOption>? CategoryOptions { get; set; }
    public ICollection<OptionQuestion>? OptionQuestions { get; set; }
}