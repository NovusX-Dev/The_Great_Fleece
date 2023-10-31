using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _coinPrefab;

    [Header("References")]
    [SerializeField] Animator _myAnim;

    private bool _isWalking = false;
    private bool _coinTossed;
    private Vector3 _targetDestination;

    NavMeshAgent _navMesh;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _coinTossed = false;
    }

    void Update()
    {
        CalculateMovement();

        DropCoin();


        _myAnim.SetBool("walk", _isWalking);
    }

    private void CalculateMovement()
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
            _isWalking = false;
        }
    }

    private void DropCoin()
    {
        if (Input.GetMouseButtonDown(1) && !_coinTossed)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000, _navMesh.areaMask))
            {
                _myAnim.SetTrigger("throw_Coin");
                StartCoroutine(TossCoin(hit));
            }
        }
    }

     IEnumerator TossCoin(RaycastHit hit)
     {
         _coinTossed = true;
         yield return new WaitForSeconds(1f);
         Instantiate(_coinPrefab, hit.point, Quaternion.identity);
         SendAITOCoinSpot(hit.point);
     }

    private void SendAITOCoinSpot(Vector3 coinPos)
    {
        var guards = GameObject.FindGameObjectsWithTag("Guard1");


        foreach (var guard in guards)
        {
            guard.GetComponent<GuardAI>().AlertAI(coinPos);
        }
    }
}
