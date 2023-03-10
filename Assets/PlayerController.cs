using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    Vector2 movementVector;
    Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        movementVector = Vector2.zero;
        bulletSpawn = transform.Find("bulletspawn");
    }

    // Update is called once per frame
    void Update()
    {
        //obrót wokó³ osi Y o iloœæ stopni równ¹ wartosci osi X kontrolera
        transform.Rotate(Vector3.up * movementVector.x);
        //przesuniêcie do przodu (transform.forward) o wychylenie osi Y kontrolera w czasie jednej klatki
        transform.Translate(Vector3.forward * movementVector.y * Time.deltaTime);
    }

    void OnMove(InputValue inputValue)
    {
        movementVector = inputValue.Get<Vector2>();

        //Debug.Log(movementVector.ToString());
    }

    void OnFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn);
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10, ForceMode.VelocityChange);
        Destroy(bullet, 5);
    }
}