using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsersInfo : MonoBehaviour
{

    //---PLAYER 1 STATS---//
    public string pName1;
    public string pChar1;
    public string pHab1;

    //-------------------//



    //---PLAYER 2 STATS---//
    public string pName2;
    public string pChar2;
    public string pHab2;


    //-------------------//


    // Start is called before the first frame update
    void Start()
    {
        pName1 = null;
        pName2 = null;
        pChar1 = null;
        pChar2 = null;
        pHab1 = null;
        pHab2 = null;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
