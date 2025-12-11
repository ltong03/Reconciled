using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class MapSystem : MonoBehaviour
{
    [SerializeField] private InputActionReference tab;
    [SerializeField] private GameObject mapParent;
    [SerializeField] private GameObject[] icons;
    [SerializeField] private Transform[] mapPositions;
    [SerializeField] private GameObject[] mapArr;
    [SerializeField] private GameObject[] cameraArr;
    private GameObject map;
    private float tabCooldown = 1f;
    private float nextTabTime = 0f;
    private bool mapOn = false;
    private bool isCoroutineRunning = false;
    Animator animator;

    void Start()
    {

        if (icons != null)
        {
            manageIcons(false);
        }
        if (mapArr[0] != null && cameraArr[0] != null)
        {
           animator = mapArr[0].gameObject.GetComponentInParent<Animator>();
           mapArr[0].SetActive(true);
           cameraArr[0].SetActive(true); 
           map = mapArr[0];
        }
    }
    private void OnEnable()
    {
        tab.action.Enable();
    }
    private void OnDisable()
    {
        tab.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && (Time.time >= nextTabTime))
        {

            nextTabTime = Time.time + tabCooldown;
            Debug.Log("Switching Map");
            swapMap();
        }

        if (Input.GetKeyDown(KeyCode.Tab) && Time.time >= nextTabTime)
        {
            if (!isCoroutineRunning)
            {
                pressMap();
                nextTabTime = Time.time + tabCooldown;
            }
            }
        }
    private void swapMap()
    {
        if (map == mapArr[0])
        {
            mapArr[0].SetActive(false);
            cameraArr[1].SetActive(true);
            map = mapArr[1];
            cameraArr[0].SetActive(false);
            mapArr[1].SetActive(true);

        }
        else {
            mapArr[1].SetActive(false);
            cameraArr[0].SetActive(true);
            map = mapArr[0];
            mapArr[0].SetActive(true);
            cameraArr[1].SetActive(false);
        }
    }
    private void pressMap()
    {
        float pressTab = tab.action.ReadValue<float>();
        if (pressTab > 0.1f)
        {
            UpdateMap();
        }
    }
    private void UpdateMap()
    {
        mapOn = !mapOn; 
        Vector3 targetPos;
        float speed;

        if (mapOn) {
            targetPos = mapPositions[0].localPosition;
            animator.SetTrigger("Open");
            speed = 5f;
        }
        else
        {
            targetPos = mapPositions[1].localPosition;
            animator.SetTrigger("Close");
            speed = 1f;
        }

        StartCoroutine(MoveToPosition(targetPos, speed));
    }
    private IEnumerator MoveToPosition(Vector3 target, float speed)
    {
        isCoroutineRunning = true;
        if (mapOn){ manageIcons(mapOn);}
            while (Vector3.Distance(mapParent.transform.localPosition, target) > 0.01f)
        {
            mapParent.transform.localPosition = Vector3.MoveTowards(
                mapParent.transform.localPosition,
                target,
                speed * Time.deltaTime
            );

            yield return null;
        }
        mapParent.transform.localPosition = target;
        if (!mapOn) { manageIcons(mapOn); }
        isCoroutineRunning = false;
    }

    private void manageIcons(bool turn)
    {
        for (int i = 0; i < icons.Length; i++) 
        {
            icons[i].SetActive(turn);
        }
    }
}
