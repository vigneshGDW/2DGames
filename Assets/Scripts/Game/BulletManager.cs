using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BulletManager : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public Transform BulletInsialPostion;
    public int maxBullets = 5;
    public float bulletDuration = 0.3f;
    public float fireRate = 0.1f;

    private List<GameObject> bulletPool = new();
    private List<Coroutine> bulletCoroutines = new();
    private int bulletIndex = 0;
    private float lastFireTime;
    public GameObject Chracter,CenterPostionObj;
    public GameObject LeftSidePostionObj,RightSidePostionObj;
    public bool IsLeftSide,IsRightSide;
    public ParticleSystem bulletFireEffect;
    void Start()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
            bulletCoroutines.Add(null);
        }
    }

    void Update()
    {
        if (Touchscreen.current == null) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;

        var touch = Touchscreen.current.primaryTouch;
        if (!touch.press.isPressed) return;

        if (Time.time < lastFireTime + fireRate) return;

        Vector2 touchPos = touch.position.ReadValue();
        Vector3 targetPoint = Camera.main.ScreenToWorldPoint(
            new Vector3(touchPos.x, touchPos.y, Mathf.Abs(Camera.main.transform.position.z))
        );

        FireBullet(targetPoint);
        lastFireTime = Time.time;
    }

    void FireBullet(Vector3 targetPoint)
    {
        // if(CenterPostionObj.transform.position.x > targetPoint.x)
        // {
        //     IsRightSide = true;
        //     IsLeftSide = false;
        //     Chracter.transform.SetParent(LeftSidePostionObj.transform);
        //     Chracter.transform.localPosition = Vector3.zero;
        //     Chracter.transform.localRotation = Quaternion.identity;
        // }
        // else
        // {
        //     IsLeftSide = true;
        //     IsRightSide = false;
        //     Chracter.transform.SetParent(RightSidePostionObj.transform);
        //     Chracter.transform.localPosition = Vector3.zero;
        //     Chracter.transform.localRotation = Quaternion.identity;
        // }
        GameObject bullet = bulletPool[bulletIndex];
        // Stop only this bullet's movement coroutine
        if (bulletCoroutines[bulletIndex] != null)
        {
            StopCoroutine(bulletCoroutines[bulletIndex]);
        }

        bullet.transform.position = BulletInsialPostion.position;
        bullet.SetActive(true);
        bulletFireEffect.Play();
        bulletCoroutines[bulletIndex] =
            StartCoroutine(BulletMove(bullet, BulletInsialPostion.position, targetPoint));

        bulletIndex++;
        if (bulletIndex >= maxBullets)
            bulletIndex = 0;
    }

    IEnumerator BulletMove(GameObject bullet, Vector3 startPos, Vector3 targetPos)
    {
        float elapsed = 0f;

        // Direction from gun to touch
        Vector3 direction = (targetPos - startPos).normalized;

        // Distance big enough to go off-screen
        float offScreenDistance = 30f;

        // Final extended target
        Vector3 extendedTarget = startPos + direction * offScreenDistance;

        while (elapsed < bulletDuration)
        {
            bullet.transform.position =
                Vector3.Lerp(startPos, extendedTarget, elapsed / bulletDuration);

            elapsed += Time.deltaTime;
            yield return null;
        }

        bullet.SetActive(false);
    }
}
