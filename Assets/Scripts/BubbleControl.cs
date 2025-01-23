using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleControl : MonoBehaviour
{
    private void Start()
    {
        var animator = GetComponent<Animator>();
        var state = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(state.fullPathHash, 0, Random.Range(0f, 1f));

        var bubbleScale = Random.Range(0f, 1f);
        transform.localScale = new Vector3(bubbleScale, bubbleScale, bubbleScale);

    }
}
