using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; // 3 -> 2 -> 1 -> 0 = Enemy Has Died

        if(health <= 0) { 
        Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        //Vector3 playerDirection = transform.position - player.transform.position;
        
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
