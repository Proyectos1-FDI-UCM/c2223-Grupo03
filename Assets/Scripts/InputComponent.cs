using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    MovementComponent _movementComponent;
    void Start()
    {
        _movementComponent = GetComponent<MovementComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        _movementComponent.horizontalAxis = Input.GetAxis("Horizontal");
        _movementComponent.verticalAxis = Input.GetAxis("Vertical");
    }
}
