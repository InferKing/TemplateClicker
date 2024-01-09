using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Censorship : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void AnimateHide()
    {
        _animator.SetBool(Constants.animatorParameterToggle, true);
    }
    public void StartState(bool hide)
    {
        gameObject.SetActive(!hide);
    }
}
