using System;
using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using System.Linq;

public class Data
{
    public BigDouble reps;

    public List<int> clickUpgradeLevel;
    public List<int> productionUpgradeLevel;

    public Data()
    {
        reps = 0;

        clickUpgradeLevel = new int[4].ToList();
        productionUpgradeLevel = new int[4].ToList();
    }
}
