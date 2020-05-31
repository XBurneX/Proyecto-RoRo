using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject car;
    public float actualLive;
    public float liveModifier;
    public float massModifier;

    public bool habilityCharged;
    public string habilityName;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<MODELO>().cooldown;
        actualLive = GetComponent<MODELO>().live * liveModifier;
        car.GetComponent<Rigidbody>().mass = (GetComponent<MODELO>().peso * massModifier) + 3000;
        car.GetComponent<Car_Script>().giroForce = (GetComponent<MODELO>().traccion * 5) + 30;
        car.GetComponent<Car_Script>().motorForce = (GetComponent<MODELO>().velocidad * 50000) + 400000;
        habilityCharged = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (habilityCharged == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                habilityCharged = true;
                timer = GetComponent<MODELO>().cooldown;
            }
        }
        
    }

    void DamageLive(float damage)
    {
        actualLive -= damage;
    }

    void ActiveHability()
    {     //cuando "Carroceria" detecte la tecla de habilidad,llamará esta función
        if (habilityCharged == true)
        {
            timer = GetComponent<MODELO>().cooldown;

            //llamar funcion generadora de habilidad(script por crear) y indicando el nombre de la habilidad "habilityName"
            Debug.Log("Habilidad lanzada");
        }

    }

}
