public struct PlayerInfo
{
    public int money;
    public int perTap;
    public PlayerInfo(int money, int perTap)
    {
        this.money = money;
        this.perTap = perTap;
    }
    public override readonly string ToString()
    {
        return $"Money: {money}, per tap: {perTap}";
    }
}