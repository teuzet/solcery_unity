using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Grimmz
{
    [CreateAssetMenu(menuName = "Grimmz/Bricks/BrickConfigs", fileName = "BrickConfigs")]
    public class BrickConfigs : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<BrickType, List<BrickConfig>> ConfigsByType = new Dictionary<BrickType, List<BrickConfig>>();

        public List<BrickConfig> GetConfigsByType(BrickType brickType)
        {
            if (ConfigsByType.TryGetValue(brickType, out var datas))
            {
                return datas;
            }

            return null;
        }

        public List<SubtypeNameConfig> GetConfigSubtypeNamesByType(BrickType brickType)
        {
            var configsOfType = GetConfigsByType(brickType);

            if (configsOfType != null && configsOfType.Count > 0)
            {
                var names = new List<SubtypeNameConfig>();

                foreach (var config in configsOfType)
                {
                    var name = brickType switch
                    {
                        BrickType.Action => Enum.GetName(typeof(BrickSubtypeAction), config.Subtype),
                        BrickType.Condition => Enum.GetName(typeof(BrickSubtypeCondition), config.Subtype),
                        _ => Enum.GetName(typeof(BrickSubtypeValue), config.Subtype)
                    };

                    names.Add(new SubtypeNameConfig(config.Subtype, name, config));
                }

                return names;
            }

            return null;
        }

        public int GetSubtypeIndex(BrickType brickType, Enum subType)
        {
            return brickType switch
            {
                BrickType.Action => (int)((BrickSubtypeAction)subType),
                BrickType.Condition => (int)((BrickSubtypeCondition)subType),
                BrickType.Value => (int)((BrickSubtypeValue)subType),
                _ => (int)((BrickSubtypeValue)subType)
            };
        }
    }

    public struct SubtypeNameConfig
    {
        public Enum Subtype;
        public string Name;
        public BrickConfig Config;

        public SubtypeNameConfig(Enum subtype, string name, BrickConfig config)
        {
            Subtype = subtype;
            Name = name;
            Config = config;
        }
    }
}
