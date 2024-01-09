public abstract class BaseModel : IService
{
    protected GameDetails gameDetails;
    public GameDetails GameDetails { get { return gameDetails; } }
    public abstract void Save();
    public abstract void Load();
    public virtual void UpdateGameDetails(GameDetails info) 
    { 
        gameDetails = info;
    }
}
