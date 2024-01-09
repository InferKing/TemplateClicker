using UnityEngine;

public class BaseController : MonoBehaviour, IInitialize, IDisposable
{
    protected EventBus _bus;
    public virtual void Initialize()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
    }
    public virtual bool TryDispose()
    {
        return _bus != null;
    }
    protected virtual void OnDisable()
    {
        TryDispose();
    }
}
