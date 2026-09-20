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
    public bool isMove;
    public Transform move1;
    public Transform move2;

    void Start()
    {
        GlobalPlayerVars.lookingAt = 0;
        move1.position = target.transform.position;
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
            if (!isMove)
                target.SetActive(true);
            else
            {
                target.transform.position = move1.position;
            }
        }
        else
        {
            if (!isMove)
                target.SetActive(false);
            else
            {
                target.transform.position = move2.position;
            }
        }
    }
}
