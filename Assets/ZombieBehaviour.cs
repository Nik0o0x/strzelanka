using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieBehaviour : MonoBehaviour
{
    int hp = 3;
    [SerializeField] float health, maxHealth = 3f;

    GameObject player;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;
        agent = GetComponent<NavMeshAgent>();   
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; // 3 -> 2 -> 1 -> 0 = Enemy Has Died

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hp> 0)
        {
            transform.LookAt(player.transform.position);
            //Vector3 playerDirection = transform.position - player.transform.position;
            //transform.LookAt(player.transform.position);

            transform.Translate(Vector3.forward * Time.deltaTime);

            agent.destination = player.transform.position;
        }
        else
        {
            agent.speed = 0;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            hp--;
            if(hp <= 0)
            {
                transform.Translate(Vector3.up);
                transform.Rotate(Vector3.right * -90);
                GetComponent<BoxCollider>().enabled = false;
                Destroy(transform.gameObject, 5);
            }
        }
    }
}
