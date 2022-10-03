using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PageFlip : MonoBehaviour, InteractableItem
{
    public Sprite[] spriteList;

    [SerializeField] private bool isRightPage;
    public SpriteRenderer visual;

    public UnityEvent OnPageFlip;

    public void Interact()
    {
        OnPageFlip?.Invoke();
    }
}
