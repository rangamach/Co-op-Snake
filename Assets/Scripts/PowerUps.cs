using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

enum PowerUp
{
    Speed,
    Double,
    Sheild
}

public class PowerUps : MonoBehaviour
{
    private PowerUp power_up;
    [SerializeField] private FoodSpawn food_spawn;
    [SerializeField] private SpriteRenderer sheild;
    [SerializeField] private Sprite[] potions;
    [SerializeField] private Shield shield;
    private SpriteRenderer sprite_renderer;

    private void Awake()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
        if (food_spawn)
        {
            food_spawn.AppleGenerator(this.gameObject);
            AudioManager.Instance.PlayAudioEffect(AudioTypes.FoodSpawn);
            sprite_renderer.enabled = true;
        }
        else
            Debug.Log("food spawn null");
    }

    private void OnEnable()
    {
        int random = UnityEngine.Random.Range(1, 4);
        if (random == 1)
        {
            sprite_renderer.sprite = potions[0];
            power_up = PowerUp.Speed;
        }
        else if (random == 2)
        {
            sprite_renderer.sprite = potions[1];
            power_up = PowerUp.Double;
        }
        else if (random == 3)
        {
            sprite_renderer.sprite = potions[2];
            power_up = PowerUp.Sheild;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeMovement>())
        {
            if (power_up == PowerUp.Double)
            {
                Double dble = collision.GetComponent<Double>();
                Debug.Log("double");
                dble.is_active = true;
                dble.StartDoubleLifeCoroutine();
            }
            else if (power_up == PowerUp.Speed)
            {
                Speed speed = collision.GetComponent<Speed>();
                Debug.Log("speed");
                speed.is_active = true;
                speed.StartSpeedLifeCoroutine();
            }
            else if (power_up == PowerUp.Sheild)
            {
                Debug.Log("sheild");
                sheild.gameObject.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
    }

    //private void OnDisable()
    //{
    //    StartCoroutine(PowerUpCoolDown());
    //}

    //IEnumerator ShieldLife()
    //{
    //    yield return new WaitForSeconds(5);
    //    sheild.gameObject.SetActive(false);
    //}

    //IEnumerator PowerUpCoolDown()
    //{
    //    yield return new WaitForSeconds(10);
    //    if (food_spawn)
    //        food_spawn.PowerUpGenerator(this.gameObject);
    //}

}
