using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FeedingManager : MonoBehaviour
{
    [SerializeField] private WolfHomeController wolf;
    [SerializeField] private GameObject feedingMenu;

    public void OnRabbitButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Rabbit)) return;
        Debug.Log("Eat: Rabbit button clicked");
        wolf.ReduceHunger(25f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

    public void OnChickenButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Chicken)) return;
        Debug.Log("Eat: Chicken button clicked");
        wolf.ReduceHunger(17f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

   public void OnTurkeyButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Turkey)) return;
        Debug.Log("Eat: Turkey button clicked");
        wolf.ReduceHunger(17f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
        Debug.Log("Eat: Turkey button clicked");
    }

    public void OnPorkButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Pork)) return;
        Debug.Log("Eat: Pork button clicked");
        wolf.ReduceHunger(30f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

    public void OnBeefButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Beef)) return;
        Debug.Log("Eat: Beef button clicked");
        wolf.ReduceHunger(30f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

    public void OnPotatoButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Potato)) return;
        Debug.Log("Eat: Potato button clicked");
        wolf.ReduceHunger(5f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

    public void OnSausageButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Sausage)) return;
        Debug.Log("Eat: Sausage button clicked");
        wolf.ReduceHunger(12f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

    public void OnDumplingsButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Dumplings)) return;
        Debug.Log("Eat: Dumplings button clicked");
        wolf.ReduceHunger(25f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

    public void OnVarenykyButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Varenyky)) return;
        Debug.Log("Eat: Varenyky button clicked");
        wolf.ReduceHunger(20f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

    public void OnBorschtButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Borscht)) return;
        Debug.Log("Eat: Borscht button clicked");
        wolf.ReduceHunger(15f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

    public void OnTeaButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Tea)) return;
        Debug.Log("Eat: Tea button clicked");
        wolf.ReduceHunger(5f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

    public void OnMedicine10ButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Tea)) return;
        Debug.Log("Healing: Medicine x10 button clicked");
        wolf.Healing(10f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating"); 
    }

    public void OnMedicine20ButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Tea)) return;
        Debug.Log("Healing: Medicine x20 button clicked");
        wolf.Healing(20f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating"); 
    }

    public void OnMedicine30ButtonClicked()
    {
        if (!FridgeInventory.Remove(HuntingGroundsItems.Tea)) return;
        Debug.Log("Healing: Medicine x30 button clicked");
        wolf.Healing(30f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating"); 
    }

    public void OnCloseButtonClicked()
    {
        CloseMenu();
        wolf.ChangeState(WolfState.Idle);
    }

    public void OpenMenu()
    {
        Debug.Log("Feeding menu opened");
        feedingMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        Debug.Log("Feeding menu closed");
        feedingMenu.SetActive(false);
    }
}