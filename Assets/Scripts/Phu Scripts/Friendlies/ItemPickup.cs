using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool isHealthPack;
    public bool isMagazine;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject playerObject = collision.gameObject;

            //HealthPack
            if(isHealthPack)
            {
                playerObject.GetComponent<PlayerResources>().ObtainHealthPack();

                Destroy(gameObject);
            }

            //Magazine
            if (isMagazine)
            {
                playerObject.GetComponent<PlayerResources>().ObtainMagazine();

                Destroy(gameObject);
            }
        }
    }
}
