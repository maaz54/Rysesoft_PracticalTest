using System.Collections;
using System.Collections.Generic;
using Gameplay;
using Gameplay.UI;
using Inventory;
using UnityEngine;
using Zenject;

/// <summary>
/// Binds all key managers and UI components as singletons in the dependency injection
/// Ensures that all scripts can get references to these systems via injection.
/// </summary>
public class SceneContextInstaller : MonoInstaller
{
    [SerializeField] UIManager uIManager;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] PileManager pileManager;
    [SerializeField] CraftingManager craftingManager;
    [SerializeField] CraftingManagerUI craftingManagerUI;
    [SerializeField] PileUIManager pileUIManager;
    [SerializeField] InventoryManagerUI inventoryManagerUI;
    [SerializeField] CraftingTable craftingTable;

    /// <summary>
    /// Registers all dependencies in Zenject container.
    /// All are bound as singletons using the instances from the scene.
    /// </summary>
    public override void InstallBindings()
    {
        Container.Bind<UIManager>().FromInstance(uIManager).AsSingle();
        Container.Bind<InventoryManager>().FromInstance(inventoryManager).AsSingle();
        Container.Bind<PileManager>().FromInstance(pileManager).AsSingle();
        Container.Bind<CraftingManager>().FromInstance(craftingManager).AsSingle();
        Container.Bind<CraftingManagerUI>().FromInstance(craftingManagerUI).AsSingle();
        Container.Bind<PileUIManager>().FromInstance(pileUIManager).AsSingle();
        Container.Bind<InventoryManagerUI>().FromInstance(inventoryManagerUI).AsSingle();
        Container.Bind<CraftingTable>().FromInstance(craftingTable).AsSingle();
    }
}
