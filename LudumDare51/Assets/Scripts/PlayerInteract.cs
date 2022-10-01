using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform _itemInHandPosition;
    private Order _orderInHand;
    private Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    public void MouseClick()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            Component target;
            if (hit.collider.gameObject.TryGetComponent(typeof(Order), out target))
            {
                Order order = target as Order;

                TryThrowItemInHand(ray.direction);
                GrabItem(order);

            }
            else if (hit.collider.gameObject.TryGetComponent(typeof(InteractableItem), out target))
            {
                InteractableItem item = target as InteractableItem;
                item.Interact();
            }
            else
            {
                TryThrowItemInHand(ray.direction);
            }
        }
        else
        {
            TryThrowItemInHand(ray.direction);
        }

    }

    private void TryThrowItemInHand(Vector3 direction)
    {
        if (!_orderInHand || _orderInHand.IsEmpty()) return;

        _orderInHand.transform.parent = null;

        Rigidbody rb = _orderInHand.gameObject.GetComponent<Rigidbody>();

        rb.isKinematic = false;
        rb.AddForce(direction.normalized * 20f, ForceMode.Impulse);

        _orderInHand = null;
    }

    private void GrabItem(Order order)
    {
        _orderInHand = order;

        Rigidbody rb = _orderInHand.gameObject.GetComponent<Rigidbody>();

        rb.isKinematic = true;
        order.transform.parent = _itemInHandPosition;
        order.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick();
        }
    }
}