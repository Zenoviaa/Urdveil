using Urdveil.Common.ArmorReforge;
using Urdveil.Common.QuestSystem;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Urdveil.Helpers
{
    public static class LangText
    {
        public static string Quest(Quest quest, string Path)
        {
            return Language.GetTextValue($"Mods.Urdveil.Quests.{quest.Name}." + Path);
        }

        public static string TownDialogue(string Path)
        {
            return Language.GetTextValue($"Mods.Urdveil.TownDialogue." + Path);
        }

        public static string Chat(ModNPC npc, string Path)
        {
            return Language.GetTextValue($"Mods.Urdveil.NPCs.{npc.Name}." + Path);
        }
        public static string Chat(ModNPC npc, string Path, object arg0)
        {
            return Language.GetTextValue($"Mods.Urdveil.NPCs.{npc.Name}." + Path, arg0);
        }
        public static string Item(ModItem item, string Path)
        {
            return Language.GetTextValue($"Mods.Urdveil.Items.{item.Name}." + Path);
        }
        public static string Item(ModItem item, string Path, object arg0)
        {
            return Language.GetTextValue($"Mods.Urdveil.Items.{item.Name}." + Path, arg0);
        }

        public static LocalizedText CreateBestiary(ModNPC npc, string Text, string key = null)
        {
            return Language.GetOrRegister($"Mods.Urdveil.NPCs.{npc.Name}.Bestiary" + key, () => Text);
        }
        /// <summary>
        /// OrginText doesn't influence anything.
        /// You should edit Mods.Urdveil.NPCs.hjson instead of OrginText.
        /// </summary>
        /// <param name="OrginText"></param>
        /// <returns></returns>
        public static string Bestiary(ModNPC npc, string OrginText, string key = null)
        {
            //return (string)Language.GetOrRegister($"Mods.Urdveil.NPCs.{npc.Name}.Bestiary" + key, () => OrginText);
            return Language.GetTextValue($"Mods.Urdveil.NPCs.{npc.Name}.Bestiary" + key, OrginText);
        }
        public static string ArmorShopClass(ModItem item, string key = null, object arg0 = null)
        {
            return Language.GetTextValue($"Mods.Urdveil.ArmorShop.{item.Name}", arg0);
        }
        public static string ArmorReforge(ArmorReforgeType type, string Path, object arg0 = null)
        {
            return Language.GetTextValue($"Mods.Urdveil.ArmorReforge.{type.ToString()}." + Path, arg0);
        }

        public static string Common(string Path, object arg0 = null)
        {
            return Language.GetTextValue("Mods.Urdveil.Items.Common." + Path, arg0);
        }
        public static string Special(ModItem item, string key = null, object arg0 = null)
        {
            return Language.GetTextValue($"Mods.Urdveil.Items.{item.Name}.Special" + key, arg0);
        }
        public static string SetBonus(ModItem item)
        {
            return Language.GetTextValue($"Mods.Urdveil.Items.SetBonus.{item.Name}");
        }

        public static string Misc(string key)
        {
            return Language.GetTextValue("Mods.Urdveil.Misc." + key);
        }
    }
}