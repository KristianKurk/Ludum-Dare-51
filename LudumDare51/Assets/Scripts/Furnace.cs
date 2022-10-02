using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour, InteractableItem
{
    [SerializeField] private IngotInsert[] _ingotInserts;
    [SerializeField] private MoldInsert[] _moldInserts;

    [SerializeField] private GameObject[] _lavaFalls;
    [SerializeField] private GameObject _hearth;
    [SerializeField] private GameObject _basePrefab;

    private float timer;
    private bool[] isCookin = new bool[3];
    private bool isAnyCookin = false;

    private const int COOKING_TIME = 5;

    public void Interact()
    {
        if (isAnyCookin) return;

        isAnyCookin = false;
        for (int i = 0; i < 3; i++)
        {
            if (_ingotInserts[i]._currentMaterial != null && _moldInserts[i]._currentMold != null)
            {
                _lavaFalls[i].SetActive(true);
                _moldInserts[i].IsInteractable = false;
                _ingotInserts[i].IsInteractable = false;
                isCookin[i] = true;
                isAnyCookin = true;
            }
            else {
                isCookin[i] = false;
            }
        }

        if (isAnyCookin)
        {
            _hearth.SetActive(true);
            this.transform.localRotation = Quaternion.Euler(-120,0,0);
        }
    }

    void Start()
    {
        timer = 0f;
        for (int i = 0; i < 3; i++)
            _lavaFalls[i].SetActive(false);
    }

    void Update()
    {
        if (isAnyCookin)
        {
            if (timer <= COOKING_TIME)
                timer += Time.deltaTime;
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    _moldInserts[i].IsInteractable = true;
                    _ingotInserts[i].IsInteractable = true;

                    if (isCookin[i])
                    {
                        if (_moldInserts[i]._completedBase != null)
                        {
                            _moldInserts[i]._completedBase.GetComponent<Rigidbody>().isKinematic = false;
                            _moldInserts[i]._completedBase.transform.position = _moldInserts[i].transform.position + 0.5f * Vector3.up;
                        }

                        _moldInserts[i]._completedBase = Instantiate(_basePrefab, new Vector3(100, 100, 100), Quaternion.identity, null).GetComponent<Order>();
                        _moldInserts[i]._completedBase.GetComponent<Rigidbody>().isKinematic = true;
                        _moldInserts[i]._completedBase.Base = _moldInserts[i]._currentMold.Base;
                        _moldInserts[i]._completedBase.Material = _ingotInserts[i]._currentMaterial.Material;
                        _moldInserts[i]._completedBase.GetComponent<ComplexItemVisual>().UpdateVisuals();

                        Destroy(_ingotInserts[i]._currentMaterial.gameObject);
                        _lavaFalls[i].SetActive(false);
                    }
                }
                timer = 0f;
                isAnyCookin = false;
                this.transform.localRotation = Quaternion.Euler(-40, 0, 0);
                _hearth.SetActive(false);
            }
        }
    }
}
