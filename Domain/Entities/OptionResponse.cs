namespace Domain.Entities;

public class OptionResponse
{
    public int Id { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string? Option_text { get; set; }
    public ICollection<CategoryOption>? CategoryOptions { get; set; }  
    public ICollection<OptionQuestion>? OptionQuestions { get; set; }  
}