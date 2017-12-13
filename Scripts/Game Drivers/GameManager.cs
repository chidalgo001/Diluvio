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

    public int coins;
    public bool options;

    private bool female, glasses, tophat;

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
        coins = 0;
        options = false;

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

            file.Close();

            //set the values into data
        }
    }

    public void ResetData()
    {
        female = glasses = tophat = false;
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
    public int score;
    public int coins;
}
