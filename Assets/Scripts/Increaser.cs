using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increaser : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _startScale;
    private Vector3 _finaleScale = new Vector3(3, 3, 3);
    private Vector3 _targetScale;
    private Coroutine _increaser;

    private void Start()
    {
        _startScale = transform.localScale;
        _targetScale = _finaleScale;
        StartIncrease();
    }

    private void Update()
    {
        if (transform.localScale == _targetScale)
        {
            _targetScale = transform.localScale == _finaleScale ? _startScale : _finaleScale;
            RestartIncrease();
        }
    }  

    private void RestartIncrease()
    {
        StopIncrease();
        StartIncrease();
    }

    private void StartIncrease()
    {
        _increaser = StartCoroutine(Increase());
    }

    private void StopIncrease()
    {
        if (_increaser != null)
            StopCoroutine(_increaser);
    }

    private IEnumerator Increase()
    {
        while (transform.localScale != _targetScale)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, _targetScale, _speed * Time.deltaTime);
            yield return null;
        }

        transform.localScale = _targetScale;
    }
}
