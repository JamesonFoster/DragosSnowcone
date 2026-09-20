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
    public int topping1Count;
    public int topping2Count;
    public int topping3Count;


    public enum CupSize
    {
        small,
        medium,
        large
    }

    public enum syrup
    {
        none,
        s1,
        s2,
        s3,
        s4,
        s5,
        s6,
        s7,
        s8
    }

    public enum topping
    {
        none,
        princesPuree,
        gummyWiz,
        nuts
    }
}
