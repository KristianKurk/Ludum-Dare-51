using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        customers = new Queue<Customer>();
    }

    private void OnEnable()
    {
        _tenSecondsPassed.AddListener(SpawnCustomer);
    }
    private void OnDisable()
    {
        _tenSecondsPassed.RemoveListener(SpawnCustomer);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10) {
            timer -= 10;
            _tenSecondsPassed.Invoke();
        }
    }

    private void SpawnCustomer() {
        Customer newCustomer = Instantiate(_customerPrefab, _customerSpawnPoint).GetComponent<Customer>();
        Customer goneCustomer = customers.Count == 3 ? customers.Dequeue() : null;

        foreach (Customer c in customers) {
            c.status++;
            c.ShowEmoji();
            c.targetPos = _customerTargetPositions[(int)c.status].position;
        }

        customers.Enqueue(newCustomer);
        newCustomer.targetPos = _customerTargetPositions[0].position;

        if (goneCustomer)
            Destroy(goneCustomer.gameObject);
    }
}