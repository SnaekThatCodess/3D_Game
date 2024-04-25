using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public TextMeshPro StartText;
    public TitleScript title;
    public BoxCollider BC;

    public void UpdatePlay()
    {
        StartText.text = "good luck to you";
    }

    public void OnMouseOver()
    {
        StartText.color = Color.green;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("DifficultySelection");
        StartText.color = Color.black;
    }

public void OnMouseDown()
    {
        UpdatePlay();
        Invoke("ChangeScene", 5);
    }
}
