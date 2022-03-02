using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Male_Anim : MonoBehaviour
{	
	public Animator man;
	public bool man_move;
	public int num;
    // Start is called before the first frame update
    void Start()
    {   
    	
    }

    // Update is called once per frame
    void Update()
    {
        if(num == 1){
        	man.enabled = true;
        	man.Play("HumanArmature|Man_Idle");
        }else if(num == 2){
        	man.enabled = true;
        	man.Play("mixamo_com");
        }else if(num == 3){
        	man.enabled = true;
        	man.Play("HumanArmature|Man_Run");
        }else if(num == 4){
        	man.enabled = true;
        	man.Play("HumanArmature|Man_Walk");
        }else{
        	man.enabled = false;
        }
        
       

    }
}
