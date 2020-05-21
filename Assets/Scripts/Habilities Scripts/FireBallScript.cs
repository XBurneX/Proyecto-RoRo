    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public Rigidbody rb;
    //public float distanceSpeed;
    public GameObject target;
    /*public float angleX;
    public float angleY;*/


    //##################################################################//

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //transform.rotation = new Vector3(angleX, angleY, 0);
        //target.transform.position = new Vector3(0,0, .parent.distanceSpeed);   
    }

    // Update is called once per frame
    void Update()
    {
        //TargMovement();
    }

    // OtherUpdate for movements with mass
    private void FixedUpdate()
    {
        TargMovement();
    }

    //##################################################################//




    void TargMovement()
    {
        rb.MovePosition(target.transform.position);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            Destroy(other);
            Destroy(gameObject);
           
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Se ha dañado al jugador");
            Destroy(gameObject);
        }

        if (other.CompareTag("Piso"))
        {    
            Destroy(gameObject);
        }
    }
}