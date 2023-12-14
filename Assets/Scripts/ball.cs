using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 m_initialVelocity = new Vector3(300.0f, 480.0f, 0.0f);
    Vector3 m_velocity;
    const float RADIUS = 10.0f;
    public const float WALL_WIDTH = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_velocity = m_initialVelocity;        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += m_velocity * Time.deltaTime;

        // check for bouncing off the top
        if (m_velocity.y > 0.0f)
        {
            if (pos.y + RADIUS >= Screen.height - WALL_WIDTH)
            {
                pos.y = Screen.height - WALL_WIDTH - RADIUS;
                m_velocity.y = -m_velocity.y;
            }
        }
        // check for bouncing off right wall
        if (m_velocity.x > 0.0f)
        {
            if (pos.x + RADIUS >= Screen.width - WALL_WIDTH)
            {
                pos.x = Screen.width - WALL_WIDTH - RADIUS;
                m_velocity.x = -m_velocity.x;
            }
        }
        // check for bouncing off left wall
        if (m_velocity.x < 0.0f)
        {
            if (pos.x - RADIUS < WALL_WIDTH)
            {
                pos.x = WALL_WIDTH + RADIUS;
                m_velocity.x = -m_velocity.x;
            }
        }

        transform.position = pos;
    }
}
