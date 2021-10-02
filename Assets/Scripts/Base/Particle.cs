using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Particle : MonoBehaviour
{
    protected Vector3 velocity;
    protected float speed;

    protected abstract void Move();
    protected abstract void ChangeDirection(Vector2 dir);
}
