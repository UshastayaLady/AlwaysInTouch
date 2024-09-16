using UnityEngine;

public class TriggerRestart : MonoBehaviour
{
    public Polosa_start polosaStart;
    // Start is called before the first frame update
    void Start()
    {
        polosaStart = FindObjectOfType<Polosa_start>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            polosaStart.Restart();
    }
}
