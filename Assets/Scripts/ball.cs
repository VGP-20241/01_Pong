using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Vector3 m_initialVelocity = new Vector3(300.0f, 480.0f, 0.0f);
    Vector3 m_velocity;
    const float m_radius = 10.0f;
    const float m_wallWidth = 20.0f;

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
            if (pos.y + m_radius >= Screen.height - m_wallWidth)
            {
                pos.y = Screen.height - m_wallWidth - m_radius;
                m_velocity.y = -m_velocity.y;
            }
        }
        // check for bouncing off right wall
        if (m_velocity.x > 0.0f)
        {
            if (pos.x + m_radius >= Screen.width - m_wallWidth)
            {
                pos.x = Screen.width - m_wallWidth - m_radius;
                m_velocity.x = -m_velocity.x;
            }
        }
        // check for bouncing off left wall
        if (m_velocity.x < 0.0f)
        {
            if (pos.x - m_radius < m_wallWidth)
            {
                pos.x = m_wallWidth + m_radius;
                m_velocity.x = -m_velocity.x;
            }
        }

        transform.position = pos;
    }
}
