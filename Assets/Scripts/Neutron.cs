using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutron : Particle
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Rod tmp))
            gameObject.SetActive(false);
    }
}
