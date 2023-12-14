using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    public float m_moveSpeed = 400.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        transform.position = pos;
    }
}
