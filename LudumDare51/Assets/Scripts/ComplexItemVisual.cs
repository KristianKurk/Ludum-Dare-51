using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexItemVisual : MonoBehaviour
{
    [SerializeField] GameObject neck;

    [SerializeField] SpriteRenderer neck1, neck2;
    [SerializeField] SpriteRenderer base1, base2;

    [SerializeField] Sprite[] baseSprites;
    [SerializeField] Sprite[] neckSprites;

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
                        base1.sprite = baseSprites[0];
                        base2.sprite = baseSprites[0];
                        break;
                    case Order.MaterialType.mat2:
                        base1.sprite = baseSprites[3];
                        base2.sprite = baseSprites[3];
                        break;
                    case Order.MaterialType.mat3:
                        base1.sprite = baseSprites[6];
                        base2.sprite = baseSprites[6];
                        break;
                    case Order.MaterialType.mat4:
                        base1.sprite = baseSprites[9];
                        base2.sprite = baseSprites[9];
                        break;
                }
                break;
            case Order.BaseType.base2:
                switch (o.Material)
                {
                    case Order.MaterialType.mat1:
                        base1.sprite = baseSprites[1];
                        base2.sprite = baseSprites[1];
                        break;
                    case Order.MaterialType.mat2:
                        base1.sprite = baseSprites[4];
                        base2.sprite = baseSprites[4];
                        break;
                    case Order.MaterialType.mat3:
                        base1.sprite = baseSprites[7];
                        base2.sprite = baseSprites[7];
                        break;
                    case Order.MaterialType.mat4:
                        base1.sprite = baseSprites[10];
                        base2.sprite = baseSprites[10];
                        break;
                }
                break;
            case Order.BaseType.base3:
                switch (o.Material)
                {
                    case Order.MaterialType.mat1:
                        base1.sprite = baseSprites[2];
                        base2.sprite = baseSprites[2];
                        break;
                    case Order.MaterialType.mat2:
                        base1.sprite = baseSprites[5];
                        base2.sprite = baseSprites[5];
                        break;
                    case Order.MaterialType.mat3:
                        base1.sprite = baseSprites[8];
                        base2.sprite = baseSprites[8];
                        break;
                    case Order.MaterialType.mat4:
                        base1.sprite = baseSprites[11];
                        base2.sprite = baseSprites[11];
                        break;
                }
                break;
        }


        switch (o.Neck)
        {
            case Order.NeckType.neck1:
                neck1.sprite = neckSprites[0];
                neck2.sprite = neckSprites[0];
                break;
            case Order.NeckType.neck2:
                neck1.sprite = neckSprites[1];
                neck2.sprite = neckSprites[1];
                break;
            case Order.NeckType.neck3:
                neck1.sprite = neckSprites[2];
                neck2.sprite = neckSprites[2];
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
