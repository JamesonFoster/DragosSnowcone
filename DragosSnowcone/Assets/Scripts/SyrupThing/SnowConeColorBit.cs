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
    public void colorSet(Color newColor, int bottleNumb)
    {
        newColor.a = 1f;
        sprrend.color = newColor;

        sCC.IncreaseColorTally(bottleNumb);
        Destroy(this);
    }
}
