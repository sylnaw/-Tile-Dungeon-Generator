using UnityEngine;

public enum Neighbor { DontCare, Have, DontHave }

[System.Serializable]
public class RulePattern
{
    [SerializeField]
    public Sprite sprite;
    public Neighbor[,] Rule { get; protected set; }

    public void ChangeSprite(Sprite sprite) { this.sprite = sprite; }

    public bool CheckRule(bool[,] neighbours)
    {
        if (neighbours.Length == 9)
            return CheckIfRuleIsMet(neighbours);
        else throw new System.Exception("Wrong size of neighbours array in tile");
    }

    bool CheckIfRuleIsMet(bool[,] neighbours)
    {
        for (int x = 0; x <= 2; x++)
        {
            for (int y = 0; y <= 2; y++)
            {
                if (CheckIfRuleIsntMetForOneTile(neighbours, x, y)) return false;
            }
        }
        return true;
    }

    bool CheckIfRuleIsntMetForOneTile(bool[,] neighbours, int x, int y)
    {
        if (Rule[x, y] == Neighbor.DontHave && neighbours[x, y] == true) return true;
        else if (Rule[x, y] == Neighbor.Have && neighbours[x, y] != true) return true;
        else return false;
    }
}