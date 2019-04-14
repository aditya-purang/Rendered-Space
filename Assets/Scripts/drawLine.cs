using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class drawLine : MonoBehaviour
{
    public string folderPath;

    public LineRenderer lrL;
    public LineRenderer lrR;

    public GameObject LeftHand;
    public GameObject RightHand;

    public GameObject BallToBeTrackedL;
    public GameObject BallToBeTrackedR;

    public List<GameObject> ballsL = new List<GameObject>();
    public List<GameObject> ballsR = new List<GameObject>();

    public GameObject parentOfTrackedObj;

    public float minDist;

    List<Vector3> positionsL = new List<Vector3>();
    List<Vector3> positionsR = new List<Vector3>();

    public void InitiateDraw()
    {
        
        

        while (parentOfTrackedObj.transform.childCount > 0)
        {
            Debug.Log("killing children");
            Destroy(parentOfTrackedObj.transform.GetChild(0).gameObject);
        }

        lrL.positionCount = 1;
        lrR.positionCount = 1;
        positionsL = new List<Vector3>();
        positionsR = new List<Vector3>();
        ballsL = new List<GameObject>();
        ballsR = new List<GameObject>();

        for (int i = 0; i < lrL.positionCount; i++)
        {
            positionsL.Add(lrL.GetPosition(i));
            GameObject h = Instantiate(BallToBeTrackedL, positionsL[i], Quaternion.identity, parentOfTrackedObj.transform);
            h.GetComponent<BallLeft>().pm = parentOfTrackedObj.GetComponent<script>().pm;
            ballsL.Add(h);
        }

        for (int i = 0; i < lrR.positionCount; i++)
        {
            positionsR.Add(lrR.GetPosition(i));
            GameObject h = Instantiate(BallToBeTrackedR, positionsR[i], Quaternion.identity, parentOfTrackedObj.transform);
            h.GetComponent<BallRight>().pm = parentOfTrackedObj.GetComponent<script>().pm;
            ballsR.Add(h);
        }

    }

    public void Draw()
    {


        Vector3 lastPointL = positionsL[positionsL.Count - 1];
        float currentDistanceL = (LeftHand.transform.position - lastPointL).magnitude;
        if (currentDistanceL >= minDist)
        {
            positionsL.Add(LeftHand.transform.position);
            lrL.positionCount = positionsL.Count;
            lrL.SetPositions(positionsL.ToArray());
            GameObject h = Instantiate(BallToBeTrackedL, positionsL[positionsL.Count - 1], Quaternion.identity, parentOfTrackedObj.transform);
            h.GetComponent<BallLeft>().pm = parentOfTrackedObj.GetComponent<script>().pm;
            ballsL.Add(h);
        }

        Vector3 lastPointR = positionsR[positionsR.Count - 1];
        float currentDistanceR = (RightHand.transform.position - lastPointR).magnitude;
        if (currentDistanceR >= minDist)
        {
            positionsR.Add(RightHand.transform.position);
            lrR.positionCount = positionsR.Count;
            lrR.SetPositions(positionsR.ToArray());
            GameObject h = Instantiate(BallToBeTrackedR, positionsR[positionsR.Count - 1], Quaternion.identity, parentOfTrackedObj.transform);
            h.GetComponent<BallRight>().pm = parentOfTrackedObj.GetComponent<script>().pm;
            ballsR.Add(h);
        }
    }
}
