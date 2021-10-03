using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : Particle
{
    [SerializeField] float disableCooldown = 1;

    protected override void OnEnable()
    {
        StartCoroutine(DisableCooldown());
        base.OnEnable();
    }

    IEnumerator DisableCooldown()
    {
        yield return new WaitForSeconds(disableCooldown);
        gameObject.SetActive(false);
    }
}
