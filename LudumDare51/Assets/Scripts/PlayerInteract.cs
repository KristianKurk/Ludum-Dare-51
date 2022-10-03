using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public static PlayerInteract Instance { get { return _instance; } }
    private static PlayerInteract _instance;
    public AudioSource pick;
    public Order OrderInHand { get => _orderInHand; set => _orderInHand = value; }

    [SerializeField] private Transform _itemInHandPosition;

    private Order _orderInHand;
    private Camera _cam;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

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

                if (order.OverrideInteractableItem == null)
                {
                    GrabItem(order, ray.direction);
                    pick.Play();
                }
                    
                else
                    order.OverrideInteractableItem.Interact();

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

    public void TryThrowItemInHand(Vector3 direction)
    {
        if (!_orderInHand || _orderInHand.IsEmpty()) return;

        _orderInHand.transform.parent = null;

        Rigidbody rb = _orderInHand.gameObject.GetComponent<Rigidbody>();

        rb.isKinematic = false;
        rb.AddForce(direction.normalized * 20f, ForceMode.Impulse);

        _orderInHand = null;
    }

    public void GrabItem(Order order, Vector3 direction)
    {
        TryThrowItemInHand(direction);
        _orderInHand = order;

        Rigidbody rb = _orderInHand.gameObject.GetComponent<Rigidbody>();

        rb.isKinematic = true;
        order.transform.parent = _itemInHandPosition;
        order.transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick();
        }
    }
}
