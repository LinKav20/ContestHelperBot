using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ContestBot.Commands
{
    class ShowAllContestsCommand : Command
    {
        public override string Name { get; set; } =  "/showallcontests" ;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string res = "*-- ALL CONTESTS --*\n\n";
            if (Program.contests.Count > 0)
            {
                foreach (var c in Program.contests)
                {
                    res += $"{Program.contests.IndexOf(c)}) " + c.ToString() + '\n';
                }
            }
            else
                res = "No contests here :(";
            await client.SendTextMessageAsync(message.Chat.Id, res);
        }
    }
}
