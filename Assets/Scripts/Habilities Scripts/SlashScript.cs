using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject target;
    public float timer;
    public float maxTime;

    //##################################################################//

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
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
        rb.MovePosition(target.transform.position);
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
            Debug.Log("Se ha dañado al jugador");
            Destroy(gameObject);
        }

        if (other.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
    }
}
