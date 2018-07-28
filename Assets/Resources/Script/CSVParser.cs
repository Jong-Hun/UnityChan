using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CsvParser : MonoBehaviour
{

    private static CsvParser instance = null;
    public static CsvParser Instance()
    {

        if (instance == null)
        {
            instance = new CsvParser();
        }

        return instance;
    }

    protected string[] data;
    protected string[] stringList;
    private string text;

    private StringReader reader;
    private string strLine;
    protected int lineCount;

    void Awake()
    {
        instance = this;
    }

    public void ReadCsvFile(TextAsset csvFile, out string[] _stringList, out int _lineCount)
    {
        // 문자 구분을 위한 변수 선언
        text = csvFile.text;
        stringList = text.Split('\n');         // 한 줄씩 읽어온다.

        // 라인 수 카운트를 위한 변수 선언
        reader = new StringReader(csvFile.text);
        strLine = reader.ReadLine();

        while (strLine != null)
        {
            strLine = reader.ReadLine();
            lineCount++;
        }

        _stringList = stringList;
        _lineCount = lineCount;

       
        // // 최상단은 컬럼명이므로 카운트는 1부터 시작
        // for (int i = 1; i < lineCount; i++)
        // {
        //     data = stringList[i].Split(',');
        //     for (int j = 0; j < data.Length; j++)
        //     {
        //         Debug.Log("[Line" + i + "] : data[" + j + "] = " + data[j]);
        //     }
        // 
        // }
    }
}