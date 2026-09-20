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
    public List<GameObject> waitLine; // line where they wait for the snowcone
    public List<Order> orderRand;// = new List<Order>();
    private GameObject currentTarg;
    public GameObject targetMain2;
    public float bob;
    public GameObject takeOrderButton;
    public int spawnWhen;
    public Order backupOrder;




    private float itmer1;
    private SpriteRenderer sprrend;
    public CustWaitSpot CWSStar1;
    private CustWaitSpot CWSStar2;
    private CustWaitSpot CWS;
    private CustWaitSpot currCWS;
    private int currentWaitPos;
    private Vector2 startingPos;
    private int posBius;
    private bool isCounting = false;
    public float counting;

    void Awake()
    {
        
    }

    void Start()
    {
        sprrend = GetComponent<SpriteRenderer>();
        orderRand = new List<Order>(customer.orders);
        //orderRand.Shuffle();
        CWSStar1 = targetMain1.GetComponent<CustWaitSpot>();
        CWSStar2 = targetMain2.GetComponent<CustWaitSpot>();
        startingPos = new Vector2(transform.position.x, transform.position.y);
        sprrend.sprite = customer.walkSpr1;
        ShuffleList(orderRand);
        ChooseOrder();
    }

    void Update()
    {
        if (isCounting)
        {
            counting += Time.deltaTime;
        }
        if (mode == 0) // moving towards line spot
        {
            sprrend.sortingOrder = 50 + posBius + spawnWhen;
            if (CWSStar1.isOn == false)
            {
                currentTarg = targetMain1;
                posBius = 9;
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
                        posBius = 8 - i;
                        currentWaitPos = i;
                        break;
                    }
                }
            }

            HandleWalkSpr();
            transform.position = Vector2.MoveTowards(transform.position, currentTarg.transform.position, customer.walkSpeed * Time.deltaTime);
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
        if (mode == 1) // waiting in non-star line spot
        {
            sprrend.sortingOrder = 40 + posBius;
            if (customer.joyful == true)
                HandleWalkSpr();
            if (CWSStar1.isOn == false)
            {
                posBius = 9;
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
                        posBius = 8 - i;
                        currCWS = CWS;
                        currentWaitPos = i;
                        mode = 0;
                        break;
                    }
                }
            }
        }
        if (mode == 2) // waiting in starspot
        {
            takeOrderButton.SetActive(true);
            sprrend.sortingOrder = 40 + posBius;
            if (customer.joyful == true)
                HandleWalkSpr();
            //whatever is handling the customers ordering will tell this to go to mode 2
        }
        if (mode == 3) // move back
        {
            isCounting = true;
            sprrend.sortingOrder = 30 + posBius + spawnWhen;
            takeOrderButton.SetActive(false);
            sprrend.flipX = true;
            HandleWalkSpr();
            //transform.position = Vector2.MoveTowards(transform.position, secndTarget.transform.position, walkSpeed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, startingPos, customer.walkSpeed * Time.deltaTime);
            Vector2 position2D = new Vector2(transform.position.x, transform.position.y);
            if (position2D == startingPos)
            {
                sprrend.flipX = false;
                transform.position = new Vector2 (transform.position.x, targetMain2.transform.position.y);
                mode = 4;
            }
        }
        if (mode == 4) // move towards waiting spot
        {
            sprrend.sortingOrder = 20 + posBius + spawnWhen;
            if (CWSStar2.isOn == false)
            {
                currentTarg = targetMain2;
                posBius = 9;
            }
            else
            {
                for (int i = 0; i < waitLine.Count; i++)
                {
                    GameObject currOb = waitLine[i];
                    CWS = currOb.GetComponent<CustWaitSpot>();
                    if (CWS.isOn == false)
                    {
                        currentTarg = currOb;
                        posBius = 8 - i;
                        currCWS = CWS;
                        currentWaitPos = i;
                        break;
                    }
                }
            }

            HandleWalkSpr();
            transform.position = Vector2.MoveTowards(transform.position, currentTarg.transform.position, customer.walkSpeed * Time.deltaTime);
            Vector2 position2D = new Vector2(transform.position.x, transform.position.y);
            Vector2 posFirst2D = new Vector2(currentTarg.transform.position.x, currentTarg.transform.position.y);
            Vector2 starPos2D = new Vector2(targetMain2.transform.position.x, targetMain2.transform.position.y);
            if ((position2D == posFirst2D) && currentTarg != targetMain2)
            {
                currCWS.setIsON(true);
                mode = 5;
            }
            if (position2D == starPos2D)
            {
                CWSStar2.starSet(true,  this);
                mode = 6;
            }
        }
        if (mode == 5) // non-star wait
        {
            sprrend.sortingOrder = 10 + posBius;
            if (customer.joyful == true)
                HandleWalkSpr();
            if (CWSStar2.isOn == false)
            {
                currentTarg = targetMain2;
                posBius = 9;
                currCWS.setIsON(false);
                mode = 4;
            }
            else
            {
                for (int i = 0; i < waitLine.Count; i++)
                {
                    GameObject currOb = waitLine[i];
                    CWS = currOb.GetComponent<CustWaitSpot>();
                    if (CWS.isOn == false && currentWaitPos > i)
                    {
                        currentTarg = currOb;
                        currCWS.setIsON(false);
                        posBius = 8 - i;
                        currCWS = CWS;
                        currentWaitPos = i;
                        mode = 4;
                        break;
                    }
                }
            }
        }
        if (mode == 6) // star wait
        {
            sprrend.sortingOrder = 10 + posBius;
            if (customer.joyful == true)
                HandleWalkSpr();
        }
        if (mode == 7) // leave
        {
            sprrend.sortingOrder = 00 + posBius + spawnWhen;
            sprrend.flipX = true;
            HandleWalkSpr();
            Vector2 goToHere = new Vector2 (startingPos.x, targetMain2.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, goToHere, customer.walkSpeed * Time.deltaTime);
            Vector2 position2D = new Vector2(transform.position.x, transform.position.y);
            if (position2D == goToHere)
            {
                GlobalPlayerVars.custToday += 1;
                Destroy(gameObject);
            }
        }
    }
    public void StopStar()
    {
        CWSStar2.starSet(false, null);
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

    public void ChooseOrder()
    {
        List<Order> tempYes = orderRand;
        for (int i = 0; i < tempYes.Count; i++)
        {
        Order orderss = tempYes[i];
        if (orderss.orderLVL > GlobalPlayerVars.lvl)
        {
            tempYes.RemoveAt(i);
            order = null;
        }
        else
        {
            order = orderss;
            tempYes.RemoveAt(i);
            break;
        }
        }
        if (order == null)
        {
            order = backupOrder;
        }
    }

    public void SetMode(int modeNum)
    {
        mode = modeNum;
    }
    public void ShuffleList(List<Order> list)
    {
        List<Order> temp = new List<Order>();
        List<Order> temp2 = new List<Order>();
        temp.AddRange(list);

        for (int i = 0; i < list.Count; i++)
        {
            int index = Random.Range(0, temp.Count - 1);
            temp2.Add(temp[index]);
            temp.RemoveAt(index);
        }
        list = temp2;
    }
}