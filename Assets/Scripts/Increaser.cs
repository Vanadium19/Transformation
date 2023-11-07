using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increaser : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _startScale;
    private Vector3 _finaleScale = new Vector3(3, 3, 3);
    private Vector3 _targetScale;
    private Coroutine _scaleChanger;

    private void Start()
    {
        _startScale = transform.localScale;
        _targetScale = _finaleScale;
        StartChangeScale();
    }

    private void Update()
    {
        if (transform.localScale == _targetScale)
        {
            _targetScale = transform.localScale == _finaleScale ? _startScale : _finaleScale;
            RestartChangeScale();
        }
    }  

    private void RestartChangeScale()
    {
        StopChangeScale();
        StartChangeScale();
    }

    private void StartChangeScale()
    {
        _scaleChanger = StartCoroutine(ChangeScale());
    }

    private void StopChangeScale()
    {
        if (_scaleChanger != null)
            StopCoroutine(_scaleChanger);
    }

    private IEnumerator ChangeScale()
    {
        while (transform.localScale != _targetScale)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, _targetScale, _speed * Time.deltaTime);
            yield return null;
        }

        transform.localScale = _targetScale;
    }
}
