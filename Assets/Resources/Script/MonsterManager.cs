using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {
    // 임시 코딩  다지우고 고칠필요있음

    public GameObject NarugaPrefab;

    private void Awake()
    {
        // 임시 스폰코드
        GameObject PlayerSpawn = GameObject.FindGameObjectWithTag("Respawn");
        MonsterSpawn(NarugaPrefab, PlayerSpawn.transform.position);
    }

    void MonsterSpawn(GameObject obj, Vector3 pos)
    {
        Instantiate(obj, pos, Quaternion.identity);
    }
}
