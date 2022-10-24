using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject character in characters)
        {
            character.SetActive(false);
        }
        int characterIndex = PlayerPrefs.GetInt("character", 0);
        characters[characterIndex].SetActive(true);
        return;
    }
}
