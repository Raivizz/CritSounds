using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CritSounds.Commands
{
    public class ReloadConfigCommand : ModCommand
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "csreload"; }
        }

        public override string Usage
        {
            get { return "/csreload"; }
        }

        public override string Description
        {
            get { return "Manually reload Crit Sounds' configuration file"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Config.Load();
            Main.NewText("Crit Sounds' configuration file reloaded succesfully!");
        }
    }
}