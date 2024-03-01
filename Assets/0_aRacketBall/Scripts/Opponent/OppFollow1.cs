using System.Collections;
using System;
using UnityEngine;
using Unity.VisualScripting.FullSerializer;

public class OppFollow1 : State
{
    OppBase _oppBase;
    bool goingUp;
    bool iCanGo;
    //float randZshift;

    public OppFollow1(OppBase oppBase)
    {
        _oppBase = oppBase;
    }
    public override void Enter()
    {
        _oppBase.oppStatus = OppBase.OppStatus.oppIsFollowing1;
        //Debug.Log("I follow ball");
        //randZshift = UnityEngine.Random.Range(-1.5f, 1.5f);
        //if (_oppBase.transform.position.z < _oppBase.centreOfGround.position.z)
        //{
        //    goingUp = false;
        //}

        //else
        //{
        //    goingUp = true;
        //}

        iCanGo = true;
    
    }
    public override void Exit()
    {
        iCanGo = false;
    }

    public override void Update()
    {
        if (iCanGo == true)
        {
            _oppBase.testSphere.transform.position = new Vector3(_oppBase.ballBasic.transform.position.x, _oppBase.wall.transform.position.y, _oppBase.wall.transform.position.z);
            _oppBase.transform.LookAt(_oppBase.testSphere.transform.position);
            _oppBase.transform.position += -Vector3.forward * _oppBase.speed * Time.deltaTime;
        }
 
        
        if (_oppBase.transform.position.z== _oppBase.centreOfGround.position.z+1.4f) 
        {
            iCanGo = false;
        }

    }
}
