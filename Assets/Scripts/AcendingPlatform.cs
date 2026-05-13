using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcendingPlatform : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private float waitTimeAtPoints = 1.0f;

    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private float nextMoveTime;
    private bool isWaiting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = endPoint.position;
    }

    void FixedUpdate()
    {
        if (isWaiting)
        {
            if (Time.time >= nextMoveTime)
            {
                isWaiting = false;
            }
            return;
        }
        Vector2 currentPos = rb.position;
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        rb.MovePosition(newPosition);

        if (Vector2.Distance(rb.position, targetPosition) < 0.05f)
        {
            targetPosition = (targetPosition == (Vector2)endPoint.position) ? startPoint.position : endPoint.position;
            isWaiting = true;
            nextMoveTime = Time.time + waitTimeAtPoints;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
