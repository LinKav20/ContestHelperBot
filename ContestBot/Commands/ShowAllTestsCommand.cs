using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ContestBot.Commands
{
    class ShowAllTestsCommand : Command
    {
        public override string Name { get; set; } = "/showalltests";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            if (Program.choosenContest >= 0 && Program.choosenTask>=0)
            {
                string allTests = "*-- ALL TESTS --*\n\n";
                if (Program.contests[Program.choosenContest].tasks[Program.choosenTask].GetAllTests().Count > 0)
                {
                    foreach (var test in Program.contests[Program.choosenContest].tasks[Program.choosenTask].GetAllTests())
                    {
                        allTests += $"{Program.contests[Program.choosenContest].tasks[Program.choosenTask].GetAllTests().IndexOf(test)}) "+ test.ToString() + '\n';
                    }
                }
                else allTests += "No tests here :(";
                await client.SendTextMessageAsync(message.Chat.Id, allTests);
            }
            else
                await client.SendTextMessageAsync(message.Chat.Id, $"I don't understand where it is");
        }
    }
}
