using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    void Start()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
