using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class Pin : MonoBehaviour
{
    // Once created, immediately render 4*4 planes, and hold their heights with initial 0
    private Tuple<Transform, int>[] Pins;
    public List<int> SelectedPins;

    // Start is called before the first frame update
    void Start()
    {
        var i = 0;
        Pins = new Tuple<Transform, int>[16];
        SelectedPins = new List<int>();
        foreach (Transform child in transform)
        {
            Pins[i] = new Tuple<Transform, int>(child, 0);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 16; i++)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) &&
                hit.collider.gameObject == Pins[i].Item1.gameObject)
            {
                ChangeColor(i);
            }
        }
    }

    // Update selected heights (invoked by ScrollBar)
    public void SetHeight(int height)
    {
        foreach (var i in SelectedPins)
        {
            Pins[i] = new Tuple<Transform, int>(Pins[i].Item1, height);
        }
    }

    public string GetHeight()
    {
        string str = "{";
        for (int i = 0; i < 16; i++)
        {
            str += (SelectedPins.Contains(i) ? "*" : " ") + Pins[i].Item2 + ",";
        }

        return str + "}";
    }

    // Change color [single pin]
    private void ChangeColor(int i)
    {
        var renderer = Pins[i].Item1.GetComponent<MeshRenderer>();
        var materials = new List<Material>();
        renderer.GetMaterials(materials);

        Assert.AreEqual(materials.Count, 1);
        if (materials[0].color == Color.black)
        {
            materials[0].color = Color.cyan;
            SelectedPins.Add(i);
        }
        else
        {
            Assert.IsTrue(materials[0].color == Color.cyan);
            materials[0].color = Color.black;
            SelectedPins.Remove(i);
        }

        renderer.SetMaterials(materials);
    }
}
