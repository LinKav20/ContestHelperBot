using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ContestBot.Commands
{
    class MoveBackCommand : Command
    {
        public override string Name { get; set; } = "/goback";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            if (Program.choosenTest >= 0)
            {
                Program.choosenTest = -1;
                await client.SendTextMessageAsync(message.Chat.Id,
                    $"Now you are in {Program.contests[Program.choosenContest].Name} " +
                    $"task {Program.contests[Program.choosenContest].tasks[Program.choosenTask].Name}");
            }
            else if (Program.choosenTask >= 0)
            {
                Program.choosenTask = -1;
                await client.SendTextMessageAsync(message.Chat.Id, 
                    $"Now you are in {Program.contests[Program.choosenContest].Name}");
            }
            else if (Program.choosenContest >= 0)
            {
                Program.choosenContest = -1;
                await client.SendTextMessageAsync(message.Chat.Id, $"Now you are in *main*!");
            }
            else
            {
                await client.SendTextMessageAsync(message.Chat.Id, $"No steps back :(");
            }
        }
    }
}
