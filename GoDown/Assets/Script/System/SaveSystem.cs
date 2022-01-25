using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class SaveSystem
{
    public static void Save(string saveName, object saveData)
    {
        Debug.Log("디버그 가능?"+ Application.persistentDataPath);
        // 폴더 있는지
        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves/" + saveName + ".save";

        //파일 있는지
        if (!File.Exists(path))
        {
            Debug.Log("디버그 가능@?");
            FileStream fs = File.Create(path);
            
        }

        string json = JsonUtility.ToJson(saveData);
        try
        {
            Byte[] data = Crypto.Encrypt(json);

            File.WriteAllBytes(path, data);
        }
        catch
        {

        }

    }

    public static object Load(string path)
    {
        path = Application.persistentDataPath + "/saves/" + path + ".save";

        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        // 파일이 존재하는지 체크
        if (!File.Exists(path))
        {
            AccountVO d = new AccountVO();
            Save(path, d);
        }

        try
        {
            Byte[] dataBack = File.ReadAllBytes(path);

            string json = Crypto.Decrypt(dataBack);

            object a = JsonUtility.FromJson<AccountVO>(json);

            return a;
        }
        catch
        {

        }

        return null;
        
    }    
}
