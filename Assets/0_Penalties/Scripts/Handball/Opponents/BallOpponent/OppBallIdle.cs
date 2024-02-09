using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppBallIdle : State
{
    OppBallBase _oppBallBase;
    public OppBallIdle (OppBallBase oppBallBase)
    {
        _oppBallBase = oppBallBase;
    }

    public override void Enter()
    {
        _oppBallBase.transform.position = Vector3.one * 1000;
        _oppBallBase.rb.detectCollisions = false;
        _oppBallBase.rb.isKinematic = true;
        _oppBallBase.rb.useGravity = false;
    }

    public override void Exit()
    {
      
    }

    public override void Update()
    {
        
    }

}
