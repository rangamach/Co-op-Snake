using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    [HideInInspector]
    public SnakeMovement snake_head;
    private void OnEnable()
    {
        StartCoroutine(DelayBoxCollider());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SnakeMovement>())
        {
            SnakeMovement other_snake = collision.GetComponent<SnakeMovement>();
            if (snake_head.GetIsPlayerOne() == other_snake.GetIsPlayerOne())
            {
                other_snake.ResetSnake();
            }
            else
            {
                AudioManager.Instance.PlayAudioEffect(AudioTypes.Eat);
                List<Transform> parts = snake_head.GetSnakeBodyList();
                int part_number = 0;
                for(int i = 0; i<parts.Count;i++)
                {
                    if (parts[i] == this.transform)
                    {
                        part_number = i;
                        break;
                    }
                }
                snake_head.Shrink();
            }
        }
    }

    private IEnumerator DelayBoxCollider()
    {
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
