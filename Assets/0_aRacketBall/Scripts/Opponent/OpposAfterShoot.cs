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
        //_oppBase.boxCollider.gameObject.SetActive(false);
       
    }
    public override void Exit()
    {
        _oppBase.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    public override void Update()
    {
        _oppBase.transform.position += Vector3.forward * _oppBase.speed * Time.deltaTime*7f;
    }
}
