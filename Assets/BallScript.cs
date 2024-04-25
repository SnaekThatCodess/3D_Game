using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody RB;
    public float Speed = 2;
    public Player1Script player1;
    public Player2Script player2;
    public AI_Script AI;

    void Start()
    {
        // Set initial velocity
        Vector3 initialVelocity = Random.insideUnitSphere.normalized * Speed;
        //initialVelocity.z = 0; // Set the z component of velocity to zero
        RB.velocity = initialVelocity;
    }

    void Update()
    {
        Vector3 vel = RB.velocity;
        if (vel.magnitude < 1)
        {
            vel = Random.insideUnitSphere.normalized * Speed;
            vel.z = 0;
        }
        
        //vel.z = Speed;
        
        if (transform.position.z < -12)
        {
            Vector3 newPosition = transform.position;
            vel.z = -1.01f;
            newPosition.z = -6;
            transform.position = newPosition;
        }
        
        RB.velocity = vel;
    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 normal = other.transform.up;
        
        if (other.gameObject.CompareTag("border"))
        {
            float dotProduct = Vector3.Dot(RB.velocity, normal);
            Vector3 perpendicularVelocity = dotProduct * normal;
            Vector3 parallelVelocity = RB.velocity - perpendicularVelocity;
            perpendicularVelocity *= -1.001f;
            AI.Speed = 1.01f;
            RB.velocity = perpendicularVelocity + parallelVelocity;

            player1.Player1Score += 5;
            player2.Player2Score += 5;
            AI.PlayerAiScore += 5;
        }
    }
}
