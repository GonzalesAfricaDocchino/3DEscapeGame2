using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystems : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask interactableLayer;
    public GameObject keyPrefab;
    public Transform spawnPoint;

    private GameObject currentTarget;
    private bool hasKey = false;
    private bool openDoor = false;
    int buttonClickCount = 0;

    [SerializeField] Item item;

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

                if (currentTarget.CompareTag("Button") && !hasKey)
                {
                    buttonClickCount++;
                    if(buttonClickCount == 1)
                    {
                        GameObject key = Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
                        key.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
                    }
                }

                if (currentTarget.CompareTag("Key"))
                {
                    InventoryItem.instance.SetItem(item);
                    Destroy(currentTarget);
                    hasKey = true;
                    Debug.Log("カギを獲得しました！");
                }

                if (currentTarget.CompareTag("Door"))
                {
                    if (hasKey && !openDoor)
                    {
                        openDoor = true;
                        Debug.Log("ドアが開きました！");
                        SceneManager.LoadScene("Clear");

                        if (playerCamera == null)
                        {
                            Debug.LogError("カメラがnullです。");
                        }
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
