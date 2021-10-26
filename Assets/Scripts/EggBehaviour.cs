using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class EggBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float torque, currentRotX, currentRotZ, fartCharge, fartChargeRate, fartChargeMax, fartCoolDown, fartForce, fartCoolDownTime;

    [SerializeField]
    public float fartCount, fartChargeTotal, Timer;
   

    [SerializeField]

    Slider effectSlider;

    [SerializeField]
    [Range(0, 1)]
    float effectsVolume;

    [SerializeField]

    bool upsideDown, headBumping, onToilet;
    public Rigidbody rb;

    [SerializeField]
    GameObject fartPoint, head, face, ui;

    [SerializeField]
    ParticleSystem fartPS, fartPSMed, fartPSSmall, superfartPS;

    [SerializeField]
    AudioSource fartSound, shellSound;

    [SerializeField]
    List<AudioClip> audioClips, shellSoundClips;


    [SerializeField]
    List<Material> slimefaces;

    Renderer faceRend;

    [SerializeField]
    public bool canMove, paused;

    [SerializeField]
    List<Image> speechBubbles; 

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        faceRend = face.GetComponent<Renderer>();
        canMove = false;
        onToilet = false;
        effectsVolume = 0.5f;
        Timer = 0;
        paused = false;

        effectSlider.value = effectsVolume;
    }

    void Update() {
        currentRotZ = transform.eulerAngles.z;

        //Prevent egg from moving off z = 5 plane
        transform.position = new Vector3(transform.position.x, transform.position.y, 5);

        //Prevent egg from rolling off axis
        transform.eulerAngles = new Vector3(0, -180, currentRotZ);

        if(canMove){
            
            if(Input.GetButton("Jump") && fartCoolDown <= 0 && fartCharge<= fartChargeMax){
                fartCharge += fartChargeRate * Time.deltaTime;

            }else if(fartCoolDown > 0){
                fartCoolDown -= Time.deltaTime;

            }

            if(Input.GetButtonUp("Jump") && fartCoolDown <= 0){
                Fart(fartCharge);
            }

            if(Input.GetKeyDown(KeyCode.Escape)){
                pauseGame();
            }

            if (fartCharge > fartChargeMax){
                fartCharge = fartChargeMax;
            }

            if (fartCoolDown < 0){
                fartCoolDown = 0;
            }

            Timer += Time.deltaTime;
        }
        
        checkUpsideDown();
        changeFace();

        fartSound.volume = effectsVolume;
        shellSound.volume = effectsVolume;


    }

    void FixedUpdate()
    {
        if(canMove){
            float turn = Input.GetAxis("Horizontal");
            rb.AddTorque(0, 0, torque * -turn);
        }
    }

    private void OnCollisionEnter(Collision other) {
        shellSound.clip = audioClips[3];
        shellSound.Play();
    }

    void bump(float charge){
        rb.AddRelativeForce(Vector3.down * charge * fartForce * 0.5f);
    }

    void checkUpsideDown(){
        Debug.DrawRay(head.transform.position, transform.up, Color.green);
        headBumping = Physics.Raycast(head.transform.position, transform.up, 1f);

        if(currentRotZ > 100f && currentRotZ < 240f){
            upsideDown = true;
        }else{
            upsideDown = false;
        }
    }


    void Fart(float charge){
        
        if(!onToilet){
            if (fartCharge >= 4.5f){
                fartSound.clip = audioClips[2];
                fartPS.Play();
            }else if(fartCharge >= 2.5f){
                fartSound.clip = audioClips[1];
                fartPSMed.Play();
            }else{
                fartSound.clip = audioClips[0];
                fartPSSmall.Play();
            }

            fartSound.Play();

            if(upsideDown && headBumping){
                bump(charge);
            }else{
                rb.AddRelativeForce(Vector3.up * charge * fartForce);
                
            }

            fartCount += 1;
            fartChargeTotal += fartCharge;

            fartCharge = 0;
            fartCoolDown = fartCoolDownTime;
        }else if(fartCharge >= 4.5f){
            fartChargeTotal += fartCharge;
            fartCount += 1;
            SuperFart();

        }
    }

    void SuperFart(){
        Debug.Log("SuperFart");
        fartSound.clip = audioClips[4];
        fartSound.Play();
        Camera.main.DOShakeRotation(1f, 1, 10, 5, true);
        rb.AddRelativeForce(Vector3.up * fartCharge * fartForce * 1.8f);
        superfartPS.Play();
        fartCharge = 0;
        fartCoolDown = fartCoolDownTime;
    }

    void changeFace(){
        if(fartCoolDown > 0f){
            faceRend.material= slimefaces[6];
        }else if(fartCharge == 5){
            faceRend.material = slimefaces[5];
        }else if(fartCharge >= 4 ){
            faceRend.material = slimefaces[4];
        }else if(fartCharge >= 3 ){
            faceRend.material = slimefaces[3];
        }else if(fartCharge >= 2 ){
            faceRend.material = slimefaces[2];
        }else if(fartCharge >= 1 ){
            faceRend.material = slimefaces[1];
        }else{
            faceRend.material = slimefaces[0];
        }
    }

    public void DisableMovement(){
        canMove = false;
    }

    public void EnableMovement(){
        canMove = true;
    }

    public void setEffectsVolume(){
        effectsVolume = effectSlider.value;
        fartSound.volume = effectsVolume;
        shellSound.volume = effectsVolume;
    }

    public void showImage(int index){
        speechBubbles[index].CrossFadeAlpha(1f, 0.01f, false);
        speechBubbles[index].CrossFadeAlpha(0f, 5f, false);
    }

    public void setOnToilet( bool ot){
        onToilet = ot;
    }

    public void Win(){
        
    }

    public void pauseGame(){
        if(!paused){
            ui.GetComponent<UIController>().SendMessage("Pause", paused);
            paused = true;
            Time.timeScale = 0;

        }else{
            Time.timeScale = 1;
            paused = false;
            ui.GetComponent<UIController>().SendMessage("Pause", paused);
        }
    }

    public void Quit(){
        Application.Quit();
    }
}

    //"Dorito 3D model" (https://skfb.ly/onKt7) by Efrain Ceja is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
    //"Doritos bag" (https://skfb.ly/6Cyrn) by HeroOfChernobyl is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
    //Background Track: Dee Yan-Key -  Ragtop https://freemusicarchive.org/music/Dee_Yan-Key/car-train-1/ragtop
   

