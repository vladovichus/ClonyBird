using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    float flapSpeed = 100f;
    float forwardSpeed = 1f;

    bool didFlap = false;

    Animator animator;

    public bool dead = false;

    float deathCoolDown;

    public bool godMode = false;

    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("no animator");
        }
    }

    //Graphic & Input updates
    void Update()
    {
        if (dead)
        {
            deathCoolDown -= Time.deltaTime;
            if (deathCoolDown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))

                    Application.LoadLevel(Application.loadedLevel);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                didFlap = true;
            }
        }
    }

    //physics engine updates
    void FixedUpdate()
    {
        if (dead)
            return;

        GetComponent<Rigidbody2D>().AddForce(force: Vector2.right * forwardSpeed);

        if (didFlap)
        {
            GetComponent<Rigidbody2D>().AddForce(force: Vector2.up * flapSpeed);
            animator.SetTrigger("DoFlap");
            didFlap = false;
        }

        if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angle = Mathf.Lerp(0, -90, (-GetComponent<Rigidbody2D>().velocity.y / 2f) - 0.2f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
            return;

        animator.SetTrigger("Death");
        dead = true;

        deathCoolDown = 0.5f;
    }
}