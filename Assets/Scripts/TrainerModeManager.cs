using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrainerModeManager : MonoBehaviour
{
    public string folderPath;
    public GameObject IKAvatar;
    public GameObject trainerRig;
    public GameObject shadowActor;

   public bool isRecording = false;

    public SteamVR_Action_Boolean triggerButton;
    public SteamVR_Action_Boolean gripButton;
    public SteamVR_Action_Boolean touchpadButton;

    private void Start()
    {
        IKAvatar.GetComponent<recording>().setParams();
        shadowActor.GetComponent<Animation>().enabled = false;
    }

    public void Update()
    {

        if (gripButton.GetStateDown(SteamVR_Input_Sources.Any))
        {
            if (!isRecording)
            {
                isRecording = true;
                //start line renderer
                startRecording();
            }
            else
            {
                isRecording = false;
                //stop line renderer
                stopRecording();
                trainerRig.SetActive(false);
                shadowActor.GetComponent<Animation>().enabled = true;
            }
        }

    }




        void startRecording()
        {
            IKAvatar.GetComponent<recording>().record = true;

        }

        void stopRecording()
        {
            IKAvatar.GetComponent<recording>().record = false;
        }

    }
