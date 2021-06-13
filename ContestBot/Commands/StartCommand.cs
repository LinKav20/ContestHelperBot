using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ContestBot.Commands
{
    class StartCommand : Command
    {
        public override string Name { get; set; } = "/start";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            if (!Program.users.ContainsKey(message.From.Id.ToString() + " " + message.From.Username))
                Program.users.Add(message.From.Id.ToString() + " " + message.From.Username, 0);

            string hi = "Welcome!\U0001F609 \n" +
                "There is a database of contests and tasks stored here, so I can help you " +
                "if you have any difficulties with the task.\n\n" +
                "_Where do I get the solutions?_ \nYour friends fill in the database when they" +
                " have solutions to queries. You can also add solutions and get points for it!\n\n" + Program.help +
                "\n\nGood luck solving contests\U0001F618";

            await client.SendTextMessageAsync(message.Chat.Id, hi);
        }
    }
}
