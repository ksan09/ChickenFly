using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtillSystem
{

    public static List<T> ShuffleList<T>(List<T> shuffleList)
    {

        for(int i = 0; i < shuffleList.Count; i++)
        {

            int randomIndex = Random.Range(i, shuffleList.Count);

            T temp = shuffleList[randomIndex];
            shuffleList[randomIndex] = shuffleList[i];
            shuffleList[i] = temp;

        }

        return shuffleList;

    }

    public static List<T> ShuffleList<T>(List<T> shuffleList, int shuffleCount)
    {

        List<T> outputList = new List<T>();

        for (int i = 0; i < shuffleCount; i++)
        {

            int randomIndex = Random.Range(i, shuffleList.Count);

            outputList.Add(shuffleList[randomIndex]);
            shuffleList[randomIndex] = shuffleList[i];

        }

        return outputList;

    }




}
