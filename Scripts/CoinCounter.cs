using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    private List<Sprite> numbers;
    private Image first_num;
    private Image second_num;

    // Start is called before the first frame update
    void Start()
    {
        first_num = GameObject.Find("first_num").GetComponent<Image>();
        second_num = GameObject.Find("second_num").GetComponent<Image>();

        numbers = new List<Sprite>();
        for (int i = 0; i < 10; i++) {
            numbers.Add(GameObject.Find(i.ToString()).GetComponent<SpriteRenderer>().sprite);
        }

    }

    // Update is called once per frame
    void Update()
    {
        int num = GameObject.FindWithTag("Player").GetComponent<PlayerControl>().getCoin();
        changeNum(num);
    }

    private void changeNum(int num) {
        num = num > 99 ? 99 : num;
        first_num.sprite = numbers[num/10];
        second_num.sprite = numbers[num%10];
        // print(first_num.GetComponent("Image"));
    }
}
