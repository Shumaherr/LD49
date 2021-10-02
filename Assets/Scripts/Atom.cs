using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Atom : Particle
{
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f), 0);
        speed = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.position += velocity * (speed * Time.deltaTime);
    }

    protected override void ChangeDirection(Vector2 dir)
    {
        velocity = dir;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 dir = other.contacts[0].point - (Vector2)transform.position;
        dir = -dir.normalized;
        ChangeDirection(dir);
    }

    private void DoFission()
    {
        //TODO
    }
}
