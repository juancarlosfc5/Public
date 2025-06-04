namespace Domain.Entities;

public class SubQuestion
{
    public int Id { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string? Subquestion_number { get; set; }
    public string? Comment_subquestion { get; set; }
    public string? Subquestion_text { get; set; }
    public int Question_Id { get; set; }
    public Question? Question { get; set; }
}