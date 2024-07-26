using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector2 turn;
    [SerializeField] Vector2 clampAngle = new Vector2(-3, 15);

    private void Start()
    {
    }

    private void Update()
    {
        //turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");

        //turn.x = Mathf.Clamp(turn.x, clampAngle.x, clampAngle.y);
        turn.y = Mathf.Clamp(turn.y, clampAngle.x, clampAngle.y);

        this.transform.localRotation = Quaternion.Euler(turn.y, 0, 0);

    }
}
