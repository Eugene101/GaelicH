using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpposAttack : State
{
    OppBase _oppBase;
    bool iCanGoAttack;

    public OpposAttack(OppBase oppBase)
    {
        _oppBase = oppBase;
    }
    public override void Enter()
    {
        _oppBase.oppStatus = OppBase.OppStatus.oppIsAttacking;
        iCanGoAttack = true;
    }
    public override void Exit()
    {
        iCanGoAttack = false;
    }
    public override void Update()
    {
        float dist = Vector3.Distance(_oppBase.transform.position, _oppBase.ballBasic.transform.position);
       
        if (iCanGoAttack)
        {
            _oppBase.testSphere.transform.position = new Vector3(_oppBase.ballBasic.transform.position.x, _oppBase.transform.position.y, _oppBase.wall.transform.position.z);
            _oppBase.transform.LookAt(_oppBase.testSphere.transform.position);
            _oppBase.transform.position += -Vector3.forward * _oppBase.speed * 10*Time.deltaTime;
        }

        if (dist<=0.2f)
        {
            iCanGoAttack = false;
        }

    }
}
