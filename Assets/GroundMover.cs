using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class GroundMover : MonoBehaviour
{
   private Rigidbody2D player;

    void Start()
    {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");

        if (player_go == null)
        {
            Debug.LogError("Didn't found player tagged object");
            return;
        }

        player = player_go.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float vel = player.velocity.x * 0.75f;

        var transform1 = transform;
        transform1.position = transform1.position + Vector3.right * (vel * Time.deltaTime);
    }
}