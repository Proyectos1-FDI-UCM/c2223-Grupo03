using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que mueve la cámara de forma suave siguiendo al jugador
// para cambiar la velocidad de seguimiento baja el valor de smoothspeed
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _smoothSpeed;
    void Update()
    {
        Vector2 desiredPosition = _player.position;
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
