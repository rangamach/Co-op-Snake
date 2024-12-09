using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FoodSpawn : MonoBehaviour
{
    private float min_x = -17.25f;
    private float max_x = 17.25f;
    private float min_y = -9.5f;
    private float max_y = 9.5f;

    public void AppleGenerator(GameObject apple)
    {
        if (apple.GetComponent<Apple>())
        {
            Vector3 apple_position = GetFoodPosition();
            apple.transform.position = apple_position;
            StartCoroutine(DelayFoodSpawn(apple));
        }
    }

    public void PowerUpGenerator(GameObject power_up)
    {
        if (power_up.GetComponent<PowerUps>())
        {
            Vector3 power_up_position = GetFoodPosition();
            power_up.transform.position = power_up_position;
            StartCoroutine(DelayPowerUpSpawn(power_up));
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
        if (food.GetComponent<Apple>())
        {
            AudioManager.Instance.PlayAudioEffect(AudioTypes.FoodSpawn);
            food.transform.gameObject.SetActive(true);
        }
    }

    IEnumerator DelayPowerUpSpawn(GameObject power_up)
    {
        yield return new WaitForSeconds(5.0f);
        if (power_up.GetComponent<PowerUps>())
        {
            AudioManager.Instance.PlayAudioEffect(AudioTypes.FoodSpawn);
            power_up.transform.gameObject.SetActive(true);
        }
    }
}
