using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldInsert : MonoBehaviour, InteractableItem
{
    public Order _currentMold;

    public Order _completedBase;

    public bool IsInteractable = true;

    public void Interact()
    {
        if (!IsInteractable) return;

        if (_completedBase != null) {
            PlayerInteract.Instance.GrabItem(_completedBase, Vector3.zero);
            _completedBase = null;
            return;
        }


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
