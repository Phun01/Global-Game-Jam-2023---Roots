using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeSpan;
    public float lifeTime;
    public float deathTimer;
    public float deathTime;
    bool death;

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if(lifeTime > lifeSpan)
        {
            Destroy(this.gameObject);
        }
        if(death)
        {
            deathTimer += Time.deltaTime;
            if(deathTimer > deathTime)
            {
                Destroy(this.gameObject);
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject)
        {
            death = true;
        }
        /*
        if (collision.gameObject.GetComponent<"Enemy"> != null)
        {
        }*/
    }
}
