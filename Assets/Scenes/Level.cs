using UnityEngine;


public class Level : MonoBehaviour
{
    public GameObject block;
    
    [Header("Parameters")]
    public int width = 200;
    public int height = 2;

    void Start()
    {
        var rand = new System.Random();

        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                double p = rand.NextDouble();
                print(p);

                if (x > 10 && p >= 0.5 )
                {
                    
                    continue;
                }
                else
                {
                    Instantiate(block, new Vector3(x, y, 0), Quaternion.identity);
                }

            }
        }

        Instantiate(block, new Vector3(0, 1, 0), Quaternion.identity);
    }
}
