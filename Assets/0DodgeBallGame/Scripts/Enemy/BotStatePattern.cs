using UnityEngine;


public class BotStatePattern : MonoBehaviour
{
    
    enum State
    {
        idle, attack, dodge, move, struggling
    };
    State state;
    //public RuntimeAnimatorController[] allAnim;
    public Animator anim;
    MovingBots movingBots;
    BotAttack botAttack;
    BotJumping botJumping;
    bool amIJumping;
    // Start is called before the first frame update
    void Start()
    {
        movingBots = GetComponent<MovingBots>();
        botJumping = GetComponent<BotJumping>();
        botAttack = GetComponent<BotAttack>();
        anim = GetComponent<Animator>();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        //anim = GetComponent<Animator>();
        Idle();
    }

    // Update is called once per frame
    public void ChangeState()
    {
        int rnd = Random.Range(0, 10);
        if (rnd < 5)
        {
            state = State.move;
        }
        else
        {
            state = State.attack;
        }
        EnemyState();
    }

    void EnemyState()
    {
        switch (state)
        {
            case State.idle: //0
                //Idle();
                break;

            case State.attack: //1
                botAttack = GetComponent<BotAttack>();
                botAttack.Attack();
                break;
            //case State.dodge: //2
            //    DodgeJump();
            //    break;
            case State.move: //3

                movingBots = GetComponent<MovingBots>();
                movingBots.SetRandomDestination();
                break;
            case State.struggling: //4
                //Struggling();
                break;
        }
    }

    public void Idle()
    {
        state = State.idle;
        Debug.Log("Idle");
        anim.SetInteger("EnemyBehavoir", -1);
        Invoke("ChangeState", 2f);
    }

    public void Jump()
    {
        int iWantToJump = Random.Range(0, 10);

        if (/*state==State.idle&&*/ iWantToJump > 3)
        {
            state = State.dodge;
            botJumping.SelectSide();
        }

        else
        {
            Idle();
        }
    }


}
