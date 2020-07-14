using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirachinasScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject target;
    public float daño;

    //##################################################################//

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
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
            other.gameObject.GetComponent<Car_Script>().player.GetComponent<PlayerController>().DamageLive(daño);
            Debug.Log("Se ha dañado al jugador");
            Destroy(gameObject);
        }

        if (other.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
    }
}
