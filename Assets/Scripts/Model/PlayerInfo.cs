[System.Serializable]
public class PlayerInfo
{
    public int money, perTap, autoClick;
    public bool musicEnabled;
    public PlayerInfo(int money, int perTap, int autoClick, bool musicEnabled)
    {
        this.money = money;
        this.perTap = perTap;
        this.autoClick = autoClick;
        this.musicEnabled = musicEnabled;
    }
    public override string ToString()
    {
        return $"Money: {money}, per tap: {perTap}, auto click: {autoClick}, music enabled: {musicEnabled}";
    }
}