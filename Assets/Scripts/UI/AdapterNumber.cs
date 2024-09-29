using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdapterNumber : MonoBehaviour
{
    [SerializeField]
    List<Sprite> imagesOfNumber = new List<Sprite>();

    [SerializeField]
    List<Image> listOfImages = new List<Image>();

   

    private void Start()
    {
       
    }

    private List<int> NumberToTransformImage(int number)
    {
        List<int> listOfNumber = new List<int>();
        while (number != 0)
        {
            int x = number % 10;
            listOfNumber.Add(x);
            number /= 10;
        }
        listOfNumber.Reverse(); 
        return listOfNumber;
    }

    public List<Sprite> listOfImage(int number)
    {
        List<Sprite> images = new List<Sprite>();
        List<int> numberDigits = NumberToTransformImage(number); 

        foreach (int digit in numberDigits)
        {
            images.Add(imagesOfNumber[digit]);
        }

        int x = 0;
        for (int i = numberDigits.Count - 1; i >= 0; i--)
        {
            listOfImages[x].sprite = images[i];
            x++;
           
        }

        return images;
    }
}
