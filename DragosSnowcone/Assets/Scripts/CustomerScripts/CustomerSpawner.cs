using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerSpawner : MonoBehaviour
{
    public List<Customer> normCust;
    public List<Customer> hardCust;
    private List<Customer> normCustRand = new List<Customer>();
    private List<Customer> hardCustRand = new List<Customer>();
    public GameObject custBase;
    public Customer currentCust;
    public int normSpawnNumb;
    public int hardSpawnNumb;
    public float spawnTime;
    private float spawnTimer = 0f;
    private int currSpawnWhen = 0;

    void Awake()
    {
        normSpawnNumb += GlobalPlayerVars.lvl;
        hardSpawnNumb += (GlobalPlayerVars.lvl % 2);
        GlobalPlayerVars.totalCustToday = normSpawnNumb + hardSpawnNumb;
        ShuffleList(normCust, normCustRand);
        ShuffleList(hardCust, hardCustRand);
    }
    void Start()
    {
        NormalCustomerSpawn();
        normSpawnNumb -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTime <= spawnTimer)
        {
            if (normSpawnNumb != 0)
            {
                NormalCustomerSpawn();
                normSpawnNumb -= 1;
                spawnTimer = 0f;
            }
            else if (hardSpawnNumb != 0)
            {
                HardCustomerSpawn();
                hardSpawnNumb -= 1;
                spawnTimer = 0f;
            }
        }
    }

    public void NormalCustomerSpawn()
    {
        for (int i = 0; i < normCustRand.Count; i++)
        {
        Customer customer = normCustRand[i];
        if (customer.custLvl > GlobalPlayerVars.lvl)
        {
            normCustRand.RemoveAt(i);
            currentCust = null;
        }
        else
        {
            currentCust = customer;
            normCustRand.RemoveAt(i);
            break;
        }
        }
        GameObject createdCust = Instantiate(custBase, transform.position, Quaternion.identity);
        CustomerMovement custMove = createdCust.GetComponent<CustomerMovement>();
        custMove.customer = currentCust;
        custMove.spawnWhen = currSpawnWhen;
        currSpawnWhen += 1;
    }

    public void HardCustomerSpawn()
    {
         for (int i = 0; i < hardCustRand.Count; i++)
        {
        Customer customer = hardCustRand[i];
        if (customer.custLvl > GlobalPlayerVars.lvl)
        {
            hardCustRand.RemoveAt(i);
            currentCust = null;
        }
        else
        {
            currentCust = customer;
            hardCustRand.RemoveAt(i);
            break;
        }
        }
        GameObject createdCust = Instantiate(custBase, transform.position, Quaternion.identity);
        CustomerMovement custMove = createdCust.GetComponent<CustomerMovement>();
        custMove.customer = currentCust;
        custMove.spawnWhen = currSpawnWhen;
        currSpawnWhen += 1;
    }

    public void ShuffleList(List<Customer> list, List<Customer> listTarg)
    {
        List<Customer> temp = new List<Customer>();
        temp.AddRange(list);

        for (int i = 0; i < list.Count; i++)
        {
            int index = Random.Range(0, temp.Count - 1);
            listTarg.Add(temp[index]);
            temp.RemoveAt(index);
        }
    }
}
