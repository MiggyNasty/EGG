using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;


public class IntroMenu : MonoBehaviour
{
    [SerializeField]
    GameObject slimeEgg, music;


    [SerializeField]
    Image background;

    [SerializeField]
    Image jamieHyneman;

    [SerializeField]

    TMP_Text dialogue;

    int dialogueIndex = 0;

    bool introActive = true;
    bool firstfade = false;

    string[] dialogues = {"<#458B00>Slime<#FFFFFF> wake up!",
                    "It’s me, <b><#FFD700>Jamie Hyneman King of balds</b><#FFFFFF>.... \n<#458B00>Slime<#FFFFFF>, it is time for you to leave your cave and face your destiny.",
                    "Your friend <#b20000>Ludwig<#FFFFFF> has become too powerful. His brain rot has become contagious and is infecting the youth of our planet. Only you have the power to stop him.", 
                    "You must leave your cave and climb all of the way up to Ludwig’s stream chamber to defeat him once and for all using your tremendous fart powers.",
                    "Only you are capable of defeating him, the whole world is counting on you....",
                    "Godspeed, gamer"};


    // Start is called before the first frame update
    void Start()
    {

        jamieHyneman.GetComponent<CanvasRenderer>().SetAlpha(0f);
        dialogue.text = dialogues[0];
        slimeEgg.GetComponent<EggBehaviour>().SendMessage("DisableMovement");

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Jump") && introActive){
            nextDialogue();
        }
    }

    void nextDialogue(){

        if(dialogueIndex == 0){
            fadeInJamie();
        }

        if(dialogueIndex == 4){
            fadeOutJamie();
        }

        if(dialogueIndex == 5){
            EndScene();
            return;
        }

        dialogueIndex += 1;
        dialogue.text = dialogues[dialogueIndex];
        

    }

    void fadeInJamie(){
        jamieHyneman.CrossFadeAlpha(1, 2.0f, false);
    }

    void fadeOutJamie(){
        jamieHyneman.CrossFadeAlpha(0, 2.0f, false);
    }

    void fadeOutBackground(){
        background.CrossFadeAlpha(0, 2.0f, false);
    }
    void fadeInText(){
        dialogue.CrossFadeAlpha(1, 2.0f, false);
    }

    void fadeOutText(){
        dialogue.CrossFadeAlpha(0, 4.0f, false);
    }

    void EndScene(){
        introActive = false;
        fadeOutBackground();
        fadeOutText();
        music.GetComponent<MusicBehaviour>().SendMessage("PlayMusic");
        slimeEgg.GetComponent<EggBehaviour>().SendMessage("EnableMovement");

        GetComponent<Canvas>().enabled = false;
    }
}
