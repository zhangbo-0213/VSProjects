using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannel
{
    public class SimpleReplyChannel:ChannelBase,IReplyChannel
    {
        private IReplyChannel _innerChannel;

        public SimpleReplyChannel(ChannelManagerBase channelManager, IReplyChannel innerChannel) : base(channelManager)
        {
            PrintHelper.Print(this,"SimpleReplyChannel");
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
            this._innerChannel.Close(timeout);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            PrintHelper.Print(this,"OnEndClose");
            this._innerChannel.EndClose(result);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"OnBeginClose");
            return this._innerChannel.BeginClose(timeout, callback,state);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            PrintHelper.Print(this,"OnOpen");
            this._innerChannel.Open(timeout);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"OnBeginOpen");
            return this._innerChannel.BeginOpen(timeout, callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            PrintHelper.Print(this,"OnEndOpen");
            this._innerChannel.EndOpen(result);
        }

        public RequestContext ReceiveRequest()
        {
            PrintHelper.Print(this,"ReceiveRequest");
            return this._innerChannel.ReceiveRequest();
        }

        public RequestContext ReceiveRequest(TimeSpan timeout)
        {
            PrintHelper.Print(this,"ReceiveRequest");
            return this._innerChannel.ReceiveRequest(timeout);
        }

        public IAsyncResult BeginReceiveRequest(AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginReceiveRequest");
            return this._innerChannel.BeginReceiveRequest(callback, state);
        }

        public IAsyncResult BeginReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginReceiveRequest");
            return this._innerChannel.BeginReceiveRequest(timeout, callback, state);
        }

        public RequestContext EndReceiveRequest(IAsyncResult result)
        {
            PrintHelper.Print(this,"EndReceiveRequest");
            return this._innerChannel.EndReceiveRequest(result);
        }

        public bool TryReceiveRequest(TimeSpan timeout, out RequestContext context)
        {
            PrintHelper.Print(this, "TryReceiveRequest");
            return this._innerChannel.TryReceiveRequest(timeout,out context);
        }

        public IAsyncResult BeginTryReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginTryReceiveRequest");
            return this._innerChannel.BeginTryReceiveRequest(timeout, callback, state);
        }

        public bool EndTryReceiveRequest(IAsyncResult result, out RequestContext context)
        {
            PrintHelper.Print(this,"EndTryReceiveRequest");
            return this._innerChannel.EndTryReceiveRequest(result, out context);
        }

        public bool WaitForRequest(TimeSpan timeout)
        {
            PrintHelper.Print(this,"WaitForRequest");
            return this._innerChannel.WaitForRequest(timeout);
        }

        public IAsyncResult BeginWaitForRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"BeginWaitForRequest");
            return this._innerChannel.BeginWaitForRequest(timeout, callback, state);
        }

        public bool EndWaitForRequest(IAsyncResult result)
        {
           PrintHelper.Print(this,"EndWaitForRequest");
            return this._innerChannel.EndWaitForRequest(result);
        }

        public EndpointAddress LocalAddress {
            get
            {
                PrintHelper.Print(this,"LocalAddress");
                return this._innerChannel.LocalAddress;
            }
        }
    }
}
