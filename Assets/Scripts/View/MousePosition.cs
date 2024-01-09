using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class MousePosition : MonoBehaviour
{
    private Vector3 _position;
    private ParticleSystem _particleSystem;
    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        _position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _position.z = 0;
        transform.position = _position;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _particleSystem.Play();
        }
    }
}
