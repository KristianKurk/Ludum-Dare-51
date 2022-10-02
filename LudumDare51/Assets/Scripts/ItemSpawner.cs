using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, InteractableItem
{
    [SerializeField] private int cost;

    [SerializeField] private GameObject item;

    public void Interact()
    {
        GameObject newMaterial = Instantiate(item);
        PlayerInteract.Instance.GrabItem(newMaterial.GetComponent<Order>(), Vector3.zero);
    }
}
