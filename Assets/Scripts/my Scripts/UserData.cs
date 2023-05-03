using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserData : MonoBehaviour
{
    public static UserData Instance;
    public string userName;
    public string highestName;
    public int highestPt = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class HighestData
    {
        public string uName;
        public int hPt;
    }

    public void Save()
    {
        HighestData uData = new HighestData();
        uData.uName = highestName;
        uData.hPt = highestPt;
        string sData = JsonUtility.ToJson(uData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", sData);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            HighestData uData = JsonUtility.FromJson<HighestData>(jsonData);

            highestName = uData.uName;
            highestPt = uData.hPt;
        }
    }
}
