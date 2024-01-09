using UnityEngine;

public class GameController : BaseController
{
    private BaseModel _model;
    public override void Initialize()
    {
        base.Initialize();
        _bus.Subscribe<GameInitializedSignal>(OnGameInitialized);
        _bus.Subscribe<UpdateModelSignal>(OnUpdateModel);
        _model = new YandexModel();
        _model.Load();
    }
    private void OnGameInitialized(GameInitializedSignal signal)
    {
        _bus.Invoke(new ModelLoadedSignal(_model.GameDetails));
        _bus.Invoke(new PlaySoundSignal(SoundConstants.Music));
    }
    private void OnUpdateModel(UpdateModelSignal signal)
    {
        _model.UpdateGameDetails(signal.data);
        _model.Save();
        _bus.Invoke(new ModelUpdatedSignal(_model.GameDetails));
    }
    public override bool TryDispose()
    {
        if (!base.TryDispose()) return false;
        _bus.Unsubscribe<GameInitializedSignal>(OnGameInitialized);
        _bus.Unsubscribe<UpdateModelSignal>(OnUpdateModel);
        return true;
    }
}
