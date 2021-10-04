using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : Particle
{
    [SerializeField] float disableCooldown = 1.5f;
    private Collider2D[] _collider2Ds;

    protected override void Awake()
    {
        _collider2Ds = GetComponentsInChildren<Collider2D>();
        base.Awake();
    }

    protected override void OnEnable()
    {
        foreach (var collider2D in _collider2Ds)
        {
            collider2D.enabled = true;
        }
        StartCoroutine(DisableCooldown());
        base.OnEnable();
    }

    IEnumerator DisableCooldown()
    {
        yield return new WaitForSeconds(disableCooldown);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "GameField")
        {
            foreach (var collider2D in _collider2Ds)
            {
                collider2D.enabled = false;
            }
        }
    }
}
