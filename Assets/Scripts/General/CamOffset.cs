using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOffset : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    [Range(0, 1)] public float lerpValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
