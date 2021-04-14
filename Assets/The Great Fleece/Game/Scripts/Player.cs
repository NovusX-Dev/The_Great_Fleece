using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _cursorMarker;
    [SerializeField] LayerMask _walkableNavMesh;

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
                _navMesh.SetDestination(hit.point);
                //Instantiate(_cursorMarker, hit.point, Quaternion.identity);
            }
            else
            {
                Debug.Log("Did not hit anything");
            }

        }
    }
}
