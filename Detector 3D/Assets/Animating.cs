using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animating : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
         
         anim.Play("head");
    }

    // Update is called once per frame
    void Update()
    {
       anim.Play("HumanArmature|Female_Sitting");
    }
}
