namespace Domain.Entities;

public class MemberRols : BaseEntity
{
    public int MemberId { get; set; }
    public Member? Member { get; set; }
    public int RolId { get; set; } 
    public Rol? Rol { get; set; }
    
}