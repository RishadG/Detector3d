using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_rifle : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator rifle;
    public bool rifle_on;

   

    void Start()
    {
        //rifle.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {     
    	if(rifle_on){
    			rifle.enabled = true;
    		rifle.Play("rifle");
    		}else{
    			rifle.enabled = false;
    		}
        
    }
}
