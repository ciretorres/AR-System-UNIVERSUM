using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ReceiverBehaviourScript : MonoBehaviour
{
    public TrackableBehaviour imageTarget1;
    public TrackableBehaviour imageTarget2;
    public TrackableBehaviour imageTarget3;

    public string trackableName1;
    public string trackableName2;
    public string trackableName3;

    public GameObject model_3;

    public bool colorTrackLost;
    public bool animalTrackLost;
    public bool numberTrackLost;

    public void imageTargetColor(TrackableBehaviour imgTarget, string trackName)
    {
        imageTarget1 = imgTarget;
        trackableName1 = trackName;
    }

    public void imageTargetAnimal(TrackableBehaviour imgTarget, string trackName)
    {
        imageTarget2 = imgTarget;
        trackableName2 = trackName;
    }

    public void imageTargetNumber(TrackableBehaviour imgTarget, string trackName)
    {
        imageTarget3 = imgTarget;
        trackableName3 = trackName;
    }

    public void animalTracked(bool t)
    {
        animalTrackLost = t;
    }

    public void numberTracked(bool t)
    {
        numberTrackLost = t;
    }

    public void colorTracked(bool t)
    {
        colorTrackLost = t;
    }

    private void Update()
    {        
        if ((imageTarget1 != null && trackableName1 != null)
            && (imageTarget2 != null && trackableName2 != null)
            && (imageTarget3 != null && trackableName3 != null))
        {            
            print("Se encontraron todas las imagenes");

            if (animalTrackLost || numberTrackLost || colorTrackLost)
            {
                print("Al menos una imagen se encuentra activa");
                model_3.SetActive(true);
            }
            else
            {
                print("Ninguna imagen se encuentra activa");
                model_3.SetActive(false);
            }

            //print("mTrackableBehaviour: " + imageTarget1);
            //print("TrackableName: " + trackableName1);
            //print("mTrackableBehaviour: " + imageTarget2);
            //print("TrackableName: " + trackableName2);
            //print("mTrackableBehaviour: " + imageTarget3);
            //print("TrackableName: " + trackableName3);
        }
        else
        {
            print("No se han encontrado las imagenes");
            model_3.SetActive(false);
        }

    }
}
