using UnityEngine;


public class Level : MonoBehaviour
{
    public GameObject block;
    public GameObject springBlock;
    public GameObject endGoal;

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
                //print(p);

                if (x > 10 && p >= 0.5 )
                {
                    
                    continue;
                }
                else if (x > 10 && p <= 0.1)
                {
                    Instantiate(springBlock, new Vector3(x, y, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(block, new Vector3(x, y, 0), Quaternion.identity);
                }

            }
        }

        Instantiate(block, new Vector3(0, 1, 0), Quaternion.identity);

        placeGoal(new Vector2(10, 3));

    }

    void placeGoal(Vector2 position) {
        Instantiate(block, position, Quaternion.identity);
        Instantiate(block, position + new Vector2(1, 0), Quaternion.identity);
        Instantiate(block, position + new Vector2(2, 0), Quaternion.identity);
        Instantiate(block, position + new Vector2(1, 1), Quaternion.identity);

        endGoal.transform.position = position + new Vector2(1, 2);
    }
}
