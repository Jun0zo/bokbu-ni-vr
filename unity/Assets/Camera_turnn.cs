using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_turnn : MonoBehaviour
{
    public GameObject stage;

    private float xRotateMove, yRotateMove;

    public float rotateSpeed = 500.0f;

    public bool isTurnning = true;

    void Update()
    {
        if (isTurnning)
        {
            xRotateMove = Time.deltaTime * rotateSpeed;

            Vector3 stagePosition = stage.transform.position;

            transform.RotateAround(stagePosition, Vector3.up, xRotateMove);

            transform.LookAt(stagePosition);
        }        
    }

    public void StopTurnning()
    {
        isTurnning = false;
    }

    public void StartTurnning()
    {
        isTurnning = true;
    }
}
