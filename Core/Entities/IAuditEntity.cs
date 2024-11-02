

namespace Core.Entities;

public interface IAuditEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedDate { get; set; }
}
