using System.Collections.Generic;
using UnityEngine;

public class BaseEntryPoint : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] _controllers;
    private List<IInitialize> _inits = new();
    private EventBus _bus;
    protected IModel Model { get; set; }
    protected EventBus Bus => _bus;
    protected IReadOnlyList<IInitialize> Inits => _inits; 
    private void OnValidate()
    {
        ValidateServices();
    }
    protected virtual void Awake()
    {
#if !UNITY_EDITOR
        ValidateServices();
#endif
        _bus = new EventBus();
    }
    private void ValidateServices()
    {
        _inits.Clear();
        foreach (var controller in _controllers)
        {
            if (controller is IInitialize initialize)
            {
                _inits.Add(initialize);
            }
            else
            {
#if UNITY_EDITOR
                Debug.LogWarning($"Object {controller} can't be cast to type IInitialize");
#endif
            }
        }
    }
}