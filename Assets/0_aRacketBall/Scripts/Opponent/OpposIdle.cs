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
        _oppBase.oppStatus = OppBase.OppStatus.oppIsIdle;
      
    }
    public override void Exit()
    {
        _oppBase.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    public override void Update()
    {

    }
}
