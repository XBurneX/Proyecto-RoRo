using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameSelect : MonoBehaviour
{
    

    string playerName_One = null;
    string playerName_Two = null;

    public GameObject pName1;
    public GameObject pName2;

    
    

    // Start is called before the first frame update
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        //pName1.GetComponent < InputField>().text = playerName_One;

        playerName_One = pName1.GetComponent<TextMeshProUGUI>().text;
        playerName_Two = pName2.GetComponent<TextMeshProUGUI>().text;

        GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pName1 = playerName_One;
        GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pName2 = playerName_Two;

        Debug.Log(playerName_One + " " + playerName_Two);
    }
}
