using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPVAScript : MonoBehaviour
{
    public TextMeshPro BeginAIText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightShift))
        {
            BeginAIText.color = Color.green;
            Invoke("ChangeScene", 5);
            ShrinkEffect();
            UpdatePlay();
        }
        else
        {
            //nothing happens
        }
    }
    
    public void UpdatePlay()
    {
        BeginAIText.text = "let the games begin";
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("PlayerAI");
    }
    
    public void ShrinkEffect()
    {
        //vignette slowly consumes screen before switching scenes
    }
}
