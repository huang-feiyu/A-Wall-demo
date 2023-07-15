using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class HeightController : MonoBehaviour
{
    private const int MaxHeight = 150;
    public Scrollbar scrollbar;
    public TMP_Text heightText;
    public List<Pin> pins;
    public List<Wall> walls;

    private void Start()
    {
        scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    private void OnScrollbarValueChanged(float value)
    {
        int height = Mathf.RoundToInt(value * MaxHeight); // Adjust the multiplier to control the range of heights
        heightText.text = height.ToString();
        Assert.AreEqual(pins.Count, walls.Count);
        for (int i = 0; i < pins.Count; i++)
        {
            walls[i].SelectedCubes = pins[i].SelectedPins;
            pins[i].SetHeight(height);
            walls[i].SetHeight(height);
        }
    }
}
