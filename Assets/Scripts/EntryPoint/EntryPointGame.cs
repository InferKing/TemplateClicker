public class EntryPointGame : BaseEntryPoint 
{
    protected override void Awake()
    {
        base.Awake();
        ServiceLocator.Initialize();
        ServiceLocator.Instance.Register(Bus);
        foreach (IInitialize item in Inits)
        {
            item.Initialize();
        }
        Bus.Invoke(new GameInitializedSignal());
    }
    private void OnDisable()
    {
        ServiceLocator.Instance.Unregister<EventBus>();
    }
}
