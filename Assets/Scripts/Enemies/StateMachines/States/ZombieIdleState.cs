using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : ZombieStates
{
    public ZombieIdleState(ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {
    }

    public override void Start()
    {
        base.Start();
        OwnerZombie.ZombieNavMesh.isStopped = true;
        OwnerZombie.ZombieNavMesh.ResetPath();
        OwnerZombie.ZombieAnimator.SetFloat("MovementZ", 0.0f);
    }
}
