using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LudwigBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject slimeEgg, face;

    [SerializeField]
    ParticleSystem deathParticles;

    [SerializeField]
    Renderer rend;

    [SerializeField]
    GameObject ui, winscreen;

    [SerializeField]
    Material mat;

    [SerializeField]
    GameObject[] body;

    [SerializeField]

    AudioSource sound, success;
    void Start()
    {
        rend = face.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player" && slimeEgg.transform.position.x > transform.position.x  ){
            Die();
        }
    }

    void Die(){
    Debug.Log("Lud Died");
        sound.Play();
        Camera.main.DOShakePosition(5f, 1, 10, 5, true);
        rend.material = mat;
        deathParticles.Play();
        Explode();
        StartCoroutine(Delay());
    }

    void Explode(){
        foreach (GameObject b in body){
            b.GetComponent<MeshCollider>().convex = true;
            b.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    IEnumerator Delay(){
        float timer = 0;
        while (timer < 5){
            timer += Time.deltaTime;
            yield return null;           
        }
        win();
    }

    void win(){
        ui.GetComponent<UIController>().Disable();
        winscreen.GetComponent<WinScreen>().Enable();
        success.Play();
    }
}
