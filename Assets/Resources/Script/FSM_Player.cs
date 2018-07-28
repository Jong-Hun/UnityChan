using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSM_Player : FSMBase {

    NavMeshAgent navAgent;

    int layerMask;

    string GroundLayer = "Ground";
    string blockLayer = "Block";
    string enemyLayer = "Enemy";
    string npcLayer = "NPC";

    ClickTarget clickTarget = ClickTarget.None;

    Transform target; // 클릭한 타겟

    // 임시..
    GameObject battlePopup;

    protected override void Awake()
    {
        base.Awake();

        target = null;

        navAgent = GetComponent<NavMeshAgent>();

        layerMask = LayerMask.GetMask(GroundLayer, blockLayer, enemyLayer, npcLayer);

        battlePopup = GameObject.Find("PanelBattleTest");
        if (battlePopup.activeSelf)
        {
            battlePopup.SetActive(false);
        }
    }

	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (UICamera.hoveredObject == null)
            {
                if (Physics.Raycast(ray, out hitInfo, 100f, layerMask))
                {
                    int layer = hitInfo.transform.gameObject.layer;

                    if (layer == LayerMask.NameToLayer(GroundLayer))
                    {
                        clickTarget = ClickTarget.move;
                        navAgent.SetDestination(hitInfo.point);
                    }
                    else if (layer == LayerMask.NameToLayer(enemyLayer))
                    {
                        target = hitInfo.transform;
                        clickTarget = ClickTarget.enemy;
                        navAgent.SetDestination(hitInfo.point);
                    }
                    SetState(CharacterState.Run);
                }
            }

        }
	}

    public void BattleMode()
    {
        transform.LookAt(target);
        navAgent.isStopped = true;
        battlePopup.SetActive(true);

        SetState(CharacterState.Battle);
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
                    case ClickTarget.enemy:
                    {

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

        } while (!isNewState);
    }
}
