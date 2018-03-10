using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FloorTileWithoutPartitionWalls))]
[CanEditMultipleObjects]
public class FloorTileWithoutPartitionWallsEditor : Editor
{
    public Texture2D currentTile;
    public Texture2D withTile;
    public Texture2D withoutTile;
    private Vector2 scrollView;
    private string[] description = new string[13];
    private const int partOfSchemeSize = 16;
    private const int lineSize = 60;

    void OnEnable() { SetDescriptions(); }

    void SetDescriptions()
    {
        description[0] = "Outside corner\nconnecting the top\nand left edge.";
        description[1] = "Top edge.";
        description[2] = "Outside corner\nconnecting the top\nand right edge.";
        description[3] = "Left edge.";
        description[4] = "Tile surrounded on\nall sides.";
        description[5] = "Right edge.";
        description[6] = "Outside corner\nconnecting the\nbottom and left\nedge.";
        description[7] = "Bottom edge.";
        description[8] = "Outside corner\nconnecting the\nbottom and right\nedge.";
        description[9] = "Inside corner\nconnecting the\nbottom and left\nedge.";
        description[10] = "Inside corner\nconnecting the\nbottom and right\nedge.";
        description[11] = "Inside corner\nconnecting the top\nand left edge.";
        description[12] = "Inside corner\nconnecting the top\nand right edge.";
    }

    public override void OnInspectorGUI()
    {
        scrollView = EditorGUILayout.BeginScrollView(scrollView, false, true);
        DrawTileSelectFields();
        for (int i = 0; i < 13; i++)
        {
            GUILayout.Space(60);
            DrawRuleSchemes(i);
            DrawDescriptions(i);
        }
        EditorGUILayout.EndScrollView();
    }

    void DrawTileSelectFields()
    {
        EditorGUI.BeginChangeCheck();
        for (int i = 0; i < 13; i++)
            ((FloorTileWithoutPartitionWalls)target).patterns[i].sprite = EditorGUI.ObjectField(new Rect(0, i * lineSize, 50, 50),
                    ((FloorTileWithoutPartitionWalls)target).patterns[i].sprite, typeof(Sprite), false) as Sprite;
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(target);
    }

    void DrawRuleSchemes(int index)
    {
        for (int x = 0; x <= 2; x++)
        {
            for (int y = 0; y <= 2; y++)
            {
                if (x == 1 && y == 1)
                    EditorGUI.DrawPreviewTexture(new Rect(ComputeRectX(x), ComputeRectY(y, index), partOfSchemeSize, partOfSchemeSize), currentTile);
                else
                {
                    Texture2D texture = ((FloorTileWithoutPartitionWalls)target).patterns[index].Rule[x, y] == Neighbor.Have ? withTile : withoutTile;
                    EditorGUI.DrawPreviewTexture(new Rect(ComputeRectX(x), ComputeRectY(y, index), partOfSchemeSize, partOfSchemeSize), texture);
                }
            }
        }
    }

    int ComputeRectX(int x) { return 60 + x * partOfSchemeSize; }
    int ComputeRectY(int y, int index)
    {
        int reverseOrder = 2 - y;
        return index * lineSize + reverseOrder * partOfSchemeSize;
    }

    void DrawDescriptions(int index)
    {
        EditorGUI.LabelField(new Rect(120, index * lineSize, 200, lineSize), description[index]);
    }
}