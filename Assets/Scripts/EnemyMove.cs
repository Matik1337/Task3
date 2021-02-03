using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float _dictance;

    private void Start()
    {
        _dictance = 5f;
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, _dictance), transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
        }
    }
}
