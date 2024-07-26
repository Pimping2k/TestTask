using System.Linq;
using TMPro;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    //[SerializeField] private GameObject bullet;
    //[SerializeField] private GameObject gunMuzzle;
    [SerializeField] private float damage = 15;
    [SerializeField] private float range = 15;
    [SerializeField] private float force = 4;
    [SerializeField] private float nextFire = 0f;
    [SerializeField] private float fireRate = 10f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private Camera cam;
    [SerializeField] private ParticleSystem gunShot;
    [SerializeField] private GunSlotController gunSlotController;
    [SerializeField] private int maxAmmo = 30;
    [SerializeField] private int currentAmmo;
    [SerializeField] private TextMeshProUGUI ammoText;

    RaycastHit hit;
    private void Start()
    {
        currentAmmo = 30;
        UpdateAmmoUI();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            if (CanShoot())
            {
                Shoot();
            }
            else
            {
                ammoText.text = "RELOADING DONE";
                Reload();
                UpdateAmmoUI();
            }
        }
    }

    bool CanShoot()
    {
        return currentAmmo > 0;
    }

    void UpdateAmmoUI()
    {
        ammoText.text = "Ammo: " + currentAmmo + " / " + maxAmmo;
    }

    void Shoot()
    {
        UpdateAmmoUI();
        if (gunSlotController.IsAnyActive())
        {
            currentAmmo--;
            audioSource.PlayOneShot(shootClip);
            gunShot.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log("SHOOOOT!");

                if (hit.rigidbody != null)
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        hit.collider.GetComponent<EnemyBehaviour>().DecreaseHP(damage);
                    }
                }
            }
        }
    }

    void Reload()
    {
        Invoke(nameof(SetMaxAmmo), 3f);
    }

    private void SetMaxAmmo()
    {
        currentAmmo = maxAmmo;
    }
}
