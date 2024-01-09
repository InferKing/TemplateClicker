using System.Collections.Generic;
using System.Text;

[System.Serializable]
public class ShopInfo
{
    public Dictionary<string, int> prices;
    public int censorshipCount;
    public ShopInfo(Dictionary<string, int> prices, int censorshipCount)
    {
        this.prices = prices;
        this.censorshipCount = censorshipCount;
    }
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append("prices: {");
        foreach (KeyValuePair<string, int> kvp in prices)
        {
            sb.Append(kvp.Key);
            sb.Append(": ");
            sb.Append(kvp.Value);
            sb.Append(", ");
        }
        sb.Append("}, censorshipCount: ");
        sb.Append(censorshipCount);
        return sb.ToString();
    }
}
