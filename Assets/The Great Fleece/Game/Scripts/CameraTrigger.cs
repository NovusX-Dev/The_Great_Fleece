using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] Transform _newCameraPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Camera.main.transform.position = _newCameraPosition.position;
            Camera.main.transform.rotation = _newCameraPosition.rotation;
        }
    }
}

