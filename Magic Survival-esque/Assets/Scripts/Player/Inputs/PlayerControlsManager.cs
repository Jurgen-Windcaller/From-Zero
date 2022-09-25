using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsManager : MonoBehaviour
{
    [SerializeField] GameObject systemsManager;

    private InputManager inputManager;
    private Rigidbody2D rb;
    private Vector2 dir;

    private float curSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = systemsManager.GetComponent<InputManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void UpdateDirection()
    {
        dir = inputManager.moveVec;
    }
    
    private void Move()
    {
        rb.velocity = new Vector2(Mathf.Lerp(0, dir.x * curSpeed, 0.8f), Mathf.Lerp(0, dir.y * curSpeed, 0.8f));
    }
}
