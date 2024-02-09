using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class UmaGenerateSpecs : MonoBehaviour
{
    public DynamicCharacterAvatar characterPrefab; // Drag and drop UMA prefab from project folder
    public UMAPredefinedDNA[] dnaPresets; // A list of predefined DNA presets from the UMA 2 library

    private GameObject[] dots;

    private void Start()
    {
        dots = GameObject.FindGameObjectsWithTag("Dots");
        int maxCharacters = Mathf.Min(dots.Length, dnaPresets.Length);
        GenerateUMAs(maxCharacters);
        print("Vasya" + maxCharacters);
    }

    void GenerateUMAs(int maxCharacters)
    {
        for (int i = 0; i < maxCharacters; i++)
        {
            
            GenerateRandomCharacter(dots[i].transform.position);
        }
    }

    private void GenerateRandomCharacter(Vector3 position)
    {
       
        // Instantiate a new character from the prefab at the specified position
        DynamicCharacterAvatar newCharacter = Instantiate(characterPrefab, position, Quaternion.identity);

        // Generate a random predefined DNA preset
        UMAPredefinedDNA randomDNA = dnaPresets[Random.Range(0, dnaPresets.Length)];
        print(dnaPresets.Length + "dnaPresets.Length");
        newCharacter.predefinedDNA = randomDNA;

        // Randomize the character's wardrobe
        newCharacter.BuildCharacter();
    }
}