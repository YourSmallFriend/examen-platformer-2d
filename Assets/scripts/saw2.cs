using System.Collections;
using UnityEngine;

public class saw2 : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the saw blade
    public float delayTime = 1f; // Delay between movements

    private bool movingUp = false; // Flag to track saw blade movement direction
    public bool waiting = false; // Flag to track whether the saw is waiting

    private Vector3 initialPosition; // Store the initial position of the saw

    void Start()
    {
        initialPosition = transform.position; // Store the initial position
        StartCoroutine(MoveSaw());
    }

    IEnumerator MoveSaw()
    {
        while (true) // Infinite loop to continuously move the saw
        {
            // Determine the target Y position based on the movement direction
            float targetY = movingUp ? initialPosition.y - 4.76f : initialPosition.y;

            // Calculate the distance to the target position
            float distanceToTarget = Mathf.Abs(transform.position.y - targetY);

            // Move the saw towards the target Y position with limited distance
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetY, transform.position.z), step);

            // Wait for the specified delay time after reaching the target position
            if (distanceToTarget < 0.01f)
            {
                waiting = true;
                yield return new WaitForSeconds(delayTime);
                waiting = false;

                // Reverse movement direction
                movingUp = !movingUp;
            }

            yield return null; // Wait for the next frame
        }
    }
}
