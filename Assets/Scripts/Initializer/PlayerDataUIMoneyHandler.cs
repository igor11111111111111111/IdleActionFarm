namespace Farm
{
    public class PlayerDataUIMoneyHandler
    {
        public void Init(PlayerData playerData, UIMoney uIMoney)
        {
            ShakeEffect shakeEffect = new ShakeEffect();

            playerData.OnMoneyChanged += (value) =>
            {
                uIMoney.Refresh(value);
                shakeEffect.Activate(uIMoney.transform);
            };
        } 
    }
}
