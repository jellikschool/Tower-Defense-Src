﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  public void playthis()
    {

        FindObjectOfType<AudioManager>().PlaySound("clickclick");
    }
}
