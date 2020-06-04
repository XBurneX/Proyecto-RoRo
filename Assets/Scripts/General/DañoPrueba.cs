using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoPrueba : MonoBehaviour
{
    public float daño;
    
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
        if(other.CompareTag("DamPlayer"))
        {
            other.gameObject.GetComponent<PlayerController>().DamageLive(daño);
        }
    }
}
