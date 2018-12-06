using PushAPI.DAL.GenericEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PushAPI.DAL.Entities
{
    public class SystemMessage : Entity
    {
        public string MessageBody { get; set; }
    }
}
