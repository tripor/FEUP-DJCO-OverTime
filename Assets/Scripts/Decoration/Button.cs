﻿using UnityEngine;
using UnityEngine.Events;

public class Button : Interactable {
    public GameObject sphere;
    MeshRenderer sphereMesh;
    public Color buttonColor;
    
    public UnityEvent PressedButton;
    public UnityEvent UnpressedButton;

    public Material materialOn;
    public Material materialOff;
    public GameObject cylinder;

    MeshRenderer mesh;
    Color offColor;
    public Color onColor;

    private bool isPressed;

    // Update is called once per frame

    void Start() {
        isPressed = false;
        
        mesh = cylinder.GetComponent<MeshRenderer>();
        offColor = mesh.material.color;

        sphereMesh = sphere.GetComponent<MeshRenderer>();
        sphereMesh.material.color = buttonColor;
    }

   override public void Interact() {
        if (isPressed) {
            UnpressedButton.Invoke();
            SetCylinderColor(offColor);
        } else {
            PressedButton.Invoke();
            SetCylinderColor(onColor);
        }

        isPressed = !isPressed;
    }

    void SetCylinderColor(Color color) {
        Material material = mesh.material;
        material.color = color;
        mesh.material = material;
    }
}
