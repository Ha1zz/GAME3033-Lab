using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathState : ZombieStates
{
    public ZombieDeathState(ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {

    }

    public override void Start()
    {
        base.Start();
        OwnerZombie.ZombieNavMesh.isStopped = true;
        OwnerZombie.ZombieNavMesh.ResetPath();

        OwnerZombie.ZombieAnimator.SetFloat("MovementZ", 0.0f);
        OwnerZombie.ZombieAnimator.SetBool("IsDead", true);

    }

    public override void Exit()
    {
        base.Exit();
        OwnerZombie.ZombieNavMesh.isStopped = false;
        OwnerZombie.ZombieAnimator.SetBool("IsDead", false);

    }
}
