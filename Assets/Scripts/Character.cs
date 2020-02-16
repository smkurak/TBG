﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum State
    {
        Idle,
        RunningToEnemy,
        RunningFromEnemy,
        BeginAttack,
        Attack,
        BeginShoot,
        Shoot,
        Died,
    }

    public enum Weapon
    {
        Pistol,
        Bat,
        Fist,
    }

    public float runSpeed;
    public float distanceFromEnemy;
    public Transform target;
  //  public Character targChar;
    public Weapon weapon;
    Animator animator;
    Vector3 originalPosition;
    Quaternion originalRotation;
    State state = State.Idle;
    bool dead;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    [ContextMenu("Attack")]
    void AttackEnemy()
    {
        switch (weapon)
        {
            case Weapon.Bat:
                state = State.RunningToEnemy;
                break;

            case Weapon.Fist:
                state = State.RunningToEnemy;
                break;

            case Weapon.Pistol:
                state = State.BeginShoot;
                break;
        }
    }

    public bool IsDead()
    {
        return state == State.Died;
    }
    public void SetState(State newState)
    {
        state = newState;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case State.Idle:
                animator.SetFloat("speed", 0.0f);
                transform.rotation = originalRotation;
                break;

            case State.RunningToEnemy:
                animator.SetFloat("speed", runSpeed);
                if (RunTowards(target.position, distanceFromEnemy))
                    state = State.BeginAttack;
                break;

            case State.RunningFromEnemy:
                animator.SetFloat("speed", runSpeed);
                if (RunTowards(originalPosition, 0.0f))
                    state = State.Idle;
                break;

//проверка на кулак или биту
            case State.BeginAttack:
                animator.SetFloat("speed", 0.0f);
                switch (weapon)
                {
                    case Weapon.Fist:
                    animator.SetTrigger("fist");
                    break;

                    case Weapon.Bat:
                    animator.SetTrigger("attack");
                    break;
                }
                state = State.Attack;
                break;

            case State.Attack:
                animator.SetFloat("speed", 0.0f);
                break;

            case State.BeginShoot:
                animator.SetFloat("speed", 0.0f);
                animator.SetTrigger("shoot");
                state = State.Shoot;
                break;

            case State.Shoot:
                animator.SetFloat("speed", 0.0f);
                break;

            case State.Died:
                break;

        }
        
    }

    bool RunTowards(Vector3 targetPosition, float distanceFromTarget)
    {
        Vector3 distance = targetPosition - transform.position;
        Vector3 direction = distance.normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        
        //расстояние между персами в консоль
        //Debug.Log($"{distance.magnitude}");

        targetPosition -= direction * distanceFromTarget;
        distance = (targetPosition - transform.position);

        Vector3 vector = direction * runSpeed;
        if (vector.magnitude < distance.magnitude)
        {
            transform.position += vector;
            return false;
        }

        transform.position = targetPosition;
        return true;
    }
    public void Die()
    {
        animator.SetTrigger("died");
        SetState(State.Died);
    }

    public void Kill()
    {
        //target.Die();
        //particleSystem.Play();
    }
}
