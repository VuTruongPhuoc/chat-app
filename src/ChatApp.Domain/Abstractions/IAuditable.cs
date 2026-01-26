namespace ChatApp.Domain.Abtractions;

public interface IAuditable 
{
    #region Fields, Properties

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    #endregion
}
