using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlindBehaviour : Attention
{
    public float SpeedApproach;
    public float SpeedWander;

    public float MaxRadiusWander;
    public float MinRadiusWander;
    public float TargetHeight;

    public float StopTime;
    private float timer;

    private Vector3 targetPos;

    private void Start() {
        targetPos = transform.position;
    }

    protected override void OnActive()
    {
        Vector3 direction = (playerLastPos - transform.position).normalized;
        transform.position += SpeedApproach * Time.deltaTime * direction;
    }

    protected override void OnIdle()
    {
        if (timer < StopTime) {
            timer += Time.deltaTime;
            return;
        }

        Vector3 distanceVector = targetPos - transform.position;

        if (distanceVector.sqrMagnitude < 0.01f) {
            Vector2 targetDirection = Random.insideUnitCircle;
            float targetDistance = Random.Range(MinRadiusWander, MaxRadiusWander);
            targetPos = new Vector3(targetDirection.x * targetDistance, 
                                    playerLastPos.y + TargetHeight,
                                    targetDirection.y * targetDistance);
        }

        Vector3 direction = (targetPos - transform.position).normalized;
        transform.position += SpeedWander * Time.deltaTime * direction;
    }

    protected override void OnStateSwitch(bool nextState)
    {
        if (nextState == false) {
            timer = 0f;
            targetPos = (playerLastPos - transform.position).normalized * MinRadiusWander;
            targetPos.y = playerLastPos.y + TargetHeight;
        }
    }
}
