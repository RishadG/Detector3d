using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movehead : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;
    void Start()
    {
        //transform.position = new Vector3(1.83f,4.87f,-1.33f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,offset.z);

    }
}
