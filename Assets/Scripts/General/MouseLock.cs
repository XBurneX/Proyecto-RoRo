﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;     
        
    }
}
