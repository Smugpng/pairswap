using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#region other player components
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(PlayerAudio))]
#endregion
public class PlayerMain : MonoBehaviour
{
    [SerializeField] float speed = 6; //The speed it takes for the player to look at the moouse
    private void FixedUpdate()
    {
        LookAtCursor();
    }
    private void LookAtCursor() //Turns player towards mouse cursor //Omar
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * speed);
    }
}
