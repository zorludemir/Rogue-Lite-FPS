using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static PlayerShoot Instance;
    [SerializeField] private Camera playerCamera;
    public Weapon weapon;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float nextTimeToFire = 0f;
    public int currentAmmo;
    private bool isReloading = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        playerCamera = transform.GetChild(0).GetComponent<Camera>();
        SetupWeapon();
    }

    private void SetupWeapon()
    {
        GameObject weaponObj = Instantiate(weapon.weaponModel, playerCamera.transform);
        weaponObj.transform.localPosition = new Vector3(-.03f, -.41f, .9f);
        firePoint = weaponObj.transform.Find("shootPoint");

        currentAmmo = Player.Instance.CalculateAmmoCapacity();
        UIManager.Instance.UpdateAmmoIndicator(false);
    }

    private void Update()
    {
        if (isReloading)
            return;
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / Player.Instance.CalculateFireRate();
            Shoot();
        }
    }

    private void Shoot()
    {
        if (currentAmmo <= 0)
            return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().Launch(playerCamera.transform.forward, Player.Instance.CalculateBulletSpeed());

        currentAmmo--;
        UIManager.Instance.UpdateAmmoIndicator(false);
    }

    private IEnumerator Reload()
    {
        UIManager.Instance.UpdateAmmoIndicator(true);
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(Player.Instance.CalculateReloadSpeed());

        currentAmmo = Player.Instance.CalculateAmmoCapacity();
        UIManager.Instance.UpdateAmmoIndicator(false);
        isReloading = false;
        Debug.Log("Reloaded.");
    }
}
