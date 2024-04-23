using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    // tutorial: https://www.youtube.com/watch?v=BLfNP4Sc_iA
    public float maxFuel = 100;
    public float _currentFuel;
    public float fuelDepletionRate = 1f;
    public float fuelDepletionAmount = 1f;

    public FuelManager fuelBar;
    public Slider slider;

    //a get set for the current fuel
    public float CurrentFuel
    {
        get
        {
            return _currentFuel;
        }
        set
        {
            if (value < 0)
            {
                _currentFuel = 0;
                Debug.Log("Fuel can't go below 0");
            }
            else if (value > maxFuel)
            {
                _currentFuel = maxFuel;
                Debug.Log("Fuel can't exceed 100");
            }
            else
            {
                _currentFuel = value;
                slider.value = _currentFuel;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentFuel = maxFuel;
        InvokeRepeating("DepleteFuel", 1.0f, fuelDepletionRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DepleteFuel()
    {
        CurrentFuel -= fuelDepletionAmount;

        //Inds�t game over her
       /*
        if (CurrentFuel <= 0)
        {
            GameOver();
        }
       */
    }

    public void AddFuel(int amount)
    {
        CurrentFuel += amount;
    }

}
