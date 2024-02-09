using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    Animator anim;
    int x_animator;
    float rand_playingtime;
    bool anim_on;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Animsw();
    }

    void turnoff()
    {
        anim.SetTrigger("Goback");
        Invoke("Animsw", 0.25f);
    }


    void Animsw()
    {
        x_animator = Random.Range(0, 9);
        rand_playingtime = Random.Range(7f, 15f);

        switch (x_animator)
        {
            case 0:
                anim.SetTrigger("Sitting0");
                break;

            case 1:
                anim.SetTrigger("Sitting1");
                break;
            case 2:
                anim.SetTrigger("Sitting2");
                break;
            case 3:
                anim.SetTrigger("Sitting3");
                break;
            case 4:
                anim.SetTrigger("Sitting4");
                break;
            case 5:
                anim.SetTrigger("Sitting5");
                break;
            case 6:
                anim.SetTrigger("Sitting6");
                break;
            case 7:
                anim.SetTrigger("Sitting7");
                break;
            case 8:
                anim.SetTrigger("Sitting8");
                break;
        }
        Invoke("turnoff", rand_playingtime);
    }
}
