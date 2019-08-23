using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVSwitcher : MonoBehaviour, ITogglable
{
    public float[] FOVs;
    
    [SerializeField]
    private bool _smoothFOV = true;
    
    private int _currentFOVIndex;

    private Camera _mainCamera;

    public float CurrentFOV
    {
        get { return FOVs[_currentFOVIndex]; }
    }

    private float _switchTimer;

    [SerializeField]
    private float _smoothSwitchSpeed = 2;

    private float _lerpSpeed;

    private void Awake()
    {
        _mainCamera = GetComponent<Camera>();
    }

    public void Next()
    {
        _currentFOVIndex = (_currentFOVIndex + 1) % FOVs.Length;
        _switchTimer = 0;
    }

    private void FixedUpdate()
    {
        _switchTimer += Time.deltaTime;

        if (_switchTimer < 2)
        {
            _lerpSpeed = _smoothSwitchSpeed;
        }
        else
        {
            _lerpSpeed = Mathf.Lerp(_lerpSpeed, 50, Time.fixedDeltaTime);
        }
        Lerp();
    }

    private void Lerp()
    {
        if (_smoothFOV)
        {
            _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, CurrentFOV, Time.fixedDeltaTime * _lerpSpeed);
        }
        else
        {
            _mainCamera.fieldOfView = CurrentFOV;
        }
    }

}