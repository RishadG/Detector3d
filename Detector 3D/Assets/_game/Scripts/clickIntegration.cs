using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabtale.TTPlugins;

public class clickIntegration : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if(!PlayerPrefs.HasKey("TTPSetup"))
        {
            TTPCore.Setup();
            PlayerPrefs.SetInt("TTPSetup", 1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
