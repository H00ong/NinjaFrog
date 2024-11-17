using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [Header("Ground Info")]
    [SerializeField] float generateYOffset = 6f;
    [SerializeField] float maxXOffset = 3.8f;
    [SerializeField] float maxYOffset = 2.7f;
    [SerializeField] float minXOffset = .25f;
    [SerializeField] float minYOffset = 1.3f;
    [SerializeField] int groundCount = 15;
    
    [SerializeField] GameObject[] groundPrefab;
    [SerializeField] DeathPlane deathPlane;
    [SerializeField] Sprite[] groundSprites;

    Transform player;

    public List<GameObject> groundList = new List<GameObject>();

    private void Awake()
    {
        player = PlayerManager.instance.player.transform;

        GameObject ground = Instantiate(groundPrefab[0], new Vector3(0, -1), Quaternion.identity);
        
        if(ground.GetComponent<SpriteRenderer>() != null)
            ground.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(0, groundSprites.Length)];

        groundList.Add(ground);

        CreateGround(groundCount - 1);
    }

    private void CreateGround(int _count = 1)
    {
        GameObject ground;

        for (int i = 0; i < _count; i++)
        {
            float xPos = groundList[groundList.Count - 1].transform.position.x > 0 ? Random.Range(-maxXOffset, -minXOffset) : Random.Range(minXOffset, maxXOffset);
            float yPos = groundList[groundList.Count - 1].transform.position.y + Random.Range(minYOffset, maxYOffset);

            ground = Instantiate(groundPrefab[Random.Range(0, groundPrefab.Length)], new Vector3(xPos, yPos), Quaternion.identity);
            
            if (ground.GetComponent<SpriteRenderer>() != null)
                ground.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(0, groundSprites.Length)];

            groundList.Add(ground);
        }
    }

    void Update()
    {
        for (int i = 0; i < groundCount; i++)
        {
            GameObject ground = groundList[i];

            if (player.transform.position.y - ground.transform.position.y > generateYOffset)
            {
                groundList.RemoveAt(i);
                Destroy(ground);
                CreateGround();
                deathPlane.UpdatePosition(groundList[0].transform);
            }
        }
    }
}
