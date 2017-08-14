using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannel
{
    public class SimpleRequestChannel:ChannelBase,IRequestChannel
    {
        private IRequestChannel _innerChannel;

        public SimpleRequestChannel(ChannelManagerBase channelManager, IRequestChannel innnerChannel):base(channelManager)
        {
            PrintHelper.Print(this,"SimpleRequestChannel");
            this._innerChannel = innnerChannel;
        }

        protected override void OnAbort()
        {
            PrintHelper.Print(this,"OnAbort");
            this._innerChannel.Abort();
        }

        protected override void OnClose(TimeSpan timeout)
        {
            PrintHelper.Print(this, "OnClose");
            this._innerChannel.Close(timeout);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            PrintHelper.Print(this, "OnEndClose");
            this._innerChannel.EndClose(result);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this, "OnBeginClose");
            return this._innerChannel.BeginClose(timeout,callback,state);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            PrintHelper.Print(this, "OnOpen");
            this._innerChannel.Open(timeout);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this, "OnBeginOpen");
            return this._innerChannel.BeginOpen(timeout, callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            PrintHelper.Print(this, "OnEndOpen");
            this._innerChannel.EndOpen(result);
        }

        #region IRequestChannel Members
        public Message Request(Message message)
        {
            PrintHelper.Print(this,"Request");
            return this._innerChannel.Request(message);
        }

        public Message Request(Message message, TimeSpan timeout)
        {
            PrintHelper.Print(this, "Request");
            return this._innerChannel.Request(message,timeout);
        }

        public IAsyncResult BeginRequest(Message message, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginReques");
            return this._innerChannel.BeginRequest(message,callback,state);
        }

        public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginRequest");
            return this._innerChannel.BeginRequest(message, timeout,callback, state);
        }

        public Message EndRequest(IAsyncResult result)
        {
            PrintHelper.Print(this,"EndRequest");
            return this._innerChannel.EndRequest(result);
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

        #endregion
    }
}
