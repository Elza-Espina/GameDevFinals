﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int waterctr = 200;
    public float gaslevel = 10f;

    public float moveSpeed = 0.0f;
    public Vector2 velocityCheck = new Vector2(20.0f, 0.0f);
    private Animator animator;
    private PlayerInput input;

    public GameObject water;
    public Transform hose;
    
    // Use this for initialization
    void Start()
    {

        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gaslevel -= Time.deltaTime;
        float forceX = 0.0f;
        float forceY = 0.0f;

            var playerAbsVelX = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
      //  var playerAbsVelY = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);

        if (playerAbsVelX <= 1.0f /*&& playerAbsVelY <= 0.1f*/)
        {
            animator.SetInteger("animState", 0);
        }


        if (gaslevel > 0)
        {
            if (input.moving.x != 0)
        {
            forceX = moveSpeed * input.moving.x;
            if (playerAbsVelX <= velocityCheck.x)
            {                
                //Debug.Log("player" + playerAbsVelX+ "limit" + velocityCheck.x);
            }
            if (input.moving.x>0)
            {
                animator.SetInteger("animState", 1);
            }
            if (input.moving.x < 0)
            {                
                animator.SetInteger("animState", -1);
            }
        }

            GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        }else
        {
            Debug.Log("no more gas");
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }

        if (Input.GetKey("space"))
        {
            if (waterctr > 0)
            {
                Instantiate(water, hose.position, hose.rotation);
                waterctr--;
            }
            else if (waterctr == 0)
            {
                Debug.Log("no more water");
            }
        }

    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if ( Input.GetKey(KeyCode.DownArrow))
        {
            if (coll.CompareTag("hydrant")) {
                Debug.Log("hydrating... water level:" + waterctr);
                waterctr++;
            }
            if (coll.CompareTag("gas"))
            {
                Debug.Log("refilling gas... gas level:" + gaslevel);
                gaslevel++;
            }
        }
    }


}
