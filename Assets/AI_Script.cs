using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AI_Script : MonoBehaviour
{
    public Rigidbody RB;
    public float Speed = 3f;
    public float BounceAngleMultiplier = 2.5f;
    public BallScript ball;
    public Transform ballTransform; // Reference to the ball's transform
    public TextMeshPro Score3Text;
    public TextMeshPro HighScoreText;
    public int PlayerAiScore = 0;
    public static int Highscore = 0;
    
    void Start()
    {
        UpdateScore();
                                          
        PlayerPrefs.SetInt("Highscore", PlayerAiScore);
        PlayerAiScore = PlayerPrefs.GetInt("Highscore");
    }
    void FixedUpdate()
    {
        if (ballTransform != null)
        {
            float directionY = Mathf.Clamp(ballTransform.position.y - transform.position.y, -1f, 1f);
            float directionZ = Mathf.Clamp(ballTransform.position.z - transform.position.z, -1f, 1f);

            Vector3 vel = new Vector3(0, directionY * Speed, directionZ * Speed);

            RB.velocity = vel;

            if (transform.position.z < -12)
            {
                Vector3 newPosition = transform.position;
                newPosition.z = -11.5f;
                transform.position = newPosition;
            }
        }
        
        int hs = PlayerPrefs.GetInt("", 0);
        HighScoreText.text = "" + hs;
        if (hs < PlayerAiScore)
        {
            PlayerPrefs.SetInt("", PlayerAiScore);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ball collided with paddle.");

            float relativeY = other.transform.position.y - transform.position.y;
            float normalizedRelativeY = relativeY / (transform.localScale.y / 2);
            float bounceAngle = normalizedRelativeY * (Mathf.PI / 4) * BounceAngleMultiplier;

            Debug.Log("Bounce Angle: " + bounceAngle);
            
            Vector3 newVelocity = new Vector3(Mathf.Cos(bounceAngle), Mathf.Sin(bounceAngle), 0) 
                                  * other.gameObject.GetComponent<BallScript>().Speed;
            
            other.gameObject.GetComponent<Rigidbody>().velocity = newVelocity;

            Debug.Log("New Ball Velocity: " + newVelocity);
            
            PlayerAiScore += 10;
            UpdateScore();
        }
    }
    public void UpdateScore()
    {
        Score3Text.text = "" + PlayerAiScore;
    }
     
    public void UpdateHighscore()
    {
        HighScoreText.text = "" + Highscore;
    }
}
