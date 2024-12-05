using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{

    [SerializeField] private FoodSpawn food_spawn;
    [SerializeField] private bool is_healthy;

    private void Awake()
    {
        if (food_spawn)
        {
            food_spawn.AppleGenerator(this.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            Debug.Log("food spawn null");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<SnakeMovement>())
        {
            SnakeMovement snake = collision.GetComponent<SnakeMovement>();
            if (is_healthy)
                snake.Grow();
            else
                snake.Shrink();
            Debug.Log("Snake Size: " + snake.GetSnakeSize());
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (food_spawn)
            food_spawn.AppleGenerator(this.gameObject);
    }

    public bool GetAppleStatus()
    {
        return is_healthy;
    }
}
