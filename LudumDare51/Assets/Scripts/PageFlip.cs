using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlip : MonoBehaviour, InteractableItem{
    public Sprite[] spriteList;
    [SerializeField] public SpriteRenderer leftPage;
    [SerializeField] public SpriteRenderer rightPage;

    public event EventHandler OnPageFlip;
    
    void Start()
    {
    }

    public void Interact()
    {
        Debug.Log("Interacted");
        if (transform.name == "LeftPage")
            {
            Debug.Log("Interact Left");
            OnPageFlip?.Invoke(this, EventArgs.Empty);
            
        }
        if (transform.name == "RightPage")
            {
            Debug.Log("Interact Right");
            OnPageFlip?.Invoke(this, EventArgs.Empty);
            }

    }

}
