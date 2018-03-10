public class MiddleTile : RulePattern
{
    public MiddleTile()
    {
        Neighbor[,] rule = {{ Neighbor.Have, Neighbor.Have, Neighbor.Have },
                             { Neighbor.Have, Neighbor.Have, Neighbor.Have },
                             { Neighbor.Have, Neighbor.Have, Neighbor.Have }};
        Rule = rule;
    }
}

public class TopTile : RulePattern
{
    public TopTile()
    {
        Neighbor[,] rule = {{ Neighbor.Have, Neighbor.Have, Neighbor.DontCare },
                             { Neighbor.Have, Neighbor.Have, Neighbor.DontHave },
                             { Neighbor.Have, Neighbor.Have, Neighbor.DontCare }};
        Rule = rule;
    }
}

public class DownTile : RulePattern
{
    public DownTile()
    {
        Neighbor[,] rule =  {{ Neighbor.DontCare, Neighbor.Have, Neighbor.Have },
                             { Neighbor.DontHave, Neighbor.Have, Neighbor.Have },
                             { Neighbor.DontCare, Neighbor.Have, Neighbor.Have }};
        Rule = rule;
    }
}

public class LeftTile : RulePattern
{
    public LeftTile()
    {
        Neighbor[,] rule =  {{ Neighbor.DontCare, Neighbor.DontHave, Neighbor.DontCare },
                             { Neighbor.Have, Neighbor.Have, Neighbor.Have },
                             { Neighbor.Have, Neighbor.Have, Neighbor.Have }};
        Rule = rule;
    }
}

public class RightTile : RulePattern
{
    public RightTile()
    {
        Neighbor[,] rule = {{ Neighbor.Have, Neighbor.Have, Neighbor.Have },
                             { Neighbor.Have, Neighbor.Have, Neighbor.Have },
                             { Neighbor.DontCare, Neighbor.DontHave, Neighbor.DontCare }};
        Rule = rule;
    }
}

public class OutsideTopLeftTile : RulePattern
{
    public OutsideTopLeftTile()
    {
        Neighbor[,] rule = {{ Neighbor.DontCare, Neighbor.DontHave, Neighbor.DontCare },
                             { Neighbor.Have, Neighbor.Have, Neighbor.DontHave },
                             { Neighbor.Have, Neighbor.Have, Neighbor.DontCare }};
        Rule = rule;
    }
}

public class OutsideTopRightTile : RulePattern
{
    public OutsideTopRightTile()
    {
        Neighbor[,] rule ={{ Neighbor.Have, Neighbor.Have, Neighbor.DontCare },
                             { Neighbor.Have, Neighbor.Have, Neighbor.DontHave },
                             { Neighbor.DontCare, Neighbor.DontHave, Neighbor.DontCare }};
        Rule = rule;
    }
}

public class OutsideDownLeftTile : RulePattern
{
    public OutsideDownLeftTile()
    {
        Neighbor[,] rule =  {{ Neighbor.DontCare, Neighbor.DontHave, Neighbor.DontCare },
                             { Neighbor.DontHave, Neighbor.Have, Neighbor.Have },
                             { Neighbor.DontCare, Neighbor.Have, Neighbor.Have }};
        Rule = rule;
    }
}

public class OutsideDownRightTile : RulePattern
{
    public OutsideDownRightTile()
    {
        Neighbor[,] rule =  {{ Neighbor.DontCare, Neighbor.Have, Neighbor.Have },
                             { Neighbor.DontHave, Neighbor.Have, Neighbor.Have },
                             { Neighbor.DontCare, Neighbor.DontHave, Neighbor.DontCare }};
        Rule = rule;
    }
}

public class InsideTopLeftTile : RulePattern
{
    public InsideTopLeftTile()
    {
        Neighbor[,] rule = {{ Neighbor.Have, Neighbor.Have, Neighbor.Have },
                             { Neighbor.Have, Neighbor.Have, Neighbor.Have },
                             { Neighbor.DontHave, Neighbor.Have, Neighbor.Have }};
        Rule = rule;
    }
}

public class InsideTopRightTile : RulePattern
{
    public InsideTopRightTile()
    {
        Neighbor[,] rule ={{ Neighbor.DontHave, Neighbor.Have, Neighbor.Have },
                             { Neighbor.Have, Neighbor.Have, Neighbor.Have },
                             { Neighbor.Have, Neighbor.Have, Neighbor.Have }};
        Rule = rule;
    }
}

public class InsideDownLeftTile : RulePattern
{
    public InsideDownLeftTile()
    {
        Neighbor[,] rule =  {{ Neighbor.Have, Neighbor.Have, Neighbor.Have },
                             { Neighbor.Have, Neighbor.Have, Neighbor.Have },
                             { Neighbor.Have, Neighbor.Have, Neighbor.DontHave }};
        Rule = rule;
    }
}

public class InsideDownRightTile : RulePattern
{
    public InsideDownRightTile()
    {
        Neighbor[,] rule =  {{ Neighbor.Have, Neighbor.Have, Neighbor.DontHave },
                             { Neighbor.Have, Neighbor.Have, Neighbor.Have },
                             { Neighbor.Have, Neighbor.Have, Neighbor.Have }};
        Rule = rule;
    }
}
