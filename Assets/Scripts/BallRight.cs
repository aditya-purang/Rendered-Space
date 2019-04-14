using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRight : MonoBehaviour
{
    public PatientManager pm;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.CompareTag("Right"))
        {
            pm.rballItr++;
            gameObject.SetActive(false);
            if (pm.rballItr < pm.draw.ballsR.Count)
            pm.draw.ballsR[pm.rballItr].SetActive(true);
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
