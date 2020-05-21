using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDePrueba : MonoBehaviour
{
    public KeyCode fireBallKey;
    public KeyCode shieldKey;
    public KeyCode slashKey;
    public KeyCode axeKey;
    public KeyCode tirachinasKey;
    public KeyCode mazoKey;
    public KeyCode pergaminoKey;

    public GameObject fireBall;
    public GameObject shield;
    public GameObject slash;
    public GameObject axe;
    public GameObject tirachinas;
    public GameObject mazo;
    public GameObject pergamino;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateComprover();
    }

    void InstantiateComprover()
    {
        if(Input.GetKeyDown(fireBallKey))
        {
            GameObject fire = Instantiate(fireBall);
            fire.transform.position = new Vector3(transform.position.x, transform.position.y + 13, transform.position.z);
        }

        if (Input.GetKeyDown(shieldKey))
        {
            GameObject shld = Instantiate(shield);
             shld.GetComponent<ShieldScript>().protectObject = gameObject;
        }

        if (Input.GetKeyDown(slashKey))
        {
            GameObject slh = Instantiate(slash);
            slh.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z +3);

        }

        if (Input.GetKeyDown(axeKey))
        {
            GameObject ax = Instantiate(axe);
            ax.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z +2);
        }

        if (Input.GetKeyDown(tirachinasKey))
        {
            GameObject stn = Instantiate(tirachinas);
            stn.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z +2);
        }

        if (Input.GetKeyDown(mazoKey))
        {
            GameObject maz = Instantiate(mazo);
            maz.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 7);
        }

        if (Input.GetKeyDown(pergaminoKey))
        {
            //Instantiate(pergamino);
        }


    }
}
