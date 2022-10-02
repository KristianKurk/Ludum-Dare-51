using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, InteractableItem
{
    [SerializeField] private bool hasCost;
    [SerializeField] private Material visualMaterial;
    [SerializeField] private Order.MaterialType materialType;
    [SerializeField] private Order.NeckType neckType;

    [SerializeField] private GameObject item;

    public void Interact()
    {
        Order newItem = Instantiate(item).GetComponent<Order>();

        if (materialType != 0)
            newItem.Material = materialType;


        if (neckType != 0)
            newItem.Neck = neckType;

        if (visualMaterial != null)
            newItem.GetComponent<Renderer>().material = visualMaterial;

        if (hasCost)
            GameManager.SpendMoney(newItem.GetCost());

        PlayerInteract.Instance.GrabItem(newItem.GetComponent<Order>(), Vector3.zero);

    }
}
