using UnityEngine;

public class SnowConeColorBit : MonoBehaviour
{
    public Color currentColor;
    public SnowConeController sCC;
    private SpriteRenderer sprrend;
    void Awake()
    {
        sprrend = GetComponent<SpriteRenderer>();
    }
    void colorSet(Color newColor, int bottleNumb)
    {
        sprrend.color = newColor;
        sCC.IncreaseColorTally(bottleNumb);
    }
}
