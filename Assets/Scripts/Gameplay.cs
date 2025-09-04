using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character
{
    public string name;
    public int hp;

    public Character(string n, int h)
    {
        name = n;
        hp = h;
    }

    public void ReceiveDamage(int dmg)
    {
        hp -= dmg;
        if (hp < 0) hp = 0;
    }
}

public class Gameplay : MonoBehaviour
{
    TextMeshProUGUI playerName;
    Image hpBar;
    Character player;

    void Start()
    {
        player = new Character("PicoChan", 100);

        playerName = GameObject.Find("PlayerName").GetComponent<TextMeshProUGUI>();
        hpBar = GameObject.Find("HP").GetComponent<Image>();

        playerName.text = player.name;
    }

    void Update()
    {
        hpBar.fillAmount = (float)player.hp / 100;
    }

    // Expose damage function for PlayerController
    public void DamagePlayer(int dmg)
    {
        player.ReceiveDamage(dmg);
        Debug.Log(player.name + " received " + dmg + " damage! HP left: " + player.hp);
    }
}
