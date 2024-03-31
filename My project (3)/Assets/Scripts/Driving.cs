using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Driving : MonoBehaviour {
    //[Header("References")]
    public Rigidbody carRb;
    public Rigidbody vanRb;

    public GameObject car;
    public GameObject van;

    //[Header("Vehicles")]
    public float acceleration;

    void Start(){
        //carRb = car.GetComponent<Rigidbody>();
        //vanRb = van.GetComponent<Rigidbody>();


    }

    private void drivingLesson(){
        //carRb.velocity = Vector3.right * acceleration;

    }

    void Update(){

    }

    private void FixedUpdate(){
        drivingLesson();
    }
}