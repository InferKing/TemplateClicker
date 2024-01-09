using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool _shopEnabled = false;
    public void ToggleShop()
    {
        _shopEnabled = !_shopEnabled;
        _animator.SetBool(Constants.animatorParameterToggle, _shopEnabled);
        ServiceLocator.Instance.Get<EventBus>().Invoke(new PlaySoundSignal(SoundConstants.Button));
    }
}
