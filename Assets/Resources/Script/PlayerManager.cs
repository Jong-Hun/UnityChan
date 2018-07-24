using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerManager : MonoBehaviour {

    public GameObject PlayerPrefab;

    void Awake()
    {
        GameObject PlayerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn");
        Spawn(PlayerPrefab, PlayerSpawn.transform.position);
    }

    void Spawn(GameObject obj, Vector3 pos)
    {
        Instantiate(obj, pos, Quaternion.identity);
    }
}
