using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionSystem : MonoBehaviour
{
    private GameObject transitionImage;

    private Animator anim;

    private void Awake()
    {
        transitionImage = GetComponentInChildren<Transform>().gameObject;
        anim = GetComponentInChildren<Animator>();

        transitionImage.SetActive(true);
    }

    public void Transition_GoBig()
    {
        transitionImage.SetActive(true);
        anim.SetTrigger("GoBig");
    }
}
