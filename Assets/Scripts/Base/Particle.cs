using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public abstract class Particle : MonoBehaviour
{
    [SerializeField] protected float minSpeed;
    [SerializeField] protected float maxSpeed;
    
    protected Rigidbody2D rb2d;

    protected virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnEnable()
    {
        SetRndVelocity();
    }

    protected virtual void SetRndVelocity()
    {
        rb2d.velocity = Vector2.up.Rotate(Random.Range(0f, 360f)) * Random.Range(minSpeed, maxSpeed);
    }
    /*
    protected abstract void Move();
    protected abstract void ChangeDirection(Vector2 dir);*/
}
