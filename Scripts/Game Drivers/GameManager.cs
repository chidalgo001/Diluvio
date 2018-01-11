using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager control;// this is a static reference, it will be accessible from everywhere.

    private int playerId;
    public int score;

    public int coins, levelID;
    public bool options;
    public bool lvl2, lvl3, lvl4, lvl5;//NOTE: CHANGE THIS TO PRIVATE WHEN DONE

    public bool female, glasses, tophat;

    public bool inUse;//This is to track if  powerUp is in use or not

    // Use this for initialization

    private void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);//this lets me keep this G.O. in all scenes
            control = this;
        }else if(control != this)
        {
            Destroy(gameObject);
        }
    }
    void Start () {
                
        female = glasses = tophat = false;
        lvl2 = lvl3 = lvl4 = lvl5 = false;
        coins = 0;
        options = false;
        levelID = 0;
        //Debug.Log(Application.persistentDataPath); //This is to get the path of the datafile saved
	}
	
	// Update is called once per frame
	void Update () {
           
		
	}

    public void SetHighScore( int newScore)
    {
        if(newScore > score)
        {
            score = newScore;
        }
    }

    public void SetPlayerID(int Id)
    {
        playerId = Id;
    }

    public void SetLvlID(int Id)
    {
        levelID = Id;
    }

    public int GetPlayerID()
    {
        return playerId;
    }

    public void UnlockCharacter(int Id)
    {
        if(Id == 2)
        {
            female = true;
        }else if(Id == 3)
        {
            glasses = true;
        }else if(Id == 4)
        {
            tophat = true;
        }

    }

    public bool IsUnlocked(int Id)
    {
        if (Id == 2)
        {
            return female;
        }
        else if (Id == 3)
        {
            return glasses;
        }
        else if (Id == 4)
        {
            return tophat;
        }

        return true;
    }

    public void UnlockLevel(int levelID)
    {
        if (levelID == 2)
        {
            lvl2 = true;
        }
        else if (levelID == 3)
        {
            lvl3 = true;
        }
        else if (levelID == 4)
        {
            lvl4 = true;
        }
        else if (levelID == 5)
        {
            lvl5 = true;
        }
    }

    public bool IsLvlUnlocked(int levelID)
    {
        if (levelID == 2)
        {
            return lvl2;
        }
        else if (levelID == 3)
        {
            return lvl3;
        }
        else if (levelID == 4)
        {
            return lvl4;
        }
        else if (levelID == 5)
        {
            return lvl5;
        }

        return true;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.female = female;
        data.glasses = glasses;
        data.tophat = tophat;
        data.score = score;
        data.coins = coins;

        data.lvl2 = lvl2;
        data.lvl3 = lvl3;
        data.lvl4 = lvl4;
        data.lvl5 = lvl5;
        //save data into "data"

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if ( File.Exists(Application.persistentDataPath + "/playerInfo.dat") )
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            
            female = data.female;
            glasses = data.glasses;
            tophat = data.tophat;
            score = data.score;
            coins = data.coins;

            lvl2 = data.lvl2;
            lvl3 = data.lvl3;
            lvl4 = data.lvl4;
            lvl5 = data.lvl5;

            file.Close();

            //set the values into data
        }
    }

    public void ResetData()
    {
        female = glasses = tophat = false;
        lvl2 = lvl3 = lvl4 = lvl5 = false;
        score = 0;
        coins = 0;
        Save();
    }
}

[Serializable]
class PlayerData
{
    public bool female;
    public bool glasses;
    public bool tophat;
    public bool lvl2, lvl3, lvl4, lvl5;
    public int score;
    public int coins;
}
