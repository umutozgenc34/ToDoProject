

namespace Core.Entities;

public interface IAuditEntity
{
    
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
