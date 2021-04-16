using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;


    private int _currentTarget = 0;
    private bool _reverse;
    private bool _targetReached;
    private bool _isAlert;
    private Vector3 _alertedPosition;

    NavMeshAgent _agent;
    Animator _anim;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (!_isAlert)
        {
            if (_waypoints.Count > 0 && _waypoints[_currentTarget] != null)
            {
                _agent.SetDestination(_waypoints[_currentTarget].position);
                var distance = Vector3.Distance(transform.position, _waypoints[_currentTarget].position);

                if (distance < 4f && (_currentTarget == 0 || _currentTarget == _waypoints.Count - 1))
                {
                    _anim.SetBool("walk", false);
                }
                else
                {
                    _anim.SetBool("walk", true);
                }

                if (distance < 4.0f && !_targetReached)
                {
                    if (_waypoints.Count < 2)
                        return;

                    _targetReached = true;
                    StartCoroutine(WaitBeforeMoving());
                }
            }
        }
        else if (_isAlert)
        {
            StartCoroutine(AlertedAIRoutine());
        }
    }

    public void AlertAI(Vector3 alertedPosition)
    {
        _isAlert = true;
        this._alertedPosition = alertedPosition;
        
    }


    IEnumerator WaitBeforeMoving()
    {
        if (_currentTarget == 0)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
        else if (_currentTarget == _waypoints.Count - 1)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
        }

        if (_reverse)
        {
            _currentTarget--;
            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
                
            }
        }
        else if (!_reverse)
        {
            _currentTarget++;
            if (_currentTarget == _waypoints.Count)
            {
                _reverse = true;
                _currentTarget--;
            }
        }

        _targetReached = false;
    }

    IEnumerator AlertedAIRoutine()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.9f));
        _anim.SetBool("walk", true);
        _agent.SetDestination(_alertedPosition);

        var distance = Vector3.Distance(transform.position, _alertedPosition);
        if (distance < Random.Range(0.1f, 4f))
        {
            _anim.SetBool("walk", false);
            yield return new WaitForSeconds(Random.Range(2f, 3f));
            _isAlert = false;
        }
    }
}
