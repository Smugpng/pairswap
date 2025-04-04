using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform player;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 2);
    }
}
