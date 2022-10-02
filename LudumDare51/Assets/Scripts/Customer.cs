using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour
{
    public Order order;
    public Status status;

    public Vector3 targetPos;

    public SpriteRenderer _emoji, _material, _base, _neck;

    [SerializeField] private Sprite[] emojis;
    [SerializeField] private Sprite[] materials;
    [SerializeField] private Sprite[] bases;
    [SerializeField] private Sprite[] necks;

    void Awake()
    {
        order = gameObject.AddComponent<Order>();
        order.GenerateRandomOrder();
        GetComponent<Rigidbody>().isKinematic = true;
        _material.sprite = materials[(int)order.Material-1];
        _base.sprite = bases[(int)order.Base-1];
        _neck.sprite = necks[(int)order.Neck-1];
    }

    private void Update()
    {
        if (targetPos != Vector3.zero)
        {
            transform.position = Vector3.Lerp(transform.position + new Vector3(0, Mathf.Sin(Time.time * 15) * 0.005f, 0), targetPos, 0.005f);
            if (Vector3.Distance(transform.position, targetPos) < 0.5f)
            {
                targetPos = Vector3.zero;
                transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            }
        }
    }

    public void ShowEmoji()
    {
        _emoji.sprite = emojis[(int)status];
    }

    public enum Status
    {
        Happy,
        Neutral,
        Angry
    }
}
