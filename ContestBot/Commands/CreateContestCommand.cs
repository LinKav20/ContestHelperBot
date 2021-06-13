using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Contest;

namespace ContestBot.Commands
{
    class CreateContestCommand : Command
    {
        public override string Name { get; set; } = "/addcontest";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string[] input = message.Text.Split();
            if (input.Length == 3 || input.Length == 2)
            {
                ConTest c = new ConTest();
                if (input.Length == 3)
                    c = new ConTest(input[1], input[2], Program.contests.Count);
                if (input.Length == 2)
                    c = new ConTest(input[1], Program.contests.Count);
                if (Program.contests.Contains(c))
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"The contest {input[1]} is already exists!");
                }
                else
                {
                    Program.contests.Add(c);
                    await client.SendTextMessageAsync(message.Chat.Id, $"The contest {input[1]} was successfully created!");
                }
            }
            else
                await client.SendTextMessageAsync(message.Chat.Id, $"Incorrect number of parametrs");
        }
    }
}
