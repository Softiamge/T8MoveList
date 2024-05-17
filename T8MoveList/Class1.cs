using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace T8MoveList
{
    
    public class Move
    {
        public string? GUID { get; set;  }
        
        public string? CharacterId { get; set; }

        public string? StanceName { get; set; }

        public bool? HeatEngage { get; set; }
        public bool? HeatSmash { get; set; }
        public bool? PowerCrush { get; set; }
        public bool? Throw { get; set; }
        public bool? Homing { get; set; }
        public bool? Tornado { get; set; }
        public bool? HeatBurst { get; set; }
        public bool? RequiresHeat  { get; set; } 
        public string? Command { get; set; }
        public string? HitLevel { get; set; }
        public string? Damage { get; set; }
        public string? StartUpFrame { get; set; }
        public string? BlockFrame { get; set; }
        public string? HitFrame { get; set; }
        public string? CounterHitFrame { get; set; }
        public string? Notes { get; set; }

        internal Dictionary<string, string> stances = 
            new Dictionary<string, string>()
        {
            { "BKP", "Backup"},
            { "SBT", "Boot"},
            { "DBT", "Dual Boot"},
            { "DES", "Destructive Form"},
            { "NWG", "Naniwa Gusto"},
            { "LIB", "Libertador"},
            { "SLS", "Slither step"},
            { "SWA", "Sway"},
            { "SNE", "Snake eyes"},
            { "STB", "Starburst"},
            { "FLY", "Fly"},
            { "MCR", "Mourning crow"},
            { "SNK", "Sneak"},
            { "HSP", "Bananeira"},
            { "RLX", "Negativa"},
            { "MD1", "Mandinga 1"},
            { "MD2", "Mandinga 2"},
            { "KNP", "Deceptive step"},
            { "STC", "Shiting Clouds"},
            { "RFF", "Right stance"},
            { "LFS", "Left flamingo stance"},
            { "RFS", "Right flamingo stance"},
            { "GMC", "Gamma Charge"},
            { "GMH", "Gamma Howl"},
            { "SIT", "Sitdown"},
            { "ZEN", "Zenshin"},
            { "GEN", "Genjitsu"},
            { "IZU", "Izumo"},
            { "MIA", "Miare"},
            { "DVK", "Devil form"},
            { "JGR", "Jaguar Run"},
            { "JGS", "Jaguar step"},
            { "HBS", "Hunting bear"},
            { "ROL", "Roll"},
            { "DEN", "Dynamic entry"},
            { "SEN", "Silent entry / Sentai"},
            { "LEN", "Limited entry"},
            { "DSS", "Dragon stance"},
            { "HMS", "Hitman"},
            { "MS", "Mist step"},
            { "KNK", "Jin Ji Du Li"},
            { "BOK", "Fo Bu"},
            { "HRM", "Hermit"},
            { "DEW", "Dew glide"},
            { "RAB", "Feisty rabbit"},
            { "CS", "Comorant step"},
            { "DPD", "Deep Dive"},
            { "SZN", "Soulzone"},
            { "UNS", "Unsoku"},
            { "WDS", "Wind step"},
            { "WGS", "Wind God Step"},
            { "WRA", "Heavens wrath"},
            { "DCK", "Duck"},
            { "EXD", "Ducking In"},
            { "FLK", "Flicker"},
            { "LNH", "Lionheart"},
            { "LWV", "ducking left"},
            { "RWV", "ducking right"},
            { "PAB", "Peekaboo"},
            { "SWY", "Swaying"},
            { "TFA", "Two faced"},
            { "IAI", "Iai stance"},
            { "PRF", "Perfumer"},
            { "AOP", "Phoenix"},
            { "HYP", "Hypnotist"},
            { "DGF", "Dragonfly"},
            { "FLE", "Flea"},
            { "IND", "Indian stance"},
            { "MED", "Meditation"},
            { "KIN", "KINCHO"},
            { "NSS", "no sword stance"},
            { "BDS", "Bad stomach"},
            { "MNT", "Mantis"},
            { "SCR", "Scarecrow"},
            { "TRT", "Tarantula"},
        };



        internal bool stb(string? str)
        {
            switch (str)
            {
                case "0": return false;
                case "1": return true;
                default: return false;
            }
        }
        public Move() { }
        public Move(string? guid)
        { GUID = guid;}
        public Move(string? gUID, string? characterId, string? stanceName, string? heatEngage, string? heatSmash, string? powerCrush, string? @throw, string? homing, string? tornado, string? heatBurst, string? requiresHeat, string? command, string? hitLevel, string? damage, string? startUpFrame, string? blockfr, string? hitfr, string? chfr, string? note)
        { 
            GUID = gUID;
            CharacterId = characterId;
            StanceName = stanceName;
            HeatEngage = stb(heatEngage);
            HeatSmash = stb(heatSmash);
            PowerCrush = stb(powerCrush);
            Throw = stb(@throw);
            Homing = stb(homing);
            Tornado = stb(tornado);
            HeatBurst = stb(heatBurst);
            RequiresHeat = stb(requiresHeat);
            Command = command;
            HitLevel = hitLevel;
            Damage = damage;
            StartUpFrame = startUpFrame;
            BlockFrame = blockfr;
            HitFrame = hitfr;
            CounterHitFrame = chfr;
            Notes = note;
        }
        public Move(string[] args)
        {
            GUID = args[0];
            CharacterId = args[1];
            StanceName = args[2];
            HeatEngage = stb(args[3]);
            HeatSmash = stb(args[4]);
            PowerCrush = stb(args[5]);
            //Throw = stb(args[6]);

            Homing = stb(args[7]);
            Tornado = stb(args[8]);
            HeatBurst = stb(args[9]);
            RequiresHeat = stb(args[10]);
            Command = args[11];
            HitLevel = args[12];
            Damage = args[13];
            StartUpFrame = args[14];
            BlockFrame = args[15];
            HitFrame = args[16];
            CounterHitFrame = args[17];
            Notes = args[18];
            Throw = IsThrow();
            StanceName = GetStanceName(Command);



        }
        public bool IsThrow()
        {
            bool res = false;
            if (HitLevel.Contains("th") || HitLevel.Contains("t")) { res = true; }

            return res;
        }
        public string? GetStanceName(string com)
        {
            foreach (var entry in stances) 
            {
                if (com.StartsWith(entry.Key)|| com.StartsWith("h."+entry.Key))
                { return entry.Value;};
            }
            return null;
        }

    }

}
