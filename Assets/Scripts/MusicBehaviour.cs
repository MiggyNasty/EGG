using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]

    AudioSource music, bossMusic, currentTrack;

    [SerializeField]
    [Range(0, 0.1f)]
    float volume;

    [SerializeField]

    Slider  musicSlider;

    [SerializeField]
     float FadeTime;

    [SerializeField]

    AudioClip[] tracks;

    float bossMusicBoost;

    [SerializeField]
    bool switchingTracks = false;
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.clip = tracks[0];
        volume = 0.01f;
        bossMusicBoost = 1.5f;

       musicSlider.value = volume;
    }

    // Update is called once per frame
    void Update()
    {
        if(!switchingTracks){

            if(currentTrack == music){
                currentTrack.volume = volume;
            }else{
                currentTrack.volume = volume * bossMusicBoost;
            }
            
        }
    }

    public void PlayMusic(){
        currentTrack = music;
        music.Play();
        bossMusic.volume = 0;
        bossMusic.Play();
    }

    public void SwitchToBossMusic(){
        StartCoroutine(FadeOutMusic());
        StartCoroutine(FadeInBossMusic());
    }

    public void SwitchOffBossMusic(){
        StartCoroutine(FadeOutBossMusic());
        StartCoroutine(FadeInMusic());
    }

    public void setVolume(){
        volume = musicSlider.value;
        
    }
    IEnumerator FadeOutMusic(){
        FadeTime = 0.5f;

        switchingTracks = true;

        while (music.volume > 0f){
            music.volume -= music.volume * Time.deltaTime/ FadeTime;
            yield return null; 
        } 
        
    }

    
    IEnumerator FadeInBossMusic(){
        FadeTime = 1f;
        
        while (bossMusic.volume < volume * bossMusicBoost){
            bossMusic.volume += Time.deltaTime / FadeTime;
            yield return null; 
        } 

        currentTrack = bossMusic;
        switchingTracks = false;

    }

      IEnumerator FadeOutBossMusic(){
        FadeTime = 0.5f;

        switchingTracks = true;

        while (bossMusic.volume > 0f){
            bossMusic.volume -= bossMusic.volume * Time.deltaTime/ FadeTime;
            yield return null; 
        } 
  
    }
    IEnumerator FadeInMusic(){
        FadeTime = 1f;
        
        while (music.volume < volume){
            music.volume += Time.deltaTime / FadeTime;
            yield return null; 
        } 

        currentTrack = music;
        switchingTracks = false;

    }


    //Boss music: Bio_Unit - Deep https://freemusicarchive.org/music/Bio_Unit
}
