using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] AudioClip _VOClip = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_VOClip != null)
            {
                AudioSource.PlayClipAtPoint(_VOClip, Camera.main.transform.position);
            }
        }
    }
}
