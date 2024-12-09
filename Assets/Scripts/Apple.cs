using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{

    [SerializeField] private FoodSpawn food_spawn;
    [SerializeField] private bool is_healthy;
    [SerializeField] private GameObject sprite;

    private void Awake()
    {
        if (food_spawn)
        {
            food_spawn.AppleGenerator(this.gameObject);
            AudioManager.Instance.PlayAudioEffect(AudioTypes.FoodSpawn);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            Debug.Log("food spawn null");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SnakeMovement>())
        {
            SnakeMovement snake = collision.GetComponent<SnakeMovement>();
            if (is_healthy)
            {
                if(collision.GetComponent<Double>() && collision.GetComponent<Double>().is_active)
                {
                    snake.Grow();
                }
                snake.Grow();
                this.gameObject.SetActive(false);
                AudioManager.Instance.PlayAudioEffect(AudioTypes.Eat);
            }
            else
            {
                if (sprite && !sprite.activeInHierarchy || sprite == null)
                {
                    if (snake.GetSnakeSize() > 1)
                        snake.Shrink();
                    else
                        snake.Shrink();
                    this.gameObject.SetActive(false);
                    AudioManager.Instance.PlayAudioEffect(AudioTypes.Eat);
                }
            }
            Debug.Log("Snake Size: " + snake.GetSnakeSize());
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

    //private int RandomNumberGenerator(int min, int max)
    //{
    //    int random = Random.Range(min, max);
    //    Debug.Log("Random Number :" + random);
    //    return random;
    //}
}
