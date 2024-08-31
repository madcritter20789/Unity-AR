using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.EventSystems;
using Unity.XR.CoreUtils;

public class Plant : MonoBehaviour
{
    public GameObject[] plants;

    public XROrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Show Raycast
            //Place the pbject randomly but i wanted at raycast point
            //disable the plane and plane manager so plane will not generate all over again

            bool collision = raycastManager.Raycast(Input.mousePosition, raycastHits, TrackableType.PlaneWithinPolygon);

            if (collision)
            {
                GameObject plant_object = Instantiate(plants[Random.Range(0, plants.Length - 1)]);
                plant_object.transform.position = raycastHits[0].pose.position;
            }

            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

            planeManager.enabled = false;

        }
    }
}
