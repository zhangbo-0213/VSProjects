using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannel
{
    public class SimpleDuplexSessionChannel : ChannelBase, IDuplexSessionChannel
    {
        private IDuplexSessionChannel _innerChannel;
        public SimpleDuplexSessionChannel(ChannelManagerBase channelManager,IDuplexSessionChannel innerChannel) : base(channelManager)
        {
            PrintHelper.Print(this,"SimpleDuplexSessionChannel");
            this._innerChannel = innerChannel;
        }

        protected override void OnAbort()
        {
            PrintHelper.Print(this,"OnAbort");
            this._innerChannel.Abort();
        }

        protected override void OnClose(TimeSpan timeout)
        {
            PrintHelper.Print(this,"OnClose");
            this._innerChannel.Close();
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            PrintHelper.Print(this,"OnEndClose");
            this._innerChannel.EndClose(result);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"OnBeginClose");
            return this._innerChannel.BeginClose(timeout, callback, state);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            PrintHelper.Print(this,"OnOpen");
            this._innerChannel.Open(timeout);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginOpen");
            return this._innerChannel.BeginOpen(timeout,callback,state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            PrintHelper.Print(this,"EndOpen");
            this._innerChannel.EndOpen(result);
        }

        public Message Receive()
        {
            PrintHelper.Print(this,"Receive");
            return this._innerChannel.Receive();
        }

        public Message Receive(TimeSpan timeout)
        {
            PrintHelper.Print(this,"Receive");
            return this._innerChannel.Receive(timeout);
        }

        public IAsyncResult BeginReceive(AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginReceive");
            return this._innerChannel.BeginReceive(callback, state);
        }

        public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginReceive");
            return this._innerChannel.BeginReceive(timeout, callback, state);
        }

        public Message EndReceive(IAsyncResult result)
        {
            PrintHelper.Print(this,"EndReceive");
            return this._innerChannel.EndReceive(result);
        }

        public bool TryReceive(TimeSpan timeout, out Message message)
        {
            PrintHelper.Print(this,"TryReceive");
            return this._innerChannel.TryReceive(timeout, out message);
        }

        public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginTryReceive");
            return this._innerChannel.BeginTryReceive(timeout, callback, state);
        }

        public bool EndTryReceive(IAsyncResult result, out Message message)
        {
            PrintHelper.Print(this,"EndTryReceive");
            return this._innerChannel.EndTryReceive(result, out message);
        }

        public bool WaitForMessage(TimeSpan timeout)
        {
            PrintHelper.Print(this,"WaitForMessage");
            return this._innerChannel.WaitForMessage(timeout);
        }

        public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginWaitForMessage");
            return this._innerChannel.BeginWaitForMessage(timeout, callback, state);
        }

        public bool EndWaitForMessage(IAsyncResult result)
        {
            PrintHelper.Print(this,"EndWaitForMessage");
            return this._innerChannel.EndWaitForMessage(result);
        }

        public EndpointAddress LocalAddress {
            get
            {
                PrintHelper.Print(this,"LocalAddress");
                return this._innerChannel.LocalAddress;
            }
        }
        public void Send(Message message)
        {
            PrintHelper.Print(this,"Send");
            this._innerChannel.Send(message);
        }

        public void Send(Message message, TimeSpan timeout)
        {
            PrintHelper.Print(this,"Send");
            this._innerChannel.Send(message,timeout);
        }

        public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginSend");
            return this._innerChannel.BeginSend(message, callback, state);
        }

        public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginSend");
            return this._innerChannel.BeginSend(message, callback, state);
        }

        public void EndSend(IAsyncResult result)
        {
            PrintHelper.Print(this,"EndSend");
            this._innerChannel.EndSend(result);
        }

        public EndpointAddress RemoteAddress {
            get
            {
                PrintHelper.Print(this,"RemoteAddress");
                return this._innerChannel.RemoteAddress;
            }
        }
        public Uri Via {
            get
            {
                PrintHelper.Print(this,"Via");
                return this._innerChannel.Via;
            }
        }
        public IDuplexSession Session {
            get
            {
                PrintHelper.Print(this,"Session");
                return this._innerChannel.Session;
            }
        }

        public override T GetProperty<T>()
        {
            return this._innerChannel.GetProperty<T>();
        }
    }
}
