using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpposIdle : State
{
    OppBase _oppBase;


    public OpposIdle(OppBase oppBase)
    {
        _oppBase = oppBase;
    }
    public override void Enter()
    {
        OppBase.oppIsIdle = true;
    }
    public override void Exit()
    {
        OppBase.oppIsIdle = false;
    }
    public override void Update()
    {

    }
}
