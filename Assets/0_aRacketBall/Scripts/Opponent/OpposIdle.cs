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
        _oppBase.transform.position = _oppBase.oppStartPoint.position;
    }
    public override void Exit()
    {
       
    }
    public override void Update()
    {
       
    }
}
