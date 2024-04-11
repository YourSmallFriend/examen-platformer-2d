using System.Collections;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float delayTime = 1f;

    private bool movingUp = false;
    public bool waiting = false;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MoveSaw());
    }

    IEnumerator MoveSaw()
    {
        while (true)
        {
            float targetY = movingUp ? initialPosition.y + 4.76f : initialPosition.y;
            float distanceToTarget = Mathf.Abs(transform.position.y - targetY);
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetY, transform.position.z), step);
            if (distanceToTarget < 0.01f)
            {
                waiting = true;
                yield return new WaitForSeconds(delayTime);
                waiting = false;

                movingUp = !movingUp;
            }

            yield return null;
        }
    }
}
