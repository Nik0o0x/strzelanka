using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Zombie"))
        {
            //trafiliœmy zombiaka - zadaj mu obra¿enia
            collision.gameObject.GetComponent<ZombieController>().ReceiveDamage(1);
        }
        Destroy(gameObject, 1);
    }
}
