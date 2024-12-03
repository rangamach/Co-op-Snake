using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{

    [SerializeField] private FoodSpawn food_spawn;

    private void Awake()
    {
        if (food_spawn)
        {
            food_spawn.AppleGenerator(this.gameObject);
            this.gameObject.GetComponent<Image>().enabled = true;
        }
        else
            Debug.Log("food spawn null");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<SnakeMovement>())
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (food_spawn)
            food_spawn.AppleGenerator(this.gameObject);
    }
}
