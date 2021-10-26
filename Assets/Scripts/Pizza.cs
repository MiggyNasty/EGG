using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{   
    [SerializeField]
    Vector3 rotationDirection;

    [SerializeField]
    public float durationTime;

    [SerializeField]
    private float smooth;
 
    // Use this for initialization
    void Start () {
   
    }
 
    // Update is called once per frame
    void Update () {
        smooth = Time.deltaTime * durationTime;
        transform.Rotate(rotationDirection * smooth);
    }
}
