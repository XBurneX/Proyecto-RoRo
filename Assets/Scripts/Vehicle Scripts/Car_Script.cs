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
    float distanceGround = 1;
    

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
        Movimiento();
    }

    void FixedUpdate()
    {
        CheckGround();
        Salto();
    }
    



    //#################################################################//



    void Movimiento()
    {
        float v = 0;
        float h = 0;
        bool breaking = true;

        //Horizontal//
        if (Input.GetKey(izq))
        {
            h = -giroForce;
        }
        else if (Input.GetKey(der))
        {
            h = giroForce;
        }
    
        //vertical//
        if (Input.GetKey(up))
        {
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
            breaking = false;
            
            v = -motorForce;

            if (Input.GetKeyUp(down))
            {
                breaking = true;
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

}
