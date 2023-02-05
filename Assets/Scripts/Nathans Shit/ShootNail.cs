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

    public PlayerResources playerResources;

    // Start is called before the first frame update
    void Start()
    {
        //audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
        player = gameObject.GetComponentInParent<PlayerMovement>();
        playerResources = gameObject.GetComponentInParent<PlayerResources>();
    }

    // Update is called once per frame
    void Update()
    {

        if (shot)
        {
            reload += Time.deltaTime;
            if(reload >= cooldown)
            {
                shot = false;
            }
        }

        if(playerResources!= null)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        if (player)
        {
            if (player.playerNo == 1 && playerResources.playerNumber == 1 && playerResources.playerAmmo > 0)
            {
                if ((Input.GetAxis("Fire1") > 0.2) && !shot)
                {
                    GameObject instBullet = Instantiate(nail, transform.position, Quaternion.identity) as GameObject;
                    instBullet.GetComponent<Bullet>().player = player.playerNo;
                    Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();
                    instBulletRB.AddForce(transform.forward * bulletSpeed);
                    //audio.NailGun();
                    shot = true;
                    reload = 0;

                    //use ammo
                    playerResources.LoseAmmo();
                }
            }
            if (player.playerNo == 2 && playerResources.playerNumber == 2 && playerResources.playerAmmo > 0)
            {
                if ((Input.GetAxis("P2Fire1") > 0.2) && !shot)
                {
                    GameObject instBullet = Instantiate(nail, transform.position, Quaternion.identity) as GameObject;
                    instBullet.GetComponent<Bullet>().player = player.playerNo;
                    Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();
                    instBulletRB.AddForce(transform.forward * bulletSpeed);
                    //audio.NailGun();
                    shot = true;
                    reload = 0;

                    //use ammo
                    playerResources.LoseAmmo();
                }
            }
        }
    }

}
