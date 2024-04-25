using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAiScript : MonoBehaviour
{
    public TextMeshPro PlayerAiText;
    // Start is called before the first frame update
    public void UpdatePlay()
    {
        PlayerAiText.text = "prepare thyself";
    }

    public void OnMouseOver()
    {
        PlayerAiText.color = Color.green;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("PvAControls");
    }

    public void OnMouseDown()
    {
        UpdatePlay();
        Invoke("ChangeScene", 5);
        ShrinkEffect();
    }

    public void ShrinkEffect()
    {
        //vignette slowly consumes screen before switching scenes
    }
}
