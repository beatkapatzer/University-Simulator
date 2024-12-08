using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRun : MonoBehaviour
{
    // Public variables to tweak speed and movement
    public float forwardSpeed = 10f;
    public float laneSwitchSpeed = 10f;
    public float laneWidth = 2f;

    // Public variable for start position
    public Vector3 startPosition;

    // Private variables
    private int currentLane = 0; // -1 = left, 0 = middle, 1 = right
    private bool isSwitchingLanes = false;

    void Start()
    {
        // Initialize start position
        startPosition = transform.position;
    }

    void Update()
    {
        // Move forward constantly
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Handle lane switching
        if (!isSwitchingLanes)
        {
            if (Input.GetKeyDown(KeyCode.A) && currentLane > -1)
            {
                StartCoroutine(SwitchLane(-1));
            }
            else if (Input.GetKeyDown(KeyCode.D) && currentLane < 1)
            {
                StartCoroutine(SwitchLane(1));
            }
        }
    }

    IEnumerator SwitchLane(int direction)
    {
        isSwitchingLanes = true;
        currentLane += direction;

        float targetX = currentLane * laneWidth;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(targetX, startPosition.y, startPosition.z);

        float elapsedTime = 0f;
        while (elapsedTime < laneSwitchSpeed)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / laneSwitchSpeed);
            yield return null;
        }

        transform.position = targetPosition;
        isSwitchingLanes = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hit an obstacle! Returning to start.");
            transform.position = startPosition;
            currentLane = 0; // Reset lane to middle
        }
        else if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("You Win!");
            // Add logic for winning the game, e.g., loading the next level or showing a win screen
        }
    }
}