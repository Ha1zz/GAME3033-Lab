using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemies.Spawners
{

    [RequireComponent(typeof(SpawnerStateMachine))]
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] public GameObject[] ZombiePrefabs;
        public int NumberOfZombieToSpawn;
        public SpawnerVolume[] SpawnVolumes;

        public GameObject TargetObject => FollowGameObject;
        private GameObject FollowGameObject;

        private SpawnerStateMachine StateMachine;

        private void Awake()
        {
            StateMachine = GetComponent<SpawnerStateMachine>();
            FollowGameObject = GameObject.FindGameObjectWithTag("Player");
        }


        // Start is called before the first frame update
        void Start()
        {
            ZombieWaveSpawnerState beginnerWave = new ZombieWaveSpawnerState(this, StateMachine)
            {
                ZombiesToSpawn = 5,
                NextState = SpawnerStateEnum.Complete
            };
            StateMachine.AddState(SpawnerStateEnum.Beginner, beginnerWave);

            StateMachine.Initialize(SpawnerStateEnum.Beginner);


            //for (int zombieCount = 0; zombieCount < NumberOfZombieToSpawn; zombieCount++)
            //{
            //    SpawnZombie();
            //}
        }

        //private void SpawnZombie()
        //{
        //    GameObject zombieToSpawn = ZombiePrefabs[Random.Range(0, ZombiePrefabs.Length)];
        //    SpawnerVolume spawnVolumes = SpawnVolumes[Random.Range(0, SpawnVolumes.Length)];

        //    GameObject zombie =
        //        Instantiate(zombieToSpawn, spawnVolumes.GetPositionInbounds(), spawnVolumes.transform.rotation);

        //    zombie.GetComponent<ZombieComponent>().Initialize(FollowGameObject);
        //}

    }

}


