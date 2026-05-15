using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour
{
    [Header("Tower Prefabs")]
    [SerializeField] private GameObject CrossbowTowerPrefab;

    private GameObject selectedTower;

    private Camera mainCamera;

    [SerializeField] private int CrossBowCost = 5;
    private int selectedTowerCost;
    private GameManager gameManager;
    private InGameUI inGameUI;


    private void Awake()
    {
        mainCamera = Camera.main;
        gameManager = FindFirstObjectByType<GameManager>();
        inGameUI = FindFirstObjectByType<InGameUI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTower();
        }
    }

    public void SelectCrossbowTower()
    {
        if (gameManager.CurrentScraps < CrossBowCost)
        {
            inGameUI.ShowWarningText();

            return;
        }
        selectedTower = CrossbowTowerPrefab;
        selectedTowerCost = CrossBowCost;

        Debug.Log("Crossbow Selected");
    }
    // Places the selected tower onto a tile
    private void PlaceTower()
    {
        // Prevents tower placement when clicking UI buttons
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        // Stops placement if no tower is selected 
        if (selectedTower == null)
            return;
        // Creates a ray from the mouse position into the world
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        // checks if the player clicked on a valid tile
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.transform.CompareTag("Tile"))
            {
                // Spwans the tower prefab onto the time
                Instantiate(selectedTower, hit.transform.position + Vector3.up * 0.5f, Quaternion.identity);
                // Reduces player scraps after building a tower 
                gameManager.UpdateScraps(-selectedTowerCost);
                Debug.Log("Tower Placed");
                // Resets tower selection
                selectedTower = null;
            }
        }
    }
}
