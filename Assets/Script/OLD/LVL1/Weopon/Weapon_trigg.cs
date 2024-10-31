  using UnityEngine;

public class Weapon_trigg : MonoBehaviour
{
    [SerializeField] private GameObject shootingRange;
    [SerializeField] private GameObject Weapon_man;
    [SerializeField] private Auttomatic Auttomatic;
    [SerializeField] private GameObject weapon , Welcome_trigger;
    [SerializeField] private GameObject podskazka, Ammo, Text_navigashon;
    [SerializeField] private GameObject Bidvijenie;
    [SerializeField] private GreenTarget GreenTarget;
    bool enter;
    public static bool ammo_bool;
    private bool one = true;
    // Start is called before the first frame update
    void Start()
    {
        weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.E) && !Weapon_man.activeSelf)
        {
            weapon.SetActive(true);
            podskazka.SetActive(false);
            Ammo.SetActive(true);
            Welcome_trigger.SetActive(true);
            Bidvijenie.SetActive(true);
            shootingRange.SetActive(true);
            this.gameObject.SetActive(false);

        }

        if (Auttomatic.currentAmmo == 0 && Auttomatic.ammo == 0 )
        {
            if (one) 
            {
                Text_navigashon.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E) && enter)
                {
                    this.gameObject.SetActive(false);
                    shootingRange.SetActive(true);
                    Auttomatic.ammo = 10;

                    Text_navigashon.SetActive(false);

                    podskazka.SetActive(false);

                    Bidvijenie.SetActive(true);

                    ammo_bool = true;

                    GreenTarget.scores = 0;
                    GreenTarget.six = 0;
                    GreenTarget.sev = 0;
                    GreenTarget.vos = 0;
                    GreenTarget.nine = 0;
                    GreenTarget.ten = 0;
                    GreenTarget.oldscore = 0;
                    gameObject.SetActive(false);

                }
                one = false;
            }


            if (Input.GetKeyDown(KeyCode.E) && enter)
            {
                weapon.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = true;
            podskazka.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            podskazka.SetActive(false);
            enter = false;
        }
    }
}
