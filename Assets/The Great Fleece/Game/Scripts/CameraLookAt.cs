using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _startingCamera;

    private void Start()
    {
        transform.position = _startingCamera.position;
        transform.rotation = _startingCamera.rotation;
        Camera.main.fieldOfView = 60f;
    }

    void Update()
    {
        transform.LookAt(_player);
    }
}
