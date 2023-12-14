using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Vector3 m_initialVelocity = new Vector3(300.0f, 480.0f, 0.0f);
    public Transform m_paddle;

    Vector3 m_velocity;

    const float BALL_RADIUS = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_velocity = m_initialVelocity;   
        if (null == m_paddle)
        {
            m_paddle = FindObjectOfType<Paddle>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += m_velocity * Time.deltaTime;

        // check for bouncing off the top
        if (m_velocity.y > 0.0f)
        {
            if (pos.y + BALL_RADIUS >= Screen.height - GameManager.WALL_WIDTH)
            {
                pos.y = Screen.height - GameManager.WALL_WIDTH - BALL_RADIUS;
                m_velocity.y = -m_velocity.y;
            }
        }
        // check for bouncing off right wall
        if (m_velocity.x > 0.0f)
        {
            if (pos.x + BALL_RADIUS >= Screen.width - GameManager.WALL_WIDTH)
            {
                pos.x = Screen.width - GameManager.WALL_WIDTH - BALL_RADIUS;
                m_velocity.x = -m_velocity.x;
            }
        }
        // check for bouncing off left wall
        if (m_velocity.x < 0.0f)
        {
            if (pos.x - BALL_RADIUS < GameManager.WALL_WIDTH)
            {
                pos.x = GameManager.WALL_WIDTH + BALL_RADIUS;
                m_velocity.x = -m_velocity.x;
            }
        }

        // check for bouncing off the paddle
        if (m_velocity.y < 0.0f)
        {
            // ball overlaps with y coord of paddle
            if ( (pos.y - BALL_RADIUS <= m_paddle.position.y + Paddle.PADDLE_HALF_HEIGHT)
                && (pos.y + BALL_RADIUS >= m_paddle.position.y - Paddle.PADDLE_HALF_HEIGHT)
                )
            { 
                if ( (pos.x + BALL_RADIUS >= m_paddle.position.x - Paddle.PADDLE_HALF_WIDTH)
                    && (pos.x - BALL_RADIUS <= m_paddle.position.x + Paddle.PADDLE_HALF_WIDTH)
                    )
                {
                    pos.y = m_paddle.position.y + Paddle.PADDLE_HALF_HEIGHT + BALL_RADIUS;
                    m_velocity.y = -m_velocity.y;
                }
            }

            // off the bottom of the screen - start over
            if (pos.y < 0.0f)
            {
                SceneManager.LoadScene("Game");
            }
        }

        transform.position = pos;
    }
}
