using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UltimateXR.Haptics;
namespace UltimateXR.Mechanics.Weapons
{
    public class WeaponBasic : MonoBehaviour
    {
        public Transform weapornPosition;
        public Transform bulletPoint;
        public GameObject bullet;
        public float ammoRespawnTime;
        public float shotInterval;
        public GameObject Shotready;
        Color shotreadyColor;

        bool isShooted;
        // Start is called before the first frame update
        void Start()
        {
            SetPosition();
            CanShoot();
            shotreadyColor = Shotready.GetComponent<MeshRenderer>().material.color = Color.green;
            ReadyToshot();
        }

        void CanShoot()
        {
            isShooted = false;
            ReadyToshot();
        }
        void SetPosition()
        {
            transform.position = weapornPosition.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isShooted && UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Trigger) && TriggerCollider.isInHand
                           || !isShooted && UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Left, UxrInputButtons.Trigger) && TriggerCollider.isInHand)
            {
                Shot();
                UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f);
                Invoke("InstantiateRocket", ammoRespawnTime);
                isShooted = true;
            }
        }

        void Shot()
        {
            GameObject playerBullet = Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation) as GameObject;
            playerBullet.tag = "Ammo";
            Rigidbody bulletRb = playerBullet.GetComponent<Rigidbody>();
            //bulletRb.AddForce(transform.forward * 50f, ForceMode.Impulse);
            Invoke("CanShoot", shotInterval);
            AmmoBasic.inFly = true;
            notReadyToshot();
        }

        
        public void ReadyToshot()
        {
            shotreadyColor = Color.green;
        }

        public void notReadyToshot()
        {
            shotreadyColor = Color.red;
        }
    }
}

