using UnityEngine;

public class PinDetecter : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        CommonTagsContainer temp = collision.gameObject.GetComponent<CommonTagsContainer>();
        if (temp == null) return;

        if (IsDefenceBlock(temp.yourpostion))
        {
            CommonTagsContainer.Instance.itsnotmoveplace = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        CommonTagsContainer temp = collision.GetComponent<CommonTagsContainer>();
        if (temp == null) return;

        SetDefenceRotateEnter(temp.yourpostion);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        CommonTagsContainer temp = collision.GetComponent<CommonTagsContainer>();
        if (temp == null) return;

        SetDefenceRotateExit(temp.yourpostion);
    }

    // ---------------- HELPERS ----------------

    bool IsDefenceBlock(Yourpostion pos)
    {
        return pos == Yourpostion.Defence1 ||
               pos == Yourpostion.Defence2 ||
               pos == Yourpostion.Defence3;
    }

    void SetDefenceRotateEnter(Yourpostion pos)
    {
        switch (pos)
        {
            case Yourpostion.DefenceRotate1:
                CommonTagsContainer.Instance.defence1bool = true;
                break;

            case Yourpostion.DefenceRotate2:
                CommonTagsContainer.Instance.defence1bool = true;
                CommonTagsContainer.Instance.defence2bool = true;
                break;

            case Yourpostion.DefenceRotate3:
                CommonTagsContainer.Instance.defence1bool = true;
                CommonTagsContainer.Instance.defence2bool = true;
                CommonTagsContainer.Instance.defence3bool = true;
                break;
        }
    }

    void SetDefenceRotateExit(Yourpostion pos)
    {
        switch (pos)
        {
            case Yourpostion.DefenceRotate3:
                CommonTagsContainer.Instance.defence3bool = false;
                break;

            case Yourpostion.DefenceRotate2:
                CommonTagsContainer.Instance.defence2bool = false;
                break;

            case Yourpostion.DefenceRotate1:
                CommonTagsContainer.Instance.defence1bool = false;
                break;
        }
    }
}
