using UnityEngine;

public class TriggerRestart : MonoBehaviour
{
    public PolosaStart polosaStart;
    // Start is called before the first frame update
    void Start()
    {
        polosaStart = FindObjectOfType<PolosaStart>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            polosaStart.Restart();
    }
}
