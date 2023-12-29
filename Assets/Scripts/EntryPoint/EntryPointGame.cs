using UnityEngine;

public class EntryPointGame : BaseEntryPoint 
{
    protected override void Awake()
    {
        base.Awake();
        // Pick another model if you want
        // TODO: Configuration
        ServiceLocator.Initialize();
        ServiceLocator.Instance.Register(Bus);
        ServiceLocator.Instance.Register(Model);
        Model = new YandexModel();
        Model.Load();
        foreach (IInitialize item in Inits)
        {
            item.Initialize();
        }
        Bus.Invoke(new GameInitializedSignal());
    }
    private void OnDisable()
    {
        ServiceLocator.Instance.Unregister<EventBus>();
        ServiceLocator.Instance.Unregister<IModel>();
    }
}
