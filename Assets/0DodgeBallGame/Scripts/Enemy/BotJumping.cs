using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotJumping : BotStatePattern
{
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void SelectSide()
    {
        int side = Random.Range(0, 2);
        if (side == 0)
        {
            JumpLeft();
        }
        else if (side == 1)
        {
            JumpRight();
        }
    }    

    void JumpLeft()
    {
        anim.SetInteger("EnemyBehavoir", 14);
        anim.Play("LowDiveLeftStart");
        print("VasianLeft");
        Invoke("Idle", 1.4f);
    }

    void JumpRight() 
    {
        anim.SetInteger("EnemyBehavoir", 55);
        anim.Play("LowDiveRightStart");
        print("VasianRight");
        Invoke("Idle", 3f);
    }
   
}
