using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Vector3 m_initialVelocity = new Vector3(300.0f, 480.0f, 0.0f);
    Vector3 m_velocity;
    const float m_radius = 10.0f;

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
        transform.position = pos;
    }
}
