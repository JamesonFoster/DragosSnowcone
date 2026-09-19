using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerMovement : MonoBehaviour
{
    public int mode = 0; // 0 walkin here, 1 waiting for order, 2 walking back, 3 walking into waiting line, 4 waiting line
    public Customer customer;
    public Order order;
    public GameObject targetMain1;
    public List<GameObject> orderLine; // line where they wait for the order
    private GameObject currentTarg;
    public GameObject secndTarget;
    public float walkSpeed;
    public float bob;
    public GameObject takeOrderButton;





    private float itmer1;
    private SpriteRenderer sprrend;
    private CustWaitSpot CWSStar1;
    private CustWaitSpot CWS;
    private CustWaitSpot currCWS;
    private int currentWaitPos;

    void Awake()
    {
        sprrend = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        CWSStar1 = targetMain1.GetComponent<CustWaitSpot>();
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
            if (CWSStar1.isOn == false)
            {
                currentTarg = targetMain1;
            }
            else
            {
                for (int i = 0; i < orderLine.Count; i++)
                {
                    GameObject currOb = orderLine[i];
                    CWS = currOb.GetComponent<CustWaitSpot>();
                    if (CWS.isOn == false)
                    {
                        currentTarg = currOb;
                        currCWS = CWS;
                        currentWaitPos = i;
                        break;
                    }
                }
            }

            HandleWalkSpr();
            transform.position = Vector2.MoveTowards(transform.position, currentTarg.transform.position, walkSpeed * Time.deltaTime);
            Vector2 position2D = new Vector2(transform.position.x, transform.position.y);
            Vector2 posFirst2D = new Vector2(currentTarg.transform.position.x, currentTarg.transform.position.y);
            Vector2 starPos2D = new Vector2(targetMain1.transform.position.x, targetMain1.transform.position.y);
            if ((position2D == posFirst2D) && currentTarg != targetMain1)
            {
                currCWS.setIsON(true);
                mode = 1;
            }
            if (position2D == starPos2D)
            {
                CWSStar1.setIsON(true);
                mode = 2;
            }
        }
        if (mode == 1)
        {
            if (CWSStar1.isOn == false)
            {
                currentTarg = targetMain1;
                currCWS.setIsON(false);
                mode = 0;
            }
            else
            {
                for (int i = 0; i < orderLine.Count; i++)
                {
                    GameObject currOb = orderLine[i];
                    CWS = currOb.GetComponent<CustWaitSpot>();
                    if (CWS.isOn == false && currentWaitPos > i)
                    {
                        currentTarg = currOb;
                        currCWS.setIsON(false);
                        currCWS = CWS;
                        currentWaitPos = i;
                        mode = 0;
                        break;
                    }
                }
            }
        }
        if (mode == 2)
        {
            takeOrderButton.SetActive(true);
            //whatever is handling the customers ordering will tell this to go to mode 2
        }
        if (mode == 3)
        {
            takeOrderButton.SetActive(false);
            //fliped
            HandleWalkSpr();
            transform.position = Vector2.MoveTowards(transform.position, secndTarget.transform.position, walkSpeed * Time.deltaTime);
            Vector2 position2D = new Vector2(transform.position.x, transform.position.y);
            Vector2 secPos2D = new Vector2(secndTarget.transform.position.x, secndTarget.transform.position.y);
            if (position2D == secPos2D)
            {
                mode = 4;
            }
        }
        if (mode == 4)
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
