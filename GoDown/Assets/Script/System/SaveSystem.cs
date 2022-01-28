using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class SaveSystem
{
    public static void Save(string saveName, object saveData)
    {        
        // 폴더 있는지
        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves/" + saveName + ".save";

        //파일 있는지
        if (!File.Exists(path))
        {
            using (FileStream fs = File.Create(path))
            {
                
            }
            
        }
        
        string json = JsonUtility.ToJson(saveData);

        try
        {
            Byte[] data = Crypto.Encrypt(json);
            File.WriteAllBytes(path, data);

            // 테스트용
            // File.WriteAllText(path, json);
        }
        catch
        {
            Debug.Log("계정 에러");
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
            // 초기화
            AccountVO accountVO = new AccountVO();
            Debug.Log("어카운트 브이오 생성");
            accountVO = new AccountVO();
            accountVO.multiplyGold = 1;
            accountVO.blockSpeed = 5;
            accountVO.blockSpeedLimit = 20;
            accountVO.blockAccel = 2;
            accountVO.playerSpeed = 5;
            accountVO.blockResistance = 0;
            Save("account", accountVO);            
        }

        try
        {
            Byte[] dataBack = File.ReadAllBytes(path);

            string json = Crypto.Decrypt(dataBack);

            // 테스트용
            // string json = File.ReadAllText(path);

            object a = JsonUtility.FromJson<AccountVO>(json);

            return a;
        }
        catch
        {
            Debug.Log("계정 에러");
        }

        return null;
        
    }    
}
