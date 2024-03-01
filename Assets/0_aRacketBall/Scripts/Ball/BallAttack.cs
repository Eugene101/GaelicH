using UnityEngine;

public class BallAttack : State
{
    BallBasic _ballBasic;
    float xshift;
    float yshift;
    float zshift;
    public BallAttack(BallBasic ballBasic)
    {
        _ballBasic = ballBasic;
    }

    public override void Enter()
    {
        Vector3 dir = _ballBasic.wall.transform.position - _ballBasic.transform.position;
        dir.z = -Mathf.Abs(dir.z);
        //Vector3 directionToObject = _ballBasic.transform.position - _ballBasic.hand.transform.position;
        //float angle = Vector3.Angle(_ballBasic.hand.transform.forward, directionToObject);
        //Debug.Log("angle " + angle);


        if (_ballBasic.goLeft)
        {
            xshift = Random.Range(0f, 2.5f);
        }
        else if (_ballBasic.goRight)
        {
            xshift = Random.Range(0f, -2f);
        }

        float power = _ballBasic.RightControllerVelocity.magnitude;
        //Debug.Log("power: " + power);

        if (power > 1.8f)
        {
            yshift = -_ballBasic.attackUpForce * 0.13f;
            zshift = 0;

            if (xshift < 0)
            {
                xshift += (-1);
            }

            else
            {
                xshift += 1;
            }
        }

        else if (power <= 1.8f)
        {
            yshift = -_ballBasic.attackUpForce * 0.15f;
            zshift = power - power * 0.5f;
        }

        _ballBasic.rb.velocity = dir.normalized * _ballBasic.ballAttackSpeed * power + new Vector3(xshift, _ballBasic.attackUpForce + yshift,-zshift);
        Debug.Log("xshift:" + xshift + " " + _ballBasic.rb.velocity + " " + power);
        //_ballBasic.rb.AddForce(_ballBasic.hand.transform.up * _ballBasic.ballAttackSpeed * UxrAvatar.LocalAvatar.GetGrabber(UxrHandSide.Right).Velocity.magnitude);
        _ballBasic.rb.useGravity = true;
        //_ballBasic.runAfterHitUp = false; _ballBasic.runAfterHitDown = false;
        _ballBasic.goLeft = false;
        _ballBasic.goRight = false;
        _ballBasic.status = BallBasic.BallPlayerStatus.isAttacking;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {

        if (_ballBasic.rb.velocity.magnitude > _ballBasic.serveVelocity)
        {
            _ballBasic.rb.velocity *= 0.8f;
        }

        //Vector3 toCentre = _ballBasic.wall.transform.position - _ballBasic.transform.position;
        //toCentre.z = 0;
        //_ballBasic.rb.AddForce(toCentre*Time.deltaTime*1000f);
    }
}
