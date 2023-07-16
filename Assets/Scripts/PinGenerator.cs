using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PinGenerator : MonoBehaviour
{
    public GameObject pinPrefab;
    public GameObject wallPrefab;
    public Transform pinParent;
    public Transform wallParent;
    public TMP_InputField rowInput;
    public TMP_InputField colInput;
    public HeightController heightController;

    public new Transform camera;

    public void GeneratePins()
    {
        var pos = new Vector3((float)3.41, (float)0.52, (float)-27.399999);
        var rot = new Quaternion();
        camera.position = pos;
        camera.rotation = rot;

        // Clear existing pins
        foreach (Transform child in pinParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in wallParent)
        {
            Destroy(child.gameObject);
        }

        pinParent.DetachChildren();
        wallParent.DetachChildren();

        Assert.IsTrue(pinParent.childCount == 0 && wallParent.childCount == 0);

        // Parse input values
        int rows, cols;
        int.TryParse(rowInput.text, out rows);
        int.TryParse(colInput.text, out cols);

        // Generate pins; row first, col second => pins[row][col], i = row*cols + col
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                // Instantiate pin object
                var pin = Instantiate(pinPrefab, pinParent);
                // Set position based on row and column
                pin.transform.position = new Vector3(-15 + row * 4, 10 - col * 4, 0);

                // Wall's turn
                var wall = Instantiate(wallPrefab, wallParent);
                // Set position based on row and column
                wall.transform.position = new Vector3(row * 4, -col * 4, 0);
            }
        }

        // Initialize controller with pins
        heightController.pins = new List<Pin>();
        var i = 0;
        foreach (Transform child in pinParent)
        {
            var pinComponent = child.GetComponent<Pin>();
            if (pinComponent != null)
            {
                heightController.pins.Add(pinComponent);
            }

            i++;
        }

        // Initialize controller with walls
        heightController.walls = new List<Wall>();
        i = 0;
        foreach (Transform child in wallParent)
        {
            var wallComponent = child.GetComponent<Wall>();
            if (wallComponent != null)
            {
                heightController.walls.Add(wallComponent);
            }

            i++;
        }
    }

    public void Debug()
    {
        int i = 0;
        foreach (Transform child in pinParent)
        {
            var pinComponent = child.GetComponent<Pin>();
            if (pinComponent != null)
            {
                print("Pin[" + i + "]: " + pinComponent.GetHeight());
            }

            i++;
        }
    }
}
