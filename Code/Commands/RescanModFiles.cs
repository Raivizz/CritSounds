using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CritSounds.Commands
{
    public class RescanModFilesCommand : ModCommand
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "csrescan"; }
        }

        public override string Usage
        {
            get { return "/csrescan"; }
        }

        public override string Description
        {
            get { return "Manually rescan mod folders for new sound files."; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            CritSFXHandler checkobject = new CritSFXHandler();
            checkobject.CheckDirectoriesForMods();
            Main.NewText("Directories scanned succesfully.");
        }
    }
}