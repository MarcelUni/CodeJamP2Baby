using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int _playerHP = 3;
    public TextMeshProUGUI HP_Display;
    public GameObject hearts;

    //Using a get set method to control the player's HP but it can't go below 0 or exceed 3
    public int PlayerHP
    {
        get
        {
            return _playerHP;
        }
        set
        {
            if (value < 0)
            {
                _playerHP = 0;
                Debug.Log("Player HP can't go below 0");
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

    private void Update()
    {
        HP_Display.text = "HP: " + _playerHP;
    }

    //method for adding HP
    public void AddHP() 
    {
        PlayerHP++;
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
}
