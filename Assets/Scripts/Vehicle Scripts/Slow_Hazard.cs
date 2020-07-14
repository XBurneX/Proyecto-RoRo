using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Hazard : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.gameObject.GetComponent<Car_Script>().spd = other.gameObject.GetComponent<Car_Script>().spd - 4;


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.gameObject.GetComponent<Car_Script>().spd = other.gameObject.GetComponent<Car_Script>().spd + 4;


        }
    }
}
