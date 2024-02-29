using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpposAttack : State
{
    OppBase _oppBase;
    bool iCanGo;

    public OpposAttack(OppBase oppBase)
    {
        _oppBase = oppBase;
    }
    public override void Enter()
    {
        Debug.Log("I attack ball 2");
        _oppBase.oppStatus = OppBase.OppStatus.oppIsAttacking;
        iCanGo = true;
    }
    public override void Exit()
    {

    }
    public override void Update()
    {
        float dist = Vector3.Distance(_oppBase.transform.position, _oppBase.ballBasic.transform.position);

        if (iCanGo)
        {
            _oppBase.testSphere.transform.position = new Vector3(_oppBase.ballBasic.transform.position.x, _oppBase.wall.transform.position.y, _oppBase.wall.transform.position.z);
            _oppBase.transform.LookAt(_oppBase.testSphere.transform.position);
            _oppBase.transform.position += -Vector3.forward * _oppBase.speed * Time.deltaTime;
        }

        if (dist<=0.2f)
        {
            iCanGo = false;
        }

    }
}
