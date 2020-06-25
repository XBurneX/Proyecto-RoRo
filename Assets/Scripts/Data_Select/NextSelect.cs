using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSelect : MonoBehaviour
{
    public GameObject selChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Nxt(int dirNum)
    {
        selChange.GetComponent<Selector>().Next(dirNum);
    }
}
