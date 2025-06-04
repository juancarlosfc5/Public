namespace Domain.Entities;

public class CategoryOption
{
    public int Id { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public int CategoryCatalog_Id { get; set; }
    public CategoryCatalog? CategoryCatalog { get; set; }
    public int OptionResponse_Id { get; set; }
    public OptionResponse? OptionResponse { get; set; }
}