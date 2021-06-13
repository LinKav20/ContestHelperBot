using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ContestBot.Commands
{
    class AddSolutionCommand : Command
    {
        public override string Name { get; set; } = "/addsolution";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            if (Program.choosenContest >= 0 && Program.choosenTask >= 0 && Program.choosenTest >= 0)
            {
                string[] input = message.Text.Split();
                string solution = "";
                if (input.Length > 1)
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        solution += input[i] + " ";
                    }
                    Program.contests[Program.choosenContest].tasks[Program.choosenTask].tests[Program.choosenTest].Solutions.Add(solution);
                    Program.users[message.From.Id.ToString() + " " + message.From.Username]++;
                    await client.SendTextMessageAsync(message.Chat.Id, $"Solution was successfully added!\nYou got one point \U0001F973");
                }
                else
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"Solutionis is empty :(");
                }
            }
            else
            {
                await client.SendTextMessageAsync(message.Chat.Id, $"I don't understand where to add the solution :(");
            }
        }
    }
}
