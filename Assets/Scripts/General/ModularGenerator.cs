using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularGenerator : MonoBehaviour
{
    public Vector3 debugPosition;

    public GameObject startMod;
    public GameObject endMod;


    public GameObject[] verticalMods;

    public int distance;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        debugPosition = transform.position;

     

        Generate();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void Generate()
    {
        Debug.Log("Generate");
       

        for (int i = 0; i <= distance; i++)
        {
            GameObject actualMod;

            Debug.Log("Before select");

            if (i == 0)
            {
                actualMod = startMod;
            }

            else if (i == distance)
            {
                actualMod = endMod;
            }

            else
            {
                actualMod = verticalMods[Random.Range(0, verticalMods.Length)];
            }
            Debug.Log("After Select");

            debugPosition = new Vector3(
                debugPosition.x + (actualMod.GetComponent<MetrsModls>().x_mod_mt * 10),
                debugPosition.y,
                debugPosition.z + (actualMod.GetComponent<MetrsModls>().z_mod_mt * 10));

            GameObject modular = Instantiate(actualMod);

            modular.transform.position = debugPosition;
            Debug.Log(i);

            debugPosition = new Vector3(
                debugPosition.x + (actualMod.GetComponent<MetrsModls>().x_mod_mt * 10),
                debugPosition.y,
                debugPosition.z + (actualMod.GetComponent<MetrsModls>().z_mod_mt * 10));

        }
    }
}
