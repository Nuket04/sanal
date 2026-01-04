using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public List<GameObject> letterPrefabs;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();


    // Update is called once per frame
    void Update()
    {
       
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                    {
                        Pose hitPose = hits[0].pose;

                        if (letterPrefabs == null || letterPrefabs.Count == 0) return;

                        int randomIndex = Random.Range(0, letterPrefabs.Count);
                        Instantiate(letterPrefabs[randomIndex], hitPose.position, hitPose.rotation);
                    }
                }
            }
        }
    }
