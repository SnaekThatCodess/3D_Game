using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player2Script : MonoBehaviour
{
    public Rigidbody RB;
    public float Speed = 3;
    public float BounceAngleMultiplier = 2.5f;
    public BallScript ball;
    public TextMeshPro Score2Text;
    public TextMeshPro HighScoreText;
    
    public int Player2Score = 0;
    public static int Highscore = 0;

    void Start()
    {
        UpdateScore();
      
        PlayerPrefs.SetInt("Highscore", Player2Score);
        Player2Score = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vel = Vector3.zero;
        vel.y = RB.velocity.y;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel += transform.up * (Speed * .5f);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vel += transform.up * (-Speed * .5f);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel += transform.forward * -Speed;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel += transform.forward * Speed;
        }

        if (transform.position.z < -12)
        {
            Vector3 newPosition = transform.position;
            newPosition.z = -11.5f;
            transform.position = newPosition;
        }
        
        int hs = PlayerPrefs.GetInt("", 0);
        HighScoreText.text = "" + hs;
        if(hs < Player2Score)
        {
            PlayerPrefs.SetInt("", Player2Score);
        }
        
        RB.velocity = vel;
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ball collided with paddle.");
        }
            
        float relativeY = ball.transform.position.y - transform.position.y;
        float normalizedRelativeY = relativeY / (transform.localScale.y / 2);
        float bounceAngle = normalizedRelativeY * (Mathf.PI / 4) * BounceAngleMultiplier;

        Debug.Log("Bounce Angle: " + bounceAngle);

        Vector3 newVelocity = new Vector3(Mathf.Cos(bounceAngle), Mathf.Sin(bounceAngle), 0) * ball.Speed;
        ball.RB.velocity = newVelocity;

        Debug.Log("New Ball Velocity: " + ball.RB.velocity);
        Player2Score += 10;
        UpdateScore();
    }
    
    public void UpdateScore()
    {
        Score2Text.text = "" + Player2Score;
    }

    public void UpdateHighscore()
    {
        HighScoreText.text = "" + Highscore;
    }
}
