﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using static Vuforia.TrackableBehaviour;

public class TrackableBehaviourAnimalScript : MonoBehaviour
{
    public TrackableBehaviour mTrackableBehaviour;

    public ReceiverBehaviourScript send;

    protected virtual void Awake()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterOnTrackableStatusChanged(OnTrackableStatusChanged);
        }
    }

    private void OnTrackableStatusChanged(TrackableBehaviour.StatusChangeResult statusChangeResult)
    {
        if (statusChangeResult.NewStatus == Status.DETECTED
            || statusChangeResult.NewStatus == Status.TRACKED
            || statusChangeResult.NewStatus == Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            if (statusChangeResult.PreviousStatus == Status.TRACKED
                && statusChangeResult.NewStatus == Status.NO_POSE)
            {
                OnTrackingLost();
            }
            else
            {
                OnTrackingLost();
            }
        }
    }

    private void OnTrackingFound()
    {
        //Debug.Log("Entre a OnTrackingFound");

        send.imageTargetAnimal(mTrackableBehaviour, mTrackableBehaviour.TrackableName);

        send.animalTracked(true);
    }

    private void OnTrackingLost()
    {
        //Debug.Log("Entre a OnTrackingLost");

        send.animalTracked(false);
    }
}
