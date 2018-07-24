using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMBase : MonoBehaviour {

    public CharacterState state;
    public bool isNewState;

    Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void OnEnable()
    {
        state = CharacterState.Idle;
        StartCoroutine(FSMMain());
    }

    IEnumerator FSMMain()
    {
        while (true)
        {
            isNewState = false;
            yield return StartCoroutine(state.ToString());
        }
    }

    public void SetState(CharacterState newState)
    {
        isNewState = true;
        state = newState;

        animator.SetInteger("state", (int)state);
    }

    protected virtual IEnumerator Idle()
    {
        do
        {
            yield return null;

        } while (!isNewState);
    }
}
