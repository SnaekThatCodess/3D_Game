using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    public TextMeshPro TitleText;
    public float Timer = .45f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            TitleText.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            Timer = .45f;
        }
    }
}
