using UnityEngine;

[CreateAssetMenu(fileName = "CustomersData", menuName = "CustomObj/Order")]
public class Order : ScriptableObject
{
    public enum cupSize
    {
        small,
        medium,
        large
    }

    public enum syrup1
    {
        none,
        test1,
        test2,
        test3
    }

    public enum syrup2
    {
        none,
        test2,
        test3
    }

    public enum syrup3
    {
        none,
        test1,
        test2
    }

    public enum topping1
    {
        none,
        princesPuree,
        gummyWiz,
        nuts
    }

    public enum topping2
    {
        none,
        princesPuree,
        gummyWiz,
        nuts
    }

    public enum topping3
    {
        none,
        princesPuree,
        gummyWiz,
        nuts
    }
}
