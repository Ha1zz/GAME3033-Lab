using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowState : ZombieStates
{

    private readonly GameObject FollowTarget;
    private const float StopDistance = 2.0f;

    public ZombieFollowState(GameObject followTarget ,ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        FollowTarget = followTarget;
        UpdateInterval = 2.0f;

    }

    public override void Start()
    {
        base.Start();
        OwnerZombie.ZombieNavMesh.SetDestination(FollowTarget.transform.position);
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
        OwnerZombie.ZombieNavMesh.SetDestination(FollowTarget.transform.position);
    }


    public override void Update()
    {
        base.Update();
        OwnerZombie.ZombieAnimator.SetFloat("MovementZ", OwnerZombie.ZombieNavMesh.velocity.normalized.z);

        if (Vector3.Distance(OwnerZombie.transform.position, FollowTarget.transform.position) < StopDistance)
        {
            StateMachine.ChangeState(ZombieStateType.Attack);
        }


    }
}
