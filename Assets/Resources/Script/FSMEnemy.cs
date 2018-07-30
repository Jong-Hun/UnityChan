using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMEnemy : FSMBase {


    Transform player;
    FSM_Player fsmPlayer;
    public float detectRange = 4;

    protected override void Awake()
    {
        base.Awake();
        //detectRange = 4;
    }

    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fsmPlayer = player.GetComponent<FSM_Player>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    bool DetectPlayer()
    {
        if (Vector3.Distance(player.position, transform.position) < detectRange)
        {
            return true;
        }
        return false;
    }

    protected override IEnumerator Idle()
    {
        do
        {
            yield return null;

            if(DetectPlayer())
            {
                fsmPlayer.SetTarget(transform);
                fsmPlayer.NavStop();             
                fsmPlayer.BattleMode();
                SetState(CharacterState.Battle);
            }

        } while (!isNewState);
    }

    protected virtual IEnumerator Battle()
    {
        do
        {
            yield return null;

            transform.LookAt(player);

            if (!DetectPlayer())
            {
                SetState(CharacterState.Idle);
            }

            Debug.Log("battle enemy");

        } while (!isNewState);
    }

    protected virtual IEnumerator Attack()
    {
        do
        {
            yield return null;

        } while (!isNewState);
    }

    protected virtual IEnumerator Damage()
    {
        do
        {
            yield return null;

        } while (!isNewState);
    }

    protected virtual IEnumerator Death()
    {
        do
        {
            yield return null;

        } while (!isNewState);
    }


}
