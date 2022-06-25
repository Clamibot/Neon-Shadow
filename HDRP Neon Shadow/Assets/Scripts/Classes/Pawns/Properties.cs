using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Properties : MonoBehaviour
{
    public int health = 100;
    public WeaponObject currentGun;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;
    private bool weapon1 = false;
    private bool weapon2 = false;
    private bool weapon3 = false;
    private bool weapon4 = false;
    public GameObject lArmUp,lArmDown,rArmUp,rArmDown;
    private Quaternion lArmUpR;
    private Quaternion lArmDownR;
    private Quaternion rArmUpR;
    private Quaternion rArmDownR;
    public float speed;

    public Slider healthBar;
    public Text playerHealth;
    public Image fill;
    public Slider ammoBar;
    public Text playerAmmo;

    // Start is called before the first frame update
    void Start()
    {
        currentGun = gun2.GetComponent(typeof(WeaponObject)) as WeaponObject;
        rArmDownR = Quaternion.Euler(new Vector3(10.491f, 64.664f, 16.355f));
        lArmDownR = Quaternion.Euler(new Vector3(8.981001f, 3.908f, 36.421f));
        lArmUpR = Quaternion.Euler(new Vector3(53.346f, 71.97f, 84.72201f));
        rArmUpR = Quaternion.Euler(new Vector3(-37.889f, -10.968f, 93.672f));

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = (float)health / 100;
        playerHealth.text = health + "%";
        if (health <= 0)
            Die();
        else if (health <= 20)
            fill.color = Color.red;
        else if (health <= 60)
            fill.color = Color.yellow;

        ammoBar.value = (float)currentGun.currentAmmo / currentGun.maxClipAmmo;
        playerAmmo.text = currentGun.currentAmmo + "/" + currentGun.totalAmmo;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentGun.gameObject.SetActive(false);
            gun1.gameObject.SetActive(true);
            currentGun = gun1.GetComponent(typeof(WeaponObject)) as WeaponObject;
            weapon1 = true;
            //AimWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentGun.gameObject.SetActive(false);
            gun2.gameObject.SetActive(true);
            currentGun = gun2.GetComponent(typeof(WeaponObject)) as WeaponObject;
            weapon1 = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentGun.gameObject.SetActive(false);
            gun3.gameObject.SetActive(true);
            currentGun = gun3.GetComponent(typeof(WeaponObject)) as WeaponObject;
            weapon1 = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentGun.gameObject.SetActive(false);
            gun4.gameObject.SetActive(true);
            currentGun = gun4.GetComponent(typeof(WeaponObject)) as WeaponObject;
            weapon1 = true;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentGun.gameObject.SetActive(false);
            weapon1 = false;
        }
    }
    private void LateUpdate()
    {
        if (weapon1)
        {
            SetArms();
        }
    }
    void SetArms()
    {
        rArmUp.transform.localRotation = rArmUpR;
        rArmDown.transform.localRotation = rArmDownR;
        lArmDown.transform.localRotation = lArmDownR;
        lArmUp.transform.localRotation = lArmUpR;
    }
    //rotates torso to aim at mouse
    //void AimWeapon()
    //{
    //    Vector3 from = gameObject.transform.position;
    //    Vector3 to = gameObject.transform.position+transform.forward;
    //    RaycastHit hit;
    //    Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

    //    if (Physics.Raycast(ray, out hit))
    //    {

    //        to = hit.point;

    //        to.y += 2.0f;
    //        Debug.Log(hit.point);
    //    }



    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            //Debug.Log("hit"+health);
            //health -= 1;
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Bullet(Clone)")
		{
			Destroy(other.gameObject);
			//Debug.Log("hit" + health);
			health -= 2;
		}
	}

	private void Die()
    {
        PlayerPrefs.SetInt("LastLoadedScene", SceneManager.GetActiveScene().buildIndex); // Save the index of the current scene so we can get back to it.
        SceneManager.LoadScene(8, LoadSceneMode.Single); // Display the death screen. This will be at index 8.
        Destroy(gameObject);
    }
}
