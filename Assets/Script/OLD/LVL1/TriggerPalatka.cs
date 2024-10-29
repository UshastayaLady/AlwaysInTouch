using UnityEngine;

public class TriggerPalatka : MonoBehaviour
{
    private bool enter;
    public static bool StayPalatka;
    public static bool strelba;
    [SerializeField] private GameObject TextStart, Instrution, scoreImage;
    [SerializeField] private GameObject[] wall;
    [SerializeField] private Auttomatic Auttomatic;
    [SerializeField] private GameObject palatka;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject Bidvijenie;
    [SerializeField] private GameObject Text_zachet;
    [SerializeField] private GameObject Rezult, Rezult_text;
    private GameObject man, avtomat;

    // Start is called before the first frame update
    void Start()
    {
        StayPalatka = false;
        man = GameObject.FindGameObjectWithTag("Player");
        avtomat = GameObject.FindGameObjectWithTag("weapon");
    }

    // Update is called once per frame
    void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.E))
        {
            StayPalatka = true;
            enter = false;

            TextStart.SetActive(false);
            Instrution.SetActive(true);
            Bidvijenie.SetActive(false);
            scoreImage.SetActive(true);

            man.transform.position = Vector3.MoveTowards(man.transform.position, startPoint.transform.position, 100f);
                       
            for(int i = 0; i < wall.Length; i++)
            {
                wall[i].SetActive(true);
            }
            if (Weapon_trigg.ammo_bool)
                Text_zachet.SetActive(true);
           

        }
        
        if (Auttomatic.currentAmmo == 0 && Auttomatic.ammo == 0)
        {
            TextStart.SetActive(false);
            StayPalatka = false;
            strelba = false;
            Text_zachet.SetActive(false);
            palatka.SetActive(true);
            for (int i = 0; i < wall.Length; i++)
            {
                wall[i].SetActive(false);
            }

            if (Weapon_trigg.ammo_bool)
            {
                Rezult.GetComponent<SphereCollider>().enabled = true;
                Rezult_text.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
       
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){enter = true; TextStart.SetActive(true); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player"){enter = false; TextStart.SetActive(false); }
    }
}
