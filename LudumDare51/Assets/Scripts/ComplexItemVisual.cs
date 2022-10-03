using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexItemVisual : MonoBehaviour
{
    [SerializeField] GameObject neck;

    [SerializeField] SpriteRenderer neck1, neck2;
    [SerializeField] SpriteRenderer base1, base2;

    [SerializeField] Sprite baseSprites;
    [SerializeField] Sprite neckSprites;

    public void UpdateVisuals()
    {
        Order o = GetComponent<Order>();
        if (o.Neck == 0)
            neck.SetActive(false);

        //INSERT SPRITES HERE MAX
        //ADD ENCHANT VISUALS IF YOU WANT, THIS METHOD GETS CALLED TO UPDATE AFTER ENCHANT

        switch (o.Base)
        {
            case Order.BaseType.base1:
                switch (o.Material)
                {
                    case Order.MaterialType.mat1:
                        break;
                    case Order.MaterialType.mat2:
                        break;
                    case Order.MaterialType.mat3:
                        break;
                    case Order.MaterialType.mat4:
                        break;
                }
                break;
            case Order.BaseType.base2:
                switch (o.Material)
                {
                    case Order.MaterialType.mat1:
                        break;
                    case Order.MaterialType.mat2:
                        break;
                    case Order.MaterialType.mat3:
                        break;
                    case Order.MaterialType.mat4:
                        break;
                }
                break;
            case Order.BaseType.base3:
                switch (o.Material)
                {
                    case Order.MaterialType.mat1:
                        break;
                    case Order.MaterialType.mat2:
                        break;
                    case Order.MaterialType.mat3:
                        break;
                    case Order.MaterialType.mat4:
                        break;
                }
                break;
        }


        switch (o.Neck)
        {
            case Order.NeckType.neck1:
                break;
            case Order.NeckType.neck2:
                break;
            case Order.NeckType.neck3:
                break;
        }
    }


    private void UpdateNeckSprite(Sprite sprite)
    {
        neck1.sprite = sprite;
        neck2.sprite = sprite;
    }

    private void UpdateBaseSprite(Sprite sprite)
    {
        base1.sprite = sprite;
        base2.sprite = sprite;
    }
}
