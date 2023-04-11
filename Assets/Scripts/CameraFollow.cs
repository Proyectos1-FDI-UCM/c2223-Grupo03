using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que mueve la cámara de forma suave siguiendo al jugador
// para cambiar la velocidad de seguimiento baja el valor de smoothspeed
public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public float _smoothSpeed;

    private void Start()
    {
        target = GameManager.Player.transform;
    }
    public void ChangeCameraPosition(Transform newTarget, float smoothspeed)
    {
        _smoothSpeed = smoothspeed;
        target = newTarget;
    }
    public void RestoreSmoothness()
    {
        _smoothSpeed = 2f;
    }
    public void ChangeCameraPosition(Transform newTarget)
    {
        target = newTarget;
    }
    public void RestartPlayerFocus()
    {
        target = GameManager.Player.transform;
    }
    void Update()
    {
        Vector2 desiredPosition = target.transform.position;
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
