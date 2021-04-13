using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStates : State<ZombieStates>
{
    protected ZombieComponent OwnerZombie;
    public ZombieStates(ZombieComponent zombie, ZombieStateType stateMachine) : base(stateMachine)
    {
        OwnerZombie = zombie;
    }
}

public class ZombieStateMachine : StateMachine<ZombieStateType>
{

}


public enum ZombieStateType
{
    Idle,
    Attack,
    Follow,
    Dead
}
