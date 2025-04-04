using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ZoomInOut : MonoBehaviour
{
    int scroll = 20;
    PixelPerfectCamera cam;
    private void Start()
    {
        cam = GetComponent<PixelPerfectCamera>();
    }
    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            ZoomIn();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            ZoomOut();
        }

    }
    public void ZoomIn()
    {
        int value = Mathf.Max(scroll, 5);
        cam.assetsPPU = value - 1;
        Debug.LogWarning("hey");
    }
    public void ZoomOut()
    {
        int value = Mathf.Min(scroll, 50);
        cam.assetsPPU = value + 1;
    }
}
