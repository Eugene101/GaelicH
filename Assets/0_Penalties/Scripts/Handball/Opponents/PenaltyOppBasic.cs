using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PenaltyOppBasic : MonoBehaviour
{
    protected float power;
    protected float accuracy;
    [SerializeField] private Animator anim;
    [SerializeField] GameObject enemyBall;
    public static bool enemyBallIsInFly;
    public GameObject hand;
    public Transform oppPointWaiting;
    public Transform PointOfShooting;
    public GameObject goals;
    private StateMachine stateMachine;
    [SerializeField] private float speed;
    public float Speed { get { return speed; } }
    public Animator animator
    {
        get
        {
            return anim;
        }
        private set { anim = value; }
    }

    public float Power
    {
        get { return power; }
    }

    public float Accuracy
    {
        get { return accuracy; }
    }
    public PenaltyOppBasic(float _power, float _accuracy)
    {
        power = _power;
        accuracy = _accuracy;
    }
    public void GoToShoot()
    {
      //  yield return new WaitForSeconds(5);
        stateMachine.ChangeState(new OppWalking(this, OppWalking.direction.forward));
        //Invoke("Attack", 3f);
    }

    void Attack()
    {
        stateMachine.ChangeState(new OppAttack(this));
    }    

    private void Start()
    {
        stateMachine = new StateMachine();
        animator = GetComponent<Animator>();
        stateMachine.Intialize(new OppIdle(this));
        
    }
    private void Update()
    {
        stateMachine.currentState.Update();
        //if(Vector3.Distance(this.transform.position,PointOfShooting.position) < 0.1f)
        //{

        //}
    }
}
