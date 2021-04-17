using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField] GameObject _winScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.HasCard)
            {
                _winScene.SetActive(true);
            }
        }
    }
}
