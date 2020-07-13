using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Script : MonoBehaviour
{
    public LayerMask groundLayer;
    public bool grounded;
    public float motorForce;
    public float giroForce;
    public float frenoForce;
    public float jumpForce;
    Rigidbody rb;
    public float distanceGround = 1;
    public float timer;
    public float mxtimer;
    public float spd;
    public GameObject player;
    

    //----------Ruedas---------//
    //(B = Traseras, F = Delanteras)
    public WheelCollider rueda_B1;
    public WheelCollider rueda_B2;
    public WheelCollider rueda_F1;
    public WheelCollider rueda_F2;
    //-------------------------//

    

    //-----Escoger Teclas------//
    public KeyCode up;
    public KeyCode down;
    public KeyCode der;
    public KeyCode izq;
    public KeyCode jump;
    public KeyCode hability;
    //-------------------------//

    //##################################################################//

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player)
        {
            Movimiento();
        }

        
        Hability();
    }

    void FixedUpdate()
    {
        CheckGround();
        if (player)
        {
            Salto();
        }
    }   

    //#################################################################//



    void Movimiento()
    {
        //////////Movimiento 1(Fuerza secundaria)////////
        float v = 0;
        float h = 0;
        bool breaking = true;
        float vel = spd * timer;

        float rotateValue = 0;
        if (grounded == true)
        {
            //Valores//
            ///////////////////////////////////////////
            if (Input.GetKey(up) || Input.GetKey(down))
            {
                timer += Time.deltaTime;
                if (timer >= mxtimer)
                {
                    timer = mxtimer;
                }
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 0;
                }
            }

            if (Input.GetKey(der) || Input.GetKey(izq))
            {
                rotateValue = Time.deltaTime * 50;

            }
            else
            {
                rotateValue -= Time.deltaTime;
                if (rotateValue <= 0)
                {
                    rotateValue = 0;
                }
            }
            //////////////////////////////////////////

            //Horizontal//
            if (Input.GetKey(izq))
            {

                h = -giroForce;
                transform.Rotate(new Vector3(0, -1, 0) * rotateValue, Space.World);
            }
            else if (Input.GetKey(der))
            {

                transform.Rotate(new Vector3(0, 1, 0) * rotateValue, Space.World);
                h = giroForce;
            }

            //vertical//
            if (Input.GetKey(up))
            {
                rb.velocity = transform.forward * vel;
                //float timer = Time.deltaTime;
                breaking = false;
                v = motorForce /** timer*/;

                if (Input.GetKeyUp(up))
                {
                    breaking = true;
                }
            }
            else if (Input.GetKey(down))
            {
                rb.velocity = transform.forward * -vel;
                breaking = false;

                v = -motorForce;

                if (Input.GetKeyUp(down))
                {
                    breaking = true;
                }
            }
        }
        //frenos
        if (breaking == true)
        {
            rueda_B1.brakeTorque = frenoForce;
            rueda_B2.brakeTorque = frenoForce;
            rueda_F1.brakeTorque = frenoForce;
            rueda_F2.brakeTorque = frenoForce;
        }
        else
        {
            rueda_B1.brakeTorque = 0;
            rueda_B2.brakeTorque = 0;
            rueda_F1.brakeTorque = 0;
            rueda_F2.brakeTorque = 0;
        }

        //Fuerza
        rueda_B1.motorTorque = v;
        rueda_B2.motorTorque = v;
        //Traccion
        rueda_F1.steerAngle = h;
        rueda_F2.steerAngle = h;

      
    }

    void Salto()
    {
        if (Input.GetKeyDown(jump) && grounded==true)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
           
        }
    }

    void CheckGround()
    {
        grounded =        
        Physics.Raycast(transform.position,
           Vector3.down,
           distanceGround,
           groundLayer
           );
    }

    void Hability()
    {
        if (Input.GetKeyDown(hability))
        {
            player.GetComponent<PlayerController>().ActiveHability();
        }
    }

}
