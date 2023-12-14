using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float m_moveSpeed = 400.0f;

    public const float PADDLE_HALF_WIDTH = 75.0f;
    public const float PADDLE_HALF_HEIGHT = 10.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            move.x += 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move.x -= 1.0f;
        }

        Vector3 pos = transform.position;
        pos += move * m_moveSpeed * Time.deltaTime;

        // bound the paddle to stay on screen
        if (pos.x > Screen.width - PADDLE_HALF_WIDTH - GameManager.WALL_WIDTH)
        {
            pos.x = Screen.width - PADDLE_HALF_WIDTH - GameManager.WALL_WIDTH;
        }
        if (pos.x < PADDLE_HALF_WIDTH + GameManager.WALL_WIDTH)
        {
            pos.x = PADDLE_HALF_WIDTH + GameManager.WALL_WIDTH;
        }    

        transform.position = pos;
    }
}
