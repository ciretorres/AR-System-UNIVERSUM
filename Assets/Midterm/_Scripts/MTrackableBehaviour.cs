using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using static Vuforia.TrackableBehaviour;

public class MTrackableBehaviour : MonoBehaviour
{
    public TrackableBehaviour mTrackableBehaviour;

    public ReceiverBehaviourScript send;
    //public bool isTracked = false;
    //public GameObject model_3;

    //// Use this for initialization
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    protected virtual void Awake(){        

        //Debug.Log(model_3);

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour){
            mTrackableBehaviour.RegisterOnTrackableStatusChanged(OnTrackableStatusChanged);            
        }

    }

    private void OnTrackableStatusChanged(TrackableBehaviour.StatusChangeResult statusChangeResult){

        if(statusChangeResult.NewStatus == Status.DETECTED
            || statusChangeResult.NewStatus == Status.TRACKED
            || statusChangeResult.NewStatus == Status.EXTENDED_TRACKED){

            OnTrackingFound();
        } else {
            if(statusChangeResult.PreviousStatus == Status.TRACKED
                && statusChangeResult.NewStatus == Status.NO_POSE){

                OnTrackingLost();
            }  else  {                

                OnTrackingLost();
            }
        }        
    }

    private void OnTrackingFound(){
        Debug.Log("Entre a OnTrackingFound");

        send.imageTargetColor(mTrackableBehaviour, mTrackableBehaviour.TrackableName);

        //Debug.Log("Targets tracked: " + isBothTargetsTracked());

        ////if (isBothTargetsTracked() == 3)
        //if(isBothTargetsTracked() == 2){
        //    model_3.SetActive(true);
        //}  else  {
        //    model_3.SetActive(false);
        //}
    }

    private void OnTrackingLost(){
        Debug.Log("Entre a OnTrackingLost");

        //    model_3.SetActive(false);     
    }

    //private int isBothTargetsTracked()
    //{
    //    int count = 0;
    //    foreach (MTrackableBehaviour m in FindObjectsOfType<MTrackableBehaviour>()){
    //        Debug.Log("m: " + m.mTrackableBehaviour.Trackable.Name);

    //        if (m.mTrackableBehaviour.Trackable.Name == "orange"){
    //            // si es orange
    //            count++;
    //        } else {
    //            if (m.mTrackableBehaviour.Trackable.Name == "2"){
    //                // si es three
    //                count++;
    //            } 
    //            //else if (m.mTrackableBehaviour.Trackable.Name == "3")
    //            //{
    //            //    // si es whale
    //            //    count++;
    //            //}
    //        }
    //    }
    //    return count;
    //}
}
