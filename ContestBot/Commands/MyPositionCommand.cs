using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ContestBot.Commands
{
    class MyPositionCommand : Command
    {
        public override string Name { get; set; } = "/myposition";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            if (Program.choosenTest >= 0)
            {
                await client.SendTextMessageAsync(message.Chat.Id,
                    $"Now you are in {Program.contests[Program.choosenContest].Name} " +
                    $"task {Program.contests[Program.choosenContest].tasks[Program.choosenTask].Name} " +
                    $"test {Program.contests[Program.choosenContest].tasks[Program.choosenTask].tests[Program.choosenTest]}");
            }
            else if (Program.choosenTask >= 0)
            {
                await client.SendTextMessageAsync(message.Chat.Id,
                    $"Now you are in {Program.contests[Program.choosenContest].Name} " +
                    $"task {Program.contests[Program.choosenContest].tasks[Program.choosenTask].Name}");
            }
            else if (Program.choosenContest >= 0)
            {
                await client.SendTextMessageAsync(message.Chat.Id,
                    $"Now you are in {Program.contests[Program.choosenContest].Name}");
            }
            else
            {
                await client.SendTextMessageAsync(message.Chat.Id, $"Now you are in main!");
            }
        }
    }
}
