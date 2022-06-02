using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Speedometer : MonoBehaviour
{
    private const float MAX_SPEED_ANGLE = -44;
    private const float ZERO_SPEED_ANGLE = 220;

    private Transform needleTransform;
    private Transform speedLabelTemplateTransform;

    private float speedMax;
    public float speed;
    public TMP_Text speedText;

    public AutoMovement player;

    private void Awake()
    {
        needleTransform = transform.Find("needle");
        speedLabelTemplateTransform = transform.Find("SpeedLableTemplate");
        speedLabelTemplateTransform.gameObject.SetActive(false);

        speed = 0f;
        speedMax = 200f;

        CreateSpeedLabels();
    }

    private void Update()
    {
        speed = player.pSpeed;
        speedText.text = speed.ToString("f0");
        
        // Keeps Speed from going above the maximum
        if (speed > speedMax)
        {
            speed = speedMax;

        }
        // Moves the needle
        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }

    // Automatically creates labels around the speedometer
    // Currently there is an error where the last number does not get printed
    private void CreateSpeedLabels()
    {
        int labelAmount = 10;
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        for (int i = 0; i < labelAmount; i++)
        {
            Transform speedLabelTransform = Instantiate(speedLabelTemplateTransform, transform);

            float labelSpeedNormalized = (float)i / labelAmount;
            float labelSpeedAngle = ZERO_SPEED_ANGLE - labelSpeedNormalized * totalAngleSize;
            speedLabelTransform.eulerAngles = new Vector3(0, 0, labelSpeedAngle);

            speedLabelTransform.Find("speedTextTMP").GetComponent<TMP_Text>().text = Mathf.RoundToInt(labelSpeedNormalized * speedMax).ToString();
            speedLabelTransform.Find("speedTextTMP").eulerAngles = Vector3.zero;
            speedLabelTransform.gameObject.SetActive(true);
        }

        // Make it so the needle is rendered on top
        // Currently doesn't work as intended
        needleTransform.SetAsLastSibling();
    }

    private float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        // Value between 0 - 1 
        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
}
