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
        _oppBase.transform.position = _oppBase.oppStartPoint.position;
    }
    public override void Exit()
    {

    }
    public override void Update()
    {

    }
}
