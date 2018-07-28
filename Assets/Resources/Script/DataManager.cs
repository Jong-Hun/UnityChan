using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : CsvParser {
    
    public TextAsset[] csvFiles;

    public CharacterData characterData = new CharacterData();

    private void Awake()
    {
        csvFiles = Resources.LoadAll<TextAsset>("CSV");
        LoadData();
    }

    public void LoadData()
    {

        int csvFileCount = csvFiles.Length;

        if (csvFileCount == 0)
        {
            Debug.Log("csvFile이 존재하지 않습니다.");
        }

        for (int i = 0; i < csvFiles.Length; i++)
        {
            ReadCsvFile(csvFiles[i], out stringList, out lineCount);
            LoadData(csvFiles[i].name);
        }

        
    }

    public void LoadData(string csvFileName)
    {
        switch (csvFileName)
        {
            case "CharacterInfo":                                   // 캐릭터 데이터 정보 ( 몬스터 등등 )
                LoadCharacterData();
                break;
            default:
                break;
        }
    }
    
    public void LoadCharacterData()
    {
        // 최상단은 컬럼명이므로 카운트는 1부터 시작
        for (int i = 1; i < lineCount; i++)
        {
            data = stringList[i].Split(',');

            CharacterData.tempData tempData = new CharacterData.tempData();
            tempData.index = int.Parse(data[0]);
            tempData.name_kr = data[1];
            tempData.name_er = data[2];

            characterData.dataList.Add(tempData);
            characterData.dicData.Add(data[0], tempData);
        }

        // 나중에 수정
        Debug.Log("characterData.dataList = " + characterData.dataList[0].index + characterData.dataList[0].name_kr);
        Debug.Log("characterData.dicData = " + characterData.dicData["1"].name_kr);

    }
}

// 나중에 한곳에 따로 모아놓거나 따로 Script로 뺄것
public class CharacterData
{
    public List<tempData> dataList = new List<tempData>();
    public Dictionary<string, tempData> dicData = new Dictionary<string, tempData>();

    public struct tempData
    {
        public int index;
        public string name_kr;
        public string name_er;
    }
}
