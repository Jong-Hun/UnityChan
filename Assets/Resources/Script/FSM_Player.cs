using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSM_Player : FSMBase {

    NavMeshAgent navAgent;

    int layerMask;

    string GroundLayer = "Ground";
    string blockLayer = "Block";
    string npcLayer = "NPC";

    ClickTarget clickTarget = ClickTarget.None;

    Transform target; // lookAt 타겟(npc, enemy)

    Vector3 EscapePos;

    GameObject battlePopup;
    GameObject battleCommand;

    protected override void Awake()
    {
        base.Awake();

        target = null;

        navAgent = GetComponent<NavMeshAgent>();

        layerMask = LayerMask.GetMask(GroundLayer, blockLayer, npcLayer);

        battlePopup = GameObject.Find("PanelBattleTest");
        battleCommand = GameObject.Find("PanelBattleTest02");

        if (battlePopup.activeSelf)      battlePopup.SetActive(false);
        if (battleCommand.activeSelf)    battleCommand.SetActive(false);

    }

	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            {
            if (UICamera.hoveredObject == null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, 100f, layerMask))
                {
                    int layer = hitInfo.transform.gameObject.layer;

                    if (layer == LayerMask.NameToLayer(GroundLayer))
                    {
                        clickTarget = ClickTarget.move;
                        navAgent.SetDestination(hitInfo.point);
                    }
                    else if (layer == LayerMask.NameToLayer(npcLayer))
                    {

                    }
                    SetState(CharacterState.Run);
                }
            }
        }
	}

    public void SetTarget(Transform tran)
    {
        target = tran;
    }


    public void NavStop()
    {
        navAgent.SetDestination(transform.position);
    }


    public void BattleMode()
    {
        transform.LookAt(target);
        battlePopup.SetActive(true);
        EscapePos = transform.position + (transform.position - target.position).normalized;
    }

    public void BattlePopupClose()
    {
        battlePopup.SetActive(false);
    }

    protected override IEnumerator Idle()
    {
        do
        {
            yield return null;



        } while (!isNewState);
    }

    protected virtual IEnumerator Run()
    {
        do
        {
            yield return null;

            if(navAgent.remainingDistance == 0.0f)
            {
                switch(clickTarget)
                {
                    case ClickTarget.move:
                    {
                         SetState(CharacterState.Idle);                
                    }break;
                }
            }
        } while (!isNewState);
    }

    protected virtual IEnumerator Battle()
    {
        do
        {
            yield return null;

            transform.LookAt(target);

            battleCommand.SetActive(true);

        } while (!isNewState);
    }

    protected virtual IEnumerator Escape()
    {
        do
        {
            yield return null;

            target = null;
            battleCommand.SetActive(false);
            navAgent.SetDestination(EscapePos);

            if(navAgent.remainingDistance == 0.0f)
                SetState(CharacterState.Idle);
            
        } while (!isNewState);
    }
}
