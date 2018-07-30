using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButton : MonoBehaviour
{
    public void BattleOK()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FSM_Player>().SetState(CharacterState.Battle);
        GameObject.FindGameObjectWithTag("Player").GetComponent<FSM_Player>().BattlePopupClose();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = false;
    }

    public void BattleEscape()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FSM_Player>().SetState(CharacterState.Escape);
        GameObject.FindGameObjectWithTag("Player").GetComponent<FSM_Player>().BattlePopupClose();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = true;
    }
}
