﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemies.Spawners
{
    public enum SpawnerStateEnum
    {
        Beginner,
        Intermediate,
        Hard,
        Complete
    }

    public class SpawnerStateMachine : StateMachine<SpawnerStateEnum>
    {

    }

    class SpawnerState : State<SpawnerStateEnum>
    {
        protected ZombieSpawner Spawner;

        protected SpawnerState(ZombieSpawner spawner,SpawnerStateMachine stateMachine) : base(stateMachine)
        {
            Spawner = spawner;
        }

        protected void SpawnZombie()
        {
            GameObject zombieToSpawn = Spawner.ZombiePrefabs[Random.Range(0, Spawner.ZombiePrefabs.Length)];
            SpawnerVolume spawnVolumes = Spawner.SpawnVolumes[Random.Range(0, Spawner.SpawnVolumes.Length)];

            GameObject zombie =
                Object.Instantiate(zombieToSpawn, spawnVolumes.GetPositionInbounds(), spawnVolumes.transform.rotation);

            zombie.GetComponent<ZombieComponent>().Initialize(Spawner.TargetObject);
        }
    }

    class ZombieWaveSpawnerState : SpawnerState
    {
        public int ZombiesToSpawn = 5;
        public SpawnerStateEnum NextState = SpawnerStateEnum.Intermediate;

        private int TotalZombiesKilled = 0;

        public ZombieWaveSpawnerState(ZombieSpawner spawner, SpawnerStateMachine stateMachine) : base(spawner, stateMachine)
        {

        }

        public override void Start()
        {
            base.Start();

            for (int i = 0; i < ZombiesToSpawn; i++)
            {
                SpawnZombie();
            }
        }
    }

}



