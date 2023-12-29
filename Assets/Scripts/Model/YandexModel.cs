using YG;

public class YandexModel : IModel
{
    public PlayerInfo PlayerInfo { get; private set; }
    public void Load()
    {
        YandexGame.LoadProgress();
        PlayerInfo = YandexGame.savesData.playerInfo;
#if UNITY_EDITOR
        UnityEngine.Debug.Log(PlayerInfo.ToString());
#endif
    }

    public void Save()
    {
        YandexGame.savesData.playerInfo = PlayerInfo;
        YandexGame.SaveProgress();
    }

    public void UpdatePlayerInfo(PlayerInfo info)
    {
        PlayerInfo = info;
    }
}
