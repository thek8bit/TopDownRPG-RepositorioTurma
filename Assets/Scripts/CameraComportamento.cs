using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComportamento : MonoBehaviour
{
    public Transform BBB;
    public float margemX = 0.15f;
    public float margemY = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = new Vector3(0, 0, 0);

        //Verificar se está dentro das margens do eixo X
        float deltaX = BBB.position.x - transform.position.x;
        if (deltaX > margemX || deltaX < -margemX)
        {
            if (transform.position.x < BBB.position.x)
            {
                delta.x = deltaX - margemX;
            }
            else
            {
                delta.x = deltaX + margemX;
            }
        }

        //Verificar se está dentro das margens do eixo Y
        float deltaY = BBB.position.y - transform.position.y;
        if (deltaY > margemY || deltaY < -margemY)
        {
            if (transform.position.y < BBB.position.y)
            {
                delta.y = deltaY - margemY;
            }
            else
            {
                delta.y = deltaY + margemY;
            }
        }
        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
