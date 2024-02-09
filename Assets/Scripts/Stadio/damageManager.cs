using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageManager : MonoBehaviour
{
    public int ammoDamage;
    // Start is called before the first frame update

    private void Awake()
    {
        string whoami = this.name;
        switch (whoami)
        {
            case "rpg7_warhead(Clone)":
                ammoDamage = 200;
                break;
            case "DroneAmmoBullet":
                ammoDamage = 50;
                break;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        print(" EnemyBulletHomeDamage " + other.name);
    }
}
