using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float speed_multiplier = 1f;
    [SerializeField] private Camera main_camera;
    private List<Transform> snake_body_parts;
    private Vector2Int direction = Vector2Int.right;
    private Vector2Int user_input;
    private float next_update;
    [SerializeField] private Transform snake_body_segment;
    private Transform initial_positon;
    [SerializeField] private string player_number;
    private void Start()
    {
        snake_body_parts = new List<Transform>();
        snake_body_parts.Add(this.transform);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 7)
    //    {
    //        if (collision.gameObject.GetComponent<Apple>().GetAppleStatus())
    //            Grow();
    //        else
    //            Shrink();
    //        Debug.Log("Snake Size: " + snake_body_parts.Count);
    //    }
    //    if (collision.gameObject.layer == 6)
    //    {
    //        Debug.Log("Hit Self");
    //        ResetSnake();
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == 6)
    //    {
    //        Debug.Log("Hit Self");
    //        ResetSnake();
    //    }
    //}

    void Update()
    {
        SnakeHeadMovement();
    }

    private void SnakeHeadMovement()
    {
        Vector2 positon = transform.position;
        Quaternion rotation = transform.rotation;
        if (direction.x != 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (user_input != Vector2Int.up)    
                {
                    transform.eulerAngles = new Vector3(0f,0f,90f);
                    user_input = Vector2Int.up;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (user_input != Vector2Int.down)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, -90f);
                    user_input = Vector2Int.down;
                }
            }
        }
        if (direction.y != 0)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (user_input != Vector2Int.right)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    user_input = Vector2Int.right;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (user_input != Vector2Int.left)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                    user_input = Vector2Int.left;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (Time.time < next_update)
            return;
        if (user_input != Vector2Int.zero)
            direction = user_input;
        for (int i = snake_body_parts.Count - 1; i>0; i--)
        {
            snake_body_parts[i].position = snake_body_parts[i - 1].position;
        }
        float x = transform.position.x + direction.x;
        float y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
        next_update = Time.time + (1f/(speed*speed_multiplier));
        WrapSnakeAroundScreen();
    }

    // This method checks if the snake's head is out of bounds and wraps it around
    private void WrapSnakeAroundScreen()
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

    public void Grow()
    {
        Transform snake_part = Instantiate(this.snake_body_segment);
        snake_part.position = snake_body_parts[snake_body_parts.Count - 1].position;
        snake_body_parts.Add(snake_part);
    }

    public void Shrink()
    {
        if (snake_body_parts.Count > 1)
        {
            Transform snake_part = snake_body_parts[snake_body_parts.Count - 1];
            snake_body_parts.RemoveAt(snake_body_parts.Count - 1);
            Destroy(snake_part.gameObject);
        }
        else if (snake_body_parts.Count == 1)
            ResetSnake();
    }

    public void ResetSnake()
    {

        GetComponent<ChangeScenes>().ChangeToScene(1);
    }

    public int GetSnakeSize()
    {
        return snake_body_parts.Count;
    }
}
