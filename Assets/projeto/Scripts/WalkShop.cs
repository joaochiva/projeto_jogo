﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkShop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

        
		if (transform.position.x > -0.6293532)
		{
            transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
        }

    }
}
