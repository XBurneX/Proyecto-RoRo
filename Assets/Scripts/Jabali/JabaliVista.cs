using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JabaliVista : MonoBehaviour
{
    public GameObject alert;
    GameObject Alerta = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GenerateAlert();
        
    }

    void GenerateAlert()
    {
        


        if (GetComponent<JabaliModelo>().alerta == true)
        {
            if (Alerta == null)
            {
                Alerta = Instantiate(alert);
                Alerta.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (Alerta)
            {
                Destroy(Alerta);
            }
        }

        

    }
}
