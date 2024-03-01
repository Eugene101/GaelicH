using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class OppPerception : State
{
    OppBase _oppBase;

    public OppPerception(OppBase oppBase)
    {
        _oppBase = oppBase;
    }
    public override void Enter()
    {
        Debug.Log("State is perception");
        _oppBase.oppStatus = OppBase.OppStatus.oppIsPercepting;
        _oppBase.transform.rotation = _oppBase.BasicRot;
    }
    public override void Exit()
    {

    }
    public override void Update()
    {
        //Vector3 toPercep = new Vector3(_oppBase.ballBasic.transform.position.x, _oppBase.transform.position.y, _oppBase.transform.position.z);
        //while (Mathf.Abs(_oppBase.transform.position.x) != Mathf.Abs(toPercep.x))
        //{
        //    _oppBase.transform.position += toPercep * _oppBase.speed * 5 * Time.deltaTime;
        //}

        _oppBase.transform.position = new Vector3(_oppBase.ballBasic.transform.position.x, _oppBase.transform.position.y, _oppBase.transform.position.z);
    }
}
