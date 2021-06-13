using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace ContestBot.Commands
{
    class CreateTaskCommand : Command
    {
        public override string Name { get; set; } = "/addtask";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string[] input = message.Text.Split();
            if (input.Length > 1)
            {
                if (Program.choosenContest >= 0)
                {
                    string name = "";
                    for (int i = 1; i < input.Length; i++)
                        name += input[i] + " ";
                    Program.contests[Program.choosenContest].AddNewTask(name);
                    await client.SendTextMessageAsync(message.Chat.Id, $"The task {name} was " +
                   $"successfully added in contest {Program.contests[Program.choosenContest].Name}!");
                }
                else
                    await client.SendTextMessageAsync(message.Chat.Id, $"I don't understand where to add the task :(");
            }
            else
                await client.SendTextMessageAsync(message.Chat.Id, $"Incorrect params");
        }
    }
}
