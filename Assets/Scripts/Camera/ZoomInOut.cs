using System.Collections;
using System.Collections.Generic;
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
