using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;

    public abstract class IMessageHandler
    {
        public delegate void BeforeMessageRecieved();
        public BeforeMessageRecieved beforeMessageRecieved;

        public delegate void AfterMessageRecieved();
        public AfterMessageRecieved afterMessageRecieved;

        public void HandleMessage(ISFSObject data)
        {
            if (beforeMessageRecieved != null)
            {
                beforeMessageRecieved();
            }
            OnHandleMessage(data);
            if (afterMessageRecieved != null)
            {
                afterMessageRecieved();
            }
        }

        public abstract void OnHandleMessage(ISFSObject data);
    }
