using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystems : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask interactableLayer;
    private GameObject currentTarget;
    private bool hasKey = false;
    private bool openDoor = false;
    public GameObject keyPrefab;
    public Transform spawnPoint;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (playerCamera != null)
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            // 以下の処理を行う
        }
        else
        {
            Debug.LogError("カメラがnullです。");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Rayをプレイヤーからまっすぐ伸ばす
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            //衝突したオブジェクトや情報を格納する
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
            {
                currentTarget = hit.collider.gameObject;

                if (currentTarget.CompareTag("Button"))
                {
                    GameObject key = Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
                }

                if (currentTarget.CompareTag("Key"))
                {
                    Destroy(currentTarget);
                    hasKey = true;
                }

                if (currentTarget.CompareTag("Door"))
                {
                    if (hasKey && !openDoor)
                    {
                        openDoor = true;
                        Debug.Log("ドアが開きました！");
                        SceneManager.LoadScene("Clear");
                    }
                    else if (!hasKey)
                    {
                        Debug.Log("鍵が必要です！");
                    }
                }
            }
        }
    }
}
