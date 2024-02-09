using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    //[SerializeField] GameObject playerBall;
    [SerializeField] OppBallBase oppBall;
    //[SerializeField] GameObject player;
    [SerializeField] PenaltyOppBasic opponent;

    // Start is called before the first frame update

    void Start()
    {
        // StartCoroutine(opponent.GoTime());
        opponent.Invoke("GoToShoot", 5f);
        Invoke("OppAttack", 7f);
        oppBall.Invoke("Attack", 8f);
    }
    
    void OppAttack()
    {
        opponent.Invoke("Attack", 7f);
        oppBall.transform.position = opponent.hand.transform.position;
    }

}
