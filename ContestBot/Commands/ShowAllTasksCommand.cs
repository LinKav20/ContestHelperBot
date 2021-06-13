using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ContestBot.Commands
{
    class ShowAllTasksCommand : Command
    {
        public override string Name { get; set; } = "/showalltasks";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string[] input = message.Text.Split();
            if (input.Length > 1)
            {
                if (int.TryParse(input[1], out int interestedContest)
                    && interestedContest >= 0 && interestedContest < Program.contests.Count)
                {
                    string allTasks = "*-- ALL TASKS --*\n";
                    if (Program.contests[interestedContest].tasks.Count > 0)
                    {
                        foreach (var task in Program.contests[interestedContest].tasks)
                        {
                            allTasks += task.ToString() + '\n';
                        }
                    }
                    else allTasks += "No tasks";
                    await client.SendTextMessageAsync(message.Chat.Id, allTasks);
                }
                else
                    await client.SendTextMessageAsync(message.Chat.Id, $":(");
            }
            else
            {
                if (Program.choosenContest >= 0)
                {
                    string allTasks = "*-- ALL TASKS --*\n\n";
                    if (Program.contests[Program.choosenContest].tasks.Count > 0)
                    {
                        foreach (var task in Program.contests[Program.choosenContest].tasks)
                        {
                            allTasks += task.ToString() + '\n';
                        }
                    }
                    else allTasks += "No tasks here :(";
                    await client.SendTextMessageAsync(message.Chat.Id, allTasks);
                }
                else
                    await client.SendTextMessageAsync(message.Chat.Id, $"I don't understand where it is");
            }
        }
    }
}
