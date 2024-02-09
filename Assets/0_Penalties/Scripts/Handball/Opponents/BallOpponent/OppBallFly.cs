using UnityEngine;

public class OppBallFly : State
{
    OppBallBase _oppBallBase;

    // Start is called before the first frame update
    public OppBallFly(OppBallBase oppBallBase)
    {
        _oppBallBase = oppBallBase;
    }

    public override void Enter()
    {
        _oppBallBase.transform.parent = null;
        _oppBallBase.rb.detectCollisions = true;
        _oppBallBase.rb.isKinematic = false;
        _oppBallBase.rb.useGravity = true;
    }

    public override void Exit()
    {
        _oppBallBase.rb.detectCollisions = false;
        _oppBallBase.rb.isKinematic = true;
        _oppBallBase.rb.useGravity = false;
    }

    public override void Update()
    {
        _oppBallBase.transform.position = Vector3.Slerp(_oppBallBase.transform.position, _oppBallBase.ballTarget, _oppBallBase.enemyBallSpeed1);
    }
}
