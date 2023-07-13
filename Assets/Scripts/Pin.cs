using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Pin : MonoBehaviour
{
    // Once created, immediately render 4*4 planes, and hold their heights with initial 0
    public Tuple<Transform, int>[] pins;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        pins = new Tuple<Transform, int>[16];
        foreach (Transform child in transform)
        {
            pins[i] = new Tuple<Transform, int>(child, 0);
            i++;
        }

        foreach (var pin in pins)
        {
            Debug.Log(pin.Item1 + " === " + pin.Item2);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

}
