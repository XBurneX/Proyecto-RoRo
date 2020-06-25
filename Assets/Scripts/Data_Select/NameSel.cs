using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NameSel : MonoBehaviour
{
    public Text n1;
    public Text n2;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("UserStatsInfo"))
        {
            n1.text = GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pName1;
            n2.text = GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pName2;
        }
        else
        {
            Debug.Log("NonDataObject");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
