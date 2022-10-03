using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enchantment : MonoBehaviour, InteractableItem
{
    private Order _holding;
    [SerializeField] private Transform targetPos;
    [SerializeField] private List<Transform> enchants;
    [SerializeField] private Book book;

    public int enchantsClicked = 0;

    public void Update()
    {
        if (enchantsClicked == 5)
        {
            enchants[book.index].gameObject.SetActive(false);
            enchantsClicked = 0;
            _holding.OverrideInteractableItem = null;
            _holding.Enchant = (Order.EnchantType)book.index;
            _holding.GetComponent<ComplexItemVisual>().UpdateVisuals();
            PlayerInteract.Instance.GrabItem(_holding, Vector3.zero);
            _holding = null;
            GameManager.SpendMoney(50);
        }
    }

    public void Interact()
    {
        if (PlayerInteract.Instance.OrderInHand != null && (PlayerInteract.Instance.OrderInHand.IsCompleteItem()))
        {
            PlayerInteract.Instance.OrderInHand.OverrideInteractableItem = this;
            enchantsClicked = 0;

            foreach (Transform child in enchants[book.index])
                child.gameObject.SetActive(true);

            enchants[book.index].gameObject.SetActive(true);

            if (_holding == null)
            {
                _holding = PlayerInteract.Instance.OrderInHand;
                SetCurrentItemToOrderInHand();
                PlayerInteract.Instance.OrderInHand = null;
            }
            else
            {
                Order _item = _holding;
                SetCurrentItemToOrderInHand();
                _item.OverrideInteractableItem = null;
                PlayerInteract.Instance.GrabItem(_item, Vector3.zero);
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
        PlayerInteract.Instance.OrderInHand.transform.position = targetPos.position;
        PlayerInteract.Instance.OrderInHand.transform.rotation = Quaternion.Euler(0, 0, 90);
    }
}
