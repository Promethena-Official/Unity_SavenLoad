using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

//Class to save data
[System.Serializable]
public class SAVEDATA
{
    public List<string> Names;
    public List<string> Codes;
}
public class SaveNLoad : MonoBehaviour
{
  
    private SAVEDATA _savedata = new SAVEDATA();
    private string SAVE_FILE_DIRECTORY;
    private string SAVE_FILE_NAME = "SaveFile.txt";
    //Doesn't matter here
    private bool IsFirst;
    private ScrollManager scroll;
    private Manager _manager;

    private void Awake()
    {
        scroll = FindObjectOfType<ScrollManager>();
    }


    void Start()
    {
        LoadData();
    }
  
  
    public void SaveData()
    {
        _savedata.Names = scroll.subjectName;
        _savedata.Codes = scroll.Codes;
        //Change datas into json and paste them in txt file
        string json = JsonUtility.ToJson(_savedata);
        File.WriteAllText(SAVE_FILE_DIRECTORY + SAVE_FILE_NAME, json);
    }
  
    //LoadData
    public void LoadData()
    {
    //if File does not exsits, create save file and make a new file
        if (!File.Exists(SAVE_FILE_DIRECTORY + SAVE_FILE_NAME))
        {
            SAVE_FILE_DIRECTORY = Application.dataPath + "/Saves/";
            Directory.CreateDirectory(SAVE_FILE_DIRECTORY);
            Debug.Log("asdasd");

        }
        else
        {
            string loadjson = File.ReadAllText(SAVE_FILE_DIRECTORY + SAVE_FILE_NAME);
            _savedata = JsonUtility.FromJson<SAVEDATA>(loadjson);
            scroll.MainSaveButton();
            _manager.AwakeAll();
            Debug.Log("Ehll");
        }
    }
}
