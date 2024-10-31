  using UnityEngine;

public class SupplyPointTrigger : MonoBehaviour
{
    [SerializeField] private GameObject shootArenaTrigger;
    [SerializeField] private Auttomatic Auttomatic;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject closeExit;
    [SerializeField] private GameObject buttonE;
    [SerializeField] private GameObject ammo;
    [SerializeField] private GameObject textNavigashon, textNavigashon2;
    [SerializeField] private GreenTarget greenTarget;
    [SerializeField] private GameObject npsInstructorPoligon, textNavigation3;
    private bool enter;
    //public static bool ammo_bool;
    private bool one = true;
    // Start is called before the first frame update
    void Start()
    {
        weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.E) && !weapon.activeSelf)
        {
            weapon.SetActive(true);
            buttonE.SetActive(false);
            ammo.SetActive(true);
            closeExit.SetActive(true);
            textNavigashon2.SetActive(true);
            shootArenaTrigger.SetActive(true);
            this.gameObject.SetActive(false);

        }

        if (Auttomatic.currentAmmo == 0 && Auttomatic.ammo == 0 )
        {
            if (one)
            {
                textNavigashon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) && enter)
                {
                    shootArenaTrigger.SetActive(true);
                    Auttomatic.ammo = 10;

                    textNavigashon.SetActive(false);
                    buttonE.SetActive(false);
                    textNavigashon2.SetActive(true);
                    //ammo_bool = true;

                    greenTarget.scores = 0;
                    greenTarget.six = 0;
                    greenTarget.sev = 0;
                    greenTarget.vos = 0;
                    greenTarget.nine = 0;
                    greenTarget.ten = 0;
                    greenTarget.oldscore = 0;
                    this.gameObject.SetActive(false);
                    one = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) & enter & !one)
            {
                buttonE.SetActive(false);
                weapon.SetActive(false);
                //if (ammo_bool)
                //{
                    npsInstructorPoligon.GetComponent<SphereCollider>().enabled = true;
                    textNavigation3.SetActive(true);
                //}
                this.gameObject.SetActive(false);
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = true;
            buttonE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonE.SetActive(false);
            enter = false;
        }
    }
}
