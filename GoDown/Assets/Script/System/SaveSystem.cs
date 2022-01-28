using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class SaveSystem
{
    public static void Save(string saveName, object saveData)
    {        
        // ���� �ִ���
        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves/" + saveName + ".save";

        //���� �ִ���
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

            // �׽�Ʈ��
            // File.WriteAllText(path, json);
        }
        catch
        {
            Debug.Log("���� ����");
        }

    }

    public static object Load(string path)
    {
        path = Application.persistentDataPath + "/saves/" + path + ".save";

        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        // ������ �����ϴ��� üũ
        if (!File.Exists(path))
        {
            // �ʱ�ȭ
            AccountVO accountVO = new AccountVO();
            Debug.Log("��ī��Ʈ ���̿� ����");
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

            // �׽�Ʈ��
            // string json = File.ReadAllText(path);

            object a = JsonUtility.FromJson<AccountVO>(json);

            return a;
        }
        catch
        {
            Debug.Log("���� ����");
        }

        return null;
        
    }    
}
