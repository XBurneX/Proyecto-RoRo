using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    public bool pj_itm;
    public bool t1_f2;

    public int selectedNum;

    public Text texto;
    public Text descripcion;
    public Sprite[] miniatura;
    public string[] mini_name;
    public string[] description;
 
    int[] selctNums;

    public string textData;

    // Start is called before the first frame update
    void Start()
    {
        selectedNum = 0;
        GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pChar1 = "Tugfa";
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = miniatura[selectedNum];
        texto.text = mini_name[selectedNum];
        descripcion.text = description[selectedNum];

        UpData();
    }

    void UpData()
    {
        if (pj_itm == true)
        {
            if (t1_f2==true)
            {
                GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pChar1 = textData;
            }
            else
            {
                GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pChar2 = textData;
            }
        }
        else
        {
            if (t1_f2 == true)
            {
                GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pHab1 = textData;
            }
            else
            {
                GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pHab2 = textData;
            }
        }
        
    }

    public void Next(int dir)
    {
        if (pj_itm == true)
        {
            selectedNum += dir;

            if(selectedNum>=miniatura.Length)
            {
                selectedNum = 0;
            }
            else if(selectedNum<0)
            {
                selectedNum = miniatura.Length-1;
            }
        }

        else
        {

        }
    }
}
