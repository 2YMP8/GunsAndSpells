using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;


    private void LateUpdate()
    {
        //FollowPlayer
        Vector3 newPosition = transform.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //rotateCamera
        transform.rotation = Quaternion.Euler(0f, player.position.y, 0f);



    }

}
