using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpComponent : MonoBehaviour
{
    [SerializeField] ItemScriptables PickUpItem;
    [SerializeField] private int Amount = -1;

    [SerializeField] private MeshRenderer PropMeshRenderer;
    [SerializeField] private MeshFilter PropMeshFilter;

    private ItemScriptables ItemInstance;

    // Start is called before the first frame update
    void Awake()
    {
        if (PropMeshRenderer == null) GetComponentInChildren<MeshRenderer>();
        if (PropMeshFilter == null) GetComponentInChildren<MeshFilter>();

        Instantiate();
    }

    public void Instantiate()
    {
        ItemInstance = Instantiate(PickUpItem);
        if (Amount > 0) ItemInstance.SetAmount(Amount);

        ApplyMesh();
    }

    private void ApplyMesh()
    {
        if (PropMeshFilter)
            PropMeshFilter.mesh = PickUpItem.ItemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;

        if (PropMeshRenderer) 
            PropMeshRenderer.materials = PickUpItem.ItemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterials;
    }

    private void OnValidate()
    {
        ApplyMesh();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        ItemInstance.UseItem(other.GetComponent<PlayerController>());
    }

}
