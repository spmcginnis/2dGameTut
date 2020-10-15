using UnityEngine;


public class Level : MonoBehaviour
{
    public GameObject block;
    
    [Header("Parameters")]
    public int width = 20;
    public int height = 2;

    void Start()
    {
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                Instantiate(block, new Vector3(x, y, 0), Quaternion.identity);
            }
        }

        Instantiate(block, new Vector3(0, 1, 0), Quaternion.identity);
    }
}
