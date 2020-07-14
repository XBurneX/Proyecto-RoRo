    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JabaliControlador : MonoBehaviour { 


    public GameObject target;
    public NavMeshAgent agent;
    public bool stun;
    public float timer;




    // Start is called before the first frame update
    void Start()
    {
        stun = true;
        timer = 0;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (stun == true)
        {
            Autostun();
        }

        if (GetComponent<JabaliModelo>().alerta == false)
        {
            follow();
        }
        else
        {
            agent.speed = 0;
        }

    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DamPlayer"))
        {
            
            target = other.gameObject;

            
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        

        if (GetComponent<JabaliModelo>().alerta == false)
        {
            Debug.Log("tugfa1");
            if (collision.gameObject.CompareTag("Player"))
            {
                
                stun = true;

                collision.gameObject.GetComponent<Car_Script>().player.GetComponent<PlayerController>().DamageLive(GetComponent<JabaliModelo>().daño);

            }
        }
    }

    void follow()
    {
        if (target != null)
        {
            if (Vector3.Distance(target.transform.position, transform.position) < GetComponent<JabaliModelo>().distancia)
            {
                agent.SetDestination(target.transform.position);
                agent.speed = GetComponent<JabaliModelo>().velocidad;
            }

            else
            {
                agent.speed = 0;

            }
        }
    }

    void Autostun()
    {
        GetComponent<JabaliModelo>().alerta = true;
        timer += Time.deltaTime;
        
        if (timer >= GetComponent<JabaliModelo>().timer)
        {
            GetComponent<JabaliModelo>().alerta = false;
            stun = false;
            timer = 0;
            
        }

    }
}
