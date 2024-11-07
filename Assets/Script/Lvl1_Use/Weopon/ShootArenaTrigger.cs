using UnityEngine;

public class ShootArenaTrigger : MonoBehaviour
{
    private bool inTrgger;
    public static bool StayPalatka;
    public static bool strelba;
    [SerializeField] private GameObject buttonE;
    [SerializeField] private GameObject shootingInstructions;
    [SerializeField] private GameObject scoreImage;
    [SerializeField] private GameObject[] wall;
    [SerializeField] private Auttomatic Auttomatic;
    [SerializeField] private GameObject supplyPoint;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject textNavigation2;
    [SerializeField] private GameObject textZachet;
    
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StayPalatka = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrgger && Input.GetKeyDown(KeyCode.E))
        {
            StayPalatka = true;
            inTrgger = false;

            buttonE.SetActive(false);
            shootingInstructions.SetActive(true);
            textNavigation2.SetActive(false);
            scoreImage.SetActive(true);

            player.transform.position = Vector3.MoveTowards(player.transform.position, startPoint.transform.position, 100f);
                       
            for(int i = 0; i < wall.Length; i++)
            {
                wall[i].SetActive(true);
            }       
        }
        
        if (Auttomatic.currentAmmo == 0 && Auttomatic.ammo == 0)
        {
            buttonE.SetActive(false);
            StayPalatka = false;
            strelba = false;
            textZachet.SetActive(false);
            supplyPoint.SetActive(true);
            for (int i = 0; i < wall.Length; i++)
            {
                wall[i].SetActive(false);
            }

            this.gameObject.SetActive(false);
        }
       
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){ inTrgger = true; buttonE.SetActive(true); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player"){ inTrgger = false; buttonE.SetActive(false); }
    }
}
