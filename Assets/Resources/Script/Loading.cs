using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// 로딩 애니메이션 시작
        // 데이터 로드
        // 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void NewGame()
    {
        // 이어하기에 있던 프리펩스 삭제;
        PlayerPrefs.DeleteAll();

        // 
        ResetPlayerStatus();
        ResetPlayerLocation();
        ResetPlayerQuest();
        ResetPlayerEquipItem();
        ResetPlayerInventoryItem();
    }

    void LoadGame()
    {

    }

    void Continue()
    {

    }

    // 플레이어 데이터 리셋
    void ResetPlayerStatus()
    {
        PlayerPrefs.SetInt("HP", 0);
        PlayerPrefs.SetInt("MP", 0);
        PlayerPrefs.SetInt("ATK", 0);
        PlayerPrefs.SetInt("MTK", 0);
        PlayerPrefs.SetInt("DEF", 0);
        PlayerPrefs.SetInt("DEX", 0);
    }

    // 플레이어 위치 리셋
    void ResetPlayerLocation()
    {
        PlayerPrefs.SetString("Map","None");
        PlayerPrefs.SetInt("PosX", 0);
        PlayerPrefs.SetInt("PosY", 0);
        PlayerPrefs.SetInt("PosZ", 0);
        PlayerPrefs.SetInt("RotX", 0);
        PlayerPrefs.SetInt("RotY", 0);
        PlayerPrefs.SetInt("RotZ", 0);
    }

    // 플레이어 퀘스트(시나리오 및 서브) 리셋
    void ResetPlayerQuest()
    {
        PlayerPrefs.SetInt("MainQuest", 0);
        PlayerPrefs.SetInt("SubQuest1", 0);
        PlayerPrefs.SetInt("SubQuest2", 0);
        PlayerPrefs.SetInt("SubQuest3", 0);
    }

    // 플레이어 아이템(착용중, 소유) 리셋
    void ResetPlayerEquipItem()
    {
        PlayerPrefs.SetInt("Weapon", 0);
        PlayerPrefs.SetInt("Weapon_U", 0);
        PlayerPrefs.SetInt("Clothing", 0);
        PlayerPrefs.SetInt("Clothing_U", 0);
        PlayerPrefs.SetInt("Shoes", 0);
        PlayerPrefs.SetInt("Shoes_U", 0);
    }

    // 플레이어 아이템(착용중, 소유) 리셋
    void ResetPlayerInventoryItem()
    {
        for(int i = 1; i <= 50; i++)
        {
            PlayerPrefs.SetInt("Item" + i.ToString(), 0);
            PlayerPrefs.SetInt("Item_U" + i.ToString(), 0);
        }
    }
}

