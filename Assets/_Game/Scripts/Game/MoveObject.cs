using UltEvents;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] Transform target;
    [SerializeField] UltEvent onComplete;

    bool isMoving;
    Vector3 direction;

    private void Update()
    {
        if (isMoving)
        {
            target.position += speed * Time.deltaTime * direction;

            if (ReachEnd())
            {
                isMoving = false;
                onComplete?.Invoke();
            }
        }
    }

    bool ReachEnd()
    {
        return Vector3.Distance(target.position, end.position) < 0.1f;
    }

    public void StartMove()
    {
        target.position = start.position;
        direction = (end.position - target.position).normalized;
        target.ChangeScaleX(Mathf.Sign(direction.x));
        isMoving = true;
    }
}
