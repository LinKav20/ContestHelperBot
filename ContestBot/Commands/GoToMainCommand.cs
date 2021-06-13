using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ContestBot.Commands
{
    class GoToMainCommand : Command
    {
        public override string Name { get; set; } = "/main";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            Program.choosenContest = -1;
            Program.choosenTask = -1;
            Program.choosenTest = -1;
            await  client.SendTextMessageAsync(message.Chat.Id, "Now you are in main!");
        }
    }
}
