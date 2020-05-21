using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public GameObject protectObject;
    public float timer;
    public float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        DestroyTimer();
        
    }

    void Follow()
    {
        transform.position = protectObject.transform.position;
    }

    void DestroyTimer()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
}
