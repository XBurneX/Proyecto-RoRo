using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JabaliControlador : MonoBehaviour { 


public GameObject Target;
public NavMeshAgent agent;
public float distance;
    //public Health healScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Target.transform.position, transform.position)< distance) {
            agent.SetDestination(Target.transform.position);
            agent.speed = 10;
        } else {
            agent.speed = 0;
        //}
        //if (Vector3.Distance(Target.transform.position,transform.position) <= 2) {
            //healScript.health = healScript.health - 5; 
        }
    }
}
