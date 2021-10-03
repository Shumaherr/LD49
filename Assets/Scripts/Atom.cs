using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Atom : Particle
{
    private float fissionProgress;
    [SerializeField] private float fissionStep = 25;
    [SerializeField] private float fissionChance = 25;
    [SerializeField] private float atomCooldownMin = 1;
    [SerializeField] private float atomCooldownMax = 3;
    [SerializeField] private int newAtoms = 2;
    [SerializeField] private int newNeutronsMin = 1;
    [SerializeField] private int newNeutronsMax = 3;

    private SpriteRenderer[] renderers;
    private Collider2D[] collider2Ds;
    private Animator animator;

    protected override void Awake()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
        collider2Ds = GetComponentsInChildren<Collider2D>();
        animator = GetComponentInChildren<Animator>();
        animator.speed = 0;
        base.Awake();
    }

    private void Start()
    {
        InvokeRepeating("FissionProgress", 1, 1);
    }

    private void FissionProgress()
    {
        var num = Random.Range(0f, 100f);
        if (fissionChance > num)
        {
            fissionProgress += fissionStep;
            animator.speed += fissionChance / 100;
        }

        if (fissionProgress > 100)
            DoFission();
    }
    private void DoFission()
    {
        animator.speed = 0;
        fissionProgress = 0;
        CreateNewParticles();
        transform.position = GameManager.Instance.GetNewAtomPos();
        rb2d.velocity = Vector2.zero;
        foreach (var renderer in renderers)
        {
            renderer.enabled = false;
        }
        foreach (var collider2D in collider2Ds)
        {
            collider2D.enabled = false;
        }
        StartCoroutine(CooldownAtom());
    }

    private void CreateNewParticles()
    {
        var pos = transform.position + Vector3.back * 2;;
        for (int i = 0; i < newAtoms; i++)
        {
            var tmp = GameManager.Instance.garbagePool.GetObject();
            tmp.SetActive(true);
            tmp.transform.position = pos;
        }

        var newNeutrons = Random.Range(newNeutronsMin, newNeutronsMax);
        for (int i = 0; i < newNeutrons; i++)
        {
            var tmp = GameManager.Instance.neutronPool.GetObject();
            tmp.SetActive(true);
            tmp.transform.position = transform.position + Vector3.back * 2;
        }
    }

    IEnumerator CooldownAtom()
    {
        yield return new WaitForSeconds(Random.Range(atomCooldownMin, atomCooldownMax));
        foreach (var renderer in renderers)
        {
            renderer.enabled = true;
        }
        foreach (var collider2D in collider2Ds)
        {
            collider2D.enabled = true;
        }
        SetRndVelocity();
        fissionProgress = 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Neutron tmp))
        {
            DoFission();
            other.gameObject.SetActive(false);
        }
    }
}
