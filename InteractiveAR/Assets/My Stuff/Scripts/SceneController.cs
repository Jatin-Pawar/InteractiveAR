﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;
public class SceneController : MonoBehaviour
{

    public Camera firstCamera;

    public InteractivePlaneController interPlane;


    // Use this for initialization
    void Start()
    {
        Debug.Log("App started.....");

    }

    // Update is called once per frame
    void Update()
    {
        //Check and display errors
        QuitOnConnectionErrors();

        // The session status must be Tracking in order to access the Frame.
        if (Session.Status != SessionStatus.Tracking)
        {
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return;
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

    }

    void QuitOnConnectionErrors()
    {
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            StartCoroutine(CodelabUtils.ToastAndExit(
                "Camera permission is needed to run this application.", 5));
        }
        else if (Session.Status.IsError())
        {
            // This covers a variety of errors.  See reference for details
            // https://developers.google.com/ar/reference/unity/namespace/GoogleARCore
            StartCoroutine(CodelabUtils.ToastAndExit(
                "ARCore encountered a problem connecting. Please restart the app.", 5));
        }

        ProcessTouches();
    }

    void ProcessTouches()
    {

        Touch touch;
        if (Input.touchCount != 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinBounds | TrackableHitFlags.PlaneWithinPolygon;


        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {

            SetSelectedPlane(hit.Trackable as DetectedPlane);

        }
    }

    void SetSelectedPlane(DetectedPlane selectedPlane)
    {
        interPlane.SetSelectedPlane(selectedPlane);
    }
}
