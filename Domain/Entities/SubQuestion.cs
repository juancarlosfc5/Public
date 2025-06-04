namespace Domain.Entities;

public class SubQuestion : BaseEntity
{
    public int Id { get; set; }
    public string? Subquestion_number { get; set; }
    public string? Comment_subquestion { get; set; }
    public string? Subquestion_text { get; set; }
    public int Question_Id { get; set; }
    public Question? Question { get; set; }
    public ICollection<OptionQuestion>? OptionQuestions { get; set; }
}