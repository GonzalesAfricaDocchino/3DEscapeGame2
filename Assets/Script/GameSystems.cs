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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray���v���C���[����܂������L�΂�
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            //�Փ˂����I�u�W�F�N�g������i�[����
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
                    Destroy(currentTarget);
                    hasKey = true;
                    Debug.Log("�J�M���l�����܂����I");
                }

                if (currentTarget.CompareTag("Door"))
                {
                    if (hasKey && !openDoor)
                    {
                        openDoor = true;
                        Debug.Log("�h�A���J���܂����I");
                        SceneManager.LoadScene("Clear");

                        if (playerCamera == null)
                        {
                            Debug.LogError("�J������null�ł��B");
                        }
                    }
                    else if (!hasKey)
                    {
                        Debug.Log("�����K�v�ł��I");
                    }
                }
            }
        }
    }
}
