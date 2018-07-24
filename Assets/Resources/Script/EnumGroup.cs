using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 상태
public enum CharacterState
{
    Idle,
    Run,
    Battle,
    Attack,
    Damage,
    Dead,
    Escape,
    Skill_1,
    Skill_2,
}

// 클릭한 것 구분
public enum ClickTarget
{
    None,
    move,
    enemy,
}
