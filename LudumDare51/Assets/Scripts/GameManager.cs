using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Customers")]
    [SerializeField] private GameObject _customerPrefab;
    [SerializeField] private Transform _customerSpawnPoint;

    [SerializeField] private UnityEvent _tenSecondsPassed;

    [SerializeField] private Transform[] _customerTargetPositions;
    private float timer;

    private Queue<Customer> customers;
    private int _customersCount = 0;
    private static int money;
    [SerializeField] private TMP_Text _moneyUI;
    [SerializeField] private TMP_Text _customersServedUI;


    void Start()
    {
        timer = 0f;
        customers = new Queue<Customer>();
        money = 100;
    }
    
    private void OnEnable()
    {
        _tenSecondsPassed.AddListener(SpawnCustomer);
    }
    private void OnDisable()
    {
        _tenSecondsPassed.RemoveListener(SpawnCustomer);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10)
        {
            
            timer -= 10;
            _tenSecondsPassed.Invoke();
        }
        _moneyUI.text = money.ToString();
    }

    public static void SpendMoney(int cost)
    {
        money -= cost;
    }

    private void SpawnCustomer()
    {
        Customer newCustomer = Instantiate(_customerPrefab, _customerSpawnPoint).GetComponent<Customer>();
        Customer goneCustomer = customers.Count == 4 ? customers.Dequeue() : null;

        foreach (Customer c in customers)
        {
            c.status++;
            c.ShowEmoji();
            c.targetPos = _customerTargetPositions[(int)c.status].position;
        }

        _customersCount++;
        _customersServedUI.text = _customersCount + "/50";

        int random = Random.Range(0, 4);

       // if (_customersCount >= 25 && random == 2)
            newCustomer.AddEnchantToOrder();

        customers.Enqueue(newCustomer);
        newCustomer.targetPos = _customerTargetPositions[0].position;
        newCustomer.ShowEmoji();
        Debug.Log(newCustomer.order);

        if (goneCustomer)
            Destroy(goneCustomer.gameObject);
    }

    public void CheckIfOrderExists()
    {
        foreach (Customer c in customers)
        {
            if (PlayerInteract.Instance.OrderInHand != null
                && PlayerInteract.Instance.OrderInHand.Material == c.order.Material
                && PlayerInteract.Instance.OrderInHand.Neck == c.order.Neck
                && PlayerInteract.Instance.OrderInHand.Base == c.order.Base)
            {
                switch (c.status)
                {
                    case Customer.Status.NewlyArrived:
                    case Customer.Status.Happy:
                        money += 2 * PlayerInteract.Instance.OrderInHand.GetCost();
                        break;
                    case Customer.Status.Neutral:
                        money += (int)(1.5 * PlayerInteract.Instance.OrderInHand.GetCost());
                        break;
                    case Customer.Status.Angry:
                        money += 1 * PlayerInteract.Instance.OrderInHand.GetCost();
                        break;
                }

                c._emoji.enabled = false;
                c._neck.enabled = false;
                c._base.enabled = false;
                c._material.enabled = false;
                c.GetComponent<SpriteRenderer>().enabled = false;

                Destroy(PlayerInteract.Instance.OrderInHand.gameObject);
                PlayerInteract.Instance.OrderInHand = null;
            }
        }
    }
}
