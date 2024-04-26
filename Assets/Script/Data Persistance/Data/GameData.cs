using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public string worldName;

    public SerializableDictionary<string, bool> enciclopedie;

    public float maxHealth;
    public float currentHealth;

    public float maxBreath;
    public float currentBreath;

    public float maxStamina;
    public float currentStamina;

    public Vector3 playerPosition;

    public int itemPlace;
    public int insectPlace;
    public int fishPlace;
    public int plantPlace;

    public List<BaseItem> itemList;
    public List<InsectItem> insectItemList;
    public List<FishItem> fishItemList;
    public List<PlantItem> plantItemList;

    public GameData()
    {
        worldName = "New World";
        enciclopedie = new SerializableDictionary<string, bool>();

        maxHealth = 100;
        currentHealth = maxHealth;

        maxBreath = 100;
        currentBreath = maxBreath;

        maxStamina = 150;
        currentStamina = maxStamina;

        playerPosition = new Vector3(0, 1, 0);

        itemPlace = 20;
        insectPlace = 10;
        fishPlace = 10;
        plantPlace = 20;

        itemList = new();
        insectItemList = new();
        fishItemList = new();
        plantItemList = new();
    }
}
