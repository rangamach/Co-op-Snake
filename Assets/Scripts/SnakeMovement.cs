using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    Direction move_direction;
    Direction forbidden_direction;
    [SerializeField] private float speed;
    [SerializeField] private Camera main_camera;
    private void Awake()
    {
        move_direction = Direction.Right;
    }
    void Update()
    {
        Vector2 positon = transform.position;
        Quaternion rotation = transform.rotation;
        if (Input.GetKeyDown(KeyCode.W))
            if (move_direction != Direction.Down)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                move_direction = Direction.Up;
            }
        if (Input.GetKeyDown(KeyCode.S))
            if (move_direction != Direction.Up)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                move_direction = Direction.Down;
            }
        if (Input.GetKeyDown(KeyCode.D))
            if (move_direction != Direction.Left)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                move_direction = Direction.Right;
            }
        if (Input.GetKeyDown(KeyCode.A))
            if (move_direction != Direction.Right)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                move_direction = Direction.Left;
            }
        if (move_direction == Direction.Right)
            positon.x += speed * Time.deltaTime;
        if (move_direction == Direction.Left)
            positon.x -= speed * Time.deltaTime;
        if (move_direction == Direction.Up)
            positon.y += speed * Time.deltaTime;
        if (move_direction == Direction.Down)
            positon.y -= speed * Time.deltaTime;
        //transform.rotation = rotation;
        transform.position = positon;
    }

    private void FixedUpdate()
    {
        WrapSnakeAroundScreen();
    }

    // This method checks if the snake's head is out of bounds and wraps it around
    void WrapSnakeAroundScreen()
    {
        Vector3 screen_position = main_camera.WorldToViewportPoint(transform.position);

        // Check if the snake is out of bounds on the left side
        if (screen_position.x < 0)
        {
            transform.position = main_camera.ViewportToWorldPoint(new Vector3(1, screen_position.y, screen_position.z));
        }
        // Check if the snake is out of bounds on the right side
        else if (screen_position.x > 1)
        {
            transform.position = main_camera.ViewportToWorldPoint(new Vector3(0, screen_position.y, screen_position.z));
        }
        // Check if the snake is out of bounds on the bottom
        else if (screen_position.y < 0)
        {
            transform.position = main_camera.ViewportToWorldPoint(new Vector3(screen_position.x, 1, screen_position.z));
        }
        // Check if the snake is out of bounds on the top
        else if (screen_position.y > 1)
        {
            transform.position = main_camera.ViewportToWorldPoint(new Vector3(screen_position.x, 0, screen_position.z));
        }
    }
}
