using Godot;
using System;
using Godot.Collections;

public class BaseCraftingMaterials : Resource
{
    [Export]
    public string name { get; private set; } = "BaseCraftingMaterial";

    [Export]
    public int ingotCost { get; private set; } = 5;

    [Export]
    public Materials.MaterialType materialType { get; private set; } = Materials.MaterialType.Undefined;

    [Export]
    public Color tint = new Color(0,0,0,0);

    public TextureRect sprite = new TextureRect();

    [Export(PropertyHint.Enum)]
    public Dictionary<Pieces.PieceType,Array<Materials.MaterialStatData>> materialProperties;
    
    public BaseCraftingMaterials()
    {
        materialProperties = new Dictionary<Pieces.PieceType,Array<Materials.MaterialStatData>>();
        materialProperties[Pieces.PieceType.Medium_Blade] = new Array<Materials.MaterialStatData>();
        materialProperties[Pieces.PieceType.Medium_Blade].Add(new Materials.MaterialStatData(Materials.MaterialStatType.Damage, 5));
    }

    public BaseCraftingMaterials(string _name, int _ingotCost, Materials.MaterialType _materialType, Color _tint) 
    {
        materialProperties = new Dictionary<Pieces.PieceType,Array<Materials.MaterialStatData>>();
        
        name = _name;
        ingotCost = _ingotCost;
        materialType = materialType;
        tint = _tint;
    }
}

namespace Materials
{
    //Each material is linked to a tint
    public enum Material
    {
        Undefined,
        Iron,
        Bronze,
        Copper,
        Tin,
        Steel,
        Gold,
        Platinum,
        Adamantite,
        Mithril,
        Cobalt,
        Darksteel,
        Titanium,
    }

    public enum MaterialType
    {
        Undefined,
        Metal,
        Wood,
        String,
    }

    public enum MaterialStatType
    {
        Undefined,
        Damage,
        CritChange,
        CritDamage,
        AttackSpeed,
        Health,
    }

    //Material Stat Data Piece
    public class MaterialStatData : Resource
    {
        public MaterialStatData(MaterialStatType _statType, int _statData){statType = _statType;statData = _statData;}

        [Export]
        public MaterialStatType statType = MaterialStatType.Undefined;

        [Export]
        public int statData = 0;
    }
}

//TODO Move this to a PiecesEnum.cs and generate that code from a list of .png files inside of the My_Art/Parts folder 
namespace Pieces
{
    //Going to use enums to simplify the number of classes + adding more types of pieces can be data read into the piece data type instead of some RTTI/CTTI
    public enum PieceType
    {
        Undefined,
        Large_Blade,
        Medium_Blade,
        Small_Blade,
        Large_Guard,    //Art Todo
        Medium_Guard,          
        Small_Guard,
        Large_Handle,
        Medium_Handle,
        Small_Handle,
        Pommel,
        Tool_Head,
        Tool_Crossing,
        Tool_Handle,
    //    HammerHead,     //Art Todo
    //    BattleaxeHead,  //Art Todo
    //    LargeGuard,     //Art Todo
    //    MediumHandle,   //Art Todo
//        Medium_MaceHead,

    }
    //Pickaxe is {LargeHandle, ToolBinding, PickaxeHead}
    //Axe is {LargeHandle, ToolBinding, AxeHead}
    //Dagger is {Pommel, Small Handle, Small Guard, Small Blade}
    //Sword is a {Pommel, Small Handle, Medium Guard, Medium Blade}

}


