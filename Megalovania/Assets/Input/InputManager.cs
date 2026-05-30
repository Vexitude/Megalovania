using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public bool menuInput { get; private set; }

    private PlayerInput playerInput;

    private InputAction menuAction;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        playerInput = GetComponent<PlayerInput>();
        menuAction = playerInput.actions["Menu"];

    }

    private void Update()
    {
        menuInput = menuAction.WasPerformedThisFrame();
    }
}
