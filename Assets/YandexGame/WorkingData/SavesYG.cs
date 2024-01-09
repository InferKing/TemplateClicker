
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;
        public GameDetails gameData = new()
        {
            PlayerInfo = new PlayerInfo(0, 1, 0, true),
            ShopInfo = new ShopInfo(new System.Collections.Generic.Dictionary<string, int>()
                {
                    { Constants.keyPerClick, Constants.basePricePerClick },
                    { Constants.keyPerSecond, Constants.basePricePerSecond },
                    { Constants.keyCensorship, Constants.basePriceCensorship },
                    { Constants.keyAdvertisement, Constants.basePriceAdvertisement }
                }, 0)
        };
        public SavesYG()
        {
            
        }
    }
}
