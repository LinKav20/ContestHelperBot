using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Contest;

namespace ContestBot.Commands
{
    class CreateTestCommand : Command
    {
        public override string Name { get; set; } = "/addtest";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            if (!(Program.choosenContest < 0 || Program.choosenTask < 0))
            {
                string[] input = message.Text.Split();
                if (input.Length == 2)
                {
                    Contest.Warning war = Warning.CE;
                    int num = -1;
                    try
                    {
                        war = Enum.Parse<Warning>(input[1].Substring(input[1].Length - 2).ToUpper());
                        num = Convert.ToInt32(input[1].Substring(0, input[1].Length - 2));
                    }
                    catch
                    {
                        try
                        {
                            war = Enum.Parse<Warning>(input[1].Substring(0, 2).ToUpper());
                            num = Convert.ToInt32(input[1].Substring(2, input[1].Length - 2));
                        }
                        catch
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, $"Incorrect params");
                        }
                    }
                    Test test = new Test(war, num, Program.choosenTask);
                    if (Program.contests[Program.choosenContest].tasks[Program.choosenTask].tests.Contains(test))
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, $"The test {num}{war} is already exists");
                    }
                    else
                    {
                        Program.contests[Program.choosenContest].tasks[Program.choosenTask].tests.Add(new Test(war, num, Program.choosenTask));
                        await client.SendTextMessageAsync(message.Chat.Id, $"The test {num}{war} was successfully created!");
                    }
                }
                else
                    await client.SendTextMessageAsync(message.Chat.Id, $"Incorrect params");
            }
            else
                await client.SendTextMessageAsync(message.Chat.Id, $"I don't understand where to add the test :(");
        }
    }
}
