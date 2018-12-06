using System.Collections.Generic;
using PushAPI.Infrastructure.Enums;

namespace PushAPI.Infrastructure.Helpers
{
    public static class ListHelpers
    {
        public static void AddMessage(this List<Message<MessageType, string>> obj, MessageType type, string value)
        {
            obj.Add(new Message<MessageType, string>(type, value));
        }
    }
}