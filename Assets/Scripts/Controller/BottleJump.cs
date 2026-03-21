using System.Collections;
using UnityEngine;

public class BottleJump : MonoBehaviour
{
    public GameObject[] BottlePrefabs;
    private GameObject[] bottles;

    public float jumpForce = 6f;
    public float flipForce = 5f;
    public float Duration;
    [System.Obsolete]
    void Start()
    {
        bottles = new GameObject[BottlePrefabs.Length];

        for (int i = 0; i < BottlePrefabs.Length; i++)
        {
            bottles[i] = Instantiate(BottlePrefabs[i], transform.position, Quaternion.identity);
            bottles[i].SetActive(false);
        }

        StartCoroutine(BottleJumpCoroutine());
    }

    [System.Obsolete]
    private IEnumerator BottleJumpCoroutine()
    {
        while (true)
        {
            foreach (var bottle in bottles)
            {
                bottle.SetActive(true);

                bottle.transform.SetParent(transform);
                bottle.transform.localPosition = Vector3.zero;
                bottle.transform.localRotation = Quaternion.identity;

                Rigidbody2D rb = bottle.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    // reset physics
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0f;

                    // jump
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                    // natural flip
                    rb.AddTorque(Random.Range(-flipForce, flipForce), ForceMode2D.Impulse);
                }

                yield return new WaitForSeconds(Duration);

                bottle.SetActive(false);
            }
        }
    }
}