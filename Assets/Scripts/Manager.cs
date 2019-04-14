using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    
    public GameObject trainerMode;
    public GameObject patientMode;





    // Start is called before the first frame update
    private void Start()
    {


        trainerMode.SetActive(false);
        patientMode.SetActive(false);

        activateTrainer();

        
    }

   public void activateTrainer()
    {
        trainerMode.SetActive(true);
    }

    public void activatePatient()
    {
        
        patientMode.SetActive(true);
    }
}
