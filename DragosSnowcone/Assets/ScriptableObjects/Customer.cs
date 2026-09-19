using UnityEngine;

[CreateAssetMenu(fileName = "CustomersData", menuName = "CustomObj/Customers")]
public class Customer : ScriptableObject
{
    [Header("Customer Settings")]
    public string customerName;
    public float patience; // How long till the customer loses points from waiting
    public float maxTip; // What is the max the customer can tip
    public Sprite walkSpr1;
    public Sprite walkSpr2;
}
