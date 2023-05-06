using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainProccessor : MonoBehaviour
{
    [SerializeField] private InputController _input;
    [SerializeField] private Transform _hole;
    [SerializeField] private Slider _scaleSlider;
    [SerializeField] private float _sensivity;
    [SerializeField] private Rect _clampRect;

    private void Start()
    {
        _scaleSlider.onValueChanged.AddListener(ChangeScale);
    }

    private void Update()
    {
        _input.UpdatePosition();
        HoleTransformation();
    }

    private void HoleTransformation()
    {
        Vector3 position = _hole.transform.position + new Vector3(_input.Delta.x, 0, _input.Delta.y)*_sensivity;
        position.x = Mathf.Clamp(position.x, _clampRect.x - _clampRect.width / 2, _clampRect.x + _clampRect.width / 2);
        position.z = Mathf.Clamp(position.z, _clampRect.y - _clampRect.height / 2, _clampRect.y + _clampRect.height / 2);
        _hole.transform.position = position;
    }


    private void ChangeScale(float scale)
    {
        _hole.transform.localScale = new Vector3(scale, scale, 1);
    }
}
