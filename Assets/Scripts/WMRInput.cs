using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WMRInput : MonoBehaviour
{
   

    public SteamVR_Action_Boolean triggerButton;
    public SteamVR_Action_Boolean gripButton;
    public SteamVR_Action_Boolean touchpadButton;   

     

    


   
   

    // Update is called once per frame
    void Update()
    {

       

    }


    

    void setTime()
    {
        //reset time
        if (gripButton.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            
        }

        


        //toggle auto update
        if (triggerButton.GetStateDown(SteamVR_Input_Sources.LeftHand)){
            
        }
    }

    void setScale()
    {

        //reset scale
        if (gripButton.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            
        }

        
    }

    void toggleConstellations()
    {
        if (touchpadButton.GetStateDown(SteamVR_Input_Sources.Any))
        {
            
        }
    }
    
}
