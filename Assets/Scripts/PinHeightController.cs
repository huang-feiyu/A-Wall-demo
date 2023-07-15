using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PinHeightController : MonoBehaviour
{
    private const int MaxHeight = 150;
    public Scrollbar scrollbar;
    public TMP_Text heightText;
    public List<Pin> pins;

    private void Start()
    {
        scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    private void OnScrollbarValueChanged(float value)
    {
        int height = Mathf.RoundToInt(value * MaxHeight); // Adjust the multiplier to control the range of heights
        heightText.text = height.ToString();
        foreach (var pin in pins)
        {
            pin.SetHeight(height);
        }
    }
}
