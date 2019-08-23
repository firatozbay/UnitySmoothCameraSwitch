using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchToggle : MonoBehaviour
{
    private ITogglable _togglable;

    private void Awake()
    {
        _togglable = GetComponent<ITogglable>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _togglable.Next();
        }
    }
}
