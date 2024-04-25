using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlayerScript : MonoBehaviour
{
    public TextMeshPro PlayerText;
    // Start is called before the first frame update

    public void UpdatePlay()
    {
        PlayerText.text = "get ready";
    }

    public void OnMouseOver()
    {
        PlayerText.color = Color.green;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("PvPControls");
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
