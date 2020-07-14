using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGenerator : MonoBehaviour
{
    public bool t1_f2;
    public GameObject maga;
    public GameObject espadachin;
    public GameObject escudero;

    public GameObject jugador;

    public string Hab;
    public string Ply;

    public Image barra;
    public Image indHab;

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
        if (t1_f2 == true)
        {
            Ply = GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pChar1;
            Hab = GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pHab1;
        }

        if (t1_f2 == false)
        {
            Ply = GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pChar2;
            Hab = GameObject.Find("UserStatsInfo").GetComponent<UsersInfo>().pHab2;
        }

        GeneratePlayer();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePlayer()
    {
        if (Ply == "Maga")
        {
            jugador = Instantiate(maga);
        }
        else if (Ply == "Espadachin")
        {
            jugador = Instantiate(espadachin);
        }
        else
        {
            jugador = Instantiate(escudero);
        }

        GetComponent<CamOffset>().target = jugador.transform;

        jugador.GetComponent<Car_Script>().player.GetComponent<PlayerVista>().BarraDeVida = barra;
        jugador.GetComponent<Car_Script>().player.GetComponent<PlayerVista>().HabilidadCooldown = indHab;

        if (Hab == "FireBall")
        {
            jugador.GetComponent<Car_Script>().player.GetComponent<PlayerController>().habilityName = Hab;
            jugador.GetComponent<Car_Script>().player.GetComponent<MODELO>().cooldown = 4;
        }
        else if (Hab == "Shield")
        {
            jugador.GetComponent<Car_Script>().player.GetComponent<PlayerController>().habilityName = Hab;
            jugador.GetComponent<Car_Script>().player.GetComponent<MODELO>().cooldown = 7;
        }
        else if (Hab == "Slash")
        {
            jugador.GetComponent<Car_Script>().player.GetComponent<PlayerController>().habilityName = Hab;
            jugador.GetComponent<Car_Script>().player.GetComponent<MODELO>().cooldown = 6;
        }
        else if (Hab == "Axe")
        {
            jugador.GetComponent<Car_Script>().player.GetComponent<PlayerController>().habilityName = Hab;
            jugador.GetComponent<Car_Script>().player.GetComponent<MODELO>().cooldown = 5;
        }
        else if (Hab == "Tirachinas")
        {
            jugador.GetComponent<Car_Script>().player.GetComponent<PlayerController>().habilityName = Hab;
            jugador.GetComponent<Car_Script>().player.GetComponent<MODELO>().cooldown = 2;
        }
        else if (Hab == "Mazo")
        {
            jugador.GetComponent<Car_Script>().player.GetComponent<PlayerController>().habilityName = Hab;
            jugador.GetComponent<Car_Script>().player.GetComponent<MODELO>().cooldown = 6;
        }
        else if (Hab == "Pergamino")
        {
            jugador.GetComponent<Car_Script>().player.GetComponent<PlayerController>().habilityName = Hab;
            jugador.GetComponent<Car_Script>().player.GetComponent<MODELO>().cooldown = 1;
        }


    }
}
