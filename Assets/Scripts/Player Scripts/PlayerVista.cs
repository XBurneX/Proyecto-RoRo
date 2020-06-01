using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVista : MonoBehaviour
{
    public Image BarraDeVida;

    public Image HabilidadCooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<PlayerController>().actualLive = Mathf.Clamp(GetComponent<PlayerController>().actualLive, 0, GetComponent<MODELO>().live * GetComponent<PlayerController>().liveModifier);
        BarraDeVida.fillAmount = GetComponent<PlayerController>().actualLive / (GetComponent<MODELO>().live * GetComponent<PlayerController>().liveModifier);

        HabilidadCooldown.fillAmount = GetComponent<PlayerController>().timer / GetComponent<MODELO>().cooldown;
    }
}
