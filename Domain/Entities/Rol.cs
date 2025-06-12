namespace Domain.Entities;

public class Rol : BaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    //public ICollection<Member> Members { get; set; } = new HashSet<Member>();
    public ICollection<MemberRols> MemberRols { get; set; } = new HashSet<MemberRols>();
}