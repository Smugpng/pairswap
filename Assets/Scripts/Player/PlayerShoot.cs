using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private bool isCharging = false;
    float timer;
    [SerializeField] private UnityEngine.UI.Image chargeUI;

    [Header("BulletStuff")]
    [SerializeField] GameObject bulletPrefab, bullet2Prefab, explosion;
    [SerializeField] Transform spawnPos;
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed())
        {
            isCharging = true;
        }
        else if (context.action.WasReleasedThisFrame())
        {
            isCharging = false;
            Shoot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Could make these only be called when input occurs, rather than constantly checking.
        ChargeShot();
        UpdateUI();
    }

    // Can update UI only when charge shot is called, because it should only update when something occurs with the charge shot.
    private void UpdateUI()
    {
       chargeUI.fillAmount = timer;
    }

    // Call this only when input occurs, not every frame.
    private void ChargeShot()
    {
        if (isCharging)
        {
            timer += Time.deltaTime / 3;
            Debug.Log(timer);
        }
        else if (!isCharging)
        {
            timer = 0;
        }
    }

    // Rather than instantiating a bullet each time shooting occurs, use an object pool to reduce garbage collection.
    private void Shoot()
    {
        if (timer < .5)
        {
            GameObject shot = Instantiate(bulletPrefab, spawnPos.position, transform.rotation);
            Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            float speed = (7 + (timer * 2));
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }
        else if( timer < 1)
        {
            GameObject shot = Instantiate(bullet2Prefab, spawnPos.position, transform.rotation);
            Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            float speed = (9 + (timer * 2));
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }
        else if (timer > 1)
        {
            GameObject explosionWave = Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
