using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

    public GameObject MainPanel = null;

    public GameObject LogoImage = null;
    public GameObject LicenseImage = null;
    public GameObject LoadingImage = null;
    private SpriteImage spriteImage = null;

    private bool isLoading = false;
    private AsyncOperation op = null;

    // Use this for initialization
    void Start () {

        // 메인 패널
        MainPanel.SetActive(false);
        // 로고 화면
        LogoImage.SetActive(true);
        // 라이센스
        LicenseImage.SetActive(false);
        // 로딩 화면
        LoadingImage.SetActive(false);

        StartCoroutine(LoadScene());
        StartCoroutine(LoadData());
        StartCoroutine(PlayImage());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        // 이어하기에 있던 프리펩스 삭제;
        PlayerPrefs.DeleteAll();

        // 
        ResetPlayerStatus();
        ResetPlayerLocation();
        ResetPlayerQuest();
        ResetPlayerEquipItem();
        ResetPlayerInventoryItem();

        // 이미 로드해놓은 씬으로 전환
        op.allowSceneActivation = true;
    }

    public void LoadGame()
    {

    }

    public void Continue()
    {
        if(PlayerPrefs.GetString("Map") == "None")
        {
            Debug.Log("이어하기 가능한 데이터가 없습니다.");
            return;
        }

        Debug.Log(PlayerPrefs.GetString("Map"));
    }

    // 플레이어 데이터 리셋
    public void ResetPlayerStatus()
    {
        PlayerPrefs.SetInt("HP", 0);
        PlayerPrefs.SetInt("MP", 0);
        PlayerPrefs.SetInt("ATK", 0);
        PlayerPrefs.SetInt("MTK", 0);
        PlayerPrefs.SetInt("DEF", 0);
        PlayerPrefs.SetInt("DEX", 0);
    }

    // 플레이어 위치 리셋
    public void ResetPlayerLocation()
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
    public void ResetPlayerQuest()
    {
        PlayerPrefs.SetInt("MainQuest", 0);
        PlayerPrefs.SetInt("SubQuest1", 0);
        PlayerPrefs.SetInt("SubQuest2", 0);
        PlayerPrefs.SetInt("SubQuest3", 0);
    }

    // 플레이어 아이템(착용중, 소유) 리셋
    public void ResetPlayerEquipItem()
    {
        PlayerPrefs.SetInt("Weapon", 0);
        PlayerPrefs.SetInt("Weapon_C", 0);
        PlayerPrefs.SetInt("Clothing", 0);
        PlayerPrefs.SetInt("Clothing_C", 0);
        PlayerPrefs.SetInt("Shoes", 0);
        PlayerPrefs.SetInt("Shoes_C", 0);
    }

    // 플레이어 아이템(착용중, 소유) 리셋
    public void ResetPlayerInventoryItem()
    {
        for(int i = 1; i <= 50; i++)
        {
            PlayerPrefs.SetInt("Item" + i.ToString(), 0);
            PlayerPrefs.SetInt("Item_C" + i.ToString(), 0);
        }
    }

    
    IEnumerator LoadScene()
    {
        op = SceneManager.LoadSceneAsync("GameScene");
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (op.progress >= 0.9f)
            {
                isLoading = true;
                break;
            }
        }
    }

    IEnumerator LoadData()
    {

        if (PlayerPrefs.GetString("Map") == "" || PlayerPrefs.HasKey("Map") == false)
        {
            ResetPlayerStatus();
            ResetPlayerLocation();
            ResetPlayerQuest();
            ResetPlayerEquipItem();
            ResetPlayerInventoryItem();
        }

        // 로딩 애니메이션 시작
        // 데이터 로드
        // 

        yield return null;
    }

    IEnumerator PlayImage()
    {
        float timer = 0.0f;
        while (true)
        {
            if (LogoImage.activeSelf)
            {
                timer += Time.deltaTime;

                if (timer >= 3.0f)
                {
                    LogoImage.SetActive(false);
                    LicenseImage.SetActive(true);
                    timer = 0.0f;
                }

                yield return null;
            }

            if (LicenseImage.activeSelf)
            {
                timer += Time.deltaTime;

                if (timer >= 3.0f)
                {
                    LicenseImage.SetActive(false);
                    LoadingImage.SetActive(true);
                    spriteImage = LoadingImage.transform.Find("Image").GetComponent<SpriteImage>();
                    spriteImage.AddImages("Image/Loading");
                    spriteImage.speed = 0.04f;
                    spriteImage.isLoop = false;
                    spriteImage.Play();
                    timer = 0.0f;
                }
                yield return null;
            }

            if (LoadingImage.activeSelf)
            {
                timer += Time.deltaTime;

                if (timer > spriteImage.GetTotalPlayTime() + 1)
                {
                    if(isLoading == true)
                    {
                        LoadingImage.SetActive(false);
                        MainPanel.SetActive(true);
                        this.transform.parent.gameObject.SetActive(false);
                        timer = 0.0f;
                        break;
                    }
                }

                yield return null;
            }
        }
        yield return null;
    }

    

}

