using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;

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
       
        cam.assetsPPU += (int)Input.mouseScrollDelta.y * 2;

    }
}
