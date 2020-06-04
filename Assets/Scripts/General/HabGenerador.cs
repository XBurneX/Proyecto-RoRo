using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabGenerador : MonoBehaviour
{

    public GameObject fireBall;
    public GameObject shield;
    public GameObject slash;
    public GameObject axe;
    public GameObject tirachinas;
    public GameObject mazo;
    public GameObject pergamino;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpeelCast(string habName, Quaternion direction)
    {

        if (habName == "FireBall")
        {
            GameObject fire = Instantiate(fireBall);
            fire.transform.position = new Vector3(transform.position.x, transform.position.y + 13, transform.position.z);
            fire.transform.rotation = new Quaternion(fire.transform.rotation.x, direction.y, fire.transform.rotation.z, fire.transform.rotation.w);
        }

        if (habName == "Shield")
        {
            GameObject shld = Instantiate(shield);
            shld.GetComponent<ShieldScript>().protectObject = gameObject;
            shld.transform.rotation = new Quaternion(shld.transform.rotation.x, direction.y, shld.transform.rotation.z, shld.transform.rotation.w);
        }
        
        if (habName == "Slash")
        {
            GameObject slh = Instantiate(slash);
            slh.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
            slh.transform.rotation = new Quaternion(slh.transform.rotation.x, direction.y, slh.transform.rotation.z, slh.transform.rotation.w);

        }

        if (habName == "Axe")
        {
            GameObject ax = Instantiate(axe);
            ax.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
            ax.transform.rotation = new Quaternion(ax.transform.rotation.x, direction.y, ax.transform.rotation.z, ax.transform.rotation.w);
        }

        if (habName == "Tirachinas")
        {
            GameObject stn = Instantiate(tirachinas);
            stn.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
            stn.transform.rotation = new Quaternion(stn.transform.rotation.x, direction.y, stn.transform.rotation.z, stn.transform.rotation.w);
        }

        if (habName == "Mazo")
        {
            GameObject maz = Instantiate(mazo);
            maz.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 7);
            maz.transform.rotation = new Quaternion(maz.transform.rotation.x, direction.y, maz.transform.rotation.z, maz.transform.rotation.w);
        }

        if (habName == "Pergamino")
        {
            //instantiate sonido;
        }


    }
}
