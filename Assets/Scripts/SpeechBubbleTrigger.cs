using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]

    int index;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        other.GetComponent<EggBehaviour>().SendMessage("showImage", index);
    }
}
