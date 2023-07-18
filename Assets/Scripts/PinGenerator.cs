using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    public Button sender;

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
        int.TryParse(rowInput.text, out var rows);
        int.TryParse(colInput.text, out var cols);

        // Generate pins; row first, col second => pins[row][col], i = row*cols + col
        for (var col = 0; col < cols; col++)
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

    //=== For JSON ===//
    [Serializable]
    public class PortJson
    {
        // JSON: {"i":1,"c":"motor","d":[40,30,20,10,40,30,20,10,40,30,20,10,40,30,20,10]}

        // i: [1, ..., n]
        // c: "motor"
        // d: [0, 1, 2, ..., 15, 16]
        public int i;
        public string c = "motor";
        public int[] d;
    }

    // Send JSON string manually USING debug button
    public void Debug()
    {
        var i = 0;
        foreach (Transform child in pinParent)
        {
            var pinComponent = child.GetComponent<Pin>();
            if (pinComponent != null)
            {
                var jsonObj = new PortJson
                {
                    i = i + 1,
                    d = pinComponent.GetHeight()
                };
                var json = JsonUtility.ToJson(jsonObj);
                print(json);
                // send to hardware
                sender.gameObject.GetComponent<CommunicateP>().SendData(json);
                // delay for 50ms to drive motors simultaneously
                Thread.Sleep(50);
            }

            i++;
        }
    }
}
