using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppBallAttack : State
{
    OppBallBase _oppBallBase;
    
    // Start is called before the first frame update
    public OppBallAttack(OppBallBase oppBallBase)
    {
        _oppBallBase = oppBallBase;
    }

    public override void Enter()
    {
        _oppBallBase.transform.position = _oppBallBase.oppHand.transform.position;
        _oppBallBase.transform.parent = _oppBallBase.oppHand.transform;
        int rand = Random.Range(0, _oppBallBase.enemyBallTargets.Length);
        _oppBallBase.ballTarget = new Vector3(_oppBallBase.enemyBallTargets[rand].transform.position.x, _oppBallBase.enemyBallTargets[rand].transform.position.y, _oppBallBase.enemyBallTargets[rand].transform.position.z);
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        
    }
}
