using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackground : MonoBehaviour
{
    // Start is called before the first frame update
    public static MusicBackground backgroundMusicScript;

    private void Awake()
    {
        if (!backgroundMusicScript)
        {
            backgroundMusicScript = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
