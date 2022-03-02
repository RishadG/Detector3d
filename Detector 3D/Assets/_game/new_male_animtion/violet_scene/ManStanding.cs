using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManStanding : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator man;
    public Animator Skeleton;
    public int val;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(val == 1){
        	man.Play("HumanArmature|Man_Idle");
        	Skeleton.Play("Sitting Idle");
        }else if(val == 2){
        	man.Play("HumanArmature|Man_Walk");
        	Skeleton.Play("Walking");
        }
    }
}
