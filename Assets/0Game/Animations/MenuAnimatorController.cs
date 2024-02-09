using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimatorController : MonoBehaviour
{
    Animator anim;
    int animationCount;
    void Start()
    {
        anim = GetComponent<Animator>();
        animationCount = anim.runtimeAnimatorController.animationClips.Length;
        InvokeRepeating("SwitchAnimation", 0.1f, 5f);
    }


    void SwitchAnimation()
    {
        int ranim = Random.Range(0, animationCount);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            anim.SetInteger("AnimNumber", ranim);
        }
    }
}
