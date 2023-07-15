using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Wall : MonoBehaviour
{
    // TODO: measurement
    private static readonly Vector3 Init = new Vector3(1, 1, 1);
    private const int Scale = 1;

    // Once created, immediately render 4*4 planes, and hold their heights with initial 0
    private Transform[] Cubes;
    public List<int> SelectedCubes;
    public float initZ;

    // Start is called before the first frame update
    void Start()
    {
        var i = 0;
        Cubes = new Transform[16];
        SelectedCubes = new List<int>();
        foreach (Transform child in transform)
        {
            initZ = child.position.z;

            child.localScale = Init;
            Cubes[i] = child;
            i++;
        }
    }

    // Update selected heights (invoked by ScrollBar)
    public void SetHeight(int height)
    {
        foreach (var i in SelectedCubes)
        {
            Cubes[i].localScale = Init + new Vector3(0, 0, height * Scale);
            Cubes[i].position = new Vector3(Cubes[i].position.x, Cubes[i].position.y,
                initZ - (float)height * Scale / 2);
        }
    }

    // Change color [single pin]
    public void ChangeColor(int i)
    {
        var renderer = Cubes[i].GetComponent<MeshRenderer>();
        var materials = new List<Material>();
        renderer.GetMaterials(materials);

        Assert.AreEqual(materials.Count, 1);
        if (materials[0].color == Color.black)
        {
            materials[0].color = Color.cyan;
            SelectedCubes.Add(i);
        }
        else
        {
            Assert.IsTrue(materials[0].color == Color.cyan);
            materials[0].color = Color.black;
            SelectedCubes.Remove(i);
        }

        renderer.SetMaterials(materials);
    }
}
