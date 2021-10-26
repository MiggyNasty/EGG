using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    GameObject winscreen;

    [SerializeField]
    EggBehaviour eb;

    [SerializeField]
    TMP_Text  fartText, timeText;
    float playtime, farts, hours, minutes, seconds;
    // Start is called before the first frame update
    void Start()
    {
        winscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enable(){
        Debug.Log("Enable WIn");
        winscreen.SetActive(true);

        playtime = (int) eb.Timer;
        farts = (int) eb.fartCount;

        hours = TimeSpan.FromSeconds(playtime).Hours;
        minutes  = TimeSpan.FromSeconds(playtime).Minutes;
        seconds= TimeSpan.FromSeconds(playtime).Seconds;

        timeText.text = string.Format("Total Run Time: {0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        fartText.text = ("Farts: " + farts.ToString());
    }
}
