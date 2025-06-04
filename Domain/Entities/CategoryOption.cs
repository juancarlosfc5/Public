namespace Domain.Entities;

public class CategoryOption : BaseEntity
{
    public int Id { get; set; }
    public int CategoryCatalog_Id { get; set; }
    public CategoryCatalog? CategoryCatalog { get; set; }
    public int OptionResponse_Id { get; set; }
    public OptionResponse? OptionResponse { get; set; }
}