using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] GameObject _gameOverCutscene;
    [SerializeField] Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MeshRenderer renderer =  GetComponent<MeshRenderer>();
            Color color = new Color(0.6f, 0.1f, 0.1f, 0.3f);
            renderer.material.SetColor("_TintColor", color);
            _animator.enabled = false;
            StartCoroutine(CapturedRoutine());
        }
    }

    IEnumerator CapturedRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        _gameOverCutscene.SetActive(true);
    }
}
