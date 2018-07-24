using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class FSM_Player : FSMBase {

    NavMeshAgent navAgent;

    int layerMask;

    string GroundLayer = "Ground";
    string blockLayer = "Block";
    string enemyLayer = "Enemy";
    string npcLayer = "NPC";

    ClickTarget clickTarget = ClickTarget.None;

    protected override void Awake()
    {
        base.Awake();

        navAgent = GetComponent<NavMeshAgent>();

        layerMask = LayerMask.GetMask(GroundLayer, blockLayer, enemyLayer, npcLayer);
    }

	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);           
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100f, layerMask))
            {
                int layer = hitInfo.transform.gameObject.layer;

                // UI를 클릭해도 뒤쪽이 눌리지않음 (유니티에 UI를 추가안하고 이 코드를 사용하면 에러뜸)
                //if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (layer == LayerMask.NameToLayer(GroundLayer))
                    {
                        clickTarget = ClickTarget.move;
                        navAgent.SetDestination(hitInfo.point);
                    }
                    else if (layer == LayerMask.NameToLayer(enemyLayer))
                    {
                        clickTarget = ClickTarget.enemy;
                        navAgent.SetDestination(hitInfo.point + Vector3.one);
                    }
                    SetState(CharacterState.Run);
                }
            }     
        }
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
                         SetState(CharacterState.Battle);
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

            
        } while (!isNewState);
    }
}
