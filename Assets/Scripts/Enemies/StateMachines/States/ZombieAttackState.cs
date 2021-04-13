using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Health_System;

public class ZombieAttackState : ZombieStates
{
    private GameObject FollowTarget;
    private IDamagable DamagableObject;
    private float AttackRange = 1.5f;

    public ZombieAttackState(GameObject followTarget, ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {
        FollowTarget = followTarget;
        UpdateInterval = 4.0f;
    }

    public override void Start()
    {
        OwnerZombie.ZombieNavMesh.isStopped = true;
        OwnerZombie.ZombieNavMesh.ResetPath();
        OwnerZombie.ZombieAnimator.SetFloat("MovementZ", 0.0f);
        OwnerZombie.ZombieAnimator.SetBool("IsAttacking", true);

        DamagableObject = FollowTarget.GetComponent<IDamagable>();
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();

        DamagableObject?.TakeDamage(OwnerZombie.ZombieDamage);
    }

    public override void Update()
    {
        OwnerZombie.transform.LookAt(FollowTarget.transform.position, Vector3.up);

        float distanceBetween = Vector3.Distance(OwnerZombie.transform.position, FollowTarget.transform.position);

        if (distanceBetween > AttackRange)
        {
            StateMachine.ChangeState(ZombieStateType.Follow);
        }
    }

    public override void Exit()
    {
        base.Exit();
        OwnerZombie.ZombieAnimator.SetBool("IsAttacking", false);
    }
}
