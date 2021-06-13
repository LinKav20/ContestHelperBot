using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ContestBot.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; set; }
        public abstract void Execute(Message message, TelegramBotClient client);
        public bool Contains(string command)
        {
            return Name == command;
        }
    }
}
