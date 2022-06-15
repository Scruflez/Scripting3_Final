using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CarSelect : MonoBehaviour
{
    [Header ("Scripting Objects")]
    public List<CarSO> cars = new List<CarSO>();
    public int currentCarIndex;
    public int playerOneSelect;
    public ChosenCarSO playerOneCar;
    public int playerTwoSelect;
    public ChosenCarSO playerTwoCar;

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

    private bool alreadyClicked = false;
    private bool bothSelected = false;


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


    public void Click()
    {
        // Has the user already clicked?
        if (alreadyClicked)
        {
            // Yes
            // Player 2 selected
            playerTwoSelect = currentCarIndex;
            playerTwoCar.currentCar = cars[currentCarIndex];

            buttonText.text = "Start";
            bothSelected = true;
        }
        else
        {
            // No -- First Click
            playerOneSelect = currentCarIndex;
            playerOneCar.currentCar = cars[currentCarIndex];
            buttonText.text = "Confirm Player 2";
            
            alreadyClicked = true;
        }

        if (bothSelected)
        {
            SceneManager.LoadScene(2);
        }

    }
}
