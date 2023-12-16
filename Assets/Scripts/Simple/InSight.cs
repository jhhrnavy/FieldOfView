using UnityEngine;

public class InSight : MonoBehaviour
{
    public float viewAngle = 30;
    public float radius = 5f;
    public Transform target;

    private void OnDrawGizmos()
    {
        Vector3 leftDir, rightDir;

        leftDir = GetVectorWithAngle(viewAngle * 0.5f, radius);
        rightDir = GetVectorWithAngle(-viewAngle * 0.5f, radius);

        Debug.DrawLine(transform.position, leftDir + transform.position, Color.green);
        Debug.DrawLine(transform.position, rightDir + transform.position, Color.green);
    }

    private void Update()
    {
        if (IsTargetInSight(target, radius))
            Debug.Log("보인다!!!");
        else
            Debug.Log("어딨지???");
    }

    private Vector3 GetVectorWithAngle(float angle, float radius)
    {
        float theta = angle - transform.eulerAngles.y + 90;
        Vector3 dir = new Vector3(Mathf.Cos(theta * Mathf.Deg2Rad), transform.position.y, Mathf.Sin(theta * Mathf.Deg2Rad)) * radius;
        return dir;
    }

    bool IsTargetInSight(Transform target, float viewDist)
    {
        //  target direction
        Vector3 targetDir = (target.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, targetDir);

        //  calculate angle using dot
        //  -   theta = cos^-1( a dot b / |a||b|)
        float theta = Mathf.Acos(dot) * Mathf.Rad2Deg;

        // check distance
        float dist = Vector3.SqrMagnitude(transform.position - target.position);
        if (viewDist * viewDist >= dist && theta <= viewAngle * 0.5f)
            return true;

        return false;

    }
}
