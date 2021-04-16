using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _cursorMarker;
    [SerializeField] LayerMask _walkableNavMesh;
    [SerializeField] Animator _myAnim;

    private bool _isWalking = false;
    private Vector3 _targetDestination;

    NavMeshAgent _navMesh;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000, _navMesh.areaMask))
            {
                _targetDestination = hit.point;
                _navMesh.SetDestination(_targetDestination);
                _isWalking = true;
            }
        }

        var distance = Vector3.Distance(transform.position, _targetDestination);
        if (distance < 1.0f)
        {
            _isWalking =false;
        }

        _myAnim.SetBool("walk", _isWalking);
    }
}
