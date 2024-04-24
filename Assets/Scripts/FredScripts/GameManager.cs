using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton pattern - help from ChatGPT as well

    public static GameManager instance;
    public int _playerHP = 3;
    public GameObject hearts;
    public GameObject _player;

    //Using a get set method to control the player's HP but it can't go below 0 or exceed 3
    public int PlayerHP
    {
        get
        {
            return _playerHP;
        }
        set
        {
            if (value <= 0)
            {
                _playerHP = 0;
                heartDisplay(_playerHP);
                GameOver();
                Debug.Log("Game Over");
            }
            else if (value > 3)
            {
                _playerHP = 3;
                Debug.Log("Player HP can't exceed 3");
            }
            else
            {
                _playerHP = value;
                heartDisplay(_playerHP);
                
                /*
                if (_playerHP == 1)
                {
                    //Uncomment når AudioManager er korrekt navngivet
                    UnMuteSiren();
                }
                */
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        PlayerHP = 3;

        if (_player == null)
        {
            _player = GameObject.Find("Ambulance");
        }

        if (_player.GetComponent<Controller>().enabled == false)
        {
            _player.GetComponent<Controller>().enabled = true;
            Debug.Log("Ambulance Controller Enabled");
        }
    }

    private void Update()
    {
        GameWinCheck();
    }

    //method for adjusting HP
    public void RemoveHP(int num)
    {
        PlayerHP -= num;
    }

    //method for removing HP
    public void RemoveHP()
    {
        PlayerHP--;
    }

    //method for displaying the hearts according to the HP
    public void heartDisplay(int _playerHP)
    {
        // Iterate through each heart
        for (int i = 0; i < hearts.transform.childCount; i++)
        {
            // Activate the heart if its index is less than the player's HP
            hearts.transform.GetChild(i).gameObject.SetActive(i < _playerHP);
        }
    }

    public void GameOver()
    {
        //Game over screen
        Debug.Log("Game Over");

        _player.GetComponent<Controller>().enabled = false;
        Debug.Log("Ambulance Controller Disabled");

        //Uncomment når spil sættes op, og GameOver Screen er klar
        
        if (GameObject.Find("GameOver") == null)
        {
            Debug.Log("Game Over Screen not found");
        }
        else
        {
            GameObject.Find("GameOver").SetActive(true);
            Debug.Log("Found GameOver Screen :)");
        }   
    }

    public void GameWinCheck()
    {
        
        if (_player.transform.position.z >= 10)
        {
            Debug.Log("Game Win");
            if (SceneManager.GetSceneByName("Win Screen").IsValid())
            {
                ScenesManager.instance.LoadScene("Win Screen");
            }
            else
            {
                Debug.Log("Win scene not found");
            }
        }

    }
    public void ResetGame()
    {
        ScenesManager.instance.LoadScene("Main Game");
    }

}
