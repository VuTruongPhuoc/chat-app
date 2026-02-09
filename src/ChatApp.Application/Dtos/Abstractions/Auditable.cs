namespace ChatApp.Application.Dtos.Abstractions;

public abstract class Auditable : IAuditable
{
    #region Fields, Properties

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? CreatedBy { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public string? UpdatedBy { get; set; }

    #endregion
}