using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

public class InteractivePlaneController : MonoBehaviour
{

    public Camera firstPersonCamera;
    private Anchor anchor;
    private DetectedPlane detectedPlane;
    private float yOffset;
    private int index = 0;

    public GameObject interactivePlanePrefab;

    private GameObject plane;

    private GameObject[] planes;

    // Use this for initialization
    void Start()
    {



        planes = new GameObject[5];

    }

    // Update is called once per frame
    void Update()
    {

        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        // If there is no plane, then return
        if (detectedPlane == null)
        {
            return;
        }

        // Check for the plane being subsumed.
        // If the plane has been subsumed switch attachment to the subsuming plane.
        while (detectedPlane.SubsumedBy != null)
        {
            detectedPlane = detectedPlane.SubsumedBy;
        }




        foreach (GameObject obj in planes)
        {
            if (obj != null)
            {
                // Make the scoreboard face the viewer.
                obj.transform.LookAt(firstPersonCamera.transform);


                // Move the position to stay consistent with the plane.
                obj.transform.position = new Vector3(obj.transform.position.x,
                            detectedPlane.CenterPose.position.y + yOffset, obj.transform.position.z);



            }

        }

        // if (plane != null)
        // {
        //     // Make the scoreboard face the viewer.
        //     plane.transform.LookAt(firstPersonCamera.transform);

        //     // anchor.transform.LookAt(firstPersonCamera.transform);

        //     // Move the position to stay consistent with the plane.
        //     plane.transform.position = new Vector3(plane.transform.position.x,
        //                 detectedPlane.CenterPose.position.y + yOffset, plane.transform.position.z);

        // }







    }

    public void SetSelectedPlane(DetectedPlane detectedPlane)
    {
        this.detectedPlane = detectedPlane;
        CreateAnchor();
    }

    void CreateAnchor()
    {
        // Create the position of the anchor by raycasting a point towards
        // the top of the screen.
        // Vector2 pos = new Vector2(Screen.width * .5f, Screen.height * .90f);
        // Ray ray = firstPersonCamera.ScreenPointToRay(pos);
        // Vector3 anchorPosition = ray.GetPoint(5f);

        // Create the anchor at that point
        anchor = detectedPlane.CreateAnchor(
            new Pose(firstPersonCamera.transform.position, Quaternion.identity));

        plane = GameObject.Instantiate(interactivePlanePrefab, anchor.transform.position, anchor.transform.rotation, anchor.transform);

        if (index < 5)
        {

            planes[index] = plane;

            index = index + 1;

        }




        // Record the y offset from the plane.
        yOffset = plane.transform.position.y - detectedPlane.CenterPose.position.y;




    }
}
