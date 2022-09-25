using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    /*[HideInInspector]*/ public Vector2 moveVec;

    private PlayerControls playerControls;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Default.Move.performed += ctx => ReturnMoveVector(ctx.ReadValue<Vector2>());
        playerControls.Default.Move.canceled += ctx => ReturnMoveVector(Vector2.zero);
    }

    private void ReturnMoveVector(Vector2 moveVector)
    {
        moveVec = moveVector;
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
