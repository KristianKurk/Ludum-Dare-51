using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour, InteractableItem
{
    public GameManager gameManager;
    public AudioSource place;
    public void Interact()
    {
        if (PlayerInteract.Instance.OrderInHand != null && PlayerInteract.Instance.OrderInHand.IsCompleteItem())
        {
            place.Play();
            gameManager.CheckIfOrderExists();
        }
    }
}
