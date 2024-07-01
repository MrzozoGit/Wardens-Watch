using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContextMenuManager : MonoBehaviour
{
    public static ContextMenuManager Instance;
    public GameObject contextMenu;
    public Canvas canvas; // Canvas reference

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // When right-clicking
        if (Input.GetMouseButtonDown(1))
        {
            HandleRightClick();
        }
    }

    private void HandleRightClick()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        Vector2 screenPosition = Input.mousePosition;
        pointerEventData.position = screenPosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);

        if (results.Count > 0)
        {
            foreach (var result in results)
            {
                Debug.Log("last clicked tag: " + result.gameObject.tag);

                // When right-clicking on a Tower Place
                if (result.gameObject.CompareTag("BuildingPlace"))
                {
                    ShowContextMenu();
                    ContextMenu.Instance.ClearButtons();
                    TowerPlace towerPlace = result.gameObject.GetComponent<TowerPlace>();
                    foreach (var type in towerPlace.compatibleTypes)
                    {
                        if (type.Value)
                        {
                            ContextMenu.Instance.NewButton("Build " + type.Key, () =>
                            {
                                towerPlace.BuildTower(type.Key);
                                HideContextMenu();
                            });
                        }
                    }
                    StartCoroutine(PlaceMenu(pointerEventData.position));
                    return;
                }
                if (result.gameObject.CompareTag("Building"))
                {
                    Debug.Log("inside building tag");
                    ShowContextMenu();
                    ContextMenu.Instance.ClearButtons();
                    ContextMenu.Instance.NewButton("Détruire le batiment", () =>
                    {
                        result.gameObject.GetComponent<Building>().Demolish();
                        HideContextMenu();
                    });
                    StartCoroutine(PlaceMenu(pointerEventData.position));
                    return;
                }
            }
        }

        // If no interactable GameObject was clicked, hide the context menu
        HideContextMenu();
    }

    public void ShowContextMenu()
    {
        contextMenu.SetActive(true);
    }

    public void HideContextMenu()
    {
        contextMenu.SetActive(false);
    }

    public IEnumerator PlaceMenu(Vector2 screenPosition)
    {
        yield return new WaitForEndOfFrame();

        LayoutRebuilder.ForceRebuildLayoutImmediate(contextMenu.GetComponent<RectTransform>());

        // Convert screen position to local position in canvas
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition, canvas.worldCamera, out localPoint);

        // Get context menu size
        RectTransform contextMenuRect = contextMenu.GetComponent<RectTransform>();
        Vector2 menuSize = contextMenuRect.sizeDelta;

        // Adjust position to place bottom left corner at click position
        Vector2 adjustedPosition = localPoint + new Vector2(menuSize.x / 2, -menuSize.y / 2);

        // Check whether the menu extends beyond the bottom edge of the screen
        if (adjustedPosition.y - menuSize.y < 0)
        {
            // Adjust position to place upper left corner at click position
            adjustedPosition.y = localPoint.y + menuSize.y / 2;
        }

        // Check whether the menu extends beyond the top edge of the screen
        else if (adjustedPosition.y > (canvas.transform as RectTransform).rect.height / 2)
        {
            // Adjust position to place bottom left corner at click position
            adjustedPosition.y = localPoint.y - menuSize.y / 2;
        }

        // Check whether the menu extends beyond the right edge of the screen
        if (adjustedPosition.x + menuSize.x > (canvas.transform as RectTransform).rect.width / 2)
        {
            // Adjust position to place bottom right corner at click position
            adjustedPosition.x = localPoint.x - menuSize.x / 2;
        }

        // Check whether the menu extends beyond the left edge of the screen
        else if (adjustedPosition.x - menuSize.x < -(canvas.transform as RectTransform).rect.width / 2)
        {
            // Adjust position to place bottom right corner at click position
            adjustedPosition.x = localPoint.x + menuSize.x / 2;
        }

        contextMenuRect.localPosition = adjustedPosition;
    }
}
