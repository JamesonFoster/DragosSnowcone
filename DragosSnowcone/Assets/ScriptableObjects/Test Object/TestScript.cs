using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Game Data/Item")]
public class TestScript : ScriptableObject
{
    public string itemName;
    public int goldValue;
    public Sprite icon;
}