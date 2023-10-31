using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEyeSight : MonoBehaviour
{
    [SerializeField] GameObject _sceneToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Trigger Captured Scene
            _sceneToActivate.SetActive(true);
        }
    }
}
