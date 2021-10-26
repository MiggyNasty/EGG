using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCameraController : MonoBehaviour
{
 public GameObject targ;

    public float camMoveSpeed = 1f;

    public float zpos;
    // Start is called before the first frame update
    void Start()
    {
        zpos = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targ){
            Vector3 targPos = new Vector3(targ.transform.position.x, targ.transform.position.y + 2, zpos);
            transform.position = Vector3.Lerp(transform.position, targPos, camMoveSpeed * Time.deltaTime);
        }

        if(targ.tag == "Player"){
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 10f, 100f);
        }else{
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 30f, 3000f);
        }
    }

    public void setTarget(GameObject target){
        targ = target;
    }

    public void removeTarget(){
        targ = null;
    }

    public void SetZPosition(float z){
        zpos = z;
    }
}
