using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour, ITogglable
{
    public Camera[] Cameras;

    [SerializeField]
    private bool _smoothTransform = true;
    [SerializeField]
    private bool _smoothFOV = true;


    private int _currentCameraIndex;

    private Camera _mainCamera;

    public Camera CurrentCamera
    {
        get { return Cameras[_currentCameraIndex]; }
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
        _currentCameraIndex = (_currentCameraIndex + 1) % Cameras.Length;
        _switchTimer = 0;
    }

    private void Update()
    {
        _switchTimer += Time.deltaTime;

        if (_switchTimer < 2)
        {
            _lerpSpeed = _smoothSwitchSpeed;
        }
        else
        {
            _lerpSpeed = Mathf.Lerp(_lerpSpeed, 50, Time.deltaTime);
        }
        LerpCamera();
    }

    private void LerpCamera()
    {
        if (_smoothTransform)
        {
            transform.position = Vector3.Lerp(transform.position, CurrentCamera.transform.position, Time.deltaTime * _lerpSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, CurrentCamera.transform.rotation, Time.deltaTime * _lerpSpeed);
        }
        else
        {
            transform.position = CurrentCamera.transform.position;
            transform.rotation = CurrentCamera.transform.rotation;
        }

        if (_smoothFOV)
        {
            _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, CurrentCamera.fieldOfView, Time.deltaTime * _lerpSpeed);
        }
        else
        {
            _mainCamera.fieldOfView = CurrentCamera.fieldOfView;
        }
    }

}