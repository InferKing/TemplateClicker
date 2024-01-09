public class ReceiverDataController : BaseController
{
    protected GameDetails _gameDetails;
    public override void Initialize()
    {
        base.Initialize();
        _bus.Subscribe<ModelLoadedSignal>(OnModelLoaded);
        _bus.Subscribe<ModelUpdatedSignal>(OnModelUpdated);
    }
    protected virtual void OnModelLoaded(ModelLoadedSignal signal)
    {
        _gameDetails = signal.data;
    }
    protected virtual void OnModelUpdated(ModelUpdatedSignal signal)
    {
        _gameDetails = signal.data;
    }
    public override bool TryDispose()
    {
        if (!base.TryDispose()) return false;
        _bus.Unsubscribe<ModelLoadedSignal>(OnModelLoaded);
        _bus.Unsubscribe<ModelUpdatedSignal>(OnModelUpdated);
        return true;
    }
}
