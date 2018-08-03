using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButton : MonoBehaviour
{
    FSM_Player fsmPlayer;
    Camera mainCam;

    private void Start()
    {
        fsmPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<FSM_Player>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void BattleOK()
    {
        fsmPlayer.SetState(CharacterState.Battle);
        fsmPlayer.BattlePopupClose();
        mainCam.enabled = false;
    }

    public void BattleEscape()
    {
        fsmPlayer.SetState(CharacterState.Escape);
        fsmPlayer.BattlePopupClose();
        mainCam.enabled = true;
    }

    public void Attack()
    {
        fsmPlayer.SetState(CharacterState.Attack);
    }
}
