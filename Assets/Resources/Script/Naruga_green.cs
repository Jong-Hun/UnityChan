using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naruga_green : FSMEnemy {

    public Transform naruga_rotate;

    protected override IEnumerator Battle()
    {
        do
        {
            yield return null;

            naruga_rotate.LookAt(player);

            if (!DetectPlayer())
            {
                SetState(CharacterState.Idle);
            }

        } while (!isNewState);
    }
}
