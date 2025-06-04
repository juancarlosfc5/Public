namespace Domain.Entities;

public class OptionQuestion : BaseEntity
{
    public int Id { get; set; }
    public string? Comment_optionres { get; set; }
    public string? Number_option { get; set; }
    public int Question_Id { get; set; }
    public Question? Question { get; set; }
    public int SubQuestion_Id { get; set; }
    public SubQuestion? SubQuestion { get; set; }
    public int CategoryCatalog_Id { get; set; }
    public CategoryCatalog? CategoryCatalog { get; set; }
    public int OptionResponse_Id { get; set; }
    public OptionResponse? OptionResponse { get; set; }
}