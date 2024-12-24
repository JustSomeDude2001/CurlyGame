using System.Collections;
using System.Collections.Generic;
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

    protected override void OnActive()
    {
        if (timer < StopTime) {
            timer += Time.deltaTime;
        } else {
            Vector3 direction = (transform.position - playerLastPos).normalized;
            transform.position += SpeedApproach * Time.deltaTime * direction;
        }
    }

    protected override void OnIdle()
    {
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
