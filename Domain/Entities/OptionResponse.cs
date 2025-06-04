namespace Domain.Entities;

public class OptionResponse : BaseEntity
{
    public int Id { get; set; }
    public string? Option_text { get; set; }
    public ICollection<CategoryOption>? CategoryOptions { get; set; }  
    public ICollection<OptionQuestion>? OptionQuestions { get; set; }  
}