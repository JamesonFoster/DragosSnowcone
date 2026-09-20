using UnityEngine;

public class ButtonActiveIn : MonoBehaviour
{
    public bool isActiveInLobby = true;
    public bool isActiveInSnowcone = true;
    public bool isActiveInSyrup = true;
    public bool isActiveInAddon = true;
    public bool isActiveInFish = true;
    public bool isActiveInTicket = true;
    public bool isActiveInJudge = true;
    public GameObject target;

    void Start()
    {
        GlobalPlayerVars.lookingAt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((isActiveInLobby && GlobalPlayerVars.lookingAt == 0)
        || (isActiveInSnowcone && GlobalPlayerVars.lookingAt == 1)
        || (isActiveInSyrup && GlobalPlayerVars.lookingAt == 2)
        || (isActiveInAddon && GlobalPlayerVars.lookingAt == 3)
        || (isActiveInFish && GlobalPlayerVars.lookingAt == 4)
        || (isActiveInTicket && GlobalPlayerVars.lookingAt == 5 && !GlobalPlayerVars.endTalk)
        || (isActiveInJudge && GlobalPlayerVars.lookingAt == 5 && GlobalPlayerVars.endTalk)
        )
        {
            target.SetActive(true);
        }
        else
        {
            target.SetActive(false);
        }
    }
}
