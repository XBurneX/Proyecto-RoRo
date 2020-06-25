using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public GameObject scnMng;
    public bool firstWinner;

    public GameObject winner;

    public string winerName;

    // Start is called before the first frame update
    void Start()
    {
        scnMng = GameObject.Find("SceneChangeManager");
        firstWinner = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation();
        
    }

    void Rotation()
    {
        /*if (transform.rotation.y == 180)
        {
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
        }
        else
        {
            transform.rotation = new Quaternion
                (
                    0,
                    transform.rotation.y + 1,
                    0,
                    transform.rotation.w
                );
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (firstWinner == false)
        {
            if (other.CompareTag("DamPlayer"))
            {
                winerName = other.name;
                firstWinner = true;
                scnMng.GetComponent<WinLoseScript>().onVictory = true;
            }
            
        }
    }

}
