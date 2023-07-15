using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PinGenerator : MonoBehaviour
{
    public GameObject pinPrefab;
    public Transform pinParent;
    public TMP_InputField rowInput;
    public TMP_InputField colInput;

    public void GeneratePins()
    {
        // Clear existing pins
        foreach (Transform child in pinParent)
        {
            Destroy(child.gameObject);
        }

        // Parse input values
        int rows, cols;
        int.TryParse(rowInput.text, out rows);
        int.TryParse(colInput.text, out cols);

        // Generate pins
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // Instantiate pin object
                GameObject pin = Instantiate(pinPrefab, pinParent);
                // Set position based on row and column
                pin.transform.position = new Vector3(row * 4, col * 4, 0);
            }
        }
    }
}