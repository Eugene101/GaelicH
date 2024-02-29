using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpposServing : State
{
    OppBase _oppBase;


    public OpposServing(OppBase oppBase)
    {
        _oppBase = oppBase;
    }
    public override void Enter()
    {
        _oppBase.oppStatus = OppBase.OppStatus.oppIsServing;
    }
    public override void Exit()
    {

    }
    public override void Update()
    {

    }
}
