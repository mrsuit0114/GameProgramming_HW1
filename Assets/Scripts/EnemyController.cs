using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float destroyLimit = 16f;
    public float moveSpeed = 2f; // Adjust the speed as needed
    private Vector3 currentDirection;

    private void Start()
    {
        Destroy(gameObject, destroyLimit);
        StartCoroutine(MoveRandomly());
    }

    private IEnumerator MoveRandomly()
    {
        while (true) // Repeat indefinitely
        {
            // Generate a random direction
            float randomAngle = Random.Range(0f, 360f);
            currentDirection = Quaternion.Euler(0f, -randomAngle, 0f) * Vector3.right;

            // Move in the current direction for a random duration
            float moveDuration = Random.Range(1f, 4f); // Adjust as needed
            float startTime = Time.time;
            float endTime = startTime + moveDuration;

            while (Time.time < endTime)
            {
                // Move the object in the current direction
                transform.Translate(currentDirection * moveSpeed * Time.deltaTime);

                yield return null; // Yield until the next frame
            }

            yield return null; // Yield for one frame before generating a new direction
        }
    }

}
