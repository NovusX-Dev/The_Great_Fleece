using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    [SerializeField] GameObject _keyCardScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.HasCard = true;
            _keyCardScene.SetActive(true);
        }
    }
}
