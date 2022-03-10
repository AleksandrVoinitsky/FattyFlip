using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject BaseBlock;
    [SerializeField] int countBlocks;
    [SerializeField] GameObject[] BobusBlocks;
    [SerializeField] int BobusBlocksCount;
    [SerializeField] GameObject[] WallBlocks;
    [SerializeField] int WallBlocksCount;
    [SerializeField] GameObject[] OtherBlocks;
    [SerializeField] int OtherBlocksCount;
    [SerializeField] GameObject FinishBlock;
    [SerializeField] GameObject Cone;

    private float distanceCounter = 0;
    private float UpCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager manager = FindObjectOfType<LevelManager>();
        countBlocks = Random.Range(manager.data.data.PlayerProgress, manager.data.data.PlayerProgress + 20);
        FindObjectOfType<LevelManager>().SetLevelDistance(countBlocks);
        while(countBlocks > 0)
        {
            Generate();
        }

        for (int i = 0; i < 5; i++)
        {
            Instantiate(FinishBlock, new Vector3(distanceCounter, UpCounter, 0), new Quaternion(0, 0, 0, 0));
            distanceCounter += 1;
        }
        
        Instantiate(Cone, new Vector3(distanceCounter, UpCounter, 0), new Quaternion(0, 0, 0, 0));

    }

    public void Generate()
    {
        GenerateBonus(Random.Range(4,6));
        GenerateWall(1);
        VerticalOffset();
        GenerateBonus(Random.Range(4, 6));
        GenerateWall(1);
        VerticalOffset();
        GenerateBonus(Random.Range(4, 6));
        GenerateWall(1);
        VerticalOffset();
        GenerateBonus(Random.Range(4, 6));
        GenerateOther(1);

    }

    void VerticalOffset()
    {
        if(Random.Range(0,100) > 50){
            Instantiate(BaseBlock, new Vector3(distanceCounter, UpCounter, 0), new Quaternion(0, 0, 0, 0));
            if (Random.Range(0, 2) == 0 && countBlocks > 0)
            {
                UpCounter++;
            }
            else
            {
                UpCounter--;
            }
        }
    }



    void GenerateBonus(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (countBlocks > 0)
            {
                Instantiate(BobusBlocks[Random.Range(0, BobusBlocks.Length)], new Vector3(distanceCounter, UpCounter, 0), new Quaternion(0, 0, 0, 0));
                distanceCounter += 1;
                countBlocks--;
            }
            else
            {
                break;
            }
        }
    }

    void GenerateWall(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (countBlocks > 0)
            {
                Instantiate(WallBlocks[Random.Range(0, WallBlocks.Length)], new Vector3(distanceCounter, UpCounter, 0), new Quaternion(0, 0, 0, 0));
                distanceCounter += 1;
                countBlocks--;
            }
            else
            {
                break;
            }
        }
    }

    void GenerateOther(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (countBlocks > 0)
            {
                Instantiate(OtherBlocks[Random.Range(0, OtherBlocks.Length)], new Vector3(distanceCounter, UpCounter, 0), new Quaternion(0, 0, 0, 0));
                distanceCounter += 1;
                countBlocks--;
            }
            else
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
