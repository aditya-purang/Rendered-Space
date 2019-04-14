using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PatientManager : MonoBehaviour
{
    public SteamVR_Action_Boolean triggerButton;
    public SteamVR_Action_Boolean gripButton;
    public SteamVR_Action_Boolean touchpadButton;

    public Transform trackingParent;

    public GameObject treesToGrow;
    public float[] treeSizes  ;


    public GameObject shrubsToGrow;
    public float[] shrubSizes  ;

    public GameObject water;
    public float[] waterLevels  ;

    bool ischanging = false;

    public GameObject shadowActor;

    public GameObject leftHand;
    public GameObject rightHand;

    public int setsCompleted = 0;

    bool posStored;
    Vector3 pos;
    Quaternion quat;
    public int lballItr = 0;
    public int rballItr = 0;

    public drawLine draw;

    private void OnEnable()
    {

        resetBalls();
    }

    void resetBalls()
    {
        lballItr = 0;
        rballItr = 0;


        trackingParent.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 0.5f, gameObject.transform.localPosition.z);

        if (posStored == false)
        {
            trackingParent.RotateAround(gameObject.transform.position, Vector3.up, 0);
            posStored = true;
        }

        for (int i = 0; i < draw.ballsL.Count; i++)
        {
            draw.ballsL[i].SetActive(false);
        }

        for (int i = 0; i < draw.ballsR.Count; i++)
        {
            draw.ballsR[i].SetActive(false);
        }

        draw.ballsL[0].SetActive(true);
        draw.ballsR[0].SetActive(true);


    }

    private void Update()
    {
        if (setsCompleted == 3)
        {
            Application.Quit();
        }

        

        if (lballItr == draw.ballsL.Count && rballItr == draw.ballsR.Count)
        {
            setsCompleted++;
            changeScene();
            resetBalls();
                        
        }


    }



    
    void changeScene()
    {
        treesToGrow.transform.localScale= new Vector3(treesToGrow.transform.localScale.x, treeSizes[setsCompleted], treesToGrow.transform.localScale.z);
        shrubsToGrow.transform.localScale= new Vector3(shrubsToGrow.transform.localScale.x, shrubSizes[setsCompleted], shrubsToGrow.transform.localScale.z);
        water.transform.localPosition= new Vector3(water.transform.localPosition.x, waterLevels[setsCompleted], water.transform.localPosition.z);
        
       
    }
}
