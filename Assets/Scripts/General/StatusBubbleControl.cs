using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBubbleControl : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    void Start()
    {
        var state = _animator.GetCurrentAnimatorStateInfo(0);
        _animator.Play(state.fullPathHash, 0, Random.Range(0f, 1f));
    }
}
