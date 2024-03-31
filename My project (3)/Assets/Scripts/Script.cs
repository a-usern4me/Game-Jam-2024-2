using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Script : MonoBehaviour {
    [Header("References")]
    //Player
    public Rigidbody rb;
    Animator anim;
    public Transform playerCameraRoot;

    //Car
    public Rigidbody carRb;
    public GameObject car;

    //Hillbilly
    public Rigidbody vanRb;
    public GameObject van;

    [Header("Movement")]
    public float speed;
    public float maxSpeed;
    public Vector3 movement;

    void Start(){
        //Player
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();

        //Vehicles
        carRb = car.GetComponent<Rigidbody>();
        vanRb = van.GetComponent<Rigidbody>();

    }

    void Update(){
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            
    }

    void Moving(Vector3 direction){
        if (movement != Vector3.zero){
            anim.SetBool("Walking", true);
            if (rb.velocity.magnitude < maxSpeed){
                rb.velocity += direction * speed * Time.fixedDeltaTime;

            }

        } else {
            anim.SetBool("Walking", false);

        }
    }

    private void Magnesis(){
        if (Input.GetKey("space")){
            anim.SetBool("Magnesis", true);
            carRb.AddForce(Vector3.up * 100);
            vanRb.AddForce(Vector3.up * 70);
        
        } else {
            anim.SetBool("Magnesis", false);

        }
    }
  
    void FixedUpdate(){
        Moving(movement);
        Magnesis();
    }
}