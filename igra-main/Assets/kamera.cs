using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    void Update()
    {
        Vector3 position = transform.position;
        position.y = (player.position + offset).y;
        position.x = (player.position + offset).x;
        transform.position = position;
    }
}
