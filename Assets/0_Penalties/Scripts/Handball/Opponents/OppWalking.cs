using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppWalking : State
{
    // Start is called before the first frame update
    public enum direction { forward, backward};
    private direction _dir;
    PenaltyOppBasic _penaltyOppBasic;
   
    public OppWalking(PenaltyOppBasic penaltyOppBasic, direction dir)
    {
        _penaltyOppBasic = penaltyOppBasic;
       _dir = dir;
    }

    public override void Enter()
    {
 
    }

    public override void Exit()
    {
        _penaltyOppBasic.transform.LookAt(_penaltyOppBasic.goals.transform.position);
        _penaltyOppBasic.animator.StopPlayback();
    }

    public override void Update()
    {
        switch(_dir)
        {
            case direction.forward:

                // _penaltyOppBasic.transform.Translate(_penaltyOppBasic.PointOfShooting.position);
                _penaltyOppBasic.transform.position = Vector3.MoveTowards(_penaltyOppBasic.transform.position, _penaltyOppBasic.PointOfShooting.position, _penaltyOppBasic.Speed * Time.deltaTime);
                _penaltyOppBasic.transform.LookAt(_penaltyOppBasic.PointOfShooting.position);
                break;
        }
    }
}
