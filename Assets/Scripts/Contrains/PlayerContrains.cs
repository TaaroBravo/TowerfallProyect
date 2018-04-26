﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContrains : MonoBehaviour {

    Transform player;
    float myContrains_Z;

    public Transform leftWarp;
    public Transform rightWarp;

    float buffer = 2f;

    void Start ()
    {
        player = gameObject.transform;
        myContrains_Z = 0;
	}

    private void Update()
    {
        if (player.position.z != 0)
            player.position = new Vector3(player.position.x, player.position.y, myContrains_Z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("DoorWarp"))
        {
            var warpPos = other.transform.position.x + (Mathf.Sign(other.transform.position.x) * buffer);
            if (player.position.x < warpPos)
                OnMyLeft();
            else if (player.position.x > warpPos)
                OnMyRight();
        }
    }

    void OnMyLeft()
    {
        player.position = new Vector3(leftWarp.position.x + buffer, player.position.y, 0);
    }

    void OnMyRight()
    {
        player.position = new Vector3(rightWarp.position.x - buffer, player.position.y, 0);
    }
}
