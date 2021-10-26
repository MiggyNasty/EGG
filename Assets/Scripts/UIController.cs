using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]

    GameObject player;

    [SerializeField]

    TMP_Text timer, fartCount, pauseText;

    [SerializeField]
    Button resume, mm, quit;

    int playtime;
    int farts;

    EggBehaviour eb;

    [SerializeField]
    bool paused;

    int hours;
    int minutes;

    int seconds;

    void Start()
    {
        eb = player.GetComponent<EggBehaviour>();
        paused = false;

    }

    // Update is called once per frame
    void Update()
    {
        playtime = (int) eb.Timer;
        farts = (int) eb.fartCount;

        hours = TimeSpan.FromSeconds(playtime).Hours;
        minutes  = TimeSpan.FromSeconds(playtime).Minutes;
        seconds= TimeSpan.FromSeconds(playtime).Seconds;

        timer.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        fartCount.text = ("Farts: " + farts.ToString());
        paused = eb.paused;
        resume.gameObject.SetActive(paused);
        mm.gameObject.SetActive(paused);
        quit.gameObject.SetActive(paused);
        pauseText.GetComponent<TextMeshProUGUI>().enabled = paused;


    }

    public void Pause(bool paused){
        this.paused = paused;
    }

    public void MainMenu(){
        paused = false;
        eb.paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Disable(){
        GetComponent<Canvas>().enabled = false;
    }
}
