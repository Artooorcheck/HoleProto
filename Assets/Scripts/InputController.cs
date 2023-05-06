using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Vector3 _lastPosition;
    public Vector3 Delta { get; private set; }

    public void UpdatePosition()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _lastPosition = Input.mousePosition;
            return;
        }
        if(Input.GetMouseButton(0))
        {
            Delta = Input.mousePosition - _lastPosition;
            _lastPosition = Input.mousePosition;
            return;
        }
        if(Input.GetMouseButtonUp(0))
        {
            Delta = Vector3.zero;
            _lastPosition = Vector3.zero;
        }
    }
}
