namespace Domain.Entities;

public class Question
{
    public int Id { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string? Question_number { get; set; }
    public string? Response_type { get; set; }
    public string? Comment_question { get; set; }
    public string? Question_text { get; set; }
    public int Chapter_Id { get; set; }
    public Chapter? Chapter { get; set; }
    public ICollection<SubQuestion>? SubQuestions { get; set; }
    public ICollection<SumaryOption>? SumaryOptions { get; set; }
}