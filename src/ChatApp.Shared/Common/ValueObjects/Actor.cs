namespace Common.ValueObjects;

public enum ActorType { User, System }

public readonly record struct Actor(ActorType Type, string Data)
{   
    #region Static Methods

    public static Actor User(string data) => new(ActorType.User, data);
    public static Actor System(string data) => new(ActorType.System, data);

    #endregion

    #region Overrides

    public override string ToString()
    {
        if (Type == ActorType.User) return Data;
        return $"{Type.ToString().ToLowerInvariant()}: {Data}";
    }

    #endregion
}