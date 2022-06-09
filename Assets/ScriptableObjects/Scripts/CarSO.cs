using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rename Me", menuName = "ScriptableObjects/Car", order = 1)]
public class CarSO : ScriptableObject
{
    public string carName;
    public Sprite image;
    public float speed;
    public float handling;
    public GameObject carModel;
}
