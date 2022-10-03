using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantmentPoints : MonoBehaviour, InteractableItem
{
    [SerializeField] Enchantment enchantment;

    public void Interact()
    {
        enchantment.enchantsClicked++;
        gameObject.SetActive(false);
    }
}
