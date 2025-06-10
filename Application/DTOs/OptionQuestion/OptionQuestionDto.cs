namespace Application.DTOs;

public class OptionQuestionDto
{
    public int Id { get; set; }
    public string? Comment_optionres { get; set; }
    public string? Number_option { get; set; }
    public int Question_Id { get; set; }
    public int SubQuestion_Id { get; set; }
    public int CategoryCatalog_Id { get; set; }
    public int OptionResponse_Id { get; set; }
}