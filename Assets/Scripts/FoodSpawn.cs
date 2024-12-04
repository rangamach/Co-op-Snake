using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FoodSpawn : MonoBehaviour
{
    private float min_x = -11.8f;
    private float max_x = 11.8f;
    private float min_y = -6.5f;
    private float max_y = 6.5f;

    public void AppleGenerator(GameObject apple)
    {
        if (apple.GetComponent<Apple>())
        {
            Vector3 apple_position = GetFoodPosition();
            apple.transform.position = apple_position;
            StartCoroutine(DelayFoodSpawn(apple));
        }
    }

    private Vector3 GetFoodPosition()
    {
        Vector3 food_position = new Vector3(Mathf.RoundToInt(Random.Range(min_x, max_x)), Mathf.RoundToInt(Random.Range(min_y, max_y)), 0f);
        return food_position;
    }

    IEnumerator DelayFoodSpawn(GameObject food)
    {
        yield return new WaitForSeconds(5.0f);
        if(food.GetComponent<Apple>())
            food.transform.gameObject.SetActive(true);
    }
}
