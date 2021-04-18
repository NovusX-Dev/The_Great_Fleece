using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    #region Singelton
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is NULLLLL!");
            }

            return _instance;
        }
    }
    #endregion

    private PlayableDirector _currentDirector;
    private bool _sceneSkipped = true;
    private float _timeToSkipTo;

    public bool HasCard { get; set; }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_sceneSkipped)
        {
            _currentDirector.time = _timeToSkipTo;
            _sceneSkipped = true;
        }
    }

    public void GetDirector(PlayableDirector director)
    {
        _sceneSkipped = false;
        _currentDirector = director;
    }

    public void GetSkipTime(float skipTime)
    {
        _timeToSkipTo = skipTime;
    }

}
