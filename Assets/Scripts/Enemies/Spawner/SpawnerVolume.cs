using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnerVolume : MonoBehaviour
{
    private BoxCollider Collider;

    // Start is called before the first frame update
    void Awake()
    {
        Collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    public Vector3 GetPositionInbounds()
    {
        Bounds bound = Collider.bounds;
        return new Vector3(Random.Range(bound.min.x, bound.max.x),
            transform.position.y,
            Random.Range(bound.min.z, bound.max.z));
    }
}
