using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    AudioSource flush;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        flush.Play();
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
