using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Timer = System.Timers.Timer;
using UnityEngine.SceneManagement;

public class Player1Script : MonoBehaviour
{
    public Rigidbody RB;
    public float Speed = 3;
    public float BounceAngleMultiplier = 2.5f;
    public BallScript ball;
    public TextMeshPro Score1Text;
    public TextMeshPro HighScoreText;
    public TextMeshPro MatchTimer;
    public float Timer;
    public Player2Script player2;
    public AI_Script playerAI;
    
    public int Player1Score = 0;
    public static int Highscore = 0;

    void Start()
    {
        UpdateScore();
      
        PlayerPrefs.SetInt("Highscore", Player1Score);
        Player1Score = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vel = Vector3.zero;
        vel.y = RB.velocity.y;
        
        if (Input.GetKey(KeyCode.W))
        {
            vel += transform.up * (Speed * .5f);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            vel += transform.up * (-Speed * .5f);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            vel += transform.forward * -Speed;
        }
        
        if (Input.GetKey(KeyCode.D))
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
        if(hs < Player1Score)
        {
            PlayerPrefs.SetInt("", Player1Score);
        }

        UpdateTime();
        
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
        Player1Score += 10;
        UpdateScore();
    }

    public void UpdateTime()
    {
        Timer -= Time.deltaTime; //* Mathf.Round(Timer);

        MatchTimer.text = "" + Timer;

        if (Timer <= 0)
        {
            DecideWinner();
        }
    }

    public void DecideWinner()
    {
        if (Player1Score > player2.Player2Score)
        {
            SceneManager.LoadScene("Player1Win");
        }
        
        if (Player1Score > playerAI.PlayerAiScore)
        {
            SceneManager.LoadScene("Player1Win");
        }
        
        if (Player1Score < player2.Player2Score)
        {
            SceneManager.LoadScene("Player2Win");
        }
        
        if (Player1Score < playerAI.PlayerAiScore)
        {
            SceneManager.LoadScene("PlayerAiWin");
        }
    }
    
    public void UpdateScore()
    {
        Score1Text.text = "" + Player1Score;
    }

    public void UpdateHighscore()
    {
        HighScoreText.text = "" + Highscore;
    }
}
