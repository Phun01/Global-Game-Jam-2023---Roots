using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootNail : MonoBehaviour
{
    public GameObject nail;
    public PlayerMovement player;
    public float bulletSpeed = 100;
    public float reload;
    public float cooldown;

    bool shot;

    public Audio audio;

    // Start is called before the first frame update
    void Start()
    {
        //audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
        player = gameObject.GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

        if (shot)
        {
            reload += Time.deltaTime;
            if(reload >= cooldown)
            {
                shot = false;
            }
        }

    }

    void Shoot()
    {
        if (player)
        {
            if (player.playerNo == 1)
            {
                if ((Input.GetAxis("Fire1") > 0.2) && !shot)
                {
                    GameObject instBullet = Instantiate(nail, transform.position, Quaternion.identity) as GameObject;
                    Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();
                    instBulletRB.AddForce(transform.forward * bulletSpeed);
                    //audio.NailGun();
                    shot = true;
                    reload = 0;
                }
            }
            if (player.playerNo == 2)
            {
                if ((Input.GetAxis("P2Fire1") > 0.2) && !shot)
                {
                    GameObject instBullet = Instantiate(nail, transform.position, Quaternion.identity) as GameObject;
                    Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();
                    instBulletRB.AddForce(transform.forward * bulletSpeed);
                    //audio.NailGun();
                    shot = true;
                    reload = 0;
                }
            }
        }
    }

}
