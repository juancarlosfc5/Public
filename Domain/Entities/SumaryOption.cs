namespace Domain.Entities;

public class SumaryOption
{
    public int Id { get; set; }
    public string? Code_number { get; set; }
    public string? Valuerta { get; set; }
    public int Survey_Id { get; set; }
    public Survey? Survey { get; set; }
    public int Question_Id { get; set; }
    public Question? Question { get; set; }
}