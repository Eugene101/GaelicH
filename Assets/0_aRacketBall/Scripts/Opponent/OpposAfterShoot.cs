using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpposAfterShoot : State
{

    OppBase _oppBase;

    public OpposAfterShoot(OppBase oppBase)
    {
        _oppBase = oppBase;
    }
    public override void Enter()
    {
        Debug.Log("State is returning");
        _oppBase.oppStatus = OppBase.OppStatus.oppIsGoBack;
    }
    public override void Exit()
    {

    }
    public override void Update()
    {
        _oppBase.transform.position += Vector3.forward * _oppBase.speed * Time.deltaTime*5f;
    }
}
