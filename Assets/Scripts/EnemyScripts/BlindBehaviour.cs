using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlindBehaviour : Attention
{
    public float speedApproach;
    public float speedWander;

    public float maxRadiusWander;
    public float minRadiusWander;
    public float targetHeight;

    public float stopTime;
    private float _timer;

    private Vector3 _targetPos;

    private void Start() {
        _targetPos = transform.position;
    }

    protected override void OnActive()
    {
        Vector3 direction = (_playerLastPos - transform.position).normalized;
        transform.position += speedApproach * Time.deltaTime * direction;
    }

    protected override void OnIdle()
    {
        if (_timer < stopTime) {
            _timer += Time.deltaTime;
            return;
        }

        Vector3 distanceVector = _targetPos - transform.position;

        if (distanceVector.sqrMagnitude < 0.01f) {
            Vector2 targetDirection = Random.insideUnitCircle;
            float targetDistance = Random.Range(minRadiusWander, maxRadiusWander);
            _targetPos = new Vector3(targetDirection.x * targetDistance, 
                                    _playerLastPos.y + targetHeight,
                                    targetDirection.y * targetDistance);
        }

        Vector3 direction = (_targetPos - transform.position).normalized;
        transform.position += speedWander * Time.deltaTime * direction;
    }

    protected override void OnStateSwitch(bool nextState)
    {
        if (nextState == false) {
            _timer = 0f;
            _targetPos = (_playerLastPos - transform.position).normalized * minRadiusWander;
            _targetPos.y = _playerLastPos.y + targetHeight;
        }
    }
}
