using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerMovement : MonoBehaviour
{
    public int mode = 0; // 0 walkin here, 1 waiting for order, 2 walking back, 3 walking into waiting line, 4 waiting line
    public Customer customer;
    public Order order;
    public Vector2 target;
    public Vector2 secndTarget;
    public float walkSpeed;
    public float bob;
    public GameObject takeOrderButton;





    private float itmer1;
    private SpriteRenderer sprrend;

    void Awake()
    {
        sprrend = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        sprrend.sprite = customer.walkSpr1;
        for (int i = 0; i < customer.orders.Count; i++)
        {
        Order order = customer.orders[i];
        if (order.orderLVL > GlobalPlayerVars.lvl)
            order = null;
        }
        Debug.Log("Chosen Order: " + order);
    }

    void Update()
    {
        if (mode == 0)
        {
        HandleWalkSpr();
        transform.position = Vector2.MoveTowards(transform.position, target, walkSpeed * Time.deltaTime);
        Vector2 position2D = new Vector2(transform.position.x, transform.position.y);
        if (position2D == target)
        {
            mode = 1;
        }
        }
        if (mode == 1)
        {
            takeOrderButton.SetActive(true);
            //whatever is handling the customers ordering will tell this to go to mode 2
        }
        if (mode == 2)
        {
            takeOrderButton.SetActive(false);
            //fliped
            HandleWalkSpr();
            transform.position = Vector2.MoveTowards(transform.position, secndTarget, walkSpeed * Time.deltaTime);
            Vector2 position2D = new Vector2(transform.position.x, transform.position.y);
            if (position2D == secndTarget)
            {
                mode = 3;
            }
        }
        if (mode == 3)
        {
            // waits for their order, or changes to mode 2 when a new open spot in the waiting line opens up
        }
    }

    private void HandleWalkSpr()
    {
        itmer1 += Time.deltaTime;
        if (itmer1 >= customer.walkSprChangeSpeed)
        {
            if (sprrend.sprite == customer.walkSpr1)
            {
                sprrend.sprite = customer.walkSpr2;
                itmer1 = 0f;
            }
            else
            {
                sprrend.sprite = customer.walkSpr1;
                itmer1 = 0f;
            }
        }
    }
}
