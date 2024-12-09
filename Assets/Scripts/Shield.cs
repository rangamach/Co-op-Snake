using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private FoodSpawn food_spawn;
    [SerializeField] private PowerUps power_ups;
    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        StartCoroutine(ShieldLife());
    }

    IEnumerator ShieldLife()
    {
        yield return new WaitForSeconds(5);
        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(PowerUpCoolDown());
    }

    IEnumerator PowerUpCoolDown()
    {
        yield return new WaitForSeconds(3);
        if (food_spawn && power_ups)
            food_spawn.PowerUpGenerator(power_ups.gameObject);
        gameObject.SetActive(false);
    }
}
