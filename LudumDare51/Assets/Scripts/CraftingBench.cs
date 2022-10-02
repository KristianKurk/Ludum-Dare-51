using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBench : MonoBehaviour, InteractableItem
{
    private Order _holding;
    [SerializeField] private GameObject complexItem;

    public void Interact()
    {
        if (PlayerInteract.Instance.OrderInHand != null && (PlayerInteract.Instance.OrderInHand.IsNeck() || PlayerInteract.Instance.OrderInHand.IsBase()))
        {
            PlayerInteract.Instance.OrderInHand.OverrideInteractableItem = this;

            if (_holding == null)
            {
                _holding = PlayerInteract.Instance.OrderInHand;
                SetCurrentItemToOrderInHand();
                PlayerInteract.Instance.OrderInHand = null;
            }
            else
            {
                if ((_holding.IsNeck() && PlayerInteract.Instance.OrderInHand.IsNeck()) || (_holding.IsBase() && PlayerInteract.Instance.OrderInHand.IsBase()))
                {
                    Order _oldNeck = _holding;
                    SetCurrentItemToOrderInHand();
                    _oldNeck.OverrideInteractableItem = null;
                    PlayerInteract.Instance.GrabItem(_oldNeck, Vector3.zero);
                }
                else
                {
                    //Neck and base, complete the item
                    Order o = Instantiate(complexItem, transform.position + Vector3.up, Quaternion.identity, null).GetComponent<Order>();
                    if (_holding.IsNeck())
                    {
                        o.Neck = _holding.Neck;
                        o.Base = PlayerInteract.Instance.OrderInHand.Base;
                        o.Material = PlayerInteract.Instance.OrderInHand.Material;
                    }
                    else {
                        o.Base = _holding.Base;
                        o.Neck = PlayerInteract.Instance.OrderInHand.Neck;
                        o.Material = _holding.Material;
                    }

                    Destroy(PlayerInteract.Instance.OrderInHand.gameObject);
                    PlayerInteract.Instance.OrderInHand = null;
                    o.GetComponent<ComplexItemVisual>().UpdateVisuals();
                    Destroy(_holding.gameObject);
                    _holding = null;
                    PlayerInteract.Instance.GrabItem(o, Vector3.zero);
                }
            }
        }
        else
        {
            if (_holding != null)
            {
                _holding.OverrideInteractableItem = null;
                PlayerInteract.Instance.GrabItem(_holding, Vector3.zero);
                _holding = null;
            }
        }
    }

    private void SetCurrentItemToOrderInHand()
    {
        PlayerInteract.Instance.OrderInHand.transform.parent = null;
        PlayerInteract.Instance.OrderInHand.transform.position = transform.position + Vector3.up ;
        PlayerInteract.Instance.OrderInHand.transform.rotation = Quaternion.identity;
    }
}
