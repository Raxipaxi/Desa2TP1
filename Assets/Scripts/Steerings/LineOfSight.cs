
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    // Line of Sight Parameters
    // public float range = 10;
    // public float angle = 90;

    public bool IsInSight(Transform target, Transform origin, LayerMask maskObs, float range, float angle) //
    {
        Vector3 diff = target.position - origin.position;
        float distance = diff.magnitude;
        if (distance > range) return false;

        Vector3 front = origin.forward;

        if (!InAngle(diff, front, angle)) return false;

        if (!IsInView(origin.position, diff.normalized, distance, maskObs)) return false;

        return true;
    }

    bool InAngle(Vector3 from, Vector3 to, float angle)
    {
        float angleToTarget = Vector3.Angle(from, to);
        return angleToTarget < angle / 2;
    }

    bool IsInView(Vector3 originPos, Vector3 dirToTarget, float distance, LayerMask maskObstacle)
    {
        return !Physics.Raycast(originPos, dirToTarget, distance, maskObstacle);
    }
}

