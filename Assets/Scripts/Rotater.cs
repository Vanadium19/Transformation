using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _startRotationY = 0;
    private float _finalRotationY = 359;
    private float _targetRotationY;    

    private void Update()
    {
        if (transform.rotation == Quaternion.Euler(0, _finalRotationY, 0))        
            _targetRotationY = _startRotationY;        

        Rotate();
    }  

    private void Rotate()
    {
        _targetRotationY = Mathf.MoveTowards(_targetRotationY, _finalRotationY, _speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, _targetRotationY, 0);
    }
}
