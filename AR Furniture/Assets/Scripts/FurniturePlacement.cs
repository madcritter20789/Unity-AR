using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FurniturePlacement : MonoBehaviour
{
    public GameObject spawnableFurniture;
    public ARSessionOrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && !IsButtonPressed())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (raycastManager.Raycast(ray, raycastHits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = raycastHits[0].pose;
                    Instantiate(spawnableFurniture, hitPose.position, hitPose.rotation);
                }

                foreach (var plane in planeManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }
                planeManager.enabled = false;
            }
        }
    }

    private bool IsButtonPressed()
    {
        return EventSystem.current.currentSelectedGameObject?.GetComponent<Button>() != null;
    }

    public void SwitchFurniture(GameObject furniture)
    {
        spawnableFurniture = furniture;
    }
}
