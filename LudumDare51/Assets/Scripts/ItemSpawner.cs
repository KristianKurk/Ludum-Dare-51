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
    public AudioSource pick;

    public void Interact()
    {
        Order newItem = Instantiate(item).GetComponent<Order>();

        if (materialType != 0) {
            if (materialType == Order.MaterialType.mat1)
            {
                newItem.GetComponent<Renderer>().material.color = new Color32(139, 69, 19, 255);
            }
            else if (materialType == Order.MaterialType.mat2)
            {
                newItem.GetComponent<Renderer>().material.color = new Color32(33, 33, 33, 255);
            }
            else if (materialType == Order.MaterialType.mat3)
            {
                newItem.GetComponent<Renderer>().material.color = new Color32(235, 215, 0, 255);
            }
            else if (materialType == Order.MaterialType.mat4)
            {
                newItem.GetComponent<Renderer>().material.color = new Color32(192, 192, 192, 255);
            }


            newItem.Material = materialType;
            pick.Play();
        }

        if (neckType != 0)
        {
            newItem.Neck = neckType;
            pick.Play();
        }
            

        if (visualMaterial != null)
            newItem.GetComponent<Renderer>().material = visualMaterial;

        if (hasCost)
            GameManager.SpendMoney(newItem.GetCost());

        PlayerInteract.Instance.GrabItem(newItem.GetComponent<Order>(), Vector3.zero);

    }
}
