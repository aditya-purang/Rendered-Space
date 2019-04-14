using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLeft : MonoBehaviour
{
    public PatientManager pm;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.CompareTag("Left"))
        {
            pm.lballItr++;
            gameObject.SetActive(false);
            if (pm.lballItr < pm.draw.ballsL.Count)
            pm.draw.ballsL[pm.lballItr].SetActive(true);
        }
    }
    /*
    void getProgress()
    {
        if (lballItr < draw.ballsL.Count && !draw.ballsL[lballItr].activeInHierarchy)
        {
            draw.ballsL[lballItr].SetActive(true);
        }
        if (rballItr < draw.ballsR.Count && !draw.ballsR[rballItr].activeInHierarchy)
        {
            draw.ballsR[rballItr].SetActive(true);
        }
    }
 
    */
    }
