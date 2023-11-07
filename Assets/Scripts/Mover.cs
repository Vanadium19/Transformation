using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _finalPositionZ;
    [SerializeField] private float _speed;

    private float _startPositionZ;
    private float _targetPositionZ;
    private Vector3 _targetPosition;
    private Coroutine _mover;

    private void Start()
    {
        _startPositionZ = transform.position.z;
        _targetPosition = new Vector3(0, 0, _finalPositionZ);
        StartMove();
    }

    private void Update()
    {
        if (transform.position == _targetPosition)
        {
            SetTargetPosition();
            RestartMove();
        }
    }

    private void SetTargetPosition()
    {
        _targetPositionZ = transform.position.z == _finalPositionZ ? _startPositionZ : _finalPositionZ;
        _targetPosition = new Vector3(0, 0, _targetPositionZ);
    }

    private void RestartMove()
    {
        StopMove();
        StartMove();
    }

    private void StartMove()
    {
        _mover = StartCoroutine(Move());
    }

    private void StopMove()
    {
        if (_mover != null)
            StopCoroutine(_mover);
    }

    private IEnumerator Move()
    {        
        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }

        transform.position = _targetPosition;
    }
}
