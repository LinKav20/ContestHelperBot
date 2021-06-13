using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ContestBot.Commands
{
    public class GetMyIdCommand : Command
    {
        public override string Name { get; set; } = "/getmyid";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, $"Your id {message.From.Id}");
        }
    }
}
