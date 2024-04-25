using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPVPScript : MonoBehaviour
{
    public TextMeshPro BeginPlayerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightShift))
        {
            BeginPlayerText.color = Color.green;
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
        BeginPlayerText.text = "let the games begin";
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("PlayerPlayer");
    }
    
    public void ShrinkEffect()
    {
        //vignette slowly consumes screen before switching scenes
    }
}
