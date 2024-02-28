using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppFollow1 : State
{
    OppBase _oppBase;

    public OppFollow1(OppBase oppBase)
    {
        _oppBase = oppBase;
    }
    public override void Enter()
    {
        OppBase.oppIsFollowing1 = true;

    }
    public override void Exit()
    {
        OppBase.oppIsFollowing1 = false;
    }

    public override void Update()
    {
        _oppBase.testSphere.transform.position =new Vector3(_oppBase.ballBasic.transform.position.x, _oppBase.wall.transform.position.y, _oppBase.wall.transform.position.z);
        _oppBase.transform.LookAt(_oppBase.testSphere.transform.position);
        _oppBase.transform.position += -Vector3.forward * _oppBase.speed*Time.deltaTime;
    }
}
