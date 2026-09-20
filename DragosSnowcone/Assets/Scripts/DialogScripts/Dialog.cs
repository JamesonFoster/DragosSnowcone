using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public GameObject DialogPanel;
    public StationSwitch sS;
    public ImageManager imgManager;
    public bool waitForImg = false;
    public int imgCount = 1;
    public CustomerMovement customer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogPanel.SetActive(false);
        imgManager.Ticket.SetActive(false);
        imgManager.custFrontImg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartDialog()
    {
        GlobalPlayerVars.orderNmbr++;
        imgManager.orderNumber.text = "" + GlobalPlayerVars.orderNmbr;
        imgManager.nameTxt.text = customer.customer.customerName;
        DialogPanel.SetActive(true);
        imgManager.custFrontImg.enabled = true;
        imgManager.custFrontImg.sprite = customer.customer.frontSpr;
        imgManager.Ticket.SetActive(true);

        sS.GoToPosition(5);
        NextImg(customer.order);
    }

    public void EndDialog()
    {
        DialogPanel.SetActive(false);
        imgManager.Ticket.SetActive(false);
        imgManager.custFrontImg.enabled = false;
        GameObject dupliTicket = Instantiate(imgManager.Ticket, imgManager.TicketParnet);
        dupliTicket.SetActive(true);
        dupliTicket.transform.position = imgManager.TicketParnet.position;
        dupliTicket.transform.localScale = new Vector3(25f, 25f, 1f);
        dupliTicket.GetComponent<TicketData>().customer = customer.customer;
        dupliTicket.GetComponent<TicketData>().order = customer.order;
        imgManager.cupImg.enabled = false;
        imgManager.syrupImg1.enabled = false;
        imgManager.syrupImg2.enabled = false;
        imgManager.syrupImg3.enabled = false;
        imgManager.toppingImg1.enabled = false;
        imgManager.toppingImg2.enabled = false;
        imgManager.toppingImg3.enabled = false;
        imgManager.toppingTxt1.text = string.Empty;
        imgManager.toppingTxt2.text = string.Empty;
        imgManager.toppingTxt3.text = string.Empty;
        
        sS.GoToPosition(0);
        customer.mode = 3;
        customer.CWSStar1.setIsON(false);
    }
    public void NextImg(Order order)
    {
        if (waitForImg)
        {
            waitForImg = false;
            imgCount++;
            Debug.Log(imgCount);
            NextImg(order);
            return;
        }
        
        if (waitForImg == false && imgCount == 1)
        {
            switch (order.cupSize)
            {
                case Order.CupSize.small:

                    imgManager.cupImg.sprite = imgManager.smallCup;
                    imgManager.cupImg.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.smallCup;
                    break;

                case Order.CupSize.medium:

                    imgManager.cupImg.sprite = imgManager.mediumCup;
                    imgManager.cupImg.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.mediumCup;
                    break;

                case Order.CupSize.large:

                    imgManager.cupImg.sprite = imgManager.largeCup;
                    imgManager.cupImg.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.largeCup;
                    break;
            }
        }

        if (waitForImg == false && imgCount == 2)
        {
            switch (order.syrup1)
            {
                case Order.syrup.none:
                    waitForImg = true;
                    
                    break;

                case Order.syrup.s1:
                    
                    imgManager.syrupImg1.sprite = imgManager.syrup1;
                    imgManager.syrupImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup1;
                    break;

                case Order.syrup.s2:
                    
                    imgManager.syrupImg1.sprite = imgManager.syrup2;
                    imgManager.syrupImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup2;
                    break;

                case Order.syrup.s3:
                    
                    imgManager.syrupImg1.sprite = imgManager.syrup3;
                    imgManager.syrupImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup3;
                    break;
                case Order.syrup.s4:
                    
                    imgManager.syrupImg1.sprite = imgManager.syrup4;
                    imgManager.syrupImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s5:
                    
                    imgManager.syrupImg1.sprite = imgManager.syrup4;
                    imgManager.syrupImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s6:
                    
                    imgManager.syrupImg1.sprite = imgManager.syrup4;
                    imgManager.syrupImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s7:
                    
                    imgManager.syrupImg1.sprite = imgManager.syrup4;
                    imgManager.syrupImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s8:
                    
                    imgManager.syrupImg1.sprite = imgManager.syrup4;
                    imgManager.syrupImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
            }
        }

        if (waitForImg == false && imgCount == 3)
        {
            switch (order.syrup2)
            {
                case Order.syrup.none:
                    waitForImg = true;
                    
                    break;

                case Order.syrup.s1:
                    
                    imgManager.syrupImg2.sprite = imgManager.syrup1;
                    imgManager.syrupImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup1;
                    break;

                case Order.syrup.s2:
                    
                    imgManager.syrupImg2.sprite = imgManager.syrup2;
                    imgManager.syrupImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup2;
                    break;

                case Order.syrup.s3:
                    
                    imgManager.syrupImg2.sprite = imgManager.syrup3;
                    imgManager.syrupImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup3;
                    break;
                case Order.syrup.s4:
                    
                    imgManager.syrupImg2.sprite = imgManager.syrup4;
                    imgManager.syrupImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s5:
                    
                    imgManager.syrupImg2.sprite = imgManager.syrup4;
                    imgManager.syrupImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s6:
                    
                    imgManager.syrupImg2.sprite = imgManager.syrup4;
                    imgManager.syrupImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s7:
                    
                    imgManager.syrupImg2.sprite = imgManager.syrup4;
                    imgManager.syrupImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s8:
                    
                    imgManager.syrupImg2.sprite = imgManager.syrup4;
                    imgManager.syrupImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
            }
        }

        if (waitForImg == false && imgCount == 4)
        {
            switch (order.syrup3)
            {
                case Order.syrup.none:
                    waitForImg = true;
                    
                    break;

                case Order.syrup.s1:
                    imgManager.syrupImg3.sprite = imgManager.syrup1;
                    imgManager.syrupImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup1;
                    break;

                case Order.syrup.s2:
                    imgManager.syrupImg3.sprite = imgManager.syrup2;
                    imgManager.syrupImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup2;
                    break;

                case Order.syrup.s3:

                    imgManager.syrupImg3.sprite = imgManager.syrup3;
                    imgManager.syrupImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup3;
                    break;
                case Order.syrup.s4:
                    imgManager.syrupImg3.sprite = imgManager.syrup4;
                    imgManager.syrupImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s5:

                    imgManager.syrupImg3.sprite = imgManager.syrup4;
                    imgManager.syrupImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s6:

                    imgManager.syrupImg3.sprite = imgManager.syrup4;
                    imgManager.syrupImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s7:

                    imgManager.syrupImg3.sprite = imgManager.syrup4;
                    imgManager.syrupImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
                case Order.syrup.s8:
                    imgManager.syrupImg3.sprite = imgManager.syrup4;
                    imgManager.syrupImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.syrup4;
                    break;
            }
        }
        Debug.Log(waitForImg);
        if (waitForImg == false && imgCount == 5)
        {
            switch (order.topping1)
            {
                case Order.topping.none:
                    waitForImg = true;
                    
                    break;

                case Order.topping.t1:
                    imgManager.toppingImg1.sprite = imgManager.topping;
                    imgManager.toppingImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping;
                    imgManager.toppingTxt1.text = "" + order.topping1Count;
                    break;

                case Order.topping.t2:
                    imgManager.toppingImg1.sprite = imgManager.topping2;
                    imgManager.toppingImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping2;
                    imgManager.toppingTxt1.text = "" + order.topping1Count;
                    break;

                case Order.topping.t3:
                    imgManager.toppingImg1.sprite = imgManager.topping3;
                    imgManager.toppingImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt1.text = "" + order.topping1Count;
                    break;

                case Order.topping.t4:
                    imgManager.toppingImg1.sprite = imgManager.topping;
                    imgManager.toppingImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping;
                    imgManager.toppingTxt1.text = "" + order.topping1Count;
                    break;

                case Order.topping.t5:
                    imgManager.toppingImg1.sprite = imgManager.topping2;
                    imgManager.toppingImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping2;
                    imgManager.toppingTxt1.text = "" + order.topping1Count;
                    break;

                case Order.topping.t6:
                    imgManager.toppingImg1.sprite = imgManager.topping3;
                    imgManager.toppingImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt1.text = "" + order.topping1Count;
                    break;

                case Order.topping.t7:
                    imgManager.toppingImg1.sprite = imgManager.topping2;
                    imgManager.toppingImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping2;
                    imgManager.toppingTxt1.text = "" + order.topping1Count;
                    break;

                case Order.topping.t8:
                    imgManager.toppingImg1.sprite = imgManager.topping3;
                    imgManager.toppingImg1.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt1.text = "" + order.topping1Count;
                    break;
            }
        }
        Debug.Log(waitForImg);
        if (waitForImg == false && imgCount == 6)
        {
            switch (order.topping2)
            {
                case Order.topping.none:
                    waitForImg = true;
                    
                    break;

                case Order.topping.t1:
                    
                    imgManager.toppingImg2.sprite = imgManager.topping;
                    imgManager.toppingImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping;
                    imgManager.toppingTxt2.text = "" + order.topping2Count;
                    break;

                case Order.topping.t2:
                    
                    imgManager.toppingImg2.sprite = imgManager.topping2;
                    imgManager.toppingImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping2;
                    imgManager.toppingTxt2.text = "" + order.topping2Count;
                    break;

                case Order.topping.t3:
                    
                    imgManager.toppingImg2.sprite = imgManager.topping3;
                    imgManager.toppingImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt2.text = "" + order.topping2Count;
                    break;

                case Order.topping.t4:
                    
                    imgManager.toppingImg2.sprite = imgManager.topping3;
                    imgManager.toppingImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt2.text = "" + order.topping2Count;
                    break;

                case Order.topping.t5:
                    
                    imgManager.toppingImg2.sprite = imgManager.topping3;
                    imgManager.toppingImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt2.text = "" + order.topping2Count;
                    break;

                case Order.topping.t6:
                    
                    imgManager.toppingImg2.sprite = imgManager.topping3;
                    imgManager.toppingImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt2.text = "" + order.topping2Count;
                    break;

                case Order.topping.t7:
                    
                    imgManager.toppingImg2.sprite = imgManager.topping3;
                    imgManager.toppingImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt2.text = "" + order.topping2Count;
                    break;

                case Order.topping.t8:
                    
                    imgManager.toppingImg2.sprite = imgManager.topping3;
                    imgManager.toppingImg2.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt2.text = "" + order.topping2Count;
                    break;
            }
        }

        if (waitForImg == false && imgCount == 7)
        {
            switch (order.topping3)
            {
                case Order.topping.none:
                    waitForImg = true;
                    
                    break;

                case Order.topping.t1:
                    
                    imgManager.toppingImg3.sprite = imgManager.topping;
                    imgManager.toppingImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping;
                    imgManager.toppingTxt3.text = "" + order.topping3Count;
                    break;

                case Order.topping.t2:
                    
                    imgManager.toppingImg3.sprite = imgManager.topping2;
                    
                    imgManager.SpeechImg.sprite = imgManager.topping2;
                    imgManager.toppingTxt3.text = "" + order.topping3Count;
                    break;

                case Order.topping.t3:
                    imgManager.toppingImg3.enabled = true;
                    imgManager.toppingImg3.sprite = imgManager.topping3;
                    imgManager.toppingImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt3.text = "" + order.topping3Count;
                    break;

                case Order.topping.t4:
                    imgManager.toppingImg3.sprite = imgManager.topping3;
                    imgManager.toppingImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt3.text = "" + order.topping3Count;
                    break;

                case Order.topping.t5:
                    imgManager.toppingImg3.sprite = imgManager.topping3;
                    imgManager.toppingImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt3.text = "" + order.topping3Count;
                    break;

                case Order.topping.t6:
                    imgManager.toppingImg3.sprite = imgManager.topping3;
                    imgManager.toppingImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt3.text = "" + order.topping3Count;
                    break;

                case Order.topping.t7:
                    imgManager.toppingImg3.sprite = imgManager.topping3;
                    imgManager.toppingImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt3.text = "" + order.topping3Count;
                    break;

                case Order.topping.t8:
                    imgManager.toppingImg3.sprite = imgManager.topping3;
                    imgManager.toppingImg3.enabled = true;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    imgManager.toppingTxt3.text = "" + order.topping3Count;
                    break;
            }
        }
        if (imgCount < 8)
        {
            if (waitForImg)
            {
                NextImg(order);
                return;
            }
            StartCoroutine(Wait1Sec(order));
            
        }
        else
        {
            EndDialog();
            Debug.Log("Ending dialog");
            imgCount = 1;
        }
        
        

    }

    IEnumerator Wait1Sec(Order order)
    {
        waitForImg = true;

        yield return new WaitForSeconds(customer.customer.talkSpeed);

        waitForImg = false;
        imgCount++;
        NextImg(order);
    }

}
