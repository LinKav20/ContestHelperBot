using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ContestBot.Commands
{
    class GetTopUsersCommand : Command
    {
        public override string Name { get; set; } = "/rating";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string[] input = message.Text.Split();
            string rating = "";
            var forRating = Program.users.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int num = forRating.Count;
            if (input.Length > 1)
            {
                if (int.TryParse(input[1], out num) && num>0)
                {
                    Console.WriteLine("Well...");
                }
                else
                {
                    num = forRating.Count;
                }
            }
            rating += $"*TOP {num} USERS*\n";
            for (int i = 0; i < Math.Min(num, forRating.Count); i++)
            {
                switch (i)
                {
                    case 0:
                        rating += "\U0001F947 ";
                        break;
                    case 1:
                        rating += "\U0001F948 ";
                        break;
                    case 2:
                        rating += "\U0001F949 ";
                        break;
                    default:
                        rating += $"{i + 1}) ";
                        break;
                }
                rating += $"{forRating.ElementAt(i).Key.Split()[1]} with {forRating.ElementAt(i).Value} point(s)\n";
            }
            await client.SendTextMessageAsync(message.Chat.Id, rating);
        }
    }
}
