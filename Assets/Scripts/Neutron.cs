using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutron : Particle
{
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        if (other.gameObject.TryGetComponent(out Rod tmp))
        {
            GameManager.Instance.PlayAbsorbSFX();
            gameObject.SetActive(false);
        }
    }
}
