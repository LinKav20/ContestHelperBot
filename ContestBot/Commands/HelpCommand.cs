using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ContestBot.Commands
{
    class HelpCommand : Command
    {
        public override string Name { get; set; } = "/help";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string help = Program.help + "✨ Well done ✨";
            await client.SendTextMessageAsync(message.Chat.Id, help);
        }
    }
}
