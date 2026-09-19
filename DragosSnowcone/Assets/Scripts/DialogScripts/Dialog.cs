using UnityEngine;

public class Dialog : MonoBehaviour
{
    public GameObject DialogPanel;
    public ImageManager imgManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartDialog()
    {
        DialogPanel.SetActive(true);
    }
    public void NextImg(Order order)
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
