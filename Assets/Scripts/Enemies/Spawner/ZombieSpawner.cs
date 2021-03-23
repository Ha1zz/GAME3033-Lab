using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ZombiePrefabs;
    [SerializeField] private int NumberOfZombieToSpawn;
    [SerializeField] private SpawnerVolume[] SpawnVolumes;

    private GameObject FollowGameObject;

    // Start is called before the first frame update
    void Start()
    {
        FollowGameObject = GameObject.FindGameObjectWithTag("Player");

        for (int zombieCount = 0; zombieCount < NumberOfZombieToSpawn; zombieCount++)
        {
            SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        GameObject zombieToSpawn = ZombiePrefabs[Random.Range(0, ZombiePrefabs.Length)];
        SpawnerVolume spawnVolumes = SpawnVolumes[Random.Range(0, SpawnVolumes.Length)];

        GameObject zombie = 
            Instantiate(zombieToSpawn, spawnVolumes.GetPositionInbounds(), spawnVolumes.transform.rotation);

        zombie.GetComponent<ZombieComponent>().Initialize(FollowGameObject);
    }

}
