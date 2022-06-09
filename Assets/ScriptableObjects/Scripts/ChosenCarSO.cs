using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rename Me", menuName = "ScriptableObjects/ChosenCar", order = 2)]
public class ChosenCarSO : ScriptableObject
{
    public CarSO currentCar;
}
