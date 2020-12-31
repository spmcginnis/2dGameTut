using UnityEngine;


public class Level : MonoBehaviour
{
    public GameObject block;
    public GameObject springBlock;
    public GameObject endGoal;

    [Header("Parameters")]
    public int width = 200;
    public int height = 5;
    public int levelShape = 0;

    void Start()
    {
        StartingPlatform();
        
        if (levelShape == 0)
        {
            StairCaseLevel(height);
        }
        else if (levelShape == 1)
        {
            PyramidLevel(height, 20);
        }
        
        
        
    }

    void PyramidLevel(int steps, int run)
    {
        int rise = height;
        for (int i=0; i<steps; i++)
        {
            HorizontalLevel(i * run, i * rise, width - ((run *2) * i) );
        }
        PlaceGoal(new Vector2(width / 2, steps*rise));
    }

    void StairCaseLevel(int steps)
    {
        int run = width / steps;
        int rise = height;
        for (int i = 0; i < steps; i++)
        {
            HorizontalLevel(i*run, i * rise, run);
        }
        PlaceGoal(new Vector2(width - 2, steps * rise-1));
    }

    void HorizontalLevel(int x, int y, int width)
    {
        var rand = new System.Random();
        int platformWidth = width + x;
        for (; x < platformWidth; ++x)
        {
            double p = rand.NextDouble();
            //print(p);

            if (p >= 0.5 )
            {
                    
                continue;
            }
            else if (p <= 0.1)
            {
                Instantiate(springBlock, new Vector3(x, y, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(block, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
    }

    void StartingPlatform()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(block, new Vector3(i-2, 2, 0), Quaternion.identity);
        }
    }

    void PlaceGoal(Vector2 position) {
        Instantiate(block, position, Quaternion.identity);
        Instantiate(block, position + new Vector2(1, 0), Quaternion.identity);
        Instantiate(block, position + new Vector2(2, 0), Quaternion.identity);
        Instantiate(block, position + new Vector2(1, 1), Quaternion.identity);

        endGoal.transform.position = position + new Vector2(1, 2);
    }
}
