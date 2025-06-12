namespace Domain.Entities;

public class RefreshToken : BaseEntity
{
    public int Id { get; set; }
    public string? MemberId { get; set; }
    public Member? Member { get; set; }
    public string? Token { get; set; }
    public DateTime Expires { get; set; }
    public bool IsExpire => DateTime.UtcNow >= Expires;
    public DateTime Created { get; set; }
    public DateTime? Revoked { get; set; }
    public bool IsActive => Revoked == null && !IsExpire;
}