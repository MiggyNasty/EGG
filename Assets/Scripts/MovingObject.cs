using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    // Start is called before the first frame update

    float timer = 0f;

    [SerializeField]
    float dir, speed, cycle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( timer < cycle){
            timer += Time.deltaTime;
        }else{
            dir = dir * -1;
            timer = 0;
        }
    }

    private void FixedUpdate() {
        transform.position = new Vector3(transform.position.x, transform.position.y + dir * speed * Time.deltaTime, transform.position.z);
    }
}
