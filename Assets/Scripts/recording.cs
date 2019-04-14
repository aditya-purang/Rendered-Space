using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
public class recording : MonoBehaviour
{
    public AnimationClip clip;
    GameObjectRecorder recorder;
    public drawLine draw;

    public Manager mng;

    public bool record = false;
    bool firstRecord = false;
    public void setParams()
    {
        // Create recorder and record the script GameObject.

        recorder = new GameObjectRecorder(gameObject);
        // Bind all the Transforms on the GameObject and all its children.
        recorder.BindComponentsOfType<Transform>(gameObject, true);
    }

    private void Start()
    {
        // Create recorder and record the script GameObject.

        recorder = new GameObjectRecorder(gameObject);
        // Bind all the Transforms on the GameObject and all its children.
        recorder.BindComponentsOfType<Transform>(gameObject, true);
    }

    private void LateUpdate()
    {
        if (clip == null)
        {
            return;
        }

        if (record)
        {
            if (!firstRecord)
            {
                setParams();
                draw.InitiateDraw();
                firstRecord = true;
            }

            draw.Draw();
            recorder.TakeSnapshot(Time.deltaTime);
        }

        else if (recorder.isRecording)
        {
            recorder.SaveToClip(clip);
            recorder.ResetRecording();
            gameObject.GetComponent<Animation>().AddClip(clip, "1");
            firstRecord = false;
            recorder = new GameObjectRecorder(gameObject);
            recorder.BindComponentsOfType<Transform>(gameObject, true);

            mng.activatePatient();
        }
    }



    /*
     
    public AnimationClip clip;

    private GameObjectRecorder m_Recorder;

    void Start()
    {
        // Create recorder and record the script GameObject.
        m_Recorder = new GameObjectRecorder(gameObject);

        // Bind all the Transforms on the GameObject and all its children.
        m_Recorder.BindComponentsOfType<Transform>(gameObject, true);
    }

    void LateUpdate()
    {
        if (clip == null)
            return;

        // Take a snapshot and record all the bindings values for this frame.
        m_Recorder.TakeSnapshot(Time.deltaTime);
    }

    void OnDisable()
    {
        if (clip == null)
            return;

        if (m_Recorder.isRecording)
        {
            // Save the recorded session to the clip.
            m_Recorder.SaveToClip(clip);
        }
    }
     
     
     */
}
