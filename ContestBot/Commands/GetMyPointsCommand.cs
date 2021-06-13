using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ContestBot.Commands
{
    class GetMyPointsCommand : Command
    {
        public override string Name { get; set; } = "/points";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            if (Program.users.ContainsKey(message.From.Id.ToString() + " " + message.From.Username))
                await client.SendTextMessageAsync(message.Chat.Id, 
                    $"You have {Program.users[message.From.Id.ToString() +" "+ message.From.Username]} points!");
            else
                await client.SendTextMessageAsync(message.Chat.Id,
                    $"You aren't in database \U0001F633");
        }
    }
}
