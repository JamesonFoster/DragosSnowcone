using UnityEngine;

[CreateAssetMenu(fileName = "CustomersData", menuName = "CustomObj/Order")]
public class Order : ScriptableObject
{
    public int orderLVL;

    public CupSize cupSize;
    public syrup syrup1;
    public syrup syrup2;
    public syrup syrup3;
    public topping topping1;
    public topping topping2;
    public topping topping3;


    public enum CupSize
    {
        small,
        medium,
        large
    }

    public enum syrup
    {
        none,
        test1,
        test2,
        test3
    }

    public enum topping
    {
        none,
        princesPuree,
        gummyWiz,
        nuts
    }
}
