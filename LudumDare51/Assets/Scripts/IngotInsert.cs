using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngotInsert : MonoBehaviour, InteractableItem
{
    public Order _currentMaterial;
    public bool IsInteractable = true;
    public AudioSource ingotPlaced;

    public void Interact()
    {
        if (!IsInteractable) return;

        if (PlayerInteract.Instance.OrderInHand != null && PlayerInteract.Instance.OrderInHand.IsMaterial())
        {
            ingotPlaced.Play();
            PlayerInteract.Instance.OrderInHand.OverrideInteractableItem = this;

            if (_currentMaterial == null)
            {
                _currentMaterial = PlayerInteract.Instance.OrderInHand;
                SetCurrentMaterialToOrderInHand();
                PlayerInteract.Instance.OrderInHand = null;
            }
            else
            {
                Order _oldMaterial = _currentMaterial;
                SetCurrentMaterialToOrderInHand();
                _oldMaterial.OverrideInteractableItem = null;
                PlayerInteract.Instance.GrabItem(_oldMaterial, Vector3.zero);
            }
        }
        else
        {
            if (_currentMaterial != null)
            {
                _currentMaterial.OverrideInteractableItem = null;
                PlayerInteract.Instance.GrabItem(_currentMaterial, Vector3.zero);
                _currentMaterial = null;
            }
        }
    }

    private void SetCurrentMaterialToOrderInHand()
    {
        PlayerInteract.Instance.OrderInHand.transform.parent = null;
        PlayerInteract.Instance.OrderInHand.transform.position = new Vector3(100, 100, 100);
        PlayerInteract.Instance.OrderInHand.transform.rotation = Quaternion.identity;
    }
}
