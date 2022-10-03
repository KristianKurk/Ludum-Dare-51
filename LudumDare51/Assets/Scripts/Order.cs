using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
[RequireComponent(typeof(Rigidbody))]
public class Order : MonoBehaviour
{
    public BaseType Base { get => _base; set => _base = value; }
    public NeckType Neck { get => _neck; set => _neck = value; }
    public MaterialType Material { get => _material; set => _material = value; }
    public EnchantType Enchant { get => _enchant; set => _enchant = value; }

    [SerializeField] private BaseType _base = 0;
    [SerializeField] private NeckType _neck = 0;
    [SerializeField] private MaterialType _material = 0;
    [SerializeField] private EnchantType _enchant = 0;

    public InteractableItem OverrideInteractableItem { get; set; } = null;

    public void GenerateRandomOrder()
    {
        _base = (BaseType)Random.Range(1, Enum.GetNames(typeof(BaseType)).Length);
        _neck = (NeckType)Random.Range(1, Enum.GetNames(typeof(NeckType)).Length);
        _material = (MaterialType)Random.Range(1, Enum.GetNames(typeof(MaterialType)).Length);
    }

    public bool IsEmpty() => (_base == 0 && _neck == 0 && _material == 0);
    public bool IsMold() => (_base != 0 && _neck == 0 && _material == 0);
    public bool IsMaterial() => (_base == 0 && _neck == 0 && _material != 0);
    public bool IsNeck() => (_base == 0 && _neck != 0 && _material == 0);
    public bool IsBase() => (_base != 0 && _neck == 0 && _material != 0);
    public bool IsCompleteItem() => (_base != 0 && _neck != 0 && _material != 0);

    [Serializable]
    public enum BaseType
    {
        empty,
        base1,
        base2,
        base3,
        base4
    }

    [Serializable]
    public enum NeckType
    {
        empty,
        neck1,
        neck2,
        neck3,
        neck4
    }

    [Serializable]
    public enum MaterialType
    {
        empty,
        mat1,
        mat2,
        mat3,
        mat4
    }

    [Serializable]
    public enum EnchantType
    {
        empty,
        blue,
        red,
        yellow,
        purple
    }

    public override string ToString()
    {
        return $"Order: {Base} made with {Material}, and {Neck}, enchanted with {Enchant}";
    }

    public int GetCost() {
        return (10 * (int)Material) + (5 * (int)Base) + (5 * (int)Neck) + ((Enchant == 0) ? 0 : 50);
    }
}
