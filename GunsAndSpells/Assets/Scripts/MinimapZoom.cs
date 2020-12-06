using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapZoom : MonoBehaviour
{
     Camera minimapCamera;
    public float zoomAmount = 20f;


    private void Start()
    {
        minimapCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        //zoomIN/OUT
        minimapCamera.orthographicSize = zoomAmount;
    }
 

    public void UseZoom(float zoom)
    {
        zoomAmount = zoom;
    }
}
