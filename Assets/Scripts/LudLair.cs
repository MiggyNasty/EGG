using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudLair : MonoBehaviour
{   

    [SerializeField]

    GameObject cam, music;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Debug.Log(" Player has entered the lair");
            Camera.main.fieldOfView = 80f;
            Camera.main.SendMessage("SetZPosition", -30f);
            music.GetComponent<MusicBehaviour>().SendMessage("SwitchToBossMusic");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            Debug.Log(" Player has entered the lair");
            Camera.main.fieldOfView = 65f;
            Camera.main.SendMessage("SetZPosition", -15f);
            music.GetComponent<MusicBehaviour>().SendMessage("SwitchOffBossMusic");
        }
    }
}
