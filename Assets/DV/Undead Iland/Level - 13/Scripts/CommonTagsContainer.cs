using UnityEngine;

public class CommonTagsContainer : MonoBehaviour
{
    public Yourpostion yourpostion;
    public bool defence1bool = false;
    public bool defence2bool = false;
    public bool defence3bool = false;
    public bool itsnotmoveplace = false;

    public static CommonTagsContainer Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
}

public enum Yourpostion
{
    None,
    Defence1,
    Defence2,
    Defence3,
    DefenceRotate1,
    DefenceRotate2,
    DefenceRotate3,
}
