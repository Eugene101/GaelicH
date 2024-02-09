using UnityEngine;

public class GKJump : State
{
    Goalkeeper _goalKeeper;
    public GKJump(Goalkeeper GolaKipper)
    {
        _goalKeeper = GolaKipper;
    }
    public override void Enter()
    {

        Debug.Log("Code for Jump while Entering");
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

    public override void Exit()
    {
        Debug.Log("Code for Jump while Exiting");
        
    }

    public override void Update()
    {
        Debug.Log("Code for Jump while Updating");

    }

    //private void Start()
    //{

    //    anim = GetComponent<Animator>();
    //}
    //public void SelectSide()
    //{
    //    int side = Random.Range(0, 2);
    //    if (side == 0)
    //    {
    //        JumpLeft();
    //    }
    //    else if (side == 1)
    //    {
    //        JumpRight();
    //    }
    //}

    private void JumpLeft()
    {
        _goalKeeper.animator.SetInteger("GkAnimState", 2);
        _goalKeeper.animator.Play("LowDiveLeftStart");
    }

    void JumpRight()
    {
        _goalKeeper.animator.SetInteger("GkAnimState", 1);
        _goalKeeper.animator.Play("LowDiveRightStart");
    }
}
