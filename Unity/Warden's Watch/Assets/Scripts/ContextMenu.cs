using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParent;
    public static ContextMenu Instance;

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

    private void OnEnable()
    {
   /*     // Creating a button with text "Button 1" and associating a custom action
        NewButton("Button 1", () => Debug.Log("Button 1 pressed!"));

        // Creating another button with text "Button 2" and associating another custom action
        NewButton("Button 2", () => Debug.Log("Button 2 pressed!"));*/
    }

    private void OnDisable()
    {
        ClearButtons();
    }

    public void NewButton(string text, Action action)
    {
        GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Button buttonComponent = newButton.GetComponent<Button>();
        buttonComponent.onClick.AddListener(() => action.Invoke());
    }

    public void ClearButtons()
    {
        // Destroy all buttons inside the context menu
        foreach (Button child in buttonParent.GetComponentsInChildren<Button>())
        {
            Destroy(child.gameObject);
        }
    }

    /*public Button buildTower1Button;
    public Button buildTower2Button;
    public Button buildTower3Button;

    private TowerPlace towerPlace;

    public void Setup(TowerPlace towerPlace)
    {
        this.towerPlace = towerPlace;

        buildTower1Button.onClick.AddListener(() => BuildTower(1));
        buildTower2Button.onClick.AddListener(() => BuildTower(2));
        buildTower3Button.onClick.AddListener(() => BuildTower(3));
    }

    void BuildTower(int towerType)
    {
        towerPlace.BuildTower(towerType);
        Destroy(gameObject); // Détruire le menu contextuel après sélection
    }*/
}
