using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 inputVector;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        inputVector = Vector2.zero;    
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Wychylenie kontrolera: " + inputVector.ToString());


        //metoda bez u¿ycia fizyki
        //Vector3 movement = new Vector3(0, 0, inputVector.y);
        //transform.Translate(movement); 
        //Vector3 rotation = new Vector3(0, inputVector.x, 0);
        //transform.Rotate(rotation);
        
    }
    private void FixedUpdate()
    {
        if(inputVector.y == 0)
        {
            //nie trzymamy wciœniêtego "w" ani "s"
            rb.velocity = Vector3.zero;
        } 
        else
        {
            //metoda z fizyk¹
            //wez kierunek do przodu wzglêdem postaci i przemnó¿ przez wychylenie kontrolera
            Vector3 movement = transform.forward * inputVector.y;
            rb.AddForce(movement, ForceMode.Impulse);
        }
        if(inputVector.x == 0)
        {
            rb.angularVelocity = Vector3.zero;
        } 
        else
        {
            Vector3 rotation = transform.up * inputVector.x;
            rb.AddTorque(rotation, ForceMode.Impulse);
        }
        
    }

    void OnMove(InputValue inputValue)
    {
        inputVector = inputValue.Get<Vector2>();
    }
}
