using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.Enums;

namespace ContestBot.Commands
{
    class MoveForwardCommand : Command
    {
        public override string Name { get; set; } = "/goto";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            if (Program.choosenContest < 0)
            {
                string[] input = message.Text.Split();
                if (input.Length > 1 && int.TryParse(input[1], out int choice)
                    && choice > -1 && choice < Program.contests.Count)
                {
                    Program.choosenContest = choice;
                    await client.SendTextMessageAsync(message.Chat.Id,
                        $"Now you are in *{Program.contests[Program.choosenContest].Name}*", ParseMode.Markdown);
                }
                else
                    await client.SendTextMessageAsync(message.Chat.Id, $"And nowhere to go...", ParseMode.Markdown);
                
            } 
            else if (Program.choosenTask < 0)
            {
                string[] input = message.Text.Split();
                if (input.Length > 1 && int.TryParse(input[1], out int choice)
                    && choice > -1 && choice < Program.contests[Program.choosenContest].tasks.Count)
                {
                    Program.choosenTask = choice;
                    await client.SendTextMessageAsync(message.Chat.Id,
                        $"Now you are in *{Program.contests[Program.choosenContest].Name}* task " +
                        $"*{Program.contests[Program.choosenContest].tasks[Program.choosenTask].Name}*");
                }
                else await client.SendTextMessageAsync(message.Chat.Id, $"And nowhere to go...");
            }
            else if (Program.choosenTest < 0)
            {
                string[] input = message.Text.Split();
                if (input.Length > 1 && int.TryParse(input[1], out int choice)
                    && choice > -1 && 
                    choice < Program.contests[Program.choosenContest].tasks[Program.choosenTask].tests.Count)
                {
                    Program.choosenTest = choice;
                    List<string> solutions = Program.contests[Program.choosenContest].tasks[Program.choosenTask].tests[Program.choosenTest].Solutions;
                   
                    await client.SendTextMessageAsync(message.Chat.Id,
                        $"Now you are in *{Program.contests[Program.choosenContest].Name}* task " +
                        $"*{Program.contests[Program.choosenContest].tasks[Program.choosenTask].Name}* test " +
                        $"*{Program.contests[Program.choosenContest].tasks[Program.choosenTask].tests[Program.choosenTest]}*");
                    foreach (var solution in solutions)
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, $"### Solution {solutions.IndexOf(solution)}\n\n{solution}");
                    }
                }
                else await client.SendTextMessageAsync(message.Chat.Id, $"And nowhere to go...");
            }
            else
            {
                await client.SendTextMessageAsync(message.Chat.Id, $"No steps forward");
            }
        }
    }
}
