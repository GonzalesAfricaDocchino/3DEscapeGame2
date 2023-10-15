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
            // �ȉ��̏������s��
        }
        else
        {
            Debug.LogError("�J������null�ł��B");
        }
    }

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
                        Debug.Log("�h�A���J���܂����I");
                        SceneManager.LoadScene("Clear");
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
