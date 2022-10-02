using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexItemVisual : MonoBehaviour
{
    [SerializeField] GameObject neck;

    public void UpdateVisuals()
    {
        Order o = GetComponent<Order>();
        if (o.Neck == 0)
            neck.SetActive(false);
    }
}
