using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveState
{
    public int totalJerseyCount = 0;
    public List<int> savedJerseyNo = new List<int>();
    public List<int> savedColourNo = new List<int>();
    public double bankBalance = 0;
    public int increaseNo = 1;
    public int[] savePriseValue = new int[5];
    public int newJerseyAmount = 0;
    public int newJerseyMultiplyValueIs = 1;
    public int[] customerChooseJerseyNo = new int[6];
    public int[] customerChooseJerseyColour = new int[6];
    public bool newBeltBool = false;
    public int beltCount = 1;
    public bool firstTimeUserBool = false;

    public int selectJInFactory = 0;
    public bool canView = false;
    public int tapOnMachineIndex = 0;
    public bool assignOnBelt = false;

    public int[] beltNo = new int[3];
}