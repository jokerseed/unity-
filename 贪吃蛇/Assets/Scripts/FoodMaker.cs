using UnityEngine;
using UnityEngine.UI;

public class FoodMaker : MonoBehaviour
{
    public int right = 12;
    public int left = 5;
    public int top = 10;
    public int bottom = 10;
    public Sprite[] sprites;
    public GameObject foodPrefab;
    public static FoodMaker instance;

    private Transform holder;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        holder = GameObject.Find("foodHolder").transform;
        MakeFood();
    }

    public void MakeFood()
    {
        int index = Random.Range(0, sprites.Length);
        GameObject food = Instantiate(foodPrefab);
        food.transform.SetParent(holder, false);
        int x = Random.Range(-left, right);
        int y = Random.Range(-bottom, top);
        food.transform.localPosition = new Vector3(x * 30, y * 30, 0);
        food.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
