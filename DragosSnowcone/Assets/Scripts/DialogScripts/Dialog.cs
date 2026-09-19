using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public GameObject DialogPanel;
    public ImageManager imgManager;
    public bool waitForImg = false;
    public int imgCount = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartDialog(Order order)
    {
        DialogPanel.SetActive(true);

        NextImg(order);
    }

    public void EndDialog()
    {
        DialogPanel.SetActive(false);
        GameObject dupliTicket = Instantiate(imgManager.Ticket, imgManager.TicketParnet);
        dupliTicket.transform.position = imgManager.TicketParnet.position;
        dupliTicket.transform.localScale = new Vector3(1.3f, 3.3f, 1f);
        imgManager.TicketImg1.enabled = false;
        imgManager.TicketImg2.enabled = false;
        imgManager.TicketImg3.enabled = false;

    }
    public void NextImg(Order order)
    {
        if (order.orderLVL == 1)
        {
            if (waitForImg == false && imgCount == 1)
            {
                switch (order.cupSize)
                {
                    case Order.CupSize.small:
                        imgManager.TicketImg1.enabled = true;
                        imgManager.TicketImg1.sprite = imgManager.smallCup;
                        imgManager.SpeechImg.sprite = imgManager.smallCup;
                        break;

                    case Order.CupSize.medium:
                        imgManager.TicketImg1.enabled = true;
                        imgManager.TicketImg1.sprite = imgManager.mediumCup;
                        imgManager.SpeechImg.sprite = imgManager.mediumCup;
                        break;

                    case Order.CupSize.large:
                        imgManager.TicketImg1.enabled = true;
                        imgManager.TicketImg1.sprite = imgManager.smallCup;
                        imgManager.SpeechImg.sprite = imgManager.largeCup;
                        break;
                }
            }
            //StartCoroutine(Wait1Sec(order));
            Debug.Log("should do img 2");
            if (waitForImg == false && imgCount == 2)
            {
                switch (order.syrup1)
                {
                    case Order.syrup.none:
                        imgManager.TicketImg2.enabled = false;
                        imgManager.TicketImg2.sprite = imgManager.mediumCup;
                        imgManager.SpeechImg.sprite = imgManager.syrup7;
                        break;

                    case Order.syrup.s1:
                        imgManager.TicketImg2.enabled = true;
                        imgManager.TicketImg2.sprite = imgManager.syrup1;
                        imgManager.SpeechImg.sprite = imgManager.syrup1;
                        break;

                    case Order.syrup.s2:
                        imgManager.TicketImg2.enabled = true;
                        imgManager.TicketImg2.sprite = imgManager.syrup2;
                        imgManager.SpeechImg.sprite = imgManager.syrup2;
                        break;

                    case Order.syrup.s3:
                        imgManager.TicketImg2.enabled = true;
                        imgManager.TicketImg2.sprite = imgManager.syrup3;
                        imgManager.SpeechImg.sprite = imgManager.syrup3;
                        break;
                }
            }
            //StartCoroutine(Wait1Sec(order));
            Debug.Log("should do img 3");
            if (waitForImg == false && imgCount == 3)
            {
                switch (order.topping1)
                {
                    case Order.topping.none:
                        imgManager.TicketImg3.enabled = false;
                        imgManager.TicketImg3.sprite = imgManager.mediumCup;
                        imgManager.SpeechImg.sprite = imgManager.topping7;
                        break;

                    case Order.topping.princesPuree:
                        imgManager.TicketImg3.enabled = true;
                        imgManager.TicketImg3.sprite = imgManager.topping;
                        imgManager.SpeechImg.sprite = imgManager.topping;
                        break;

                    case Order.topping.gummyWiz:
                        imgManager.TicketImg2.enabled = true;
                        imgManager.TicketImg2.sprite = imgManager.topping2;
                        imgManager.SpeechImg.sprite = imgManager.topping2;
                        break;

                    case Order.topping.nuts:
                        imgManager.TicketImg2.enabled = true;
                        imgManager.TicketImg2.sprite = imgManager.topping3;
                        imgManager.SpeechImg.sprite = imgManager.topping3;
                        break;
                }
            }
            if (imgCount < 3)
                StartCoroutine(Wait1Sec(order));
            else
            {
                EndDialog();
                Debug.Log("Ending dialog");
                imgCount = 1;
            }
        }

        if (order.orderLVL == 2 && waitForImg == false)
        {
            switch (order.cupSize)
            {
                case Order.CupSize.small:
                    imgManager.TicketImg1.enabled = true;
                    imgManager.TicketImg1.sprite = imgManager.smallCup;
                    imgManager.SpeechImg.sprite = imgManager.smallCup;
                    break;

                case Order.CupSize.medium:
                    imgManager.TicketImg1.enabled = true;
                    imgManager.TicketImg1.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.mediumCup;
                    break;

                case Order.CupSize.large:
                    imgManager.TicketImg1.enabled = true;
                    imgManager.TicketImg1.sprite = imgManager.smallCup;
                    imgManager.SpeechImg.sprite = imgManager.largeCup;
                    break;
            }
            StartCoroutine(Wait1Sec(order));

            switch (order.syrup1)
            {
                case Order.syrup.none:
                    imgManager.TicketImg2.enabled = false;
                    imgManager.TicketImg2.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.syrup7;
                    break;

                case Order.syrup.s1:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup1;
                    imgManager.SpeechImg.sprite = imgManager.syrup1;
                    break;

                case Order.syrup.s2:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup2;
                    imgManager.SpeechImg.sprite = imgManager.syrup2;
                    break;

                case Order.syrup.s3:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup3;
                    imgManager.SpeechImg.sprite = imgManager.syrup3;
                    break;
            }
            StartCoroutine(Wait1Sec(order));

            switch (order.syrup2)
            {
                case Order.syrup.none:
                    imgManager.TicketImg2.enabled = false;
                    imgManager.TicketImg2.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.syrup7;
                    break;

                case Order.syrup.s1:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup1;
                    imgManager.SpeechImg.sprite = imgManager.syrup1;
                    break;

                case Order.syrup.s2:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup2;
                    imgManager.SpeechImg.sprite = imgManager.syrup2;
                    break;

                case Order.syrup.s3:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup3;
                    imgManager.SpeechImg.sprite = imgManager.syrup3;
                    break;
            }
            StartCoroutine(Wait1Sec(order));

            switch (order.topping1)
            {
                case Order.topping.none:
                    imgManager.TicketImg3.enabled = false;
                    imgManager.TicketImg3.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.topping7;
                    break;

                case Order.topping.princesPuree:
                    imgManager.TicketImg3.enabled = true;
                    imgManager.TicketImg3.sprite = imgManager.topping;
                    imgManager.SpeechImg.sprite = imgManager.topping;
                    break;

                case Order.topping.gummyWiz:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.topping2;
                    imgManager.SpeechImg.sprite = imgManager.topping2;
                    break;

                case Order.topping.nuts:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.topping3;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    break;
            }
            StartCoroutine(Wait1Sec(order));

            switch (order.topping2)
            {
                case Order.topping.none:
                    imgManager.TicketImg3.enabled = false;
                    imgManager.TicketImg3.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.topping7;
                    break;

                case Order.topping.princesPuree:
                    imgManager.TicketImg3.enabled = true;
                    imgManager.TicketImg3.sprite = imgManager.topping;
                    imgManager.SpeechImg.sprite = imgManager.topping;
                    break;

                case Order.topping.gummyWiz:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.topping2;
                    imgManager.SpeechImg.sprite = imgManager.topping2;
                    break;

                case Order.topping.nuts:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.topping3;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    break;
            }

        }

        if (order.orderLVL == 3 && waitForImg == false)
        {
            switch (order.cupSize)
            {
                case Order.CupSize.small:
                    imgManager.TicketImg1.enabled = true;
                    imgManager.TicketImg1.sprite = imgManager.smallCup;
                    imgManager.SpeechImg.sprite = imgManager.smallCup;
                    break;

                case Order.CupSize.medium:
                    imgManager.TicketImg1.enabled = true;
                    imgManager.TicketImg1.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.mediumCup;
                    break;

                case Order.CupSize.large:
                    imgManager.TicketImg1.enabled = true;
                    imgManager.TicketImg1.sprite = imgManager.smallCup;
                    imgManager.SpeechImg.sprite = imgManager.largeCup;
                    break;
            }
            StartCoroutine(Wait1Sec(order));
            switch (order.syrup1)
            {
                case Order.syrup.none:
                    imgManager.TicketImg2.enabled = false;
                    imgManager.TicketImg2.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.syrup7;
                    break;

                case Order.syrup.s1:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup1;
                    imgManager.SpeechImg.sprite = imgManager.syrup1;
                    break;

                case Order.syrup.s2:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup2;
                    imgManager.SpeechImg.sprite = imgManager.syrup2;
                    break;

                case Order.syrup.s3:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup3;
                    imgManager.SpeechImg.sprite = imgManager.syrup3;
                    break;
            }
            StartCoroutine(Wait1Sec(order));
            switch (order.syrup2)
            {
                case Order.syrup.none:
                    imgManager.TicketImg2.enabled = false;
                    imgManager.TicketImg2.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.syrup7;
                    break;

                case Order.syrup.s1:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup1;
                    imgManager.SpeechImg.sprite = imgManager.syrup1;
                    break;

                case Order.syrup.s2:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup2;
                    imgManager.SpeechImg.sprite = imgManager.syrup2;
                    break;

                case Order.syrup.s3:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup3;
                    imgManager.SpeechImg.sprite = imgManager.syrup3;
                    break;
            }
            StartCoroutine(Wait1Sec(order));
            switch (order.syrup3)
            {
                case Order.syrup.none:
                    imgManager.TicketImg2.enabled = false;
                    imgManager.TicketImg2.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.syrup7;
                    break;

                case Order.syrup.s1:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup1;
                    imgManager.SpeechImg.sprite = imgManager.syrup1;
                    break;

                case Order.syrup.s2:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup2;
                    imgManager.SpeechImg.sprite = imgManager.syrup2;
                    break;

                case Order.syrup.s3:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.syrup3;
                    imgManager.SpeechImg.sprite = imgManager.syrup3;
                    break;
            }
            StartCoroutine(Wait1Sec(order));
            switch (order.topping1)
            {
                case Order.topping.none:
                    imgManager.TicketImg3.enabled = false;
                    imgManager.TicketImg3.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.topping7;
                    break;

                case Order.topping.princesPuree:
                    imgManager.TicketImg3.enabled = true;
                    imgManager.TicketImg3.sprite = imgManager.topping;
                    imgManager.SpeechImg.sprite = imgManager.topping;
                    break;

                case Order.topping.gummyWiz:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.topping2;
                    imgManager.SpeechImg.sprite = imgManager.topping2;
                    break;

                case Order.topping.nuts:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.topping3;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    break;
            }
            StartCoroutine(Wait1Sec(order));
            switch (order.topping2)
            {
                case Order.topping.none:
                    imgManager.TicketImg3.enabled = false;
                    imgManager.TicketImg3.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.topping7;
                    break;

                case Order.topping.princesPuree:
                    imgManager.TicketImg3.enabled = true;
                    imgManager.TicketImg3.sprite = imgManager.topping;
                    imgManager.SpeechImg.sprite = imgManager.topping;
                    break;

                case Order.topping.gummyWiz:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.topping2;
                    imgManager.SpeechImg.sprite = imgManager.topping2;
                    break;

                case Order.topping.nuts:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.topping3;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    break;
            }
            StartCoroutine(Wait1Sec(order));
            switch (order.topping3)
            {
                case Order.topping.none:
                    imgManager.TicketImg3.enabled = false;
                    imgManager.TicketImg3.sprite = imgManager.mediumCup;
                    imgManager.SpeechImg.sprite = imgManager.topping7;
                    break;

                case Order.topping.princesPuree:
                    imgManager.TicketImg3.enabled = true;
                    imgManager.TicketImg3.sprite = imgManager.topping;
                    imgManager.SpeechImg.sprite = imgManager.topping;
                    break;

                case Order.topping.gummyWiz:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.topping2;
                    imgManager.SpeechImg.sprite = imgManager.topping2;
                    break;

                case Order.topping.nuts:
                    imgManager.TicketImg2.enabled = true;
                    imgManager.TicketImg2.sprite = imgManager.topping3;
                    imgManager.SpeechImg.sprite = imgManager.topping3;
                    break;
            }
        }

    }

    IEnumerator Wait1Sec(Order order)
    {
        waitForImg = true;

        yield return new WaitForSeconds(0.5f);

        waitForImg = false;
        imgCount++;
        NextImg(order);
    }

}
