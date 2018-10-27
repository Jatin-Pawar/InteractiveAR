using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

public class AnchorFun : MonoBehaviour
{

    private GameObject anchoredToPrefab;

    public GameObject anchoredPrefab;

    private List<GameObject> anchoredPrefabs;

    public Camera firstCamera;


    Anchor anchor;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase != TouchPhase.Began)
        {
            anchor = Session.CreateAnchor(new Pose(transform.position, transform.rotation));
            anchoredPrefab = GameObject.Instantiate(anchoredToPrefab, anchor.transform.position, anchor.transform.rotation, anchor.transform);
            anchoredPrefabs.Add(anchoredPrefab);

        }

        anchoredPrefab.transform.LookAt(firstCamera.transform);

        foreach (GameObject prefab in anchoredPrefabs)
        {
            prefab.transform.LookAt(firstCamera.transform);

        }



    }


}
