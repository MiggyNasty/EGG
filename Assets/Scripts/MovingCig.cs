using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCig : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject cig;

    bool forward;
    bool up;
    bool back;

    float xpos;
    float ypos;

    void Start()
    {
        forward = true;
        up = false;
        back = false;
    }

    // Update is called once per frame
    void Update()
    {   
        xpos = transform.position.x;
        ypos = transform.position.y;

        if(forward){
            transform.position = new Vector3(xpos + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if(up){
            transform.position = new Vector3(xpos, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }

        if(back){
            transform.position = new Vector3(xpos - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if(xpos >= -28f && ypos <= 225f){
            up = true;
            forward = false;
        }

        if(ypos>= 225f){
            up = false;
            back = true;
        }

        if(ypos>= 225f && xpos <= -38f){
            Destroy(this);
        }
    }
}
