using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldInsert : MonoBehaviour, InteractableItem
{
    Order _currentMold;

    public void Interact()
    {
        if (PlayerInteract.Instance.OrderInHand != null && PlayerInteract.Instance.OrderInHand.IsMold())
        {
            PlayerInteract.Instance.OrderInHand.OverrideInteractableItem = this;

            if (_currentMold == null)
            {
                _currentMold = PlayerInteract.Instance.OrderInHand;
                SetCurrentMoldToOrderInHand();
                PlayerInteract.Instance.OrderInHand = null;
            }
            else
            {
                Order _oldMold = _currentMold;
                SetCurrentMoldToOrderInHand();
                _oldMold.OverrideInteractableItem = null;
                PlayerInteract.Instance.GrabItem(_oldMold, Vector3.zero);
            }
        }
        else
        {
            if (_currentMold != null)
            {
                _currentMold.OverrideInteractableItem = null;
                PlayerInteract.Instance.GrabItem(_currentMold, Vector3.zero);
                _currentMold = null;
            }
        }
    }

    private void SetCurrentMoldToOrderInHand() {
        PlayerInteract.Instance.OrderInHand.transform.parent = null;
        PlayerInteract.Instance.OrderInHand.transform.position = transform.position;
        PlayerInteract.Instance.OrderInHand.transform.rotation = Quaternion.identity;
    }
}
