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

    [SerializeField] private BaseType _base = 0;
    [SerializeField] private NeckType _neck = 0;
    [SerializeField] private MaterialType _material = 0;

    public void GenerateRandomOrder()
    {
        _base = (BaseType)Random.Range(1, Enum.GetNames(typeof(BaseType)).Length);
        _neck = (NeckType)Random.Range(1, Enum.GetNames(typeof(NeckType)).Length);
        _material = (MaterialType)Random.Range(1, Enum.GetNames(typeof(MaterialType)).Length);
    }

    public bool IsEmpty() {
        return (_base == 0 && _neck == 0 && _material == 0);
    }

    [Serializable]
    public enum BaseType
    {
        empty,
        base1,
        base2,
        base3
    }

    [Serializable]
    public enum NeckType
    {
        empty,
        neck1,
        neck2,
        neck3
    }

    [Serializable]
    public enum MaterialType
    {
        empty,
        mat1,
        mat2,
        mat3
    }
}
