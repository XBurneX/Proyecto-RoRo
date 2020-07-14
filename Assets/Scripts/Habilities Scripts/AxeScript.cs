using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject target;
    public float timer;
    public float maxTime;
    public float axeLoops;
    public float spd;
    public float daño;

    //##################################################################//

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.angularVelocity = new Vector3((axeLoops,0,0), Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyTimer();
    }

    // OtherUpdate for movements with mass
    private void FixedUpdate()
    {
        TargMovement();
    }

    //##################################################################//

    void TargMovement()
    {
        //rb.MovePosition(target.transform.position);
        rb.velocity = transform.forward * spd;
        transform.Rotate(new Vector3(1, 0, 0) * axeLoops, Space.World);
    }

    void DestroyTimer()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            Destroy(gameObject);
            timer = 0;
        }
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
