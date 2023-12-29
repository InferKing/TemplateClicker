public interface IModel : IService
{
    void UpdatePlayerInfo(PlayerInfo info);
    void Save();
    void Load();
}
