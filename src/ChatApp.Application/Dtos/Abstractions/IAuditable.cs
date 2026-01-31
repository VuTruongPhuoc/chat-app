public interface IAuditable : ICreateAuditable, IUpdateAuditable
{
}

public interface ICreateAuditable
{
    #region Fields, Properties

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    #endregion
}

public interface IUpdateAuditable
{
    #region Fields, Properties

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    #endregion
}