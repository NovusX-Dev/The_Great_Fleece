using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _startingCamera;

    CinemachineBrain _brain;

    private void Awake()
    {
        _brain = GetComponent<CinemachineBrain>();    
    }

    private void Start()
    {
        transform.position = _startingCamera.position;
        transform.rotation = _startingCamera.rotation;
        Camera.main.fieldOfView = 60f;
    }

    void Update()
    {
        
        transform.LookAt(_player);
        if (_brain.ActiveVirtualCamera == null)
        {
            Camera.main.fieldOfView = 60f;
        }
    }
}
