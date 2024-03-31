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
    //private Transform playerModel;

    private Vector3 startPosition;

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

    public float acceleration;
    public float timer;
    private float maxTimer = 15;
   
    void Start(){
        //Player
        rb = this.GetComponent<Rigidbody>();
        //anim = this.GetComponentInChildren<Animator>();
        anim = this.GetComponent<Animator>();
        //playerModel = transform.GetChild(0);

        //Vehicles
        carRb = car.GetComponent<Rigidbody>();
        vanRb = van.GetComponent<Rigidbody>();

    }

    void Update(){
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        timer -= Time.fixedDeltaTime;
        drivingLesson();

        if (timer <= -maxTimer){
            timer = maxTimer;

        } else {
            timer -= Time.deltaTime;

        }
        print(timer);
            
    }

    void Moving(Vector3 direction){
        //Character Direction
        if (Input.GetKey("w")){
            playerCameraRoot.transform.localRotation = Quaternion.Euler(0, 0, 0);
            rb.MoveRotation(Quaternion.Euler(0f, 0f, 0f));
            //playerModel.rotation = Quaternion.Euler(0f, 0f, 0f);
           
        }

        if (Input.GetKey("a")){
            playerCameraRoot.transform.localRotation = Quaternion.Euler(0, -90, 0);
            rb.MoveRotation(Quaternion.Euler(0f, -90f, 0f));
            //playerModel.rotation = Quaternion.Euler(0f, -90f, 0f);
        
        }

        if (Input.GetKey("s")){
            playerCameraRoot.transform.localRotation = Quaternion.Euler(0, 180, 0);
            rb.MoveRotation(Quaternion.Euler(0f, 180f, 0f));
            //playerModel.rotation = Quaternion.Euler(0f, 180f, 0f);
        
        }

        if (Input.GetKey("d")){
            playerCameraRoot.transform.localRotation = Quaternion.Euler(0, 90, 0);
            rb.MoveRotation(Quaternion.Euler(0f, 90f, 0f));
            //playerModel.rotation = Quaternion.Euler(0f, 90f, 0f);
        
        }

        if (movement != Vector3.zero){
            anim.SetBool("Walking", true);
            if (rb.velocity.magnitude < maxSpeed){
                rb.velocity += direction * speed * Time.fixedDeltaTime;

            }

        } else {
            anim.SetBool("Walking", false);
            rb.velocity = direction * maxSpeed * Time.fixedDeltaTime;
            //rb.transform.rotation = Quaternion.identity;

        }
        
        
    }

    private void Magnesis(){
        if (Input.GetKey("space")){
            anim.SetBool("Magnesis", true);
           
            timer = 5f;
            carRb.AddForce(Vector3.up * 100);
            vanRb.AddForce(Vector3.up * 70);
        
        } else {
            anim.SetBool("Magnesis", false);
          
        }
    }

    private void drivingLesson(){
        carRb.transform.Translate(0f,0f,0.009f);
        
        if (timer <= 0){
            carRb.MoveRotation(Quaternion.Euler(0f, 180f, 0f));
            
        } else {
            carRb.MoveRotation(Quaternion.Euler(0f, 0f, 0f));
        }

        
    }

    /*
    private void OnCollisionEnter(){
        rb.transform.position = startPosition;

    }
    */

    void FixedUpdate(){
        Moving(movement);
        Magnesis();
        drivingLesson();
    }
}