using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Random_Frase : MonoBehaviour
{
    public Text texttext;
    public GameObject targettext;

    public string tx;

    public string[] T_Frase;

    // Use this for initialization
    void Start()
    {
        texttext = targettext.GetComponent<Text>();

        tx = T_Frase[Random.Range(0,T_Frase.Length)];
        texttext.text = tx;
    }
}
