using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{

    private void OnEnable()
    {
        StartCoroutine(DelayBoxCollider());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SnakeMovement>())
        {
            SnakeMovement snake = collision.GetComponent<SnakeMovement>();
            Debug.Log("Hit Self.");
            snake.ResetSnake();
        }
    }

    private IEnumerator DelayBoxCollider()
    {
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
