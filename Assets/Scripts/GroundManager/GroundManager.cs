using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    // ground간에 위치 조정이 필요 현재 yPos와 xPos가 너무 밀집되는 경우가 많음
    [SerializeField] float generateYOffset = 6f;
    [SerializeField] float maxXOffset = 3.8f;
    [SerializeField] float maxYOffset = 2.7f;
    [SerializeField] float minXOffset = .25f;
    [SerializeField] float minYOffset = 1.3f;
    [SerializeField] int groundCount = 15;
    [SerializeField] GameObject[] groundPrefab;

    Transform player;

    public List<GameObject> groundList = new List<GameObject>();

    private void Start()
    {
        player = PlayerManager.instance.player.transform;

        GameObject ground = Instantiate(groundPrefab[Random.Range(0, groundPrefab.Length)], new Vector3(0, -1), Quaternion.Euler(new Vector3(0, 0, 90)), transform);
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

            ground = Instantiate(groundPrefab[Random.Range(0, groundPrefab.Length)], new Vector3(xPos, yPos), Quaternion.Euler(new Vector3(0, 0, 90)), transform);
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
            }
        }
    }
}
