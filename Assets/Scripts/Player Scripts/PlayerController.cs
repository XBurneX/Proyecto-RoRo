using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject car;
    public GameObject generator;

    public float actualLive;
    public float liveModifier;
    public float massModifier;

    public bool habilityCharged;
    public string habilityName;
    public float timer;

    bool lessPlayer = false;

    /*
    lista de habilidades:
        -FireBall
        -Shield
        -Slash
        -Axe
        -Tirachinas
        -Mazo
        -Pergamino
    */


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
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
            timer += Time.deltaTime;
            if (timer >= GetComponent<MODELO>().cooldown)
            {
                habilityCharged = true;
                //timer = 0;
            }
        }
        Die();
        
    }

    public void DamageLive(float damage)
    {
        actualLive -= damage;
    }

    public void ActiveHability()
    {     //cuando "Carroceria" detecte la tecla de habilidad,llamará esta función
        if (habilityCharged == true)
        {
            timer = 0;
            habilityCharged = false;

            generator.GetComponent<HabGenerador>().SpeelCast(habilityName, car.transform.rotation);

            //llamar funcion generadora de habilidad(script por crear) y indicando el nombre de la habilidad "habilityName"
            Debug.Log("Habilidad lanzada");
            //car.transform.rotation;
        }

    }

    void Die()
    {
        if(actualLive <= 0)
        {
            if (lessPlayer == false)
            {
                GameObject.Find("SceneChangeManager").GetComponent<WinLoseScript>().playersCounter--;
                lessPlayer = true;
            }

            Destroy(gameObject,0.5f);
        }
    }

}
