using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] private FoodSpawn food_spawn;
    [SerializeField] private PowerUps power_ups;
    public bool is_active;
    private void OnEnable()
    {
        //StartCoroutine(SpeedLife());
        //StartCoroutine(PowerUpCoolDown());
    }

    IEnumerator SpeedLife()
    {
        yield return new WaitForSeconds(5);
        is_active = false;
        StartCoroutine(PowerUpCoolDown());
    }

    IEnumerator PowerUpCoolDown()
    {
        yield return new WaitForSeconds(3);
        if (food_spawn && power_ups)
            food_spawn.PowerUpGenerator(power_ups.gameObject);
    }

    public void StartSpeedLifeCoroutine()
    {
        StartCoroutine(SpeedLife());
    }

}
