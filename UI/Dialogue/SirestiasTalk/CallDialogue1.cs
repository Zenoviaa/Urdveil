namespace Urdveil.UI.Dialogue
{
    internal class CallDialogue1 : Dialogue
    {
        //The number of steps in this dialogue
        public override int Length => 1;

        public override void Next(int index)
        {
            base.Next(index);

            //This starts the dialogue
            switch (index)
            {
                case 0:
                    //Set the texture of the portrait
                    DialogueSystem.SetPortrait("Urdveil/UI/Dialogue/SirestiasDialoguePortrait");

                    //Put your dialogue in Mods.Urdveil.Dialogue.hjson, then get it like this
                    DialogueSystem.WriteText(GetLocalizedText("SirestiasTalk1"));
                    break;

            }
        }

        public override void Update(int index)
        {
            base.Update(index);
            //If you want stuff to happen while they're talking you can do it here ig
            //But that might not be a good idea since you can just speed through dialogues
        }

        public override void Complete()
        {

            //Do something when the dialogue is completely finished


            base.Complete();
        }




    }
}
