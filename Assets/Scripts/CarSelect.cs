using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CarSelect : MonoBehaviour
{
    public List<CarSO> cars = new List<CarSO>();
    public int currentCarIndex;
    public int playerOneSelect;
    public int playerTwoSelect;

    [Header("References")]
    public Image carImage;
    public TMP_Text carName;
    public TMP_Text carSpeed;
    public TMP_Text carHandling;
    public Button confirm;
    public TextMeshProUGUI buttonText;

    [Header("Sliders")]
    //public float currentSpeed; // Created with the intention that the sliders will visably go up and down as the player switches cars on screen
    //public float currentHandling;
    public Slider carSpeedSlider;
    public Slider carHandlingSlider;

    private bool AlreadyClicked = false;


    private void Start()
    {
        SetStats(cars[currentCarIndex]);

        //confirm.onClick.AddListener(PlayerOneConfirm);
        //confirm.onClick.AddListener(PlayerTwoConfirm);
    }

    public void SetStats(CarSO _currentCar)
    {
        carImage.sprite = _currentCar.image;
        carName.text = _currentCar.carName;
        carSpeed.text = "Speed: " + _currentCar.speed;
        carHandling.text = "Handling: " + _currentCar.handling;
        
        carSpeedSlider.value = _currentCar.speed;
        carHandlingSlider.value = _currentCar.handling;
    }

    public void OnSelectionLeft()
    {
        currentCarIndex--;
        if (currentCarIndex < 0)
        {
            currentCarIndex = cars.Count - 1;
        }
        SetStats(cars[currentCarIndex]);
    }

    public void OnSelectionRight()
    {
        currentCarIndex++;
        if (currentCarIndex > cars.Count -1)
        {
            currentCarIndex = 0;
        }
        SetStats(cars[currentCarIndex]);
    }

    //public void PlayerOneConfirm()
    //{
    //    //playerOneSelect = currentCarIndex;
    //    Debug.Log("Player 1");
    //}

    //public void PlayerTwoConfirm()
    //{
    //    //playerTwoSelect = currentCarIndex;
    //    Debug.Log("Player 2");

    //    // for when we have an additional scene
    //    //SceneManager.LoadScene(0); // Right now, it calls itself
    //}

    public void Click()
    {
        // Has the user already clicked?
        if (AlreadyClicked)
        {
            // Yes
            // Player 2 selected
            playerTwoSelect = currentCarIndex;

            // for when we have an additional scene
            //    //SceneManager.LoadScene(0); // Right now, it calls itself
        }
        else
        {
            // No -- First Click
            playerOneSelect = currentCarIndex;
            buttonText.text = "Start";
            
            AlreadyClicked = true;
        }
    }
}
