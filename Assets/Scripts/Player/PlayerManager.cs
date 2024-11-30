using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Player player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
