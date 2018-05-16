using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class PixelPerfectCameraScript : MonoBehaviour {

	public Camera Camera
    {
        get { return _camera ?? (_camera = GetComponent<Camera>()); }
    }

    private Camera _camera;

    public int PixelsPerUnit = 16;

    private int _lastHeight;
    private int _lastPPU;

    public void OnPreRender()
    {
        if (_lastHeight == Screen.height && _lastPPU == PixelsPerUnit) return;

        _lastHeight = Screen.height;
        _lastPPU = PixelsPerUnit;

        Camera.orthographicSize = Screen.height / (PixelsPerUnit * 2f);
    }
}
